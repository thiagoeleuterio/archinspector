using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Reporting;

namespace ArchInspector.Engine.Tests.Reporting;

public sealed class ExecutiveReportGeneratorTests
{
    [Theory]
    [InlineData(ArchitectureKind.Unknown)]
    [InlineData(ArchitectureKind.Hexagonal)]
    [InlineData(ArchitectureKind.DomainDrivenDesign)]
    [InlineData(ArchitectureKind.Layered)]
    public void Generate_ShouldWritePredominantArchitecture(ArchitectureKind architecture)
    {
        var markdown = Generate(CreateDiagnosis(primaryArchitecture: architecture));

        Assert.Contains(
            $"## Predominant Architecture{Environment.NewLine}{Environment.NewLine}{architecture}",
            markdown);
    }

    [Fact]
    public void Generate_ShouldPreserveSummary()
    {
        var summary = "The predominant architecture is Hexagonal with Strong diagnostic strength.";

        var markdown = Generate(CreateDiagnosis(summary: summary));

        Assert.Contains(
            $"## Executive Summary{Environment.NewLine}{Environment.NewLine}{summary}",
            markdown);
    }

    [Fact]
    public void Generate_ShouldWriteDiagnosticStrength()
    {
        var markdown = Generate(CreateDiagnosis(strength: DiagnosisStrength.Strong));

        Assert.Contains(
            $"## Diagnostic Strength{Environment.NewLine}{Environment.NewLine}Strong",
            markdown);
    }

    [Fact]
    public void Generate_ShouldListSupportingPatterns()
    {
        var markdown = Generate(CreateDiagnosis(
            supportingPatterns:
            [
                CreatePattern("PortsAndAdapters"),
                CreatePattern("DomainModel")
            ]));

        Assert.Contains(
            $"## Supporting Patterns{Environment.NewLine}{Environment.NewLine}- PortsAndAdapters{Environment.NewLine}- DomainModel",
            markdown);
    }

    [Fact]
    public void Generate_ShouldListSecondaryArchitectures()
    {
        var markdown = Generate(CreateDiagnosis(
            secondaryArchitectures:
            [
                ArchitectureKind.Layered,
                ArchitectureKind.DomainDrivenDesign
            ]));

        Assert.Contains(
            $"## Secondary Architectures{Environment.NewLine}{Environment.NewLine}- Layered{Environment.NewLine}- DomainDrivenDesign",
            markdown);
    }

    [Fact]
    public void Generate_ShouldListRisks()
    {
        var markdown = Generate(CreateDiagnosis(
            risks:
            [
                new DiagnosisRisk("RISK-1", "Leaky boundary", "Application code depends on infrastructure details.", null),
                new DiagnosisRisk("RISK-2", "Mixed responsibilities", "Domain behavior is spread across unrelated layers.", null)
            ]));

        Assert.Contains(
            string.Join(
                Environment.NewLine,
                "## Risks",
                string.Empty,
                "- Leaky boundary",
                string.Empty,
                "  Application code depends on infrastructure details.",
                string.Empty,
                "- Mixed responsibilities",
                string.Empty,
                "  Domain behavior is spread across unrelated layers."),
            markdown);
    }

    [Fact]
    public void Generate_ShouldListLimitations()
    {
        var markdown = Generate(CreateDiagnosis(
            limitations:
            [
                new DiagnosisLimitation("LIMIT-1", "Only static evidence was analyzed."),
                new DiagnosisLimitation("LIMIT-2", "Runtime coupling was not inspected.")
            ]));

        Assert.Contains(
            $"## Limitations{Environment.NewLine}{Environment.NewLine}- Only static evidence was analyzed.{Environment.NewLine}- Runtime coupling was not inspected.",
            markdown);
    }

    [Fact]
    public void Generate_WithEmptyCollections_ShouldWriteNoneForEachCollection()
    {
        var markdown = Generate(CreateDiagnosis());

        Assert.Contains(
            $"## Supporting Patterns{Environment.NewLine}{Environment.NewLine}None.",
            markdown);
        Assert.Contains(
            $"## Secondary Architectures{Environment.NewLine}{Environment.NewLine}None.",
            markdown);
        Assert.Contains(
            $"## Risks{Environment.NewLine}{Environment.NewLine}None.",
            markdown);
        Assert.Contains(
            $"## Limitations{Environment.NewLine}{Environment.NewLine}None.",
            markdown);
    }

    [Fact]
    public void Generate_ShouldWriteSectionsInOrder()
    {
        var markdown = Generate(CreateDiagnosis());
        string[] headings =
        [
            "# Architecture Analysis",
            "## Executive Summary",
            "## Predominant Architecture",
            "## Diagnostic Strength",
            "## Supporting Patterns",
            "## Secondary Architectures",
            "## Risks",
            "## Limitations"
        ];

        var previousIndex = -1;

        foreach (var heading in headings)
        {
            var index = markdown.IndexOf(heading, StringComparison.Ordinal);

            Assert.True(index > previousIndex, $"{heading} should appear after the previous heading.");
            previousIndex = index;
        }
    }

    [Fact]
    public void Generate_ShouldWriteValidMarkdownShape()
    {
        var markdown = Generate(CreateDiagnosis(
            supportingPatterns: [CreatePattern("PortsAndAdapters")],
            secondaryArchitectures: [ArchitectureKind.Layered],
            risks: [new DiagnosisRisk("RISK-1", "Risk", "Description", null)],
            limitations: [new DiagnosisLimitation("LIMIT-1", "Limitation")]));

        var expected = string.Join(
            Environment.NewLine,
            "# Architecture Analysis",
            string.Empty,
            "## Executive Summary",
            string.Empty,
            "Summary",
            string.Empty,
            "## Predominant Architecture",
            string.Empty,
            "Hexagonal",
            string.Empty,
            "## Diagnostic Strength",
            string.Empty,
            "Strong",
            string.Empty,
            "## Supporting Patterns",
            string.Empty,
            "- PortsAndAdapters",
            string.Empty,
            "## Secondary Architectures",
            string.Empty,
            "- Layered",
            string.Empty,
            "## Risks",
            string.Empty,
            "- Risk",
            string.Empty,
            "  Description",
            string.Empty,
            "## Limitations",
            string.Empty,
            "- Limitation",
            string.Empty);

        Assert.Equal(expected, markdown);
    }

    private static string Generate(ArchitectureDiagnosis diagnosis)
    {
        return new ExecutiveReportGenerator().Generate(diagnosis);
    }

    private static ArchitectureDiagnosis CreateDiagnosis(
        ArchitectureKind primaryArchitecture = ArchitectureKind.Hexagonal,
        DiagnosisStrength strength = DiagnosisStrength.Strong,
        string summary = "Summary",
        IEnumerable<ArchitectureKind>? secondaryArchitectures = null,
        IEnumerable<CorrelatedPattern>? supportingPatterns = null,
        IEnumerable<DiagnosisRisk>? risks = null,
        IEnumerable<DiagnosisLimitation>? limitations = null)
    {
        return new ArchitectureDiagnosis(
            primaryArchitecture,
            strength,
            summary,
            secondaryArchitectures,
            supportingPatterns,
            risks,
            limitations);
    }

    private static CorrelatedPattern CreatePattern(string patternName)
    {
        return new CorrelatedPattern(
            patternName,
            patternName,
            "ArchitecturalPattern",
            [],
            [],
            ConfidenceCandidate.High);
    }
}
