using System.Text.Json;
using System.Text.Json.Serialization;
using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Pipeline;
using ArchInspector.Engine.Reporting;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Cli;

public sealed class Application(
    IArchitectureAnalyzer analyzer,
    IExecutiveReportGenerator reportGenerator)
{
    public const int SuccessExitCode = 0;
    public const int InvalidArgumentsExitCode = 1;
    public const int FileNotFoundExitCode = 2;
    public const int InvalidJsonExitCode = 3;
    public const int UnexpectedErrorExitCode = 4;

    private const string Usage = "Usage:" + "\n" + "\n" + "archinspector analyze <rules.json>";
    private const string ReportFileName = "EXECUTIVE_REPORT.md";

    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web)
    {
        PropertyNameCaseInsensitive = true,
        Converters =
        {
            new JsonStringEnumConverter(),
            new RuleResultJsonConverter()
        }
    };

    public static Application CreateDefault()
    {
        return new Application(
            new ArchitectureAnalyzer(
                new EvidenceBuilder(),
                new EvidenceAggregator(),
                new EvidenceCorrelator(),
                new ArchitectureClassifier(),
                new DiagnosisBuilder()),
            new ExecutiveReportGenerator());
    }

    public int Run(string[] args)
    {
        if (!IsAnalyzeCommand(args))
        {
            Console.Error.WriteLine(Usage);
            return InvalidArgumentsExitCode;
        }

        var rulesPath = args[1];

        if (!File.Exists(rulesPath))
        {
            return FileNotFoundExitCode;
        }

        try
        {
            var json = File.ReadAllText(rulesPath);
            var ruleResults = JsonSerializer.Deserialize<List<RuleResult>>(json, JsonOptions);

            if (ruleResults is null)
            {
                return InvalidJsonExitCode;
            }

            var repository = GetRepositoryName(rulesPath);
            var diagnosis = analyzer.Analyze(
                Guid.NewGuid().ToString("N"),
                repository,
                DateTimeOffset.UtcNow,
                ruleResults);
            var report = reportGenerator.Generate(diagnosis);
            var reportPath = Path.Combine(
                Path.GetDirectoryName(Path.GetFullPath(rulesPath)) ?? Directory.GetCurrentDirectory(),
                ReportFileName);

            File.WriteAllText(reportPath, report);

            return SuccessExitCode;
        }
        catch (JsonException)
        {
            return InvalidJsonExitCode;
        }
        catch (ArgumentException)
        {
            return InvalidJsonExitCode;
        }
        catch (NotSupportedException)
        {
            return InvalidJsonExitCode;
        }
        catch
        {
            return UnexpectedErrorExitCode;
        }
    }

    private static bool IsAnalyzeCommand(string[] args)
    {
        return args.Length == 2
            && string.Equals(args[0], "analyze", StringComparison.Ordinal)
            && !string.IsNullOrWhiteSpace(args[1]);
    }

    private static string GetRepositoryName(string rulesPath)
    {
        var directory = Path.GetDirectoryName(Path.GetFullPath(rulesPath));

        if (string.IsNullOrWhiteSpace(directory))
        {
            return "unknown";
        }

        return new DirectoryInfo(directory).Name;
    }

    private sealed class RuleResultJsonConverter : JsonConverter<RuleResult>
    {
        public override RuleResult Read(
            ref Utf8JsonReader reader,
            Type typeToConvert,
            JsonSerializerOptions options)
        {
            using var document = JsonDocument.ParseValue(ref reader);
            var root = document.RootElement;

            return new RuleResult(
                GetRequiredString(root, "ruleId"),
                GetRequiredString(root, "taxonomyReference"),
                GetRequiredEnum<RuleOutcome>(root, "outcome", options),
                GetRequiredEnum<RuleSeverity>(root, "severity", options),
                GetRequiredString(root, "message"),
                GetRequiredString(root, "repository"),
                GetRequiredString(root, "filePath"),
                GetOptionalString(root, "findingId"),
                GetOptionalString(root, "project"),
                GetOptionalString(root, "module"),
                GetOptionalString(root, "namespace"),
                GetOptionalString(root, "symbol"),
                GetOptionalInt(root, "lineStart"),
                GetOptionalInt(root, "lineEnd"),
                GetStringArray(root, "tags"),
                GetMetadata(root, "metadata"));
        }

        public override void Write(
            Utf8JsonWriter writer,
            RuleResult value,
            JsonSerializerOptions options)
        {
            JsonSerializer.Serialize(writer, value, options);
        }

        private static string GetRequiredString(JsonElement root, string propertyName)
        {
            var value = GetOptionalString(root, propertyName);

            if (value is null)
            {
                throw new JsonException($"{propertyName} is required.");
            }

            return value;
        }

        private static string? GetOptionalString(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.GetString();
        }

        private static int? GetOptionalInt(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.GetInt32();
        }

        private static TEnum GetRequiredEnum<TEnum>(
            JsonElement root,
            string propertyName,
            JsonSerializerOptions options)
            where TEnum : struct, Enum
        {
            if (!TryGetProperty(root, propertyName, out var property))
            {
                throw new JsonException($"{propertyName} is required.");
            }

            return property.Deserialize<TEnum>(options);
        }

        private static IEnumerable<string>? GetStringArray(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property.Deserialize<string[]>(JsonOptions);
        }

        private static IEnumerable<KeyValuePair<string, string>>? GetMetadata(JsonElement root, string propertyName)
        {
            if (!TryGetProperty(root, propertyName, out var property) || property.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            return property
                .Deserialize<Dictionary<string, string>>(JsonOptions)
                ?.Select(item => new KeyValuePair<string, string>(item.Key, item.Value));
        }

        private static bool TryGetProperty(
            JsonElement root,
            string propertyName,
            out JsonElement property)
        {
            foreach (var item in root.EnumerateObject())
            {
                if (string.Equals(item.Name, propertyName, StringComparison.OrdinalIgnoreCase))
                {
                    property = item.Value;
                    return true;
                }
            }

            property = default;
            return false;
        }
    }
}
