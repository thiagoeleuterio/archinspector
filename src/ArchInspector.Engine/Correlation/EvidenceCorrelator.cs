using ArchInspector.Engine.Aggregation;

namespace ArchInspector.Engine.Correlation;

public sealed class EvidenceCorrelator : IEvidenceCorrelator
{
    private static readonly CorrelationDefinition[] Correlations =
    [
        new(
            "PortsAndAdapters",
            "PortsAndAdapters",
            "ArchitecturalPattern",
            ["HEX-001", "HEX-003", "HEX-005"]),
        new(
            "DomainModel",
            "DomainModel",
            "ArchitecturalPattern",
            ["DDD-001", "DDD-002", "DDD-004"]),
        new(
            "LayerSeparation",
            "LayerSeparation",
            "ArchitecturalPattern",
            ["LAY-001", "LAY-002", "LAY-003"])
    ];

    public CorrelatedEvidenceSet Correlate(AggregatedEvidenceSet aggregatedEvidence)
    {
        ArgumentNullException.ThrowIfNull(aggregatedEvidence);

        var patterns = Correlations
            .Select(correlation => TryCreatePattern(correlation, aggregatedEvidence))
            .OfType<CorrelatedPattern>()
            .OrderBy(pattern => GetFirstSupportingEvidenceIndex(pattern, aggregatedEvidence))
            .ToList();

        return new CorrelatedEvidenceSet(
            aggregatedEvidence.AnalysisId,
            aggregatedEvidence.Repository,
            aggregatedEvidence.CollectedAt,
            patterns);
    }

    private static CorrelatedPattern? TryCreatePattern(
        CorrelationDefinition correlation,
        AggregatedEvidenceSet aggregatedEvidence)
    {
        var ruleIds = correlation.RuleIds.ToHashSet(StringComparer.Ordinal);
        var supportingEvidence = aggregatedEvidence
            .Where(evidence => ruleIds.Contains(evidence.TaxonomyReference))
            .ToList();

        var matchedRules = correlation.RuleIds
            .Where(ruleId => supportingEvidence.Any(evidence => evidence.TaxonomyReference == ruleId))
            .ToList();

        var missingCount = correlation.RuleIds.Length - matchedRules.Count;

        if (missingCount > 1)
        {
            return null;
        }

        var confidenceCandidate = missingCount == 0
            ? ConfidenceCandidate.High
            : ConfidenceCandidate.Medium;

        return new CorrelatedPattern(
            correlation.PatternId,
            correlation.PatternName,
            correlation.Category,
            supportingEvidence,
            matchedRules,
            confidenceCandidate);
    }

    private static int GetFirstSupportingEvidenceIndex(
        CorrelatedPattern pattern,
        AggregatedEvidenceSet aggregatedEvidence)
    {
        for (var index = 0; index < aggregatedEvidence.Items.Count; index++)
        {
            if (pattern.SupportingEvidence.Contains(aggregatedEvidence.Items[index]))
            {
                return index;
            }
        }

        return int.MaxValue;
    }

    private sealed record CorrelationDefinition(
        string PatternId,
        string PatternName,
        string Category,
        string[] RuleIds);
}
