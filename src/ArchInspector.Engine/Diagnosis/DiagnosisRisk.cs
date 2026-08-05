namespace ArchInspector.Engine.Diagnosis;

public sealed record DiagnosisRisk
{
    public DiagnosisRisk(
        string id,
        string title,
        string description,
        IEnumerable<string>? relatedPatternIds)
    {
        Id = RequireText(id, nameof(id));
        Title = RequireText(title, nameof(title));
        Description = RequireText(description, nameof(description));
        RelatedPatternIds = NormalizeRelatedPatternIds(relatedPatternIds);
    }

    public string Id { get; }

    public string Title { get; }

    public string Description { get; }

    public IReadOnlyList<string> RelatedPatternIds { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static IReadOnlyList<string> NormalizeRelatedPatternIds(IEnumerable<string>? relatedPatternIds)
    {
        if (relatedPatternIds is null)
        {
            return Array.Empty<string>();
        }

        var normalized = new List<string>();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (var patternId in relatedPatternIds)
        {
            if (string.IsNullOrWhiteSpace(patternId))
            {
                continue;
            }

            var trimmed = patternId.Trim();

            if (seen.Add(trimmed))
            {
                normalized.Add(trimmed);
            }
        }

        return normalized.AsReadOnly();
    }
}
