using ArchInspector.Engine.Evidence;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Builder;

public interface IEvidenceBuilder
{
    EvidenceSet Build(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<RuleResult> ruleResults);
}
