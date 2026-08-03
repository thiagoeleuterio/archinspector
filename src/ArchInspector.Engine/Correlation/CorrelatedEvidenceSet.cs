using System.Collections;

namespace ArchInspector.Engine.Correlation;

public sealed class CorrelatedEvidenceSet : IEnumerable<CorrelatedPattern>
{
    public CorrelatedEvidenceSet(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<CorrelatedPattern>? patterns)
    {
        AnalysisId = RequireText(analysisId, nameof(analysisId));
        Repository = RequireText(repository, nameof(repository));
        CollectedAt = collectedAt;
        Patterns = NormalizePatterns(patterns);
    }

    public string AnalysisId { get; }

    public string Repository { get; }

    public DateTimeOffset CollectedAt { get; }

    public IReadOnlyList<CorrelatedPattern> Patterns { get; }

    public int Count => Patterns.Count;

    public bool HasPatterns => Count > 0;

    public IEnumerator<CorrelatedPattern> GetEnumerator()
    {
        return Patterns.GetEnumerator();
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

    private static IReadOnlyList<CorrelatedPattern> NormalizePatterns(IEnumerable<CorrelatedPattern>? patterns)
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
                throw new ArgumentException("Correlated patterns cannot be null.", nameof(patterns));
            }

            normalized.Add(pattern);
        }

        return normalized.AsReadOnly();
    }
}
