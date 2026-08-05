using ArchInspector.Engine.Classification;

namespace ArchInspector.Engine.Diagnosis;

public interface IDiagnosisBuilder
{
    ArchitectureDiagnosis Build(
        ArchitectureClassification classification);
}
