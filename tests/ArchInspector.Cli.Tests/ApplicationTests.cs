using ArchInspector.Cli;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Pipeline;
using ArchInspector.Engine.Reporting;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Cli.Tests;

public sealed class ApplicationTests
{
    [Theory]
    [InlineData()]
    [InlineData("scan")]
    [InlineData("analyze")]
    [InlineData("analyze", "rules.json", "extra")]
    public void Run_WithInvalidArguments_ShouldReturnInvalidArguments(params string[] args)
    {
        var application = CreateApplication();

        var exitCode = application.Run(args);

        Assert.Equal(Application.InvalidArgumentsExitCode, exitCode);
    }

    [Fact]
    public void Run_WithMissingFile_ShouldReturnFileNotFound()
    {
        var application = CreateApplication();
        var missingPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString("N"), "rules.json");

        var exitCode = application.Run(["analyze", missingPath]);

        Assert.Equal(Application.FileNotFoundExitCode, exitCode);
    }

    [Fact]
    public void Run_WithInvalidJson_ShouldReturnInvalidJson()
    {
        using var directory = new TempDirectory();
        var rulesPath = Path.Combine(directory.Path, "rules.json");
        File.WriteAllText(rulesPath, "{ invalid json");
        var application = CreateApplication();

        var exitCode = application.Run(["analyze", rulesPath]);

        Assert.Equal(Application.InvalidJsonExitCode, exitCode);
    }

    [Fact]
    public void Run_WithValidJson_ShouldAnalyzeRulesAndWriteExecutiveReport()
    {
        using var directory = new TempDirectory();
        var rulesPath = Path.Combine(directory.Path, "rules.json");
        File.WriteAllText(
            rulesPath,
            """
            [
              {
                "ruleId": "HEX-001",
                "taxonomyReference": "HEX-001",
                "outcome": "Passed",
                "severity": "High",
                "message": "Port found.",
                "repository": "repo",
                "filePath": "src/Port.cs"
              }
            ]
            """);
        var analyzer = new FakeArchitectureAnalyzer();
        var reportGenerator = new FakeExecutiveReportGenerator("report body");
        var application = CreateApplication(analyzer, reportGenerator);

        var exitCode = application.Run(["analyze", rulesPath]);

        Assert.Equal(Application.SuccessExitCode, exitCode);
        Assert.NotNull(analyzer.RuleResults);
        var ruleResult = Assert.Single(analyzer.RuleResults);
        Assert.Equal("HEX-001", ruleResult.RuleId);
        Assert.Equal("repo", ruleResult.Repository);
        Assert.Same(analyzer.Diagnosis, reportGenerator.Diagnosis);
        Assert.Equal("report body", File.ReadAllText(Path.Combine(directory.Path, "EXECUTIVE_REPORT.md")));
    }

    [Fact]
    public void Run_WithMetadataArrayJson_ShouldAnalyzeRules()
    {
        using var directory = new TempDirectory();
        var rulesPath = Path.Combine(directory.Path, "rules.json");
        File.WriteAllText(
            rulesPath,
            """
            [
              {
                "ruleId": "HEX-003",
                "taxonomyReference": "HEX-003",
                "outcome": 0,
                "severity": 3,
                "message": "Dependency direction found.",
                "repository": "repo",
                "filePath": "src/Infrastructure.csproj",
                "metadata": [
                  {
                    "key": "reference",
                    "value": "Application"
                  }
                ]
              }
            ]
            """);
        var analyzer = new FakeArchitectureAnalyzer();
        var application = CreateApplication(analyzer);

        var exitCode = application.Run(["analyze", rulesPath]);

        Assert.Equal(Application.SuccessExitCode, exitCode);
        Assert.NotNull(analyzer.RuleResults);
        var ruleResult = Assert.Single(analyzer.RuleResults);
        Assert.Equal("Application", ruleResult.Metadata["reference"]);
    }

    [Fact]
    public void Run_WithSolution_ShouldScanProjectsAndWriteExecutiveReportToArchInspectorDirectory()
    {
        using var directory = new TempDirectory();
        var solutionPath = Path.Combine(directory.Path, "Sample.sln");
        CreateProject(
            directory.Path,
            "Sample.Application",
            "Sample.Application.csproj",
            sourceFiles: ["Ports/IClock.cs"]);
        CreateProject(
            directory.Path,
            "Sample.Infrastructure",
            "Sample.Infrastructure.csproj",
            projectReferences: ["..\\Sample.Application\\Sample.Application.csproj"],
            sourceFiles: ["Adapters/ClockAdapter.cs"]);
        File.WriteAllText(
            solutionPath,
            """
            Microsoft Visual Studio Solution File, Format Version 12.00
            Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Sample.Application", "Sample.Application\Sample.Application.csproj", "{11111111-1111-1111-1111-111111111111}"
            EndProject
            Project("{FAE04EC0-301F-11D3-BF4B-00C04F79EFBC}") = "Sample.Infrastructure", "Sample.Infrastructure\Sample.Infrastructure.csproj", "{22222222-2222-2222-2222-222222222222}"
            EndProject
            """);
        var analyzer = new FakeArchitectureAnalyzer();
        var reportGenerator = new FakeExecutiveReportGenerator("solution report");
        var application = CreateApplication(analyzer, reportGenerator);

        var exitCode = application.Run(["analyze", solutionPath]);

        Assert.Equal(Application.SuccessExitCode, exitCode);
        Assert.NotNull(analyzer.RuleResults);
        Assert.Contains(analyzer.RuleResults, rule => rule.RuleId == "HEX-001");
        Assert.Contains(analyzer.RuleResults, rule => rule.RuleId == "HEX-003");
        Assert.Contains(analyzer.RuleResults, rule => rule.RuleId == "HEX-005");
        Assert.Equal(
            "solution report",
            File.ReadAllText(Path.Combine(directory.Path, ".archinspector", "EXECUTIVE_REPORT.md")));
    }

    private static Application CreateApplication(
        IArchitectureAnalyzer? analyzer = null,
        IExecutiveReportGenerator? reportGenerator = null)
    {
        return new Application(
            analyzer ?? new FakeArchitectureAnalyzer(),
            reportGenerator ?? new FakeExecutiveReportGenerator("report"));
    }

    private static void CreateProject(
        string solutionDirectory,
        string projectName,
        string projectFileName,
        string[]? projectReferences = null,
        string[]? sourceFiles = null)
    {
        var projectDirectory = Path.Combine(solutionDirectory, projectName);
        Directory.CreateDirectory(projectDirectory);
        File.WriteAllText(
            Path.Combine(projectDirectory, projectFileName),
            $"""
            <Project Sdk="Microsoft.NET.Sdk">
              <ItemGroup>
            {string.Join(Environment.NewLine, (projectReferences ?? []).Select(reference => $"    <ProjectReference Include=\"{reference}\" />"))}
              </ItemGroup>
            </Project>
            """);

        foreach (var sourceFile in sourceFiles ?? [])
        {
            var sourcePath = Path.Combine(projectDirectory, sourceFile);
            Directory.CreateDirectory(Path.GetDirectoryName(sourcePath)!);
            File.WriteAllText(sourcePath, "namespace Sample;");
        }
    }

    private sealed class FakeArchitectureAnalyzer : IArchitectureAnalyzer
    {
        public ArchitectureDiagnosis Diagnosis { get; } = new(
            ArchitectureKind.Unknown,
            DiagnosisStrength.Unknown,
            "Unknown architecture.",
            [],
            [],
            [],
            []);

        public IReadOnlyList<RuleResult>? RuleResults { get; private set; }

        public ArchitectureDiagnosis Analyze(
            string analysisId,
            string repository,
            DateTimeOffset collectedAt,
            IEnumerable<RuleResult> ruleResults)
        {
            RuleResults = ruleResults.ToList();

            return Diagnosis;
        }
    }

    private sealed class FakeExecutiveReportGenerator(string report) : IExecutiveReportGenerator
    {
        public ArchitectureDiagnosis? Diagnosis { get; private set; }

        public string Generate(ArchitectureDiagnosis diagnosis)
        {
            Diagnosis = diagnosis;

            return report;
        }
    }

    private sealed class TempDirectory : IDisposable
    {
        public TempDirectory()
        {
            Path = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(Path);
        }

        public string Path { get; }

        public void Dispose()
        {
            if (Directory.Exists(Path))
            {
                Directory.Delete(Path, recursive: true);
            }
        }
    }
}
