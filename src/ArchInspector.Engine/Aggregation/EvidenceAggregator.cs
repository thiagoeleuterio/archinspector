using ArchInspector.Engine.Evidence;

namespace ArchInspector.Engine.Aggregation;

public sealed class EvidenceAggregator : IEvidenceAggregator
{
    public AggregatedEvidenceSet Aggregate(EvidenceSet evidenceSet)
    {
        ArgumentNullException.ThrowIfNull(evidenceSet);

        var groups = new List<Group>();
        var groupIndexes = new Dictionary<GroupKey, int>();

        foreach (var evidence in evidenceSet)
        {
            var key = new GroupKey(evidence.Type, evidence.TaxonomyReference);

            if (!groupIndexes.TryGetValue(key, out var groupIndex))
            {
                groupIndex = groups.Count;
                groupIndexes.Add(key, groupIndex);
                groups.Add(new Group(evidence.Type, evidence.TaxonomyReference));
            }

            groups[groupIndex].Evidence.Add(evidence);
        }

        var aggregatedEvidence = groups
            .Select(group => new AggregatedEvidence(group.Type, group.TaxonomyReference, group.Evidence))
            .ToList();

        return new AggregatedEvidenceSet(
            evidenceSet.AnalysisId,
            evidenceSet.Repository,
            evidenceSet.CollectedAt,
            aggregatedEvidence);
    }

    private readonly record struct GroupKey(EvidenceType Type, string TaxonomyReference);

    private sealed class Group(EvidenceType type, string taxonomyReference)
    {
        public EvidenceType Type { get; } = type;

        public string TaxonomyReference { get; } = taxonomyReference;

        public List<Evidence.Evidence> Evidence { get; } = [];
    }
}
