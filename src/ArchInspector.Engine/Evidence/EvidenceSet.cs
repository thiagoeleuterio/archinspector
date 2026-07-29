using System.Collections;

namespace ArchInspector.Engine.Evidence;

public sealed class EvidenceSet : IEnumerable<Evidence>
{
    public EvidenceSet(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<Evidence>? evidence)
    {
        AnalysisId = RequireText(analysisId, nameof(analysisId));
        Repository = RequireText(repository, nameof(repository));
        CollectedAt = collectedAt;
        Items = NormalizeEvidence(evidence);
    }

    public string AnalysisId { get; }

    public string Repository { get; }

    public DateTimeOffset CollectedAt { get; }

    public IReadOnlyList<Evidence> Items { get; }

    public int Count => Items.Count;

    public bool HasEvidence => Count > 0;

    public IReadOnlyList<Evidence> PositiveEvidence => GetByType(EvidenceType.Positive);

    public IReadOnlyList<Evidence> WeakEvidence => GetByType(EvidenceType.Weak);

    public IReadOnlyList<Evidence> NegativeEvidence => GetByType(EvidenceType.Negative);

    public IReadOnlyList<Evidence> ContradictoryEvidence => GetByType(EvidenceType.Contradictory);

    public IReadOnlyList<Evidence> ContextualEvidence => GetByType(EvidenceType.Contextual);

    public IReadOnlyList<Evidence> GetByType(EvidenceType type)
    {
        if (!Enum.IsDefined(type))
        {
            throw new ArgumentOutOfRangeException(nameof(type), type, "Evidence type is not defined.");
        }

        return Items.Where(item => item.Type == type).ToList().AsReadOnly();
    }

    public IEnumerator<Evidence> GetEnumerator()
    {
        return Items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static IReadOnlyList<Evidence> NormalizeEvidence(IEnumerable<Evidence>? evidence)
    {
        if (evidence is null)
        {
            return Array.Empty<Evidence>();
        }

        var normalized = new List<Evidence>();

        foreach (var item in evidence)
        {
            if (item is null)
            {
                throw new ArgumentException("Evidence items cannot be null.", nameof(evidence));
            }

            normalized.Add(item);
        }

        return normalized.AsReadOnly();
    }
}
