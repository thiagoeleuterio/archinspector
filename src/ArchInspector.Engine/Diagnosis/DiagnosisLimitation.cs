namespace ArchInspector.Engine.Diagnosis;

public sealed record DiagnosisLimitation
{
    public DiagnosisLimitation(string id, string description)
    {
        Id = RequireText(id, nameof(id));
        Description = RequireText(description, nameof(description));
    }

    public string Id { get; }

    public string Description { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }
}
