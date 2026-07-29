using System.Collections.ObjectModel;

namespace ArchInspector.Engine.Rules;

public sealed record RuleResult
{
    public RuleResult(
        string ruleId,
        string taxonomyReference,
        RuleOutcome outcome,
        RuleSeverity severity,
        string message,
        string repository,
        string filePath,
        string? findingId = null,
        string? project = null,
        string? module = null,
        string? @namespace = null,
        string? symbol = null,
        int? lineStart = null,
        int? lineEnd = null,
        IEnumerable<string>? tags = null,
        IEnumerable<KeyValuePair<string, string>>? metadata = null)
    {
        RuleId = RequireText(ruleId, nameof(ruleId));
        TaxonomyReference = RequireText(taxonomyReference, nameof(taxonomyReference));
        Outcome = RequireDefined(outcome, nameof(outcome));
        Severity = RequireDefined(severity, nameof(severity));
        Message = RequireText(message, nameof(message));
        Repository = RequireText(repository, nameof(repository));
        FilePath = RequireText(filePath, nameof(filePath));
        FindingId = NormalizeOptionalText(findingId);
        Project = NormalizeOptionalText(project);
        Module = NormalizeOptionalText(module);
        Namespace = NormalizeOptionalText(@namespace);
        Symbol = NormalizeOptionalText(symbol);
        ValidateLines(lineStart, lineEnd);
        LineStart = lineStart;
        LineEnd = lineEnd;
        Tags = NormalizeTags(tags);
        Metadata = NormalizeMetadata(metadata);
    }

    public string RuleId { get; }

    public string TaxonomyReference { get; }

    public RuleOutcome Outcome { get; }

    public RuleSeverity Severity { get; }

    public string Message { get; }

    public string Repository { get; }

    public string FilePath { get; }

    public string? FindingId { get; }

    public string? Project { get; }

    public string? Module { get; }

    public string? Namespace { get; }

    public string? Symbol { get; }

    public int? LineStart { get; }

    public int? LineEnd { get; }

    public IReadOnlyList<string> Tags { get; }

    public IReadOnlyDictionary<string, string> Metadata { get; }

    private static string RequireText(string value, string parameterName)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            throw new ArgumentException($"{parameterName} is required.", parameterName);
        }

        return value.Trim();
    }

    private static string? NormalizeOptionalText(string? value)
    {
        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        return value.Trim();
    }

    private static RuleOutcome RequireDefined(RuleOutcome outcome, string parameterName)
    {
        if (!Enum.IsDefined(outcome))
        {
            throw new ArgumentOutOfRangeException(parameterName, outcome, "Rule outcome is not defined.");
        }

        return outcome;
    }

    private static RuleSeverity RequireDefined(RuleSeverity severity, string parameterName)
    {
        if (!Enum.IsDefined(severity))
        {
            throw new ArgumentOutOfRangeException(parameterName, severity, "Rule severity is not defined.");
        }

        return severity;
    }

    private static void ValidateLines(int? lineStart, int? lineEnd)
    {
        if (lineStart <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lineStart), lineStart, "Line start must be greater than zero.");
        }

        if (lineEnd <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(lineEnd), lineEnd, "Line end must be greater than zero.");
        }

        if (lineStart.HasValue && lineEnd.HasValue && lineEnd.Value < lineStart.Value)
        {
            throw new ArgumentOutOfRangeException(nameof(lineEnd), lineEnd, "Line end cannot be less than line start.");
        }
    }

    private static IReadOnlyList<string> NormalizeTags(IEnumerable<string>? tags)
    {
        if (tags is null)
        {
            return Array.Empty<string>();
        }

        var normalized = new List<string>();
        var seen = new HashSet<string>(StringComparer.Ordinal);

        foreach (var tag in tags)
        {
            if (string.IsNullOrWhiteSpace(tag))
            {
                continue;
            }

            var trimmed = tag.Trim();
            if (seen.Add(trimmed))
            {
                normalized.Add(trimmed);
            }
        }

        return normalized.AsReadOnly();
    }

    private static IReadOnlyDictionary<string, string> NormalizeMetadata(IEnumerable<KeyValuePair<string, string>>? metadata)
    {
        var normalized = new Dictionary<string, string>(StringComparer.Ordinal);

        if (metadata is null)
        {
            return new ReadOnlyDictionary<string, string>(normalized);
        }

        foreach (var item in metadata)
        {
            if (string.IsNullOrWhiteSpace(item.Key))
            {
                throw new ArgumentException("Metadata keys are required.", nameof(metadata));
            }

            if (item.Value is null)
            {
                throw new ArgumentException("Metadata values cannot be null.", nameof(metadata));
            }

            var key = item.Key.Trim();
            var value = item.Value.Trim();

            if (normalized.ContainsKey(key))
            {
                throw new ArgumentException("Metadata keys must be unique.", nameof(metadata));
            }

            normalized.Add(key, value);
        }

        return new ReadOnlyDictionary<string, string>(normalized);
    }
}
