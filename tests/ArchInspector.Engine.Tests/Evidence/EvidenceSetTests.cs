using System.Collections;
using ArchInspector.Engine.Evidence;

using EvidenceItem = ArchInspector.Engine.Evidence.Evidence;

namespace ArchInspector.Engine.Tests.Evidence;

public sealed class EvidenceSetTests
{
    private static readonly DateTimeOffset CollectedAt = new(2026, 7, 29, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void Constructor_WithNullEvidence_ShouldCreateEmptySet()
    {
        var set = CreateSet(evidence: null);

        Assert.Empty(set.Items);
        Assert.Equal(0, set.Count);
        Assert.False(set.HasEvidence);
    }

    [Fact]
    public void Constructor_WithEmptyEvidence_ShouldCreateEmptySet()
    {
        var set = CreateSet(Array.Empty<EvidenceItem>());

        Assert.Empty(set.Items);
        Assert.Equal(0, set.Count);
        Assert.False(set.HasEvidence);
    }

    [Fact]
    public void Constructor_WithOneEvidence_ShouldCreateSet()
    {
        var evidence = CreateEvidence("evidence-1", EvidenceType.Positive);

        var set = CreateSet(new[] { evidence });

        Assert.Equal(evidence, Assert.Single(set.Items));
    }

    [Fact]
    public void Constructor_WithMultipleEvidence_ShouldCreateSet()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive);
        var second = CreateEvidence("evidence-2", EvidenceType.Negative);

        var set = CreateSet(new[] { first, second });

