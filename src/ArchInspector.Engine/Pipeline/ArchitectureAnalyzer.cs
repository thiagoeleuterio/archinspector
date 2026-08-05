using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Pipeline;

public sealed class ArchitectureAnalyzer(
    IEvidenceBuilder evidenceBuilder,
    IEvidenceAggregator evidenceAggregator,
    IEvidenceCorrelator evidenceCorrelator,
    IArchitectureClassifier architectureClassifier,
    IDiagnosisBuilder diagnosisBuilder) : IArchitectureAnalyzer
{
    public ArchitectureDiagnosis Analyze(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<RuleResult> ruleResults)
    {
        var evidence = evidenceBuilder.Build(analysisId, repository, collectedAt, ruleResults);
        var aggregatedEvidence = evidenceAggregator.Aggregate(evidence);
        var correlatedEvidence = evidenceCorrelator.Correlate(aggregatedEvidence);
        var classification = architectureClassifier.Classify(correlatedEvidence);

        return diagnosisBuilder.Build(classification);
    }
}
