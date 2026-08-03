using ArchInspector.Engine.Evidence;

namespace ArchInspector.Engine.Aggregation;

public interface IEvidenceAggregator
{
    AggregatedEvidenceSet Aggregate(EvidenceSet evidenceSet);
}
