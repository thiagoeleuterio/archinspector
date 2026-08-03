using System.Collections;

namespace ArchInspector.Engine.Aggregation;

public sealed class AggregatedEvidenceSet : IEnumerable<AggregatedEvidence>
{
    public AggregatedEvidenceSet(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<AggregatedEvidence>? items)
    {
        AnalysisId = RequireText(analysisId, nameof(analysisId));
        Repository = RequireText(repository, nameof(repository));
        CollectedAt = collectedAt;
        Items = NormalizeItems(items);
    }

    public string AnalysisId { get; }

    public string Repository { get; }

    public DateTimeOffset CollectedAt { get; }

    public IReadOnlyList<AggregatedEvidence> Items { get; }

    public int Count => Items.Count;

    public bool HasEvidence => Count > 0;

    public IEnumerator<AggregatedEvidence> GetEnumerator()
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

    private static IReadOnlyList<AggregatedEvidence> NormalizeItems(IEnumerable<AggregatedEvidence>? items)
    {
        if (items is null)
        {
            return Array.Empty<AggregatedEvidence>();
        }

        var normalized = new List<AggregatedEvidence>();

        foreach (var item in items)
        {
            if (item is null)
            {
                throw new ArgumentException("Aggregated evidence items cannot be null.", nameof(items));
            }

            normalized.Add(item);
        }

        return normalized.AsReadOnly();
    }
}
