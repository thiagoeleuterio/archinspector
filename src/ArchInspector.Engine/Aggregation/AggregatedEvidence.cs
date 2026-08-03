using EvidenceItem = ArchInspector.Engine.Evidence.Evidence;
using EvidenceType = ArchInspector.Engine.Evidence.EvidenceType;

namespace ArchInspector.Engine.Aggregation;

public sealed class AggregatedEvidence
{
    public AggregatedEvidence(
        EvidenceType type,
        string taxonomyReference,
        IEnumerable<EvidenceItem> evidence)
    {
        Type = type;
        TaxonomyReference = RequireText(taxonomyReference, nameof(taxonomyReference));
        Evidence = NormalizeEvidence(evidence);
        Count = Evidence.Count;
    }

    public EvidenceType Type { get; }

    public string TaxonomyReference { get; }

    public int Count { get; }

    public IReadOnlyList<EvidenceItem> Evidence { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static IReadOnlyList<EvidenceItem> NormalizeEvidence(IEnumerable<EvidenceItem> evidence)
    {
        ArgumentNullException.ThrowIfNull(evidence);

        var normalized = new List<EvidenceItem>();

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
