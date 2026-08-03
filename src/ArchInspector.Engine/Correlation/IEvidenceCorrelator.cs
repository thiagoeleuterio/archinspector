using ArchInspector.Engine.Aggregation;

namespace ArchInspector.Engine.Correlation;

public interface IEvidenceCorrelator
{
    CorrelatedEvidenceSet Correlate(AggregatedEvidenceSet aggregatedEvidence);
}
