using ArchInspector.Engine.Classification;

namespace ArchInspector.Engine.Diagnosis;

public static class DiagnosisSummaryFactory
{
    public static string Create(
        ArchitectureKind primaryArchitecture,
        DiagnosisStrength strength,
        IReadOnlyList<ArchitectureKind> secondaryArchitectures)
    {
        if (primaryArchitecture == ArchitectureKind.Unknown)
        {
            return "The available evidence is insufficient to identify a predominant architecture.";
        }

        var summary = $"The predominant architecture is {primaryArchitecture} with {strength} diagnostic strength.";

        if (secondaryArchitectures.Count == 0)
        {
            return summary;
        }

        return $"{summary} Secondary architectural influences: {string.Join(", ", secondaryArchitectures)}.";
    }
}
