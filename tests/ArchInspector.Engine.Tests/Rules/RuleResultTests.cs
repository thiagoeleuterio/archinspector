using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Tests.Rules;

public sealed class RuleResultTests
{
    [Fact]
    public void Constructor_WithRequiredFields_ShouldCreateRuleResult()
    {
        var result = CreateResult();

        Assert.Equal("rule-1", result.RuleId);
        Assert.Equal("taxonomy.reference", result.TaxonomyReference);
        Assert.Equal(RuleOutcome.Passed, result.Outcome);
        Assert.Equal(RuleSeverity.Medium, result.Severity);
        Assert.Equal("Rule passed.", result.Message);
        Assert.Equal("repo", result.Repository);
        Assert.Equal("src/file.cs", result.FilePath);
        Assert.Null(result.FindingId);
        Assert.Null(result.Project);
        Assert.Null(result.Module);
        Assert.Null(result.Namespace);
        Assert.Null(result.Symbol);
        Assert.Null(result.LineStart);
        Assert.Null(result.LineEnd);
        Assert.Empty(result.Tags);
        Assert.Empty(result.Metadata);
    }

    [Fact]
    public void Constructor_WithAllFields_ShouldCreateRuleResult()
    {
        var result = CreateResult(
            outcome: RuleOutcome.Warning,
            severity: RuleSeverity.High,
            findingId: "finding-1",
            project: "Project",
            module: "Module",
            @namespace: "Project.Namespace",
            symbol: "Type.Member",
            lineStart: 10,
            lineEnd: 12,
            tags: new[] { "architecture", "layering" },
            metadata: new[]
            {
                new KeyValuePair<string, string>("key", "value")
            });

        Assert.Equal(RuleOutcome.Warning, result.Outcome);
        Assert.Equal(RuleSeverity.High, result.Severity);
        Assert.Equal("finding-1", result.FindingId);
        Assert.Equal("Project", result.Project);
        Assert.Equal("Module", result.Module);
        Assert.Equal("Project.Namespace", result.Namespace);
        Assert.Equal("Type.Member", result.Symbol);
        Assert.Equal(10, result.LineStart);
        Assert.Equal(12, result.LineEnd);
        Assert.Equal(new[] { "architecture", "layering" }, result.Tags);
        Assert.Equal("value", result.Metadata["key"]);
    }

    [Fact]
    public void Constructor_ShouldPreserveOutcome()
    {
        var result = CreateResult(outcome: RuleOutcome.Inconclusive);

        Assert.Equal(RuleOutcome.Inconclusive, result.Outcome);
    }

    [Fact]
    public void Constructor_ShouldPreserveSeverity()
    {
        var result = CreateResult(severity: RuleSeverity.Critical);

        Assert.Equal(RuleSeverity.Critical, result.Severity);
    }

    [Fact]
    public void Constructor_ShouldTrimRequiredFields()
    {
        var result = CreateResult(
            ruleId: " rule-1 ",
            taxonomyReference: " taxonomy.reference ",
            message: " Rule passed. ",
            repository: " repo ",
            filePath: " src/file.cs ");

        Assert.Equal("rule-1", result.RuleId);
        Assert.Equal("taxonomy.reference", result.TaxonomyReference);
        Assert.Equal("Rule passed.", result.Message);
        Assert.Equal("repo", result.Repository);
        Assert.Equal("src/file.cs", result.FilePath);
    }

    [Fact]
    public void Constructor_ShouldNormalizeBlankOptionalFieldsToNull()
    {
        var result = CreateResult(
            findingId: " ",
            project: "",
            module: "\t",
            @namespace: " ",
            symbol: "");

        Assert.Null(result.FindingId);
        Assert.Null(result.Project);
        Assert.Null(result.Module);
        Assert.Null(result.Namespace);
        Assert.Null(result.Symbol);
    }

