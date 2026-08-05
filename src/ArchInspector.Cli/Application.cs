using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Pipeline;
using ArchInspector.Engine.Reporting;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Cli;

public sealed class Application(
    IArchitectureAnalyzer analyzer,
    IExecutiveReportGenerator reportGenerator)
{
    public const int SuccessExitCode = 0;
    public const int InvalidArgumentsExitCode = 1;
    public const int FileNotFoundExitCode = 2;
    public const int InvalidJsonExitCode = 3;
    public const int UnexpectedErrorExitCode = 4;

    private const string Usage = "Usage:" + "\n" + "\n" + "archinspector analyze <rules.json|solution.sln>";
    private const string ReportFileName = "EXECUTIVE_REPORT.md";
    private const string AnalysisDirectoryName = ".archinspector";

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter(),
            new RuleResultJsonConverter()
        }
    };

    public static Application CreateDefault()
    {
        return new Application(
            new ArchitectureAnalyzer(
                new EvidenceBuilder(),
                new EvidenceAggregator(),
                new EvidenceCorrelator(),
                new ArchitectureClassifier(),
                new DiagnosisBuilder()),
            new ExecutiveReportGenerator());
    }

    public int Run(string[] args)
    {
        if (!IsAnalyzeCommand(args))
        {
            Console.Error.WriteLine(Usage);
            return InvalidArgumentsExitCode;
        }

        var inputPath = args[1];

        if (!File.Exists(inputPath))
        {
            return FileNotFoundExitCode;
        }

        try
        {
            var analysisInput = CreateAnalysisInput(inputPath);
            var diagnosis = analyzer.Analyze(
                Guid.NewGuid().ToString("N"),
                analysisInput.Repository,
                DateTimeOffset.UtcNow,
                analysisInput.RuleResults);
            var report = reportGenerator.Generate(diagnosis);

            Directory.CreateDirectory(analysisInput.ReportDirectory);
            File.WriteAllText(Path.Combine(analysisInput.ReportDirectory, ReportFileName), report);

            return SuccessExitCode;
        }
        catch (JsonException)
        {
            return InvalidJsonExitCode;
        }
        catch (ArgumentException)
        {
            return InvalidJsonExitCode;
        }
        catch (NotSupportedException)
        {
            return InvalidJsonExitCode;
        }
        catch
        {
            return UnexpectedErrorExitCode;
        }
    }

    private static bool IsAnalyzeCommand(string[] args)
    {
        return args.Length == 2
            && string.Equals(args[0], "analyze", StringComparison.Ordinal)
            && !string.IsNullOrWhiteSpace(args[1]);
    }

    private static AnalysisInput CreateAnalysisInput(string inputPath)
    {
        var extension = Path.GetExtension(inputPath);

        if (string.Equals(extension, ".json", StringComparison.OrdinalIgnoreCase))
        {
            return CreateRulesJsonAnalysisInput(inputPath);
        }

        if (string.Equals(extension, ".sln", StringComparison.OrdinalIgnoreCase))
        {
            return CreateSolutionAnalysisInput(inputPath);
        }

        throw new ArgumentException("Unsupported input file type.", nameof(inputPath));
    }

    private static AnalysisInput CreateRulesJsonAnalysisInput(string rulesPath)
    {
        var json = File.ReadAllText(rulesPath);
        var ruleResults = JsonSerializer.Deserialize<List<RuleResult>>(json, JsonOptions);

        if (ruleResults is null)
        {
            throw new JsonException("Rules JSON cannot be null.");
        }

        return new AnalysisInput(
            GetRepositoryName(rulesPath),
            ruleResults,
            Path.GetDirectoryName(Path.GetFullPath(rulesPath)) ?? Directory.GetCurrentDirectory());
    }

    private static AnalysisInput CreateSolutionAnalysisInput(string solutionPath)
    {
        var solutionDirectory = Path.GetDirectoryName(Path.GetFullPath(solutionPath)) ?? Directory.GetCurrentDirectory();

        return new AnalysisInput(
            Path.GetFileNameWithoutExtension(solutionPath),
            SolutionRuleScanner.Scan(solutionPath),
            Path.Combine(solutionDirectory, AnalysisDirectoryName));
    }

    private static string GetRepositoryName(string rulesPath)
    {
        var directory = Path.GetDirectoryName(Path.GetFullPath(rulesPath));

        if (string.IsNullOrWhiteSpace(directory))
        {
            return "unknown";
        }

        return new DirectoryInfo(directory).Name;
    }

    private sealed record AnalysisInput(
        string Repository,
        IReadOnlyList<RuleResult> RuleResults,
        string ReportDirectory);

    private static class SolutionRuleScanner
    {
        public static IReadOnlyList<RuleResult> Scan(string solutionPath)
        {
            var solutionDirectory = Path.GetDirectoryName(Path.GetFullPath(solutionPath))
                ?? Directory.GetCurrentDirectory();
            var repository = Path.GetFileNameWithoutExtension(solutionPath);
            var projects = ReadProjects(solutionPath, solutionDirectory);
            var results = new List<RuleResult>();

            AddHexagonalEvidence(results, repository, projects);

            if (results.Count == 0)
            {
                results.Add(new RuleResult(
                    "SOL-001",
                    "Solution Architecture",
                    RuleOutcome.Inconclusive,
                    RuleSeverity.Informational,
                    "The solution was scanned, but no supported architectural signals were detected.",
                    repository,
                    GetRelativePath(solutionDirectory, solutionPath)));
            }

            return results;
        }

        private static void AddHexagonalEvidence(
            List<RuleResult> results,
            string repository,
            IReadOnlyList<ProjectInfo> projects)
        {
            if (projects.Count == 0)
            {
                return;
            }

            AddPortsEvidence(results, repository, projects);
            AddDependencyDirectionEvidence(results, repository, projects);
            AddAdapterEvidence(results, repository, projects);
        }

        private static void AddPortsEvidence(
            List<RuleResult> results,
            string repository,
            IReadOnlyList<ProjectInfo> projects)
        {
            var hasApplicationOrDomainProject = projects.Any(project =>
                project.Layer is ProjectLayer.Application or ProjectLayer.Domain);
            var hasPorts = projects.Any(project =>
                project.Layer is ProjectLayer.Application or ProjectLayer.Domain
                && project.SourceFiles.Any(file => Path.GetFileName(file).StartsWith("I", StringComparison.Ordinal)
                    && string.Equals(Path.GetExtension(file), ".cs", StringComparison.OrdinalIgnoreCase)));

            if (!hasApplicationOrDomainProject && !hasPorts)
            {
                return;
            }

            var sourceProject = projects.FirstOrDefault(project =>
                project.Layer is ProjectLayer.Application or ProjectLayer.Domain)
                ?? projects[0];

            results.Add(new RuleResult(
                "HEX-001",
                "HEX-001",
                hasPorts ? RuleOutcome.Passed : RuleOutcome.Warning,
                RuleSeverity.Medium,
                hasPorts
                    ? "Application or domain ports are represented by interface files."
                    : "Application or domain projects were found, but explicit port interfaces were not detected.",
                repository,
                sourceProject.RelativePath,
                project: sourceProject.Name,
                tags: ["dependency", "hexagonal"],
                metadata: [new("scanner", "solution")]));
        }

        private static void AddDependencyDirectionEvidence(
            List<RuleResult> results,
            string repository,
            IReadOnlyList<ProjectInfo> projects)
        {
            var dependencyViolation = projects.FirstOrDefault(project =>
                project.Layer is ProjectLayer.Application or ProjectLayer.Domain
                && project.ProjectReferences.Any(reference => reference.Layer == ProjectLayer.Infrastructure));
            var infrastructureDependency = projects.FirstOrDefault(project =>
                project.Layer == ProjectLayer.Infrastructure
                && project.ProjectReferences.Any(reference =>
                    reference.Layer is ProjectLayer.Application or ProjectLayer.Domain));

            if (dependencyViolation is null && infrastructureDependency is null)
            {
                return;
            }

            var sourceProject = dependencyViolation ?? infrastructureDependency!;

            results.Add(new RuleResult(
                "HEX-003",
                "HEX-003",
                dependencyViolation is null ? RuleOutcome.Passed : RuleOutcome.Failed,
                dependencyViolation is null ? RuleSeverity.High : RuleSeverity.Critical,
                dependencyViolation is null
                    ? "Infrastructure dependencies are directed toward application or domain abstractions."
                    : "Application or domain project references infrastructure directly.",
                repository,
                sourceProject.RelativePath,
                project: sourceProject.Name,
                tags: ["dependency", "hexagonal"],
                metadata: sourceProject.ProjectReferences.Select(reference =>
                    new KeyValuePair<string, string>($"reference.{reference.Name}", reference.RelativePath))));
        }

        private static void AddAdapterEvidence(
            List<RuleResult> results,
            string repository,
            IReadOnlyList<ProjectInfo> projects)
        {
            var adapterProject = projects.FirstOrDefault(project =>
                project.Layer == ProjectLayer.Infrastructure
                && project.SourceFiles.Any(IsAdapterFile));

            if (adapterProject is null)
            {
                return;
            }

            results.Add(new RuleResult(
                "HEX-005",
                "HEX-005",
                RuleOutcome.Passed,
                RuleSeverity.Medium,
                "Infrastructure contains adapter classes for external integrations.",
                repository,
                adapterProject.RelativePath,
                project: adapterProject.Name,
                tags: ["adapter", "hexagonal"],
                metadata: [new("scanner", "solution")]));
        }

        private static IReadOnlyList<ProjectInfo> ReadProjects(string solutionPath, string solutionDirectory)
        {
            var projectCandidates = File.ReadLines(solutionPath)
                .Select(TryParseSolutionProject)
                .OfType<SolutionProject>()
                .Where(project => string.Equals(Path.GetExtension(project.RelativePath), ".csproj", StringComparison.OrdinalIgnoreCase))
                .Select(project => new ProjectInfo(
                    project.Name,
                    project.RelativePath.Replace('\\', Path.DirectorySeparatorChar),
                    Path.GetFullPath(Path.Combine(solutionDirectory, project.RelativePath))))
                .Where(project => File.Exists(project.FullPath))
                .ToList();

            var projectsByFullPath = projectCandidates.ToDictionary(
                project => project.FullPath,
                StringComparer.OrdinalIgnoreCase);

            foreach (var project in projectCandidates)
            {
                project.Load(solutionDirectory, projectsByFullPath);
            }

            return projectCandidates;
        }

        private static SolutionProject? TryParseSolutionProject(string line)
        {
            const string prefix = "Project(";

            if (!line.StartsWith(prefix, StringComparison.Ordinal))
            {
                return null;
            }

            var parts = line.Split('"');

            if (parts.Length < 8)
            {
                return null;
            }

            return new SolutionProject(parts[3], parts[5]);
        }

        private static bool IsAdapterFile(string sourceFile)
        {
            var fileName = Path.GetFileNameWithoutExtension(sourceFile);

            return fileName.EndsWith("Adapter", StringComparison.OrdinalIgnoreCase)
                || sourceFile.Split(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar)
                    .Any(part => string.Equals(part, "Adapters", StringComparison.OrdinalIgnoreCase)
                        || string.Equals(part, "Adapter", StringComparison.OrdinalIgnoreCase));
        }

        private static string GetRelativePath(string baseDirectory, string path)
        {
            return Path.GetRelativePath(baseDirectory, Path.GetFullPath(path))
                .Replace(Path.DirectorySeparatorChar, '/');
        }

        private sealed record SolutionProject(string Name, string RelativePath);

        private sealed class ProjectInfo(string name, string relativePath, string fullPath)
        {
            public string Name { get; } = name;

            public string RelativePath { get; } = relativePath.Replace(Path.DirectorySeparatorChar, '/');

            public string FullPath { get; } = fullPath;

            public ProjectLayer Layer { get; } = InferLayer(name, relativePath);

            public List<ProjectInfo> ProjectReferences { get; } = [];

            public List<string> SourceFiles { get; } = [];

            public void Load(string solutionDirectory, IReadOnlyDictionary<string, ProjectInfo> projectsByFullPath)
            {
                var projectDirectory = Path.GetDirectoryName(FullPath);

                if (string.IsNullOrWhiteSpace(projectDirectory))
                {
                    return;
                }

                var document = XDocument.Load(FullPath);

                foreach (var include in document.Descendants()
                    .Where(element => element.Name.LocalName == "ProjectReference")
                    .Select(element => element.Attribute("Include")?.Value)
                    .Where(value => !string.IsNullOrWhiteSpace(value)))
                {
                    var referencePath = Path.GetFullPath(Path.Combine(projectDirectory, include!));

                    if (projectsByFullPath.TryGetValue(referencePath, out var referencedProject))
                    {
                        ProjectReferences.Add(referencedProject);
                    }
                }

                SourceFiles.AddRange(Directory.EnumerateFiles(projectDirectory, "*.cs", SearchOption.AllDirectories)
                    .Where(file => !file.Contains($"{Path.DirectorySeparatorChar}bin{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
                    .Where(file => !file.Contains($"{Path.DirectorySeparatorChar}obj{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase))
                    .Select(file => GetRelativePath(solutionDirectory, file)));
            }
        }

        private static ProjectLayer InferLayer(string name, string path)
        {
            var text = $"{name} {path}";

            if (text.Contains("Infrastructure", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Infraestructure", StringComparison.OrdinalIgnoreCase)
                || text.Contains(".Infra", StringComparison.OrdinalIgnoreCase))
            {
                return ProjectLayer.Infrastructure;
            }

            if (text.Contains("Application", StringComparison.OrdinalIgnoreCase))
            {
                return ProjectLayer.Application;
            }

            if (text.Contains("Domain", StringComparison.OrdinalIgnoreCase))
            {
                return ProjectLayer.Domain;
            }

            if (text.Contains("Api", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Web", StringComparison.OrdinalIgnoreCase)
                || text.Contains("Presentation", StringComparison.OrdinalIgnoreCase))
            {
                return ProjectLayer.Presentation;
            }

            return ProjectLayer.Unknown;
        }

        private enum ProjectLayer
        {
            Unknown,
            Presentation,
            Application,
            Domain,
            Infrastructure
        }
    }

    private sealed class RuleResultJsonConverter : JsonConverter<RuleResult>
    {
        public override RuleResult Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var root = document.RootElement;

            return new RuleResult(
                GetRequiredString(root, "ruleId"),
                GetRequiredString(root, "taxonomyReference"),
                GetRequiredEnum<RuleOutcome>(root, "outcome", options),
                GetRequiredEnum<RuleSeverity>(root, "severity", options),
                GetRequiredString(root, "message"),
                GetRequiredString(root, "repository"),
                GetRequiredString(root, "filePath"),
                GetOptionalString(root, "findingId"),
                GetOptionalString(root, "project"),
                GetOptionalString(root, "module"),
                GetOptionalString(root, "namespace"),
                GetOptionalString(root, "symbol"),
                GetOptionalInt(root, "lineStart"),
                GetOptionalInt(root, "lineEnd"),
                GetStringArray(root, "tags"),
                GetMetadata(root, "metadata"));
        }

        public override void Write(
            Utf8JsonWriter writer,
            RuleResult value,
            JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        private static string GetRequiredString(JsonElement root, string propertyName)
        {
            var value = GetOptionalString(root, propertyName);

            if (value is null)
            {
                throw new JsonException($"{propertyName} is required.");
            }

            return value;
        }

        private static string? GetOptionalString(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.GetString();
        }

        private static int? GetOptionalInt(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.GetInt32();
        }

        private static TEnum GetRequiredEnum<TEnum>(
            JsonElement root,
            string propertyName,
            JsonSerializerOptions options)
            where TEnum : struct, Enum
        {
            if (!TryGetProperty(root, propertyName, out var property))
            {
                throw new JsonException($"{propertyName} is required.");
            }

            return property.Deserialize<TEnum>(options);
        }

        private static IEnumerable<string>? GetStringArray(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.Deserialize<string[]>(JsonOptions);
        }

        private static IEnumerable<KeyValuePair<string, string>>? GetMetadata(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            if (property.ValueKind == JsonValueKind.Array)
            {
                return property
                    .Deserialize<MetadataItem[]>(JsonOptions)
                    ?.Select(item => new KeyValuePair<string, string>(item.Key, item.Value));
            }

            return property
                .Deserialize<Dictionary<string, string>>(JsonOptions)
                ?.Select(item => new KeyValuePair<string, string>(item.Key, item.Value));
        }

        private static bool TryGetProperty(
            JsonElement root,
            string propertyName,
            out JsonElement property)
        {
            foreach (var item in root.EnumerateObject())
            {
                if (string.Equals(item.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    property = item.Value;
                    return true;
                }
            }

            property = default;
            return false;
        }

        private sealed record MetadataItem(string Key, string Value);
    }
}
