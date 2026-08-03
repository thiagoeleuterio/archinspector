using ArchInspector.Engine.Correlation;

namespace ArchInspector.Engine.Classification;

public sealed class ArchitectureClassifier : IArchitectureClassifier
{
    public ArchitectureClassification Classify(CorrelatedEvidenceSet correlatedEvidence)
    {
        ArgumentNullException.ThrowIfNull(correlatedEvidence);

        var candidates = correlatedEvidence.Patterns
            .Select(TryCreateCandidate)
            .OfType<ClassificationCandidate>()
            .ToList();

        if (candidates.Count == 0)
        {
            return new ArchitectureClassification(
                ArchitectureKind.Unknown,
                ClassificationConfidence.Low,
                [],
                [],
                []);
        }

        var primary = candidates
            .OrderByDescending(candidate => candidate.Confidence)
            .ThenBy(candidate => GetPriority(candidate.Architecture))
            .First();

        var secondaryArchitectures = candidates
            .Where(candidate => candidate != primary)
            .Select(candidate => candidate.Architecture)
            .Where(architecture => architecture != primary.Architecture)
            .Distinct()
            .ToList();

        return new ArchitectureClassification(
            primary.Architecture,
            primary.Confidence,
            candidates.Select(candidate => candidate.Pattern),
            secondaryArchitectures,
            []);
    }

    private static ClassificationCandidate? TryCreateCandidate(CorrelatedPattern pattern)
    {
        var architecture = pattern.PatternId switch
        {
            "PortsAndAdapters" => ArchitectureKind.Hexagonal,
            "DomainModel" => ArchitectureKind.DomainDrivenDesign,
            "LayerSeparation" => ArchitectureKind.Layered,
            _ => ArchitectureKind.Unknown
        };

        if (architecture == ArchitectureKind.Unknown)
        {
            return null;
        }

        return new ClassificationCandidate(
            pattern,
            architecture,
            ToClassificationConfidence(pattern.ConfidenceCandidate));
    }

    private static ClassificationConfidence ToClassificationConfidence(ConfidenceCandidate confidenceCandidate)
    {
        return confidenceCandidate switch
        {
            ConfidenceCandidate.Low => ClassificationConfidence.Low,
            ConfidenceCandidate.Medium => ClassificationConfidence.Medium,
            ConfidenceCandidate.High => ClassificationConfidence.High,
            _ => throw new ArgumentOutOfRangeException(nameof(confidenceCandidate), confidenceCandidate, null)
        };
    }

    private static int GetPriority(ArchitectureKind architecture)
    {
        return architecture switch
        {
            ArchitectureKind.Hexagonal => 0,
            ArchitectureKind.DomainDrivenDesign => 1,
            ArchitectureKind.Layered => 2,
            ArchitectureKind.Unknown => 3,
            _ => throw new ArgumentOutOfRangeException(nameof(architecture), architecture, null)
        };
    }

    private sealed record ClassificationCandidate(
        CorrelatedPattern Pattern,
        ArchitectureKind Architecture,
        ClassificationConfidence Confidence);
}