    [Fact]
    public void Constructor_ShouldTrimOptionalFields()
    {
        var result = CreateResult(
            findingId: " finding-1 ",
            project: " Project ",
            module: " Module ",
            @namespace: " Project.Namespace ",
            symbol: " Type ");

        Assert.Equal("finding-1", result.FindingId);
        Assert.Equal("Project", result.Project);
        Assert.Equal("Module", result.Module);
        Assert.Equal("Project.Namespace", result.Namespace);
        Assert.Equal("Type", result.Symbol);
    }

    [Fact]
    public void Constructor_ShouldPreserveRelativeFilePath()
    {
        var result = CreateResult(filePath: "../src/file.cs");

        Assert.Equal("../src/file.cs", result.FilePath);
    }

    [Fact]
    public void Constructor_ShouldPreserveProvidedLines()
    {
        var result = CreateResult(lineStart: 4, lineEnd: 8);

        Assert.Equal(4, result.LineStart);
        Assert.Equal(8, result.LineEnd);
    }

    [Theory]
    [InlineData("ruleId", null)]
    [InlineData("ruleId", "")]
    [InlineData("ruleId", " ")]
    [InlineData("taxonomyReference", null)]
    [InlineData("taxonomyReference", "")]
    [InlineData("message", null)]
    [InlineData("message", "")]
    [InlineData("repository", null)]
    [InlineData("repository", "")]
    [InlineData("filePath", null)]
    [InlineData("filePath", "")]
    public void Constructor_WithInvalidRequiredField_ShouldThrow(string parameterName, string? value)
    {
        var exception = Assert.Throws<ArgumentException>(() => parameterName switch
        {
            "ruleId" => CreateResult(ruleId: value!),
            "taxonomyReference" => CreateResult(taxonomyReference: value!),
            "message" => CreateResult(message: value!),
            "repository" => CreateResult(repository: value!),
            "filePath" => CreateResult(filePath: value!),
            _ => throw new InvalidOperationException()
        });

        Assert.Equal(parameterName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WithUndefinedOutcome_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CreateResult(outcome: (RuleOutcome)999));
    }

