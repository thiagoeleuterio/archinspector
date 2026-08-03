using ArchInspector.Engine.Aggregation;

namespace ArchInspector.Engine.Correlation;

public sealed class CorrelatedPattern
{
    public CorrelatedPattern(
        string patternId,
        string patternName,
        string category,
        IEnumerable<AggregatedEvidence> supportingEvidence,
        IEnumerable<string> matchedRules,
        ConfidenceCandidate confidenceCandidate)
    {
        PatternId = RequireText(patternId, nameof(patternId));
        PatternName = RequireText(patternName, nameof(patternName));
        Category = RequireText(category, nameof(category));
        SupportingEvidence = NormalizeSupportingEvidence(supportingEvidence);
        MatchedRules = NormalizeMatchedRules(matchedRules);
        ConfidenceCandidate = confidenceCandidate;
    }

    public string PatternId { get; }

    public string PatternName { get; }

    public string Category { get; }

    public IReadOnlyList<AggregatedEvidence> SupportingEvidence { get; }

    public IReadOnlyList<string> MatchedRules { get; }

    public ConfidenceCandidate ConfidenceCandidate { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static IReadOnlyList<AggregatedEvidence> NormalizeSupportingEvidence(
        IEnumerable<AggregatedEvidence> supportingEvidence)
    {
        ArgumentNullException.ThrowIfNull(supportingEvidence);

        var normalized = new List<AggregatedEvidence>();

        foreach (var item in supportingEvidence)
        {
            if (item is null)
            {
                throw new ArgumentException("Supporting evidence items cannot be null.", nameof(supportingEvidence));
            }

            normalized.Add(item);
        }

        return normalized.AsReadOnly();
    }

    private static IReadOnlyList<string> NormalizeMatchedRules(IEnumerable<string> matchedRules)
    {
        ArgumentNullException.ThrowIfNull(matchedRules);

        var normalized = new List<string>();

        foreach (var ruleId in matchedRules)
        {
            if (string.IsNullOrWhiteSpace(ruleId))
            {
                throw new ArgumentException("Matched rule IDs are required.", nameof(matchedRules));
            }

            normalized.Add(ruleId.Trim());
        }

        return normalized.AsReadOnly();
    }
}
