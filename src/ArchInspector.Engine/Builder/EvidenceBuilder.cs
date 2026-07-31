using System.Collections.ObjectModel;
using ArchInspector.Engine.Evidence;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Builder;

public sealed class EvidenceBuilder : IEvidenceBuilder
{
    private const string RuleOutcomeMetadataKey = "rule.outcome";
    private const string RuleSeverityMetadataKey = "rule.severity";

    public EvidenceSet Build(
        string analysisId,
        string repository,
        DateTimeOffset collectedAt,
        IEnumerable<RuleResult> ruleResults)
    {
        ArgumentNullException.ThrowIfNull(ruleResults);

        var evidence = new List<Evidence.Evidence>();
        var index = 1;

        foreach (var ruleResult in ruleResults)
        {
            if (ruleResult is null)
            {
                throw new ArgumentException("Rule result items cannot be null.", nameof(ruleResults));
            }

            evidence.Add(CreateEvidence(analysisId, index, ruleResult));
            index++;
        }

        return new EvidenceSet(analysisId, repository, collectedAt, evidence);
    }

    private static Evidence.Evidence CreateEvidence(string analysisId, int index, RuleResult ruleResult)
    {
        return new Evidence.Evidence(
            $"{analysisId}:{index}:{ruleResult.RuleId}",
            ruleResult.TaxonomyReference,
            MapType(ruleResult.Outcome),
            MapStrength(ruleResult.Severity),
            ruleResult.RuleId,
            ruleResult.Message,
            CreateTrace(ruleResult),
            CreateScope(ruleResult),
            ruleResult.FindingId,
            limitations: [],
            metadata: NormalizeMetadata(ruleResult));
    }

    private static EvidenceTrace CreateTrace(RuleResult ruleResult)
    {
        return new EvidenceTrace(
            ruleResult.Repository,
            ruleResult.FilePath,
            ruleResult.Project,
            ruleResult.Module,
            ruleResult.Namespace,
            ruleResult.Symbol,
            ruleResult.LineStart,
            ruleResult.LineEnd);
    }

    private static EvidenceScope CreateScope(RuleResult ruleResult)
    {
        return new EvidenceScope(
            ruleResult.Repository,
            ruleResult.Project,
            ruleResult.Module,
            ruleResult.Symbol);
    }

    private static EvidenceType MapType(RuleOutcome outcome)
    {
        return outcome switch
        {
            RuleOutcome.Passed => EvidenceType.Positive,
            RuleOutcome.Failed => EvidenceType.Negative,
            RuleOutcome.Warning => EvidenceType.Weak,
            RuleOutcome.NotApplicable => EvidenceType.Contextual,
            RuleOutcome.Inconclusive => EvidenceType.Contextual,
            _ => throw new ArgumentOutOfRangeException(nameof(outcome), outcome, "Rule outcome is not defined.")
        };
    }

    private static EvidenceStrength MapStrength(RuleSeverity severity)
    {
        return severity switch
        {
            RuleSeverity.Critical => EvidenceStrength.Strong,
            RuleSeverity.High => EvidenceStrength.Strong,
            RuleSeverity.Medium => EvidenceStrength.Moderate,
            RuleSeverity.Low => EvidenceStrength.Weak,
            RuleSeverity.Informational => EvidenceStrength.Contextual,
            _ => throw new ArgumentOutOfRangeException(nameof(severity), severity, "Rule severity is not defined.")
        };
    }

    private static IReadOnlyDictionary<string, string> NormalizeMetadata(RuleResult ruleResult)
    {
        if (ruleResult.Metadata.ContainsKey(RuleOutcomeMetadataKey))
        {
            throw new ArgumentException("Metadata cannot contain reserved key rule.outcome.", nameof(ruleResult));
        }

        if (ruleResult.Metadata.ContainsKey(RuleSeverityMetadataKey))
        {
            throw new ArgumentException("Metadata cannot contain reserved key rule.severity.", nameof(ruleResult));
        }

        var metadata = new Dictionary<string, string>(ruleResult.Metadata, StringComparer.Ordinal)
        {
            [RuleOutcomeMetadataKey] = ruleResult.Outcome.ToString(),
            [RuleSeverityMetadataKey] = ruleResult.Severity.ToString()
        };

        return new ReadOnlyDictionary<string, string>(metadata);
    }
}