    [Fact]
    public void Constructor_WithUndefinedSeverity_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => CreateResult(severity: (RuleSeverity)999));
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithInvalidLineStart_ShouldThrow(int lineStart)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreateResult(lineStart: lineStart));

        Assert.Equal("lineStart", exception.ParamName);
    }

    [Theory]
    [InlineData(0)]
    [InlineData(-1)]
    public void Constructor_WithInvalidLineEnd_ShouldThrow(int lineEnd)
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreateResult(lineEnd: lineEnd));

        Assert.Equal("lineEnd", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithLineEndLessThanLineStart_ShouldThrow()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => CreateResult(lineStart: 5, lineEnd: 4));

        Assert.Equal("lineEnd", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithOnlyLineStart_ShouldCreateRuleResult()
    {
        var result = CreateResult(lineStart: 5);

        Assert.Equal(5, result.LineStart);
        Assert.Null(result.LineEnd);
    }

    [Fact]
    public void Constructor_WithOnlyLineEnd_ShouldCreateRuleResult()
    {
        var result = CreateResult(lineEnd: 5);

        Assert.Null(result.LineStart);
        Assert.Equal(5, result.LineEnd);
    }

    [Fact]
    public void Constructor_WithNullTags_ShouldCreateEmptyList()
    {
        var result = CreateResult(tags: null);

        Assert.Empty(result.Tags);
    }

    [Fact]
    public void Constructor_WithEmptyTags_ShouldRemoveThem()
    {
        var result = CreateResult(tags: new[] { "first", "", " ", "\t", "second" });

        Assert.Equal(new[] { "first", "second" }, result.Tags);
    }

    [Fact]
    public void Constructor_WithTags_ShouldTrimThem()
    {
        var result = CreateResult(tags: new[] { " first ", " second\t" });

        Assert.Equal(new[] { "first", "second" }, result.Tags);
    }

    [Fact]
    public void Constructor_WithDuplicateTags_ShouldRemoveDuplicates()
    {
        var result = CreateResult(tags: new[] { "first", "second", "first", " first " });

        Assert.Equal(new[] { "first", "second" }, result.Tags);
    }

    [Fact]
    public void Constructor_WithTags_ShouldPreserveFirstOccurrenceOrder()
    {
        var result = CreateResult(tags: new[] { "third", "first", "second", "first" });

        Assert.Equal(new[] { "third", "first", "second" }, result.Tags);
    }

    [Fact]
    public void Constructor_WithTags_ShouldUseOrdinalComparison()
    {
        var result = CreateResult(tags: new[] { "tag", "TAG", "tag" });

        Assert.Equal(new[] { "tag", "TAG" }, result.Tags);
    }

    [Fact]
    public void Constructor_WithTags_ShouldPreserveOriginalCasing()
    {
        var result = CreateResult(tags: new[] { "Architecture" });

        Assert.Equal("Architecture", Assert.Single(result.Tags));
    }

    [Fact]
    public void Constructor_ShouldNotExposeMutableTags()
    {
        var tags = new List<string> { "first" };
        var result = CreateResult(tags: tags);

        tags.Add("second");

        Assert.Equal(new[] { "first" }, result.Tags);
        Assert.Throws<NotSupportedException>(() => ((IList<string>)result.Tags).Add("third"));
    }

    [Fact]
    public void Constructor_WithNullMetadata_ShouldCreateEmptyDictionary()
    {
        var result = CreateResult(metadata: null);

        Assert.Empty(result.Metadata);
    }

    [Fact]
    public void Constructor_WithMetadata_ShouldTrimKeysAndValues()
    {
        var result = CreateResult(metadata: new[]
        {
            new KeyValuePair<string, string>(" key ", " value ")
        });

        Assert.Equal("value", result.Metadata["key"]);
    }

    [Fact]
    public void Constructor_WithEmptyMetadataKey_ShouldThrow()
    {
        var metadata = new[]
        {
            new KeyValuePair<string, string>(" ", "value")
        };

        var exception = Assert.Throws<ArgumentException>(() => CreateResult(metadata: metadata));

        Assert.Equal("metadata", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullMetadataValue_ShouldThrow()
    {
        var metadata = new[]
        {
            new KeyValuePair<string, string>("key", null!)
        };

        var exception = Assert.Throws<ArgumentException>(() => CreateResult(metadata: metadata));

        Assert.Equal("metadata", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithDuplicateMetadataKeyAfterTrim_ShouldThrow()
    {
        var metadata = new[]
        {
            new KeyValuePair<string, string>("key", "value"),
            new KeyValuePair<string, string>(" key ", "other")
        };

        var exception = Assert.Throws<ArgumentException>(() => CreateResult(metadata: metadata));

        Assert.Equal("metadata", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithMetadata_ShouldUseOrdinalComparison()
    {
        var result = CreateResult(metadata: new[]
        {
            new KeyValuePair<string, string>("key", "value"),
            new KeyValuePair<string, string>("KEY", "other")
        });

        Assert.Equal("value", result.Metadata["key"]);
        Assert.Equal("other", result.Metadata["KEY"]);
    }

    [Fact]
    public void Constructor_ShouldNotExposeMutableMetadata()
    {
        var metadata = new List<KeyValuePair<string, string>>
        {
            new("key", "value")
        };
        var result = CreateResult(metadata: metadata);

        metadata.Add(new KeyValuePair<string, string>("other", "changed"));

        Assert.False(result.Metadata.ContainsKey("other"));
        Assert.Throws<NotSupportedException>(() => ((IDictionary<string, string>)result.Metadata).Add("new", "value"));
    }

    private static RuleResult CreateResult(
        string ruleId = "rule-1",
        string taxonomyReference = "taxonomy.reference",
        RuleOutcome outcome = RuleOutcome.Passed,
        RuleSeverity severity = RuleSeverity.Medium,
        string message = "Rule passed.",
        string repository = "repo",
        string filePath = "src/file.cs",
        string? findingId = null,
        string? project = null,
        string? module = null,
        string? @namespace = null,
        string? symbol = null,
        int? lineStart = null,
        int? lineEnd = null,
        IEnumerable<string>? tags = null,
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
            tags,
            metadata);
    }
}
