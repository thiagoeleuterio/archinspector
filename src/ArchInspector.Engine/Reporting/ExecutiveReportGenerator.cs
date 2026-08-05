using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Diagnosis;

namespace ArchInspector.Engine.Reporting;

public sealed class ExecutiveReportGenerator : IExecutiveReportGenerator
{
    public string Generate(
        ArchitectureDiagnosis diagnosis)
    {
        ArgumentNullException.ThrowIfNull(diagnosis);

        return string.Join(
            Environment.NewLine + Environment.NewLine,
            "# Architecture Analysis",
            "## Executive Summary" + Environment.NewLine + Environment.NewLine + diagnosis.Summary,
            "## Predominant Architecture" + Environment.NewLine + Environment.NewLine + diagnosis.PrimaryArchitecture,
            "## Diagnostic Strength" + Environment.NewLine + Environment.NewLine + diagnosis.Strength,
            "## Supporting Patterns" + Environment.NewLine + Environment.NewLine + FormatSupportingPatterns(diagnosis),
            "## Secondary Architectures" + Environment.NewLine + Environment.NewLine + FormatSecondaryArchitectures(diagnosis),
            "## Risks" + Environment.NewLine + Environment.NewLine + FormatRisks(diagnosis),
            "## Limitations" + Environment.NewLine + Environment.NewLine + FormatLimitations(diagnosis)) +
            Environment.NewLine;
    }

    private static string FormatSupportingPatterns(ArchitectureDiagnosis diagnosis)
    {
        if (diagnosis.SupportingPatterns.Count == 0)
        {
            return "None.";
        }

        return string.Join(
            Environment.NewLine,
            diagnosis.SupportingPatterns.Select(pattern => $"- {pattern.PatternName}"));
    }

    private static string FormatSecondaryArchitectures(ArchitectureDiagnosis diagnosis)
    {
        if (diagnosis.SecondaryArchitectures.Count == 0)
        {
            return "None.";
        }

        return string.Join(
            Environment.NewLine,
            diagnosis.SecondaryArchitectures.Select(FormatArchitecture));
    }

    private static string FormatRisks(ArchitectureDiagnosis diagnosis)
    {
        if (diagnosis.Risks.Count == 0)
        {
            return "None.";
        }

        return string.Join(
            Environment.NewLine + Environment.NewLine,
            diagnosis.Risks.Select(risk =>
                $"- {risk.Title}{Environment.NewLine}{Environment.NewLine}  {risk.Description}"));
    }

    private static string FormatLimitations(ArchitectureDiagnosis diagnosis)
    {
        if (diagnosis.Limitations.Count == 0)
        {
            return "None.";
        }

        return string.Join(
            Environment.NewLine,
            diagnosis.Limitations.Select(limitation => $"- {limitation.Description}"));
    }

    private static string FormatArchitecture(ArchitectureKind architecture)
    {
        return $"- {architecture}";
    }
}
