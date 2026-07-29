using System.Collections.ObjectModel;

namespace ArchInspector.Engine.Evidence;

public sealed record Evidence
{
    public Evidence(
        string id,
        string taxonomyReference,
        EvidenceType type,
        EvidenceStrength strength,
        string sourceRuleId,
        string collectedFact,
        EvidenceTrace trace,
        EvidenceScope scope,
        string? sourceFindingId = null,
        IEnumerable<string>? limitations = null,
        IReadOnlyDictionary<string, string>? metadata = null)
    {
        Id = RequireText(id, nameof(id));
        TaxonomyReference = RequireText(taxonomyReference, nameof(taxonomyReference));
        Type = type;
        Strength = strength;
        SourceRuleId = RequireText(sourceRuleId, nameof(sourceRuleId));
        SourceFindingId = sourceFindingId;
        CollectedFact = RequireText(collectedFact, nameof(collectedFact));
        Trace = trace ?? throw new ArgumentNullException(nameof(trace));
        Scope = scope ?? throw new ArgumentNullException(nameof(scope));
        Limitations = NormalizeLimitations(limitations);
        Metadata = NormalizeMetadata(metadata);
    }

    public string Id { get; }

    public string TaxonomyReference { get; }

    public EvidenceType Type { get; }

    public EvidenceStrength Strength { get; }

    public string SourceRuleId { get; }

    public string? SourceFindingId { get; }

    public string CollectedFact { get; }

    public EvidenceTrace Trace { get; }

    public EvidenceScope Scope { get; }

    public IReadOnlyList<string> Limitations { get; }

    public IReadOnlyDictionary<string, string> Metadata { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value;
    }

    private static IReadOnlyList<string> NormalizeLimitations(IEnumerable<string>? limitations)
    {
        if (limitations is null)
        {
            return Array.Empty<string>();
        }

        var normalized = new List<string>();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (var limitation in limitations)
        {
            if (string.IsNullOrWhiteSpace(limitation))
            {
                continue;
            }

            var trimmed = limitation.Trim();
            if (seen.Add(trimmed))
            {
                normalized.Add(trimmed);
            }
        }

        return normalized.AsReadOnly();
    }

    private static IReadOnlyDictionary<string, string> NormalizeMetadata(IReadOnlyDictionary<string, string>? metadata)
    {
        var normalized = new Dictionary<string, string>(StringComparer.Ordinal);

        if (metadata is null)
        {
            return new ReadOnlyDictionary<string, string>(normalized);
        }

        foreach (var item in metadata)
        {
            if (string.IsNullOrWhiteSpace(item.Key))
            {
                throw new ArgumentException("Metadata keys are required.", nameof(metadata));
            }

            if (item.Value is null)
            {
                throw new ArgumentException("Metadata values cannot be null.", nameof(metadata));
            }

            var key = item.Key.Trim();
            var value = item.Value.Trim();

            if (normalized.ContainsKey(key))
            {
                throw new ArgumentException("Metadata keys must be unique.", nameof(metadata));
            }

            normalized.Add(key, value);
        }

        return new ReadOnlyDictionary<string, string>(normalized);
    }
}
