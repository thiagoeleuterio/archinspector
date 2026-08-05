using ArchInspector.Engine.Diagnosis;

namespace ArchInspector.Engine.Reporting;

public interface IExecutiveReportGenerator
{
    string Generate(
        ArchitectureDiagnosis diagnosis);
}
