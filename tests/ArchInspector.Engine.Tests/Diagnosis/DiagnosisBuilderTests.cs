using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;

namespace ArchInspector.Engine.Tests.Diagnosis;

public sealed class DiagnosisBuilderTests
{
    [Fact]
    public void DiagnosisBuilder_ShouldImplementIDiagnosisBuilder()
    {
        Assert.IsAssignableFrom<IDiagnosisBuilder>(new DiagnosisBuilder());
    }

    [Fact]
    public void Build_WithNullClassification_ShouldThrow()
    {
        Assert.Throws<ArgumentNullException>(() => new DiagnosisBuilder().Build(null!));
    }

    [Fact]
    public void Build_WithUnknownArchitecture_ShouldUseUnknownStrength()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Unknown, ClassificationConfidence.Low));

        Assert.Equal(DiagnosisStrength.Unknown, diagnosis.Strength);
    }

    [Fact]
    public void Build_WithLowConfidence_ShouldUseWeakStrength()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Layered, ClassificationConfidence.Low));

        Assert.Equal(DiagnosisStrength.Weak, diagnosis.Strength);
    }

    [Fact]
    public void Build_WithMediumConfidence_ShouldUseModerateStrength()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Layered, ClassificationConfidence.Medium));

        Assert.Equal(DiagnosisStrength.Moderate, diagnosis.Strength);
    }

    [Fact]
    public void Build_WithHighConfidence_ShouldUseStrongStrength()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Layered, ClassificationConfidence.High));

        Assert.Equal(DiagnosisStrength.Strong, diagnosis.Strength);
    }

    [Fact]
    public void Build_ShouldPreservePrimaryArchitecture()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.DomainDrivenDesign, ClassificationConfidence.High));

        Assert.Equal(ArchitectureKind.DomainDrivenDesign, diagnosis.PrimaryArchitecture);
    }

    [Fact]
    public void Build_ShouldPreserveSecondaryArchitectures()
    {
        var classification = CreateClassification(
            ArchitectureKind.Hexagonal,
            ClassificationConfidence.High,
            secondaryArchitectures:
            [
                ArchitectureKind.DomainDrivenDesign,
                ArchitectureKind.Layered
            ]);

        var diagnosis = Build(classification);

        Assert.Equal(classification.SecondaryArchitectures, diagnosis.SecondaryArchitectures);
    }

    [Fact]
    public void Build_ShouldPreserveSupportingPatterns()
    {
        var first = CreatePattern("PortsAndAdapters");
        var second = CreatePattern("DomainModel");
        var classification = CreateClassification(
            ArchitectureKind.Hexagonal,
            ClassificationConfidence.High,
            supportingPatterns: [first, second]);

        var diagnosis = Build(classification);

        Assert.Equal([first, second], diagnosis.SupportingPatterns);
    }

    [Fact]
    public void Build_WithUnknownArchitecture_ShouldAddInsufficientEvidenceLimitation()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Unknown, ClassificationConfidence.Low));

        var limitation = Assert.Single(diagnosis.Limitations);
        Assert.Equal("INSUFFICIENT-EVIDENCE", limitation.Id);
        Assert.Equal(
            "The correlated evidence does not support a predominant architectural classification.",
            limitation.Description);
    }

    [Fact]
    public void Build_WithConflictingPatterns_ShouldAddConflictingPatternsLimitation()
    {
        var classification = CreateClassification(
            ArchitectureKind.Hexagonal,
            ClassificationConfidence.High,
            conflictingPatterns: [CreatePattern("LayerSeparation")]);

        var diagnosis = Build(classification);

        var limitation = Assert.Single(diagnosis.Limitations);
        Assert.Equal("CONFLICTING-PATTERNS", limitation.Id);
        Assert.Equal(
            "Conflicting architectural patterns were detected and require further analysis.",
            limitation.Description);
    }

    [Fact]
    public void Build_WithKnownArchitectureAndNoConflicts_ShouldReturnEmptyLimitations()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Hexagonal, ClassificationConfidence.High));

        Assert.Empty(diagnosis.Limitations);
    }

    [Fact]
    public void Build_ShouldReturnEmptyRisks()
    {
        var diagnosis = Build(CreateClassification(ArchitectureKind.Hexagonal, ClassificationConfidence.High));

        Assert.Empty(diagnosis.Risks);
    }

    [Fact]
    public void Build_ShouldCreateExpectedSummary()
    {
        var classification = CreateClassification(
            ArchitectureKind.Hexagonal,
            ClassificationConfidence.High,
            secondaryArchitectures: [ArchitectureKind.Layered]);

        var diagnosis = Build(classification);

        Assert.Equal(
            "The predominant architecture is Hexagonal with Strong diagnostic strength. Secondary architectural influences: Layered.",
            diagnosis.Summary);
    }

    [Fact]
    public void Build_CallsShouldNotShareState()
    {
        var builder = new DiagnosisBuilder();
        var unknown = builder.Build(CreateClassification(ArchitectureKind.Unknown, ClassificationConfidence.Low));
        var known = builder.Build(CreateClassification(ArchitectureKind.Hexagonal, ClassificationConfidence.High));

        Assert.Single(unknown.Limitations);
        Assert.Empty(known.Limitations);
    }

    private static ArchitectureDiagnosis Build(ArchitectureClassification classification)
    {
        return new DiagnosisBuilder().Build(classification);
    }

    private static ArchitectureClassification CreateClassification(
        ArchitectureKind primaryArchitecture,
        ClassificationConfidence confidence,
        IEnumerable<CorrelatedPattern>? supportingPatterns = null,
        IEnumerable<ArchitectureKind>? secondaryArchitectures = null,
        IEnumerable<CorrelatedPattern>? conflictingPatterns = null)
    {
        return new ArchitectureClassification(
            primaryArchitecture,
            confidence,
            supportingPatterns,
            secondaryArchitectures,
            conflictingPatterns);
    }

    private static CorrelatedPattern CreatePattern(string patternId)
    {
        return new CorrelatedPattern(
            patternId,
            patternId,
            "ArchitecturalPattern",
            [],
            [],
            ConfidenceCandidate.High);
    }
}
