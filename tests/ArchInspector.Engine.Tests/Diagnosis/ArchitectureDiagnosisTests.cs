using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;

namespace ArchInspector.Engine.Tests.Diagnosis;

public sealed class ArchitectureDiagnosisTests
{
    [Fact]
    public void Constructor_WithValidValues_ShouldCreateDiagnosis()
    {
        var pattern = CreatePattern("PortsAndAdapters");
        var risk = new DiagnosisRisk("RISK-1", "Risk", "Description", ["PortsAndAdapters"]);
        var limitation = new DiagnosisLimitation("LIMIT-1", "Description");

        var diagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "Summary",
            [ArchitectureKind.Layered],
            [pattern],
            [risk],
            [limitation]);

        Assert.Equal(ArchitectureKind.Hexagonal, diagnosis.PrimaryArchitecture);
        Assert.Equal(DiagnosisStrength.Strong, diagnosis.Strength);
        Assert.Equal("Summary", diagnosis.Summary);
        Assert.Equal([ArchitectureKind.Layered], diagnosis.SecondaryArchitectures);
        Assert.Equal([pattern], diagnosis.SupportingPatterns);
        Assert.Equal([risk], diagnosis.Risks);
        Assert.Equal([limitation], diagnosis.Limitations);
    }

    [Fact]
    public void Constructor_WithNullCollections_ShouldUseEmptyCollections()
    {
        var diagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "Summary",
            null,
            null,
            null,
            null);

        Assert.Empty(diagnosis.SecondaryArchitectures);
        Assert.Empty(diagnosis.SupportingPatterns);
        Assert.Empty(diagnosis.Risks);
        Assert.Empty(diagnosis.Limitations);
    }

    [Fact]
    public void Constructor_ShouldTrimSummary()
    {
        var diagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "  Summary  ",
            null,
            null,
            null,
            null);

        Assert.Equal("Summary", diagnosis.Summary);
    }

    [Fact]
    public void Constructor_WithEmptySummary_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "  ",
            null,
            null,
            null,
            null));
    }

    [Fact]
    public void Constructor_ShouldRemoveDuplicateSecondaryArchitectures()
    {
        var diagnosis = CreateDiagnosis(
            secondaryArchitectures:
            [
                ArchitectureKind.Layered,
                ArchitectureKind.Hexagonal,
                ArchitectureKind.Layered
            ]);

        Assert.Equal(
            [ArchitectureKind.Layered, ArchitectureKind.Hexagonal],
            diagnosis.SecondaryArchitectures);
    }

    [Fact]
    public void Constructor_ShouldPreserveSecondaryArchitectureOrder()
    {
        var diagnosis = CreateDiagnosis(
            secondaryArchitectures:
            [
                ArchitectureKind.DomainDrivenDesign,
                ArchitectureKind.Layered,
                ArchitectureKind.Hexagonal
            ]);

        Assert.Equal(
            [
                ArchitectureKind.DomainDrivenDesign,
                ArchitectureKind.Layered,
                ArchitectureKind.Hexagonal
            ],
            diagnosis.SecondaryArchitectures);
    }

    [Fact]
    public void Constructor_ShouldPreserveSupportingPatternDuplicates()
    {
        var pattern = CreatePattern("PortsAndAdapters");
        var diagnosis = CreateDiagnosis(supportingPatterns: [pattern, pattern]);

        Assert.Equal([pattern, pattern], diagnosis.SupportingPatterns);
    }

    [Fact]
    public void Constructor_ShouldPreserveSupportingPatternOrder()
    {
        var first = CreatePattern("PortsAndAdapters");
        var second = CreatePattern("DomainModel");
        var third = CreatePattern("LayerSeparation");
        var diagnosis = CreateDiagnosis(supportingPatterns: [first, second, third]);

        Assert.Equal([first, second, third], diagnosis.SupportingPatterns);
    }

    [Fact]
    public void Collections_ShouldNotReflectChangesToInputLists()
    {
        var secondaryArchitectures = new List<ArchitectureKind> { ArchitectureKind.Layered };
        var supportingPatterns = new List<CorrelatedPattern> { CreatePattern("PortsAndAdapters") };
        var risks = new List<DiagnosisRisk> { new("RISK-1", "Risk", "Description", null) };
        var limitations = new List<DiagnosisLimitation> { new("LIMIT-1", "Description") };

        var diagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "Summary",
            secondaryArchitectures,
            supportingPatterns,
            risks,
            limitations);

        secondaryArchitectures.Add(ArchitectureKind.DomainDrivenDesign);
        supportingPatterns.Clear();
        risks.Clear();
        limitations.Clear();

        Assert.Equal([ArchitectureKind.Layered], diagnosis.SecondaryArchitectures);
        Assert.Single(diagnosis.SupportingPatterns);
        Assert.Single(diagnosis.Risks);
        Assert.Single(diagnosis.Limitations);
    }

    [Fact]
    public void SupportingPatternCount_ShouldReturnSupportingPatternCount()
    {
        var diagnosis = CreateDiagnosis(
            supportingPatterns:
            [
                CreatePattern("PortsAndAdapters"),
                CreatePattern("DomainModel")
            ]);

        Assert.Equal(2, diagnosis.SupportingPatternCount);
    }

    [Fact]
    public void IsConclusive_WithUnknownArchitecture_ShouldReturnFalse()
    {
        var diagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Unknown,
            DiagnosisStrength.Unknown,
            "Summary",
            null,
            null,
            null,
            null);

        Assert.False(diagnosis.IsConclusive);
    }

    [Fact]
    public void IsConclusive_WithKnownArchitecture_ShouldReturnTrue()
    {
        var diagnosis = CreateDiagnosis();

        Assert.True(diagnosis.IsConclusive);
    }

    [Fact]
    public void DiagnosisRisk_ShouldNormalizeRelatedPatternIds()
    {
        var risk = new DiagnosisRisk(
            " RISK-1 ",
            " Risk ",
            " Description ",
            [" PortsAndAdapters ", "", "PortsAndAdapters", "portsandadapters", "  DomainModel"]);

        Assert.Equal("RISK-1", risk.Id);
        Assert.Equal("Risk", risk.Title);
        Assert.Equal("Description", risk.Description);
        Assert.Equal(
            ["PortsAndAdapters", "portsandadapters", "DomainModel"],
            risk.RelatedPatternIds);
    }

    [Fact]
    public void DiagnosisLimitation_ShouldTrimValues()
    {
        var limitation = new DiagnosisLimitation(" LIMIT-1 ", " Description ");

        Assert.Equal("LIMIT-1", limitation.Id);
        Assert.Equal("Description", limitation.Description);
    }

    private static ArchitectureDiagnosis CreateDiagnosis(
        IEnumerable<ArchitectureKind>? secondaryArchitectures = null,
        IEnumerable<CorrelatedPattern>? supportingPatterns = null)
    {
        return new ArchitectureDiagnosis(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            "Summary",
            secondaryArchitectures,
            supportingPatterns,
            null,
            null);
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
