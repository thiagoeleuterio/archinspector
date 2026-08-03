using ArchInspector.Engine.Correlation;

namespace ArchInspector.Engine.Classification;

public interface IArchitectureClassifier
{
    ArchitectureClassification Classify(
        CorrelatedEvidenceSet correlatedEvidence);
}
