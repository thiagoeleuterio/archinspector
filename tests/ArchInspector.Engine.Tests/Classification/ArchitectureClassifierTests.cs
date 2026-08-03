using System.Collections;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;

namespace ArchInspector.Engine.Tests.Classification;

public sealed class ArchitectureClassifierTests
{
    private static readonly DateTimeOffset CollectedAt = new(2026, 8, 3, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void ArchitectureClassifier_ShouldImplementIArchitectureClassifier()
    {
        Assert.IsAssignableFrom<IArchitectureClassifier>(new ArchitectureClassifier());
    }

    [Fact]
    public void Classify_WithNullCorrelatedEvidence_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new ArchitectureClassifier().Classify(null!));
    }

    [Fact]
    public void Classify_WithEmptySet_ShouldReturnUnknownWithLowConfidence()
    {
        var result = Classify([]);

        Assert.Equal(ArchitectureKind.Unknown, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.Low, result.Confidence);
        Assert.Equal(0, result.Count);
        Assert.Empty(result.SupportingPatterns);
        Assert.Empty(result.SecondaryArchitectures);
        Assert.Empty(result.ConflictingPatterns);
    }

    [Fact]
    public void Classify_WithUnknownPattern_ShouldReturnUnknownWithLowConfidence()
    {
        var result = Classify([CreatePattern("UnmappedPattern", ConfidenceCandidate.High)]);

        Assert.Equal(ArchitectureKind.Unknown, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.Low, result.Confidence);
        Assert.Empty(result.SupportingPatterns);
        Assert.Empty(result.SecondaryArchitectures);
        Assert.Empty(result.ConflictingPatterns);
    }

    [Fact]
    public void Classify_WithLayerSeparation_ShouldReturnLayered()
    {
        var result = Classify([CreatePattern("LayerSeparation", ConfidenceCandidate.High)]);

        Assert.Equal(ArchitectureKind.Layered, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.High, result.Confidence);
    }

    [Fact]
    public void Classify_WithPortsAndAdapters_ShouldReturnHexagonal()
    {
        var result = Classify([CreatePattern("PortsAndAdapters", ConfidenceCandidate.High)]);

        Assert.Equal(ArchitectureKind.Hexagonal, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.High, result.Confidence);
    }

    [Fact]
    public void Classify_WithDomainModel_ShouldReturnDomainDrivenDesign()
    {
        var result = Classify([CreatePattern("DomainModel", ConfidenceCandidate.High)]);

        Assert.Equal(ArchitectureKind.DomainDrivenDesign, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.High, result.Confidence);
    }

    [Fact]
    public void Classify_WithSinglePattern_ShouldInheritPatternConfidence()
    {
        var medium = Classify([CreatePattern("PortsAndAdapters", ConfidenceCandidate.Medium)]);
        var low = Classify([CreatePattern("DomainModel", ConfidenceCandidate.Low)]);

        Assert.Equal(ClassificationConfidence.Medium, medium.Confidence);
        Assert.Equal(ClassificationConfidence.Low, low.Confidence);
    }

    [Fact]
    public void Classify_WithMultiplePatterns_ShouldUseHighestConfidenceAsPrimary()
    {
        var result = Classify([
            CreatePattern("PortsAndAdapters", ConfidenceCandidate.Medium),
            CreatePattern("DomainModel", ConfidenceCandidate.High),
            CreatePattern("LayerSeparation", ConfidenceCandidate.Low)
        ]);

        Assert.Equal(ArchitectureKind.DomainDrivenDesign, result.PrimaryArchitecture);
        Assert.Equal(ClassificationConfidence.High, result.Confidence);
    }

    [Fact]
    public void Classify_WithConfidenceTie_ShouldUseArchitecturePriority()
    {
        var result = Classify([
            CreatePattern("LayerSeparation", ConfidenceCandidate.High),
            CreatePattern("DomainModel", ConfidenceCandidate.High),
            CreatePattern("PortsAndAdapters", ConfidenceCandidate.High)
        ]);

        Assert.Equal(ArchitectureKind.Hexagonal, result.PrimaryArchitecture);
    }

    [Fact]
    public void Classify_WithDomainAndLayeredTie_ShouldPreferDomainDrivenDesign()
    {
        var result = Classify([
            CreatePattern("LayerSeparation", ConfidenceCandidate.Medium),
            CreatePattern("DomainModel", ConfidenceCandidate.Medium)
        ]);

        Assert.Equal(ArchitectureKind.DomainDrivenDesign, result.PrimaryArchitecture);
    }

    [Fact]
    public void Classify_WithMultiplePatterns_ShouldPopulateSecondaryArchitectures()
    {
        var result = Classify([
            CreatePattern("PortsAndAdapters", ConfidenceCandidate.High),
            CreatePattern("DomainModel", ConfidenceCandidate.Medium),
            CreatePattern("LayerSeparation", ConfidenceCandidate.Low)
        ]);

        Assert.Equal(
            [ArchitectureKind.DomainDrivenDesign, ArchitectureKind.Layered],
            result.SecondaryArchitectures);
    }

    [Fact]
    public void Classify_WithMultiplePatterns_ShouldKeepConflictingPatternsEmpty()
    {
        var result = Classify([
            CreatePattern("PortsAndAdapters", ConfidenceCandidate.High),
            CreatePattern("DomainModel", ConfidenceCandidate.High)
        ]);

        Assert.Empty(result.ConflictingPatterns);
    }

    [Fact]
    public void ArchitectureClassification_GenericEnumeration_ShouldUseSupportingPatterns()
    {
        var first = CreatePattern("PortsAndAdapters", ConfidenceCandidate.High);
        var second = CreatePattern("DomainModel", ConfidenceCandidate.Medium);
        var result = Classify([first, second]);
        IEnumerable<CorrelatedPattern> enumerable = result;

        Assert.Equal(result.SupportingPatterns, enumerable);
    }

    [Fact]
    public void ArchitectureClassification_NonGenericEnumeration_ShouldUseSupportingPatterns()
    {
        var first = CreatePattern("PortsAndAdapters", ConfidenceCandidate.High);
        var second = CreatePattern("DomainModel", ConfidenceCandidate.Medium);
        var result = Classify([first, second]);
        IEnumerable enumerable = result;
        var patterns = new List<object>();

        foreach (var pattern in enumerable)
        {
            patterns.Add(pattern);
        }

        Assert.Equal(result.SupportingPatterns.Cast<object>(), patterns);
    }

    [Fact]
    public void ArchitectureClassification_Count_ShouldReturnSupportingPatternCount()
    {
        var result = Classify([
            CreatePattern("PortsAndAdapters", ConfidenceCandidate.High),
            CreatePattern("DomainModel", ConfidenceCandidate.Medium)
        ]);

        Assert.Equal(2, result.Count);
    }

    [Fact]
    public void Classify_ShouldPreserveSupportingPatternOrder()
    {
        var first = CreatePattern("LayerSeparation", ConfidenceCandidate.Low);
        var second = CreatePattern("PortsAndAdapters", ConfidenceCandidate.High);
        var third = CreatePattern("DomainModel", ConfidenceCandidate.Medium);

        var result = Classify([first, second, third]);

        Assert.Equal([first, second, third], result.SupportingPatterns);
    }

    [Fact]
    public void ArchitectureClassification_Collections_ShouldNotReflectChangesToInputLists()
    {
        var pattern = CreatePattern("PortsAndAdapters", ConfidenceCandidate.High);
        var supportingPatterns = new List<CorrelatedPattern> { pattern };
        var secondaryArchitectures = new List<ArchitectureKind> { ArchitectureKind.Layered };
        var conflictingPatterns = new List<CorrelatedPattern> { CreatePattern("DomainModel", ConfidenceCandidate.Medium) };

        var result = new ArchitectureClassification(
            ArchitectureKind.Hexagonal,
            ClassificationConfidence.High,
            supportingPatterns,
            secondaryArchitectures,
            conflictingPatterns);

        supportingPatterns.Add(CreatePattern("LayerSeparation", ConfidenceCandidate.Low));
        secondaryArchitectures.Add(ArchitectureKind.DomainDrivenDesign);
        conflictingPatterns.Clear();

        Assert.Equal([pattern], result.SupportingPatterns);
        Assert.Equal([ArchitectureKind.Layered], result.SecondaryArchitectures);
        Assert.Single(result.ConflictingPatterns);
    }

    private static ArchitectureClassification Classify(IEnumerable<CorrelatedPattern> patterns)
    {
        var set = new CorrelatedEvidenceSet("analysis-1", "repo", CollectedAt, patterns);

        return new ArchitectureClassifier().Classify(set);
    }

    private static CorrelatedPattern CreatePattern(
        string patternId,
        ConfidenceCandidate confidenceCandidate)
    {
        return new CorrelatedPattern(
            patternId,
            patternId,
            "ArchitecturalPattern",
            [],
            [],
            confidenceCandidate);
    }
}
