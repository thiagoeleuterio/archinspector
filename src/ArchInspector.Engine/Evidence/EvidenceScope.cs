namespace ArchInspector.Engine.Evidence;

public sealed record EvidenceScope
{
    public EvidenceScope(
        string? repository = null,
        string? project = null,
        string? module = null,
        string? component = null)
    {
        Repository = NormalizeOptional(repository);
        Project = NormalizeOptional(project);
        Module = NormalizeOptional(module);
        Component = NormalizeOptional(component);

        if (Repository is null && Project is null && Module is null && Component is null)
        {
            throw new ArgumentException("At least one scope value is required.");
        }
    }

    public string? Repository { get; }

    public string? Project { get; }

    public string? Module { get; }

    public string? Component { get; }

    private static string? NormalizeOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }
}
