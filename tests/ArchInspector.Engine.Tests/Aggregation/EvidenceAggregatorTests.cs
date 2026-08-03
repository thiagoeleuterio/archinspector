using System.Collections;
using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Evidence;

using EvidenceItem = ArchInspector.Engine.Evidence.Evidence;

namespace ArchInspector.Engine.Tests.Aggregation;

public sealed class EvidenceAggregatorTests
{
    private static readonly DateTimeOffset CollectedAt = new(2026, 7, 29, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void EvidenceAggregator_ShouldImplementIEvidenceAggregator()
    {
        Assert.IsAssignableFrom<IEvidenceAggregator>(new EvidenceAggregator());
    }

    [Fact]
    public void Aggregate_WithNullEvidenceSet_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new EvidenceAggregator().Aggregate(null!));
    }

    [Fact]
    public void Aggregate_WithEmptySet_ShouldReturnEmptyAggregatedSet()
    {
        var result = Aggregate([]);

        Assert.Equal("analysis-1", result.AnalysisId);
        Assert.Equal("repo", result.Repository);
        Assert.Equal(CollectedAt, result.CollectedAt);
        Assert.Equal(0, result.Count);
        Assert.False(result.HasEvidence);
        Assert.Empty(result.Items);
    }

    [Fact]
    public void Aggregate_WithOneGroup_ShouldCreateAggregatedEvidence()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var second = CreateEvidence("evidence-2", EvidenceType.Positive, "HEX-001");

        var result = Aggregate([first, second]);
        var group = Assert.Single(result.Items);

        Assert.Equal(EvidenceType.Positive, group.Type);
        Assert.Equal("HEX-001", group.TaxonomyReference);
        Assert.Equal(2, group.Count);
        Assert.Equal(new[] { first, second }, group.Evidence);
    }

    [Fact]
    public void Aggregate_WithMultipleGroups_ShouldCreateOneItemPerGroup()
    {
        var hex = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var ddd = CreateEvidence("evidence-2", EvidenceType.Positive, "DDD-001");
        var negative = CreateEvidence("evidence-3", EvidenceType.Negative, "HEX-001");

        var result = Aggregate([hex, ddd, negative]);

        Assert.Collection(
            result.Items,
            group =>
            {
                Assert.Equal(EvidenceType.Positive, group.Type);
                Assert.Equal("HEX-001", group.TaxonomyReference);
                Assert.Equal(new[] { hex }, group.Evidence);
            },
            group =>
            {
                Assert.Equal(EvidenceType.Positive, group.Type);
                Assert.Equal("DDD-001", group.TaxonomyReference);
                Assert.Equal(new[] { ddd }, group.Evidence);
            },
            group =>
            {
                Assert.Equal(EvidenceType.Negative, group.Type);
                Assert.Equal("HEX-001", group.TaxonomyReference);
                Assert.Equal(new[] { negative }, group.Evidence);
            });
    }

    [Fact]
    public void Aggregate_ShouldPreserveFirstOccurrenceOrder()
    {
        var firstHex = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var firstDdd = CreateEvidence("evidence-2", EvidenceType.Positive, "DDD-001");
        var secondHex = CreateEvidence("evidence-3", EvidenceType.Positive, "HEX-001");
        var firstLayer = CreateEvidence("evidence-4", EvidenceType.Weak, "LAYER-001");

        var result = Aggregate([firstHex, firstDdd, secondHex, firstLayer]);

        Assert.Equal(
            new[] { "Positive:HEX-001", "Positive:DDD-001", "Weak:LAYER-001" },
            result.Items.Select(item => $"{item.Type}:{item.TaxonomyReference}"));
    }

    [Fact]
    public void Aggregate_ShouldPreserveEvidenceOrderInsideGroup()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var otherGroup = CreateEvidence("evidence-2", EvidenceType.Negative, "HEX-001");
        var second = CreateEvidence("evidence-3", EvidenceType.Positive, "HEX-001");
        var third = CreateEvidence("evidence-4", EvidenceType.Positive, "HEX-001");

        var result = Aggregate([first, otherGroup, second, third]);

        Assert.Equal(new[] { first, second, third }, result.Items[0].Evidence);
    }

    [Fact]
    public void Aggregate_ShouldPreserveDuplicateEvidence()
    {
        var evidence = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");

        var result = Aggregate([evidence, evidence]);
        var group = Assert.Single(result.Items);

        Assert.Equal(new[] { evidence, evidence }, group.Evidence);
        Assert.Equal(2, group.Count);
    }

    [Fact]
    public void Aggregate_Count_ShouldReturnGroupCount()
    {
        var result = Aggregate([
            CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001"),
            CreateEvidence("evidence-2", EvidenceType.Positive, "HEX-001"),
            CreateEvidence("evidence-3", EvidenceType.Negative, "HEX-001")
        ]);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Aggregate_HasEvidence_WithGroups_ShouldReturnTrue()
    {
        var result = Aggregate([CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001")]);

        Assert.True(result.HasEvidence);
    }

    [Fact]
    public void Aggregate_ShouldGroupByType()
    {
        var positive = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var weak = CreateEvidence("evidence-2", EvidenceType.Weak, "HEX-001");

        var result = Aggregate([positive, weak]);

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { positive }, result.Items[0].Evidence);
        Assert.Equal(new[] { weak }, result.Items[1].Evidence);
    }

    [Fact]
    public void Aggregate_ShouldGroupByTaxonomyReference()
    {
        var hex = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var ddd = CreateEvidence("evidence-2", EvidenceType.Positive, "DDD-001");

        var result = Aggregate([hex, ddd]);

        Assert.Equal(2, result.Count);
        Assert.Equal(new[] { hex }, result.Items[0].Evidence);
        Assert.Equal(new[] { ddd }, result.Items[1].Evidence);
    }

    [Fact]
    public void Aggregate_WithSameTaxonomyReferenceAndDifferentTypes_ShouldCreateDifferentGroups()
    {
        var positive = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var negative = CreateEvidence("evidence-2", EvidenceType.Negative, "HEX-001");

        var result = Aggregate([positive, negative]);

        Assert.Collection(
            result.Items,
            group =>
            {
                Assert.Equal(EvidenceType.Positive, group.Type);
                Assert.Equal("HEX-001", group.TaxonomyReference);
            },
            group =>
            {
                Assert.Equal(EvidenceType.Negative, group.Type);
                Assert.Equal("HEX-001", group.TaxonomyReference);
            });
    }

    [Fact]
    public void Aggregate_WithSameTypeAndDifferentTaxonomyReference_ShouldCreateDifferentGroups()
    {
        var hex = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var ddd = CreateEvidence("evidence-2", EvidenceType.Positive, "DDD-001");

        var result = Aggregate([hex, ddd]);

        Assert.Collection(
            result.Items,
            group =>
            {
                Assert.Equal(EvidenceType.Positive, group.Type);
                Assert.Equal("HEX-001", group.TaxonomyReference);
            },
            group =>
            {
                Assert.Equal(EvidenceType.Positive, group.Type);
                Assert.Equal("DDD-001", group.TaxonomyReference);
            });
    }

    [Fact]
    public void AggregatedEvidence_Count_ShouldMatchEvidenceCollection()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var second = CreateEvidence("evidence-2", EvidenceType.Positive, "HEX-001");

        var group = new AggregatedEvidence(EvidenceType.Positive, "HEX-001", [first, second]);

        Assert.Equal(group.Evidence.Count, group.Count);
    }

    [Fact]
    public void AggregatedEvidence_Evidence_ShouldNotReflectChangesToInputList()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001");
        var second = CreateEvidence("evidence-2", EvidenceType.Positive, "HEX-001");
        var evidence = new List<EvidenceItem> { first };

        var group = new AggregatedEvidence(EvidenceType.Positive, "HEX-001", evidence);
        evidence.Add(second);

        Assert.Equal(new[] { first }, group.Evidence);
        Assert.Equal(1, group.Count);
    }

    [Fact]
    public void AggregatedEvidence_Evidence_ShouldNotBeExternallyMutable()
    {
        var group = new AggregatedEvidence(
            EvidenceType.Positive,
            "HEX-001",
            [CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001")]);

        Assert.Throws<NotSupportedException>(() => ((IList<EvidenceItem>)group.Evidence).Add(
            CreateEvidence("evidence-2", EvidenceType.Positive, "HEX-001")));
    }

    [Fact]
    public void AggregatedEvidenceSet_Items_ShouldNotBeExternallyMutable()
    {
        var result = Aggregate([CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001")]);

        Assert.Throws<NotSupportedException>(() => ((IList<AggregatedEvidence>)result.Items).Add(
            new AggregatedEvidence(EvidenceType.Positive, "DDD-001", [])));
    }

    [Fact]
    public void GenericEnumeration_ShouldWork()
    {
        var result = Aggregate([CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001")]);
        IEnumerable<AggregatedEvidence> enumerable = result;

        Assert.Equal(result.Items, enumerable);
    }

    [Fact]
    public void NonGenericEnumeration_ShouldWork()
    {
        var result = Aggregate([CreateEvidence("evidence-1", EvidenceType.Positive, "HEX-001")]);
        IEnumerable enumerable = result;
        var items = new List<object>();

        foreach (var item in enumerable)
        {
            items.Add(item);
        }

        Assert.Equal(result.Items.Cast<object>(), items);
    }

    private static AggregatedEvidenceSet Aggregate(IEnumerable<EvidenceItem> evidence)
    {
        var set = new EvidenceSet("analysis-1", "repo", CollectedAt, evidence);

        return new EvidenceAggregator().Aggregate(set);
    }

    private static EvidenceItem CreateEvidence(
        string id,
        EvidenceType type,
        string taxonomyReference)
    {
        return new EvidenceItem(
            id,
            taxonomyReference,
            type,
            EvidenceStrength.Moderate,
            "rule-1",
            "Collected fact.",
            new EvidenceTrace("repo", "src/file.cs"),
            new EvidenceScope(repository: "repo"));
    }
}
