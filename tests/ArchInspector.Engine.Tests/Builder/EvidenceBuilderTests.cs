using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Evidence;
using ArchInspector.Engine.Rules;
using EvidenceModel = ArchInspector.Engine.Evidence.Evidence;

namespace ArchInspector.Engine.Tests.Builder;

public sealed class EvidenceBuilderTests
{
    [Fact]
    public void EvidenceBuilder_ShouldImplementIEvidenceBuilder()
    {
        Assert.IsAssignableFrom<IEvidenceBuilder>(new EvidenceBuilder());
    }

    [Fact]
    public void Build_ShouldReturnEvidenceSet()
    {
        var result = new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [CreateRuleResult()]);

        Assert.IsType<EvidenceSet>(result);
    }

    [Fact]
    public void Build_WithEmptyCollection_ShouldReturnValidEmptyEvidenceSet()
    {
        var collectedAt = DateTimeOffset.Parse("2026-01-02T03:04:05Z");

        var result = new EvidenceBuilder().Build("analysis-001", "repo", collectedAt, []);

        Assert.Equal("analysis-001", result.AnalysisId);
        Assert.Equal("repo", result.Repository);
        Assert.Equal(collectedAt, result.CollectedAt);
        Assert.Equal(0, result.Count);
        Assert.Empty(result.Items);
    }

    [Fact]
    public void Build_WithNullRuleResults_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            null!));
    }

    [Fact]
    public void Build_WithNullItem_ShouldThrow()
    {
        var ruleResults = new RuleResult?[] { CreateRuleResult(), null };

        var exception = Assert.Throws<ArgumentException>(() => new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            ruleResults!));

        Assert.Equal("ruleResults", exception.ParamName);
    }

    [Fact]
    public void Build_ShouldPreserveSetInputs()
    {
        var collectedAt = DateTimeOffset.Parse("2026-01-02T03:04:05Z");

        var result = new EvidenceBuilder().Build("analysis-001", "repo", collectedAt, []);

        Assert.Equal("analysis-001", result.AnalysisId);
        Assert.Equal("repo", result.Repository);
        Assert.Equal(collectedAt, result.CollectedAt);
    }

    [Fact]
    public void Build_ShouldPreserveOrderAndDuplicates()
    {
        var first = CreateRuleResult(ruleId: "RULE-001", message: "First.");
        var duplicate = CreateRuleResult(ruleId: "RULE-001", message: "First.");
        var third = CreateRuleResult(ruleId: "RULE-003", message: "Third.");

        var result = new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [first, duplicate, third]);

        Assert.Collection(
            result.Items,
            evidence =>
            {
                Assert.Equal("analysis-001:1:RULE-001", evidence.Id);
                Assert.Equal("First.", evidence.CollectedFact);
            },
            evidence =>
            {
                Assert.Equal("analysis-001:2:RULE-001", evidence.Id);
                Assert.Equal("First.", evidence.CollectedFact);
            },
            evidence =>
            {
                Assert.Equal("analysis-001:3:RULE-003", evidence.Id);
                Assert.Equal("Third.", evidence.CollectedFact);
            });
    }

    [Theory]
    [InlineData(RuleOutcome.Passed, EvidenceType.Positive)]
    [InlineData(RuleOutcome.Failed, EvidenceType.Negative)]
    [InlineData(RuleOutcome.Warning, EvidenceType.Weak)]
    [InlineData(RuleOutcome.NotApplicable, EvidenceType.Contextual)]
    [InlineData(RuleOutcome.Inconclusive, EvidenceType.Contextual)]
    public void Build_ShouldMapOutcomeToEvidenceType(RuleOutcome outcome, EvidenceType expected)
    {
        var evidence = BuildSingle(CreateRuleResult(outcome: outcome));

        Assert.Equal(expected, evidence.Type);
    }

    [Theory]
    [InlineData(RuleSeverity.Critical, EvidenceStrength.Strong)]
    [InlineData(RuleSeverity.High, EvidenceStrength.Strong)]
    [InlineData(RuleSeverity.Medium, EvidenceStrength.Moderate)]
    [InlineData(RuleSeverity.Low, EvidenceStrength.Weak)]
    [InlineData(RuleSeverity.Informational, EvidenceStrength.Contextual)]
    public void Build_ShouldMapSeverityToEvidenceStrength(RuleSeverity severity, EvidenceStrength expected)
    {
        var evidence = BuildSingle(CreateRuleResult(severity: severity));

        Assert.Equal(expected, evidence.Strength);
    }

    [Fact]
    public void Build_ShouldMapRuleResultToEvidence()
    {
        var ruleResult = CreateRuleResult(
            ruleId: "HEX-003",
            taxonomyReference: "taxonomy.hexagonal.dependencies",
            outcome: RuleOutcome.Warning,
            severity: RuleSeverity.Medium,
            message: "Controller depends on infrastructure.",
            repository: "rule-repo",
            filePath: "src/App/Controller.cs",
            findingId: "finding-42",
            project: "App",
            module: "Api",
            @namespace: "App.Api",
            symbol: "OrdersController",
            lineStart: 12,
            lineEnd: 18,
            metadata: [new("custom", "value")]);

        var evidence = BuildSingle(ruleResult);

        Assert.Equal("analysis-001:1:HEX-003", evidence.Id);
        Assert.Equal("taxonomy.hexagonal.dependencies", evidence.TaxonomyReference);
        Assert.Equal("HEX-003", evidence.SourceRuleId);
        Assert.Equal("finding-42", evidence.SourceFindingId);
        Assert.Equal("Controller depends on infrastructure.", evidence.CollectedFact);
        Assert.Empty(evidence.Limitations);
        Assert.Equal("value", evidence.Metadata["custom"]);
        Assert.Equal("Warning", evidence.Metadata["rule.outcome"]);
        Assert.Equal("Medium", evidence.Metadata["rule.severity"]);
        Assert.Equal("rule-repo", evidence.Trace.Repository);
        Assert.Equal("src/App/Controller.cs", evidence.Trace.FilePath);
        Assert.Equal("App", evidence.Trace.Project);
        Assert.Equal("Api", evidence.Trace.Module);
        Assert.Equal("App.Api", evidence.Trace.Namespace);
        Assert.Equal("OrdersController", evidence.Trace.Symbol);
        Assert.Equal(12, evidence.Trace.LineStart);
        Assert.Equal(18, evidence.Trace.LineEnd);
        Assert.Equal("rule-repo", evidence.Scope.Repository);
        Assert.Equal("App", evidence.Scope.Project);
        Assert.Equal("Api", evidence.Scope.Module);
        Assert.Equal("OrdersController", evidence.Scope.Component);
    }

    [Fact]
    public void Build_ShouldUseRuleResultRepositoryForTraceAndScope()
    {
        var evidence = BuildSingle(CreateRuleResult(repository: "rule-repo"), repository: "set-repo");

        Assert.Equal("set-repo", new EvidenceBuilder().Build(
            "analysis-001",
            "set-repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            []).Repository);
        Assert.Equal("rule-repo", evidence.Trace.Repository);
        Assert.Equal("rule-repo", evidence.Scope.Repository);
    }

    [Fact]
    public void Build_WithDuplicateRuleResults_ShouldCreateDistinctIds()
    {
        var ruleResult = CreateRuleResult(ruleId: "HEX-003");

        var result = new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [ruleResult, ruleResult]);

        Assert.Equal(["analysis-001:1:HEX-003", "analysis-001:2:HEX-003"], result.Items.Select(item => item.Id));
    }

    [Theory]
    [InlineData("rule.outcome")]
    [InlineData("rule.severity")]
    public void Build_WithReservedMetadataKey_ShouldThrow(string key)
    {
        var ruleResult = CreateRuleResult(metadata: [new(key, "existing")]);

        var exception = Assert.Throws<ArgumentException>(() => new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [ruleResult]));

        Assert.Equal("ruleResult", exception.ParamName);
    }

    [Fact]
    public void Build_CallsSequentially_ShouldNotShareState()
    {
        var builder = new EvidenceBuilder();

        var first = builder.Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [CreateRuleResult(ruleId: "FIRST")]);
        var second = builder.Build(
            "analysis-002",
            "repo",
            DateTimeOffset.Parse("2026-01-03T03:04:05Z"),
            [CreateRuleResult(ruleId: "SECOND")]);

        Assert.Equal("analysis-001:1:FIRST", Assert.Single(first.Items).Id);
        Assert.Equal("analysis-002:1:SECOND", Assert.Single(second.Items).Id);
    }

    [Fact]
    public void Build_ShouldNotExposeLaterInputListChanges()
    {
        var ruleResults = new List<RuleResult> { CreateRuleResult(ruleId: "FIRST") };

        var result = new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            ruleResults);

        ruleResults.Add(CreateRuleResult(ruleId: "SECOND"));

        var evidence = Assert.Single(result.Items);
        Assert.Equal("analysis-001:1:FIRST", evidence.Id);
    }

    [Fact]
    public void Build_ShouldEnumerateInputOnce()
    {
        var ruleResults = new CountingEnumerable<RuleResult>([CreateRuleResult(), CreateRuleResult(ruleId: "SECOND")]);

        var result = new EvidenceBuilder().Build(
            "analysis-001",
            "repo",
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            ruleResults);

        Assert.Equal(2, result.Count);
        Assert.Equal(1, ruleResults.EnumerationCount);
    }

    private static EvidenceModel BuildSingle(RuleResult ruleResult, string repository = "repo")
    {
        var result = new EvidenceBuilder().Build(
            "analysis-001",
            repository,
            DateTimeOffset.Parse("2026-01-02T03:04:05Z"),
            [ruleResult]);

        return Assert.Single(result.Items);
    }

    private static RuleResult CreateRuleResult(
        string ruleId = "RULE-001",
        string taxonomyReference = "taxonomy.reference",
        RuleOutcome outcome = RuleOutcome.Passed,
        RuleSeverity severity = RuleSeverity.Critical,
        string message = "Rule passed.",
        string repository = "repo",
        string filePath = "src/File.cs",
        string? findingId = null,
        string? project = null,
        string? module = null,
        string? @namespace = null,
        string? symbol = null,
        int? lineStart = null,
        int? lineEnd = null,
        IEnumerable<KeyValuePair<string, string>>? metadata = null)
    {
        return new RuleResult(
            ruleId,
            taxonomyReference,
            outcome,
            severity,
            message,
            repository,
            filePath,
            findingId,
            project,
            module,
            @namespace,
            symbol,
            lineStart,
            lineEnd,
            metadata: metadata);
    }

    private sealed class CountingEnumerable<T>(IEnumerable<T> items) : IEnumerable<T>
    {
        public int EnumerationCount { get; private set; }

        public IEnumerator<T> GetEnumerator()
        {
            EnumerationCount++;

            return items.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
