using ArchInspector.Engine.Classification;

namespace ArchInspector.Engine.Diagnosis;

public sealed class DiagnosisBuilder : IDiagnosisBuilder
{
    public ArchitectureDiagnosis Build(
        ArchitectureClassification classification)
    {
        ArgumentNullException.ThrowIfNull(classification);

        var strength = MapStrength(classification);
        var summary = DiagnosisSummaryFactory.Create(
            classification.PrimaryArchitecture,
            strength,
            classification.SecondaryArchitectures);

        return new ArchitectureDiagnosis(
            classification.PrimaryArchitecture,
            strength,
            summary,
            classification.SecondaryArchitectures,
            classification.SupportingPatterns,
            [],
            CreateLimitations(classification));
    }

    private static DiagnosisStrength MapStrength(ArchitectureClassification classification)
    {
        if (classification.PrimaryArchitecture == ArchitectureKind.Unknown)
        {
            return DiagnosisStrength.Unknown;
        }

        return classification.Confidence switch
        {
            ClassificationConfidence.Low => DiagnosisStrength.Weak,
            ClassificationConfidence.Medium => DiagnosisStrength.Moderate,
            ClassificationConfidence.High => DiagnosisStrength.Strong,
            _ => DiagnosisStrength.Unknown
        };
    }

    private static IReadOnlyList<DiagnosisLimitation> CreateLimitations(
        ArchitectureClassification classification)
    {
        var limitations = new List<DiagnosisLimitation>();

        if (classification.PrimaryArchitecture == ArchitectureKind.Unknown)
        {
            limitations.Add(new DiagnosisLimitation(
                "INSUFFICIENT-EVIDENCE",
                "The correlated evidence does not support a predominant architectural classification."));
        }

        if (classification.ConflictingPatterns.Count > 0)
        {
            limitations.Add(new DiagnosisLimitation(
                "CONFLICTING-PATTERNS",
                "Conflicting architectural patterns were detected and require further analysis."));
        }

        return limitations.AsReadOnly();
    }
}
