using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Diagnosis;

namespace ArchInspector.Engine.Tests.Diagnosis;

public sealed class DiagnosisSummaryFactoryTests
{
    [Fact]
    public void Create_WithUnknownArchitecture_ShouldReturnUnknownSummary()
    {
        var summary = DiagnosisSummaryFactory.Create(
            ArchitectureKind.Unknown,
            DiagnosisStrength.Unknown,
            []);

        Assert.Equal(
            "The available evidence is insufficient to identify a predominant architecture.",
            summary);
    }

    [Fact]
    public void Create_WithoutSecondaryArchitectures_ShouldReturnPrimarySummary()
    {
        var summary = DiagnosisSummaryFactory.Create(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            []);

        Assert.Equal(
            "The predominant architecture is Hexagonal with Strong diagnostic strength.",
            summary);
    }

    [Fact]
    public void Create_WithOneSecondaryArchitecture_ShouldReturnSecondarySummary()
    {
        var summary = DiagnosisSummaryFactory.Create(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            [ArchitectureKind.Layered]);

        Assert.Equal(
            "The predominant architecture is Hexagonal with Strong diagnostic strength. Secondary architectural influences: Layered.",
            summary);
    }

    [Fact]
    public void Create_WithMultipleSecondaryArchitectures_ShouldReturnSecondarySummary()
    {
        var summary = DiagnosisSummaryFactory.Create(
            ArchitectureKind.Hexagonal,
            DiagnosisStrength.Strong,
            [ArchitectureKind.DomainDrivenDesign, ArchitectureKind.Layered]);

        Assert.Equal(
            "The predominant architecture is Hexagonal with Strong diagnostic strength. Secondary architectural influences: DomainDrivenDesign, Layered.",
            summary);
    }

    [Fact]
    public void Create_ShouldPreserveSecondaryArchitectureOrder()
    {
        var summary = DiagnosisSummaryFactory.Create(
            ArchitectureKind.Layered,
            DiagnosisStrength.Moderate,
            [ArchitectureKind.Hexagonal, ArchitectureKind.DomainDrivenDesign]);

        Assert.EndsWith(
            "Secondary architectural influences: Hexagonal, DomainDrivenDesign.",
            summary);
    }
}
