using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;

namespace ArchInspector.Engine.Diagnosis;

public sealed class ArchitectureDiagnosis
{
    public ArchitectureDiagnosis(
        ArchitectureKind primaryArchitecture,
        DiagnosisStrength strength,
        string summary,
        IEnumerable<ArchitectureKind>? secondaryArchitectures,
        IEnumerable<CorrelatedPattern>? supportingPatterns,
        IEnumerable<DiagnosisRisk>? risks,
        IEnumerable<DiagnosisLimitation>? limitations)
    {
        PrimaryArchitecture = primaryArchitecture;
        Strength = strength;
        Summary = RequireText(summary, nameof(summary));
        SecondaryArchitectures = NormalizeSecondaryArchitectures(secondaryArchitectures);
        SupportingPatterns = NormalizeItems(supportingPatterns, nameof(supportingPatterns));
        Risks = NormalizeItems(risks, nameof(risks));
        Limitations = NormalizeItems(limitations, nameof(limitations));
    }

    public ArchitectureKind PrimaryArchitecture { get; }

    public DiagnosisStrength Strength { get; }

    public string Summary { get; }

    public IReadOnlyList<ArchitectureKind> SecondaryArchitectures { get; }

    public IReadOnlyList<CorrelatedPattern> SupportingPatterns { get; }

    public IReadOnlyList<DiagnosisRisk> Risks { get; }

    public IReadOnlyList<DiagnosisLimitation> Limitations { get; }

    public bool IsConclusive =>
        PrimaryArchitecture != ArchitectureKind.Unknown &&
        Strength != DiagnosisStrength.Unknown;

    public int SupportingPatternCount => SupportingPatterns.Count;

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static IReadOnlyList<ArchitectureKind> NormalizeSecondaryArchitectures(
        IEnumerable<ArchitectureKind>? architectures)
    {
        if (architectures is null)
        {
            return Array.Empty<ArchitectureKind>();
        }

        var normalized = new List<ArchitectureKind>();
        var seen = new HashSet<ArchitectureKind>();

        foreach (var architecture in architectures)
        {
            if (seen.Add(architecture))
            {
                normalized.Add(architecture);
            }
        }

        return normalized.AsReadOnly();
    }

    private static IReadOnlyList<T> NormalizeItems<T>(
        IEnumerable<T>? items,
        string parameterName)
        where T : class
    {
        if (items is null)
        {
            return Array.Empty<T>();
        }

        var normalized = new List<T>();

        foreach (var item in items)
        {
            if (item is null)
            {
                throw new ArgumentException($"{parameterName} items cannot be null.", parameterName);
            }

            normalized.Add(item);
        }

        return normalized.AsReadOnly();
    }
}
