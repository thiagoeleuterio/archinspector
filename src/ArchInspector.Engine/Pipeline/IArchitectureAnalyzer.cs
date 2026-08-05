using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Pipeline;

public interface IArchitectureAnalyzer
{
    ArchitectureDiagnosis Analyze(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<RuleResult> ruleResults);
}
