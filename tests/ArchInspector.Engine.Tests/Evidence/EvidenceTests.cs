using ArchInspector.Engine.Evidence;

namespace ArchInspector.Engine.Tests.Evidence;

public sealed class EvidenceTests
{
    [Fact]
    public void Constructor_WithRequiredFields_ShouldCreateEvidence()
    {
        var evidence = CreateEvidence();

        Assert.Equal("evidence-1", evidence.Id);
        Assert.Equal("taxonomy.reference", evidence.TaxonomyReference);
        Assert.Equal(EvidenceType.Positive, evidence.Type);
        Assert.Equal(EvidenceStrength.Strong, evidence.Strength);
        Assert.Equal("rule-1", evidence.SourceRuleId);
        Assert.Null(evidence.SourceFindingId);
        Assert.Equal("Collected fact.", evidence.CollectedFact);
        Assert.Empty(evidence.Limitations);
        Assert.Empty(evidence.Metadata);
    }

    [Fact]
    public void Constructor_WithAllFields_ShouldCreateEvidence()
    {
        var trace = CreateTrace();
        var scope = CreateScope();
        var evidence = new ArchInspector.Engine.Evidence.Evidence(
            "evidence-2",
            "taxonomy.other",
            EvidenceType.Contextual,
            EvidenceStrength.Contextual,
            "rule-2",
            "Another fact.",
            trace,
            scope,
            "finding-1",
            new[] { "limited" },
            new Dictionary<string, string> { ["key"] = "value" });

        Assert.Equal("finding-1", evidence.SourceFindingId);
        Assert.Same(trace, evidence.Trace);
        Assert.Same(scope, evidence.Scope);
        Assert.Equal("limited", Assert.Single(evidence.Limitations));
        Assert.Equal("value", evidence.Metadata["key"]);
    }

    [Theory]
    [InlineData("id")]
    [InlineData("taxonomyReference")]
    [InlineData("sourceRuleId")]
    [InlineData("collectedFact")]
    public void Constructor_WithEmptyRequiredString_ShouldThrow(string parameterName)
    {
        var exception = Assert.Throws<ArgumentException>(() => parameterName switch
        {
            "id" => CreateEvidence(id: " "),
            "taxonomyReference" => CreateEvidence(taxonomyReference: " "),
            "sourceRuleId" => CreateEvidence(sourceRuleId: " "),
            "collectedFact" => CreateEvidence(collectedFact: " "),
            _ => throw new InvalidOperationException()
        });

        Assert.Equal(parameterName, exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullTrace_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new ArchInspector.Engine.Evidence.Evidence(
            "evidence-1",
            "taxonomy.reference",
            EvidenceType.Positive,
            EvidenceStrength.Strong,
            "rule-1",
            "Collected fact.",
            null!,
            CreateScope()));
    }

    [Fact]
    public void Constructor_WithNullScope_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new ArchInspector.Engine.Evidence.Evidence(
            "evidence-1",
            "taxonomy.reference",
            EvidenceType.Positive,
            EvidenceStrength.Strong,
            "rule-1",
            "Collected fact.",
            CreateTrace(),
            null!));
    }

    [Fact]
    public void Constructor_WithNullLimitations_ShouldCreateEmptyList()
    {
        var evidence = CreateEvidence(limitations: null);

        Assert.Empty(evidence.Limitations);
    }

    [Fact]
    public void Constructor_WithEmptyLimitations_ShouldRemoveThem()
    {
        var evidence = CreateEvidence(limitations: new[] { "first", " ", "", "\t", "second" });

        Assert.Equal(new[] { "first", "second" }, evidence.Limitations);
    }

    [Fact]
    public void Constructor_WithDuplicateLimitations_ShouldRemoveDuplicates()
    {
        var evidence = CreateEvidence(limitations: new[] { "first", "second", "first", " first " });

        Assert.Equal(new[] { "first", "second" }, evidence.Limitations);
    }

    [Fact]
    public void Constructor_WithLimitations_ShouldPreserveFirstOccurrenceOrder()
    {
        var evidence = CreateEvidence(limitations: new[] { "third", "first", "second", "first" });

        Assert.Equal(new[] { "third", "first", "second" }, evidence.Limitations);
    }

    [Fact]
    public void Constructor_WithNullMetadata_ShouldCreateEmptyDictionary()
    {
        var evidence = CreateEvidence(metadata: null);

        Assert.Empty(evidence.Metadata);
    }

    [Fact]
    public void Constructor_WithEmptyMetadataKey_ShouldThrow()
    {
        var metadata = new Dictionary<string, string> { [" "] = "value" };

        Assert.Throws<ArgumentException>(() => CreateEvidence(metadata: metadata));
    }

    [Fact]
    public void Constructor_WithDuplicateMetadataKeyAfterTrim_ShouldThrow()
    {
        var metadata = new Dictionary<string, string>
        {
            ["key"] = "value",
            [" key "] = "other"
        };

        Assert.Throws<ArgumentException>(() => CreateEvidence(metadata: metadata));
    }

    [Fact]
    public void Constructor_ShouldNotExposeMutableLimitations()
    {
        var limitations = new List<string> { "first" };
        var evidence = CreateEvidence(limitations: limitations);

        limitations.Add("second");

        Assert.Equal(new[] { "first" }, evidence.Limitations);
        Assert.Throws<NotSupportedException>(() => ((IList<string>)evidence.Limitations).Add("third"));
    }

    [Fact]
    public void Constructor_ShouldNotExposeMutableMetadata()
    {
        var metadata = new Dictionary<string, string> { ["key"] = "value" };
        var evidence = CreateEvidence(metadata: metadata);

        metadata["other"] = "changed";

        Assert.False(evidence.Metadata.ContainsKey("other"));
        Assert.Throws<NotSupportedException>(() => ((IDictionary<string, string>)evidence.Metadata).Add("new", "value"));
    }

    [Fact]
    public void Constructor_ShouldPreserveEnumValuesWithoutTransformation()
    {
        var evidence = CreateEvidence(type: EvidenceType.Contradictory, strength: EvidenceStrength.Moderate);

        Assert.Equal(EvidenceType.Contradictory, evidence.Type);
        Assert.Equal(EvidenceStrength.Moderate, evidence.Strength);
    }

    private static ArchInspector.Engine.Evidence.Evidence CreateEvidence(
        string id = "evidence-1",
        string taxonomyReference = "taxonomy.reference",
        EvidenceType type = EvidenceType.Positive,
        EvidenceStrength strength = EvidenceStrength.Strong,
        string sourceRuleId = "rule-1",
        string collectedFact = "Collected fact.",
        EvidenceTrace? trace = null,
        EvidenceScope? scope = null,
        string? sourceFindingId = null,
        IEnumerable<string>? limitations = null,
        IReadOnlyDictionary<string, string>? metadata = null)
    {
        return new ArchInspector.Engine.Evidence.Evidence(
            id,
            taxonomyReference,
            type,
            strength,
            sourceRuleId,
            collectedFact,
            trace ?? CreateTrace(),
            scope ?? CreateScope(),
            sourceFindingId,
            limitations,
            metadata);
    }

    private static EvidenceTrace CreateTrace()
    {
        return new EvidenceTrace("repo", "src/file.cs");
    }

    private static EvidenceScope CreateScope()
    {
        return new EvidenceScope(repository: "repo");
    }
}
