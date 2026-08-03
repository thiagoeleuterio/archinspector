using System.Collections;
using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Evidence;

using EvidenceItem = ArchInspector.Engine.Evidence.Evidence;

namespace ArchInspector.Engine.Tests.Correlation;

public sealed class EvidenceCorrelatorTests
{
    private static readonly DateTimeOffset CollectedAt = new(2026, 8, 3, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void EvidenceCorrelator_ShouldImplementIEvidenceCorrelator()
    {
        Assert.IsAssignableFrom<IEvidenceCorrelator>(new EvidenceCorrelator());
    }

    [Fact]
    public void Correlate_WithNullAggregatedEvidence_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new EvidenceCorrelator().Correlate(null!));
    }

    [Fact]
    public void Correlate_WithEmptySet_ShouldReturnEmptyCorrelatedSet()
    {
        var result = Correlate([]);

        Assert.Equal("analysis-1", result.AnalysisId);
        Assert.Equal("repo", result.Repository);
        Assert.Equal(CollectedAt, result.CollectedAt);
        Assert.Equal(0, result.Count);
        Assert.False(result.HasPatterns);
        Assert.Empty(result.Patterns);
    }

    [Fact]
    public void Correlate_WithNoPatternFound_ShouldReturnEmptyCorrelatedSet()
    {
        var result = Correlate(["HEX-002", "DDD-003", "LAY-004"]);

        Assert.Empty(result.Patterns);
        Assert.Equal(0, result.Count);
        Assert.False(result.HasPatterns);
    }

    [Fact]
    public void Correlate_WithCompletePortsAndAdapters_ShouldCreatePattern()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal("PortsAndAdapters", pattern.PatternId);
        Assert.Equal("PortsAndAdapters", pattern.PatternName);
        Assert.Equal("ArchitecturalPattern", pattern.Category);
        Assert.Equal(["HEX-001", "HEX-003", "HEX-005"], pattern.MatchedRules);
        Assert.Equal(["HEX-001", "HEX-003", "HEX-005"], pattern.SupportingEvidence.Select(e => e.TaxonomyReference));
    }

    [Fact]
    public void Correlate_WithPartialPortsAndAdapters_ShouldCreateMediumPattern()
    {
        var result = Correlate(["HEX-001", "HEX-005"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal("PortsAndAdapters", pattern.PatternName);
        Assert.Equal(ConfidenceCandidate.Medium, pattern.ConfidenceCandidate);
        Assert.Equal(["HEX-001", "HEX-005"], pattern.MatchedRules);
        Assert.Equal(["HEX-001", "HEX-005"], pattern.SupportingEvidence.Select(e => e.TaxonomyReference));
    }

    [Fact]
    public void Correlate_WithInsufficientPortsAndAdapters_ShouldNotCreatePattern()
    {
        var result = Correlate(["HEX-001"]);

        Assert.Empty(result.Patterns);
    }

    [Fact]
    public void Correlate_WithCompleteDomainModel_ShouldCreatePattern()
    {
        var result = Correlate(["DDD-001", "DDD-002", "DDD-004"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal("DomainModel", pattern.PatternName);
        Assert.Equal(ConfidenceCandidate.High, pattern.ConfidenceCandidate);
        Assert.Equal(["DDD-001", "DDD-002", "DDD-004"], pattern.MatchedRules);
    }

    [Fact]
    public void Correlate_WithCompleteLayerSeparation_ShouldCreatePattern()
    {
        var result = Correlate(["LAY-001", "LAY-002", "LAY-003"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal("LayerSeparation", pattern.PatternName);
        Assert.Equal(ConfidenceCandidate.High, pattern.ConfidenceCandidate);
        Assert.Equal(["LAY-001", "LAY-002", "LAY-003"], pattern.MatchedRules);
    }

    [Fact]
    public void Correlate_WithMultiplePatterns_ShouldCreateAllMatchingPatterns()
    {
        var result = Correlate([
            "DDD-001",
            "HEX-001",
            "DDD-002",
            "HEX-003",
            "DDD-004",
            "HEX-005"
        ]);

        Assert.Equal(["DomainModel", "PortsAndAdapters"], result.Patterns.Select(pattern => pattern.PatternName));
    }

    [Fact]
    public void Correlate_ShouldPreserveSupportingEvidenceOrder()
    {
        var result = Correlate(["HEX-005", "HEX-001", "HEX-003"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal(["HEX-005", "HEX-001", "HEX-003"], pattern.SupportingEvidence.Select(e => e.TaxonomyReference));
        Assert.Equal(["HEX-001", "HEX-003", "HEX-005"], pattern.MatchedRules);
    }

    [Fact]
    public void CorrelatedEvidenceSet_GenericEnumeration_ShouldWork()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005"]);
        IEnumerable<CorrelatedPattern> enumerable = result;

        Assert.Equal(result.Patterns, enumerable);
    }

    [Fact]
    public void CorrelatedEvidenceSet_NonGenericEnumeration_ShouldWork()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005"]);
        IEnumerable enumerable = result;
        var patterns = new List<object>();

        foreach (var pattern in enumerable)
        {
            patterns.Add(pattern);
        }

        Assert.Equal(result.Patterns.Cast<object>(), patterns);
    }

    [Fact]
    public void CorrelatedEvidenceSet_HasPatterns_WithPatterns_ShouldReturnTrue()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005"]);

        Assert.True(result.HasPatterns);
    }

    [Fact]
    public void CorrelatedEvidenceSet_Count_ShouldReturnPatternCount()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005", "DDD-001", "DDD-002", "DDD-004"]);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Correlate_WithCompleteMatch_ShouldUseHighConfidenceCandidate()
    {
        var result = Correlate(["HEX-001", "HEX-003", "HEX-005"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal(ConfidenceCandidate.High, pattern.ConfidenceCandidate);
    }

    [Fact]
    public void Correlate_WithOneMissingRule_ShouldUseMediumConfidenceCandidate()
    {
        var result = Correlate(["DDD-001", "DDD-004"]);
        var pattern = Assert.Single(result.Patterns);

        Assert.Equal(ConfidenceCandidate.Medium, pattern.ConfidenceCandidate);
    }

    [Fact]
    public void CorrelatedPattern_Collections_ShouldNotReflectChangesToInputLists()
    {
        var evidence = new List<AggregatedEvidence> { CreateAggregatedEvidence("HEX-001") };
        var matchedRules = new List<string> { "HEX-001" };
        var pattern = new CorrelatedPattern(
            "PortsAndAdapters",
            "PortsAndAdapters",
            "ArchitecturalPattern",
            evidence,
            matchedRules,
            ConfidenceCandidate.Medium);

        evidence.Add(CreateAggregatedEvidence("HEX-003"));
        matchedRules.Add("HEX-003");

        Assert.Equal(["HEX-001"], pattern.SupportingEvidence.Select(item => item.TaxonomyReference));
        Assert.Equal(["HEX-001"], pattern.MatchedRules);
    }

    private static CorrelatedEvidenceSet Correlate(IEnumerable<string> taxonomyReferences)
    {
        var aggregatedEvidence = taxonomyReferences
            .Select(CreateAggregatedEvidence)
            .ToList();
        var set = new AggregatedEvidenceSet("analysis-1", "repo", CollectedAt, aggregatedEvidence);

        return new EvidenceCorrelator().Correlate(set);
    }

    private static AggregatedEvidence CreateAggregatedEvidence(string taxonomyReference)
    {
        return new AggregatedEvidence(
            EvidenceType.Positive,
            taxonomyReference,
            [CreateEvidence($"evidence-{taxonomyReference}", taxonomyReference)]);
    }

    private static EvidenceItem CreateEvidence(string id, string taxonomyReference)
    {
        return new EvidenceItem(
            id,
            taxonomyReference,
            EvidenceType.Positive,
            EvidenceStrength.Moderate,
            taxonomyReference,
            "Collected fact.",
            new EvidenceTrace("repo", "src/file.cs"),
            new EvidenceScope(repository: "repo"));
    }
}