        Assert.Equal(new[] { first, second }, set.Items);
    }

    [Fact]
    public void Constructor_WithAnalysisIdPadding_ShouldTrimAnalysisId()
    {
        var set = CreateSet(analysisId: " analysis-1 ");

        Assert.Equal("analysis-1", set.AnalysisId);
    }

    [Fact]
    public void Constructor_WithRepositoryPadding_ShouldTrimRepository()
    {
        var set = CreateSet(repository: " repo ");

        Assert.Equal("repo", set.Repository);
    }

    [Fact]
    public void Constructor_WithNullAnalysisId_ShouldThrow()
    {
        var exception = Assert.Throws<ArgumentException>(() => CreateSet(analysisId: null!));

        Assert.Equal("analysisId", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void Constructor_WithInvalidAnalysisId_ShouldThrow(string analysisId)
    {
        var exception = Assert.Throws<ArgumentException>(() => CreateSet(analysisId: analysisId));

        Assert.Equal("analysisId", exception.ParamName);
    }

    [Fact]
    public void Constructor_WithNullRepository_ShouldThrow()
    {
        var exception = Assert.Throws<ArgumentException>(() => CreateSet(repository: null!));

        Assert.Equal("repository", exception.ParamName);
    }

    [Theory]
    [InlineData("")]
    [InlineData(" ")]
    [InlineData("\t")]
    public void Constructor_WithInvalidRepository_ShouldThrow(string repository)
    {
        var exception = Assert.Throws<ArgumentException>(() => CreateSet(repository: repository));

        Assert.Equal("repository", exception.ParamName);
    }

    [Fact]
    public void Constructor_ShouldPreserveCollectedAt()
    {
        var collectedAt = new DateTimeOffset(2026, 7, 29, 10, 30, 0, TimeSpan.FromHours(-3));

        var set = CreateSet(collectedAt: collectedAt);

        Assert.Equal(collectedAt, set.CollectedAt);
    }

    [Fact]
    public void Constructor_WithPastCollectedAt_ShouldCreateSet()
    {
        var collectedAt = CollectedAt.AddYears(-5);

        var set = CreateSet(collectedAt: collectedAt);

        Assert.Equal(collectedAt, set.CollectedAt);
    }

    [Fact]
    public void Constructor_WithFutureCollectedAt_ShouldCreateSet()
    {
        var collectedAt = CollectedAt.AddYears(5);

        var set = CreateSet(collectedAt: collectedAt);

        Assert.Equal(collectedAt, set.CollectedAt);
    }

    [Fact]
    public void Constructor_WithNullEvidenceItem_ShouldThrow()
    {
        var exception = Assert.Throws<ArgumentException>(() => CreateSet(CreateEvidenceSequenceWithNull()));

        Assert.Equal("evidence", exception.ParamName);
    }

    [Fact]
    public void Items_ShouldPreserveOriginalOrder()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive);
        var second = CreateEvidence("evidence-2", EvidenceType.Weak);
        var third = CreateEvidence("evidence-3", EvidenceType.Negative);

        var set = CreateSet(new[] { first, second, third });

        Assert.Equal(new[] { first, second, third }, set.Items);
    }

    [Fact]
    public void Items_ShouldPreserveDuplicateEvidence()
    {
        var evidence = CreateEvidence("evidence-1", EvidenceType.Positive);

        var set = CreateSet(new[] { evidence, evidence });

        Assert.Equal(new[] { evidence, evidence }, set.Items);
    }

    [Fact]
    public void Items_ShouldNotReflectChangesToInputList()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive);
        var second = CreateEvidence("evidence-2", EvidenceType.Negative);
        var evidence = new List<EvidenceItem> { first };

        var set = CreateSet(evidence);
        evidence.Add(second);

        Assert.Equal(new[] { first }, set.Items);
    }

    [Fact]
    public void Items_ShouldNotBeExternallyMutable()
    {
        var set = CreateSet(new[] { CreateEvidence("evidence-1", EvidenceType.Positive) });

        Assert.Throws<NotSupportedException>(() => ((IList<EvidenceItem>)set.Items).Add(CreateEvidence("evidence-2", EvidenceType.Negative)));
    }

    [Fact]
    public void Count_ShouldReturnTotalItems()
    {
        var set = CreateSet(new[]
        {
            CreateEvidence("evidence-1", EvidenceType.Positive),
            CreateEvidence("evidence-2", EvidenceType.Weak)
        });

        Assert.Equal(2, set.Count);
    }

    [Fact]
    public void HasEvidence_WithEmptySet_ShouldReturnFalse()
    {
        var set = CreateSet(Array.Empty<EvidenceItem>());

        Assert.False(set.HasEvidence);
    }

    [Fact]
    public void HasEvidence_WithFilledSet_ShouldReturnTrue()
    {
        var set = CreateSet(new[] { CreateEvidence("evidence-1", EvidenceType.Positive) });

        Assert.True(set.HasEvidence);
    }

    [Fact]
    public void PositiveEvidence_ShouldReturnOnlyPositiveEvidence()
    {
        var positive = CreateEvidence("evidence-1", EvidenceType.Positive);
        var weak = CreateEvidence("evidence-2", EvidenceType.Weak);

        var set = CreateSet(new[] { positive, weak });

        Assert.Equal(new[] { positive }, set.PositiveEvidence);
    }

    [Fact]
    public void WeakEvidence_ShouldReturnOnlyWeakEvidenceType()
    {
        var weakType = CreateEvidence("evidence-1", EvidenceType.Weak, EvidenceStrength.Strong);
        var weakStrength = CreateEvidence("evidence-2", EvidenceType.Positive, EvidenceStrength.Weak);

        var set = CreateSet(new[] { weakType, weakStrength });

        Assert.Equal(new[] { weakType }, set.WeakEvidence);
    }

    [Fact]
    public void NegativeEvidence_ShouldReturnOnlyNegativeEvidence()
    {
        var positive = CreateEvidence("evidence-1", EvidenceType.Positive);
        var negative = CreateEvidence("evidence-2", EvidenceType.Negative);

        var set = CreateSet(new[] { positive, negative });

        Assert.Equal(new[] { negative }, set.NegativeEvidence);
    }

    [Fact]
    public void ContradictoryEvidence_ShouldReturnOnlyContradictoryEvidence()
    {
        var contradictory = CreateEvidence("evidence-1", EvidenceType.Contradictory);
        var contextual = CreateEvidence("evidence-2", EvidenceType.Contextual);

        var set = CreateSet(new[] { contradictory, contextual });

        Assert.Equal(new[] { contradictory }, set.ContradictoryEvidence);
    }

    [Fact]
    public void ContextualEvidence_ShouldReturnOnlyContextualEvidence()
    {
        var contextual = CreateEvidence("evidence-1", EvidenceType.Contextual);
        var negative = CreateEvidence("evidence-2", EvidenceType.Negative);

        var set = CreateSet(new[] { contextual, negative });

        Assert.Equal(new[] { contextual }, set.ContextualEvidence);
    }

    [Fact]
    public void FilteredEvidence_ShouldPreserveOriginalOrder()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive);
        var negative = CreateEvidence("evidence-2", EvidenceType.Negative);
        var second = CreateEvidence("evidence-3", EvidenceType.Positive);

        var set = CreateSet(new[] { first, negative, second });

        Assert.Equal(new[] { first, second }, set.PositiveEvidence);
    }

    [Fact]
    public void FilteredEvidence_WithNoMatches_ShouldReturnEmptyList()
    {
        var set = CreateSet(new[] { CreateEvidence("evidence-1", EvidenceType.Positive) });

        Assert.Empty(set.NegativeEvidence);
    }

    [Fact]
    public void FilteredEvidence_ShouldNotBeExternallyMutable()
    {
        var set = CreateSet(new[] { CreateEvidence("evidence-1", EvidenceType.Positive) });

        Assert.Throws<NotSupportedException>(() => ((IList<EvidenceItem>)set.PositiveEvidence).Add(CreateEvidence("evidence-2", EvidenceType.Positive)));
    }

    [Fact]
    public void GetByType_ShouldReturnItemsForRequestedType()
    {
        var positive = CreateEvidence("evidence-1", EvidenceType.Positive);
        var negative = CreateEvidence("evidence-2", EvidenceType.Negative);

        var set = CreateSet(new[] { positive, negative });

        Assert.Equal(new[] { negative }, set.GetByType(EvidenceType.Negative));
    }

    [Fact]
    public void GetByType_WithNoMatches_ShouldReturnEmptyList()
    {
        var set = CreateSet(new[] { CreateEvidence("evidence-1", EvidenceType.Positive) });

        Assert.Empty(set.GetByType(EvidenceType.Contextual));
    }

    [Fact]
    public void GetByType_WithUndefinedType_ShouldThrow()
    {
        var set = CreateSet(Array.Empty<EvidenceItem>());

        Assert.Throws<ArgumentOutOfRangeException>(() => set.GetByType((EvidenceType)999));
    }

    [Fact]
    public void GetByType_ShouldPreserveOriginalOrder()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Contextual);
        var positive = CreateEvidence("evidence-2", EvidenceType.Positive);
        var second = CreateEvidence("evidence-3", EvidenceType.Contextual);

        var set = CreateSet(new[] { first, positive, second });

        Assert.Equal(new[] { first, second }, set.GetByType(EvidenceType.Contextual));
    }

    [Fact]
    public void Foreach_ShouldEnumerateAllItems()
    {
        var first = CreateEvidence("evidence-1", EvidenceType.Positive);
        var second = CreateEvidence("evidence-2", EvidenceType.Negative);
        var set = CreateSet(new[] { first, second });
        var result = new List<EvidenceItem>();

        foreach (var item in set)
        {
            result.Add(item);
        }

        Assert.Equal(new[] { first, second }, result);
    }

    [Fact]
    public void GenericEnumeration_ShouldWork()
    {
        var evidence = CreateEvidence("evidence-1", EvidenceType.Positive);
        IEnumerable<EvidenceItem> set = CreateSet(new[] { evidence });

        Assert.Equal(new[] { evidence }, set);
    }

    [Fact]
    public void NonGenericEnumeration_ShouldWork()
    {
        var evidence = CreateEvidence("evidence-1", EvidenceType.Positive);
        IEnumerable set = CreateSet(new[] { evidence });
        var result = new List<object>();

        foreach (var item in set)
        {
            result.Add(item);
        }

        Assert.Equal(new object[] { evidence }, result);
    }

    private static EvidenceSet CreateSet(
        IEnumerable<EvidenceItem>? evidence = null,
        string analysisId = "analysis-1",
        string repository = "repo",
        DateTimeOffset? collectedAt = null)
    {
        return new EvidenceSet(analysisId, repository, collectedAt ?? CollectedAt, evidence);
    }

    private static EvidenceItem CreateEvidence(
        string id,
        EvidenceType type,
        EvidenceStrength strength = EvidenceStrength.Moderate)
    {
        return new EvidenceItem(
            id,
            "taxonomy.reference",
            type,
            strength,
            "rule-1",
            "Collected fact.",
            new EvidenceTrace("repo", "src/file.cs"),
            new EvidenceScope(repository: "repo"));
    }

    private static IEnumerable<EvidenceItem> CreateEvidenceSequenceWithNull()
    {
        yield return CreateEvidence("evidence-1", EvidenceType.Positive);
        yield return null!;
    }
}
