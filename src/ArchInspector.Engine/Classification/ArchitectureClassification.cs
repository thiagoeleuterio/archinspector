using System.Collections;
using ArchInspector.Engine.Correlation;

namespace ArchInspector.Engine.Classification;

public sealed class ArchitectureClassification : IEnumerable<CorrelatedPattern>
{
    public ArchitectureClassification(
        ArchitectureKind primaryArchitecture,
        ClassificationConfidence confidence,
        IEnumerable<CorrelatedPattern>? supportingPatterns,
        IEnumerable<ArchitectureKind>? secondaryArchitectures,
        IEnumerable<CorrelatedPattern>? conflictingPatterns)
    {
        PrimaryArchitecture = primaryArchitecture;
        Confidence = confidence;
        SupportingPatterns = NormalizePatterns(supportingPatterns, nameof(supportingPatterns));
        SecondaryArchitectures = NormalizeArchitectures(secondaryArchitectures);
        ConflictingPatterns = NormalizePatterns(conflictingPatterns, nameof(conflictingPatterns));
    }

    public ArchitectureKind PrimaryArchitecture { get; }

    public ClassificationConfidence Confidence { get; }

    public IReadOnlyList<CorrelatedPattern> SupportingPatterns { get; }

    public IReadOnlyList<ArchitectureKind> SecondaryArchitectures { get; }

    public IReadOnlyList<CorrelatedPattern> ConflictingPatterns { get; }

    public int Count => SupportingPatterns.Count;

    public IEnumerator<CorrelatedPattern> GetEnumerator()
    {
        return SupportingPatterns.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static IReadOnlyList<CorrelatedPattern> NormalizePatterns(
        IEnumerable<CorrelatedPattern>? patterns,
        string parameterName)
    {
        if (patterns is null)
        {
            return Array.Empty<CorrelatedPattern>();
        }

        var normalized = new List<CorrelatedPattern>();

        foreach (var pattern in patterns)
        {
            if (pattern is null)
            {
                throw new ArgumentException("Correlated patterns cannot be null.", parameterName);
            }

            normalized.Add(pattern);
        }

        return normalized.AsReadOnly();
    }

    private static IReadOnlyList<ArchitectureKind> NormalizeArchitectures(
        IEnumerable<ArchitectureKind>? architectures)
    {
        if (architectures is null)
        {
            return Array.Empty<ArchitectureKind>();
        }

        return architectures.ToList().AsReadOnly();
    }
}
