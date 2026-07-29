namespace ArchInspector.Engine.Evidence;

public sealed record EvidenceTrace
{
    public EvidenceTrace(
        string repository,
        string filePath,
        string? project = null,
        string? module = null,
        string? @namespace = null,
        string? symbol = null,
        int? lineStart = null,
        int? lineEnd = null)
    {
        if (string.IsNullOrWhiteSpace(repository))
        {
            throw new ArgumentException("Repository is required.", nameof(repository));
        }

        if (string.IsNullOrWhiteSpace(filePath))
        {
            throw new ArgumentException("File path is required.", nameof(filePath));
        }

        if (lineStart <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lineStart), "Line start must be greater than zero.");
        }

        if (lineEnd <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lineEnd), "Line end must be greater than zero.");
        }

        if (lineStart.HasValue && lineEnd.HasValue && lineEnd.Value < lineStart.Value)
        {
            throw new ArgumentOutOfRangeException(nameof(lineEnd), "Line end cannot be less than line start.");
        }

        Repository = repository;
        FilePath = filePath;
        Project = NormalizeOptional(project);
        Module = NormalizeOptional(module);
        Namespace = NormalizeOptional(@namespace);
        Symbol = NormalizeOptional(symbol);
        LineStart = lineStart;
        LineEnd = lineEnd;
    }

    public string Repository { get; }

    public string FilePath { get; }

    public string? Project { get; }

    public string? Module { get; }

    public string? Namespace { get; }

    public string? Symbol { get; }

    public int? LineStart { get; }

    public int? LineEnd { get; }

    private static string? NormalizeOptional(string? value)
    {
        return string.IsNullOrWhiteSpace(value) ? null : value;
    }
}
