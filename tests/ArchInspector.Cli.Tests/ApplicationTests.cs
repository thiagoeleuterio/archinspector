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

    private static Application CreateApplication(
        IArchitectureAnalyzer? analyzer = null,
        IExecutiveReportGenerator? reportGenerator = null)
    {
        return new Application(
            analyzer ?? new FakeArchitectureAnalyzer(),
            reportGenerator ?? new FakeExecutiveReportGenerator("report"));
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
