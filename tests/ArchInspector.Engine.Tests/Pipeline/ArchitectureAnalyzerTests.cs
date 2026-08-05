using ArchInspector.Engine.Aggregation;
using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Classification;
using ArchInspector.Engine.Correlation;
using ArchInspector.Engine.Diagnosis;
using ArchInspector.Engine.Evidence;
using ArchInspector.Engine.Pipeline;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Tests.Pipeline;

public sealed class ArchitectureAnalyzerTests
{
    private static readonly DateTimeOffset CollectedAt = new(2026, 8, 5, 12, 0, 0, TimeSpan.Zero);

    [Fact]
    public void ArchitectureAnalyzer_ShouldImplementIArchitectureAnalyzer()
    {
        var pipeline = CreatePipeline();

        Assert.IsAssignableFrom<IArchitectureAnalyzer>(pipeline.Analyzer);
    }

    [Fact]
    public void Analyze_ShouldCallAllComponentsInOrder()
    {
        var pipeline = CreatePipeline();

        pipeline.Analyzer.Analyze("analysis-1", "repo", CollectedAt, [CreateRuleResult()]);

        Assert.Equal(
            [
                "EvidenceBuilder.Build",
                "EvidenceAggregator.Aggregate",
                "EvidenceCorrelator.Correlate",
                "ArchitectureClassifier.Classify",
                "DiagnosisBuilder.Build"
            ],
            pipeline.Calls);
    }

    [Fact]
    public void Analyze_ShouldPropagateParametersAndIntermediateResults()
    {
        var ruleResults = new[] { CreateRuleResult() };
        var pipeline = CreatePipeline();

        pipeline.Analyzer.Analyze("analysis-1", "repo", CollectedAt, ruleResults);

        Assert.Equal("analysis-1", pipeline.EvidenceBuilder.AnalysisId);
        Assert.Equal("repo", pipeline.EvidenceBuilder.Repository);
        Assert.Equal(CollectedAt, pipeline.EvidenceBuilder.CollectedAt);
        Assert.Same(ruleResults, pipeline.EvidenceBuilder.RuleResults);
        Assert.Same(pipeline.EvidenceSet, pipeline.EvidenceAggregator.EvidenceSet);
        Assert.Same(pipeline.AggregatedEvidenceSet, pipeline.EvidenceCorrelator.AggregatedEvidenceSet);
        Assert.Same(pipeline.CorrelatedEvidenceSet, pipeline.ArchitectureClassifier.CorrelatedEvidenceSet);
        Assert.Same(pipeline.ArchitectureClassification, pipeline.DiagnosisBuilder.ArchitectureClassification);
    }

    [Fact]
    public void Analyze_ShouldReturnDiagnosisProducedByDiagnosisBuilder()
    {
        var pipeline = CreatePipeline();

        var result = pipeline.Analyzer.Analyze("analysis-1", "repo", CollectedAt, [CreateRuleResult()]);

        Assert.Same(pipeline.ArchitectureDiagnosis, result);
    }

    [Fact]
    public void Analyze_WhenComponentThrows_ShouldPropagateException()
    {
        var expected = new InvalidOperationException("Classification failed.");
        var pipeline = CreatePipeline();
        pipeline.ArchitectureClassifier.ExceptionToThrow = expected;

        var thrown = Assert.Throws<InvalidOperationException>(() =>
            pipeline.Analyzer.Analyze("analysis-1", "repo", CollectedAt, [CreateRuleResult()]));

        Assert.Same(expected, thrown);
    }

    [Fact]
    public void Analyze_WithEmptyRuleResults_ShouldContinuePipeline()
    {
        var ruleResults = Array.Empty<RuleResult>();
        var pipeline = CreatePipeline();

        var result = pipeline.Analyzer.Analyze("analysis-1", "repo", CollectedAt, ruleResults);

        Assert.Same(ruleResults, pipeline.EvidenceBuilder.RuleResults);
        Assert.Same(pipeline.ArchitectureDiagnosis, result);
        Assert.Equal(5, pipeline.Calls.Count);
    }

    private static TestPipeline CreatePipeline()
    {
        var calls = new List<string>();
        var evidenceSet = new EvidenceSet("analysis-1", "repo", CollectedAt, []);
        var aggregatedEvidenceSet = new AggregatedEvidenceSet("analysis-1", "repo", CollectedAt, []);
        var correlatedEvidenceSet = new CorrelatedEvidenceSet("analysis-1", "repo", CollectedAt, []);
        var architectureClassification = new ArchitectureClassification(
            ArchitectureKind.Unknown,
            ClassificationConfidence.Low,
            [],
            [],
            []);
        var architectureDiagnosis = new ArchitectureDiagnosis(
            ArchitectureKind.Unknown,
            DiagnosisStrength.Unknown,
            "Unknown architecture.",
            [],
            [],
            [],
            []);
        var evidenceBuilder = new FakeEvidenceBuilder(calls, evidenceSet);
        var evidenceAggregator = new FakeEvidenceAggregator(calls, aggregatedEvidenceSet);
        var evidenceCorrelator = new FakeEvidenceCorrelator(calls, correlatedEvidenceSet);
        var architectureClassifier = new FakeArchitectureClassifier(calls, architectureClassification);
        var diagnosisBuilder = new FakeDiagnosisBuilder(calls, architectureDiagnosis);
        var analyzer = new ArchitectureAnalyzer(
            evidenceBuilder,
            evidenceAggregator,
            evidenceCorrelator,
            architectureClassifier,
            diagnosisBuilder);

        return new TestPipeline(
            analyzer,
            calls,
            evidenceSet,
            aggregatedEvidenceSet,
            correlatedEvidenceSet,
            architectureClassification,
            architectureDiagnosis,
            evidenceBuilder,
            evidenceAggregator,
            evidenceCorrelator,
            architectureClassifier,
            diagnosisBuilder);
    }

    private static RuleResult CreateRuleResult()
    {
        return new RuleResult(
            "RULE-001",
            "LayerSeparation",
            RuleOutcome.Passed,
            RuleSeverity.Informational,
            "Layer separation found.",
            "repo",
            "src/File.cs");
    }

    private sealed record TestPipeline(
        ArchitectureAnalyzer Analyzer,
        IReadOnlyList<string> Calls,
        EvidenceSet EvidenceSet,
        AggregatedEvidenceSet AggregatedEvidenceSet,
        CorrelatedEvidenceSet CorrelatedEvidenceSet,
        ArchitectureClassification ArchitectureClassification,
        ArchitectureDiagnosis ArchitectureDiagnosis,
        FakeEvidenceBuilder EvidenceBuilder,
        FakeEvidenceAggregator EvidenceAggregator,
        FakeEvidenceCorrelator EvidenceCorrelator,
        FakeArchitectureClassifier ArchitectureClassifier,
        FakeDiagnosisBuilder DiagnosisBuilder);

    private sealed class FakeEvidenceBuilder(
        List<string> calls,
        EvidenceSet result) : IEvidenceBuilder
    {
        public string? AnalysisId { get; private set; }

        public string? Repository { get; private set; }

        public DateTimeOffset? CollectedAt { get; private set; }

        public IEnumerable<RuleResult>? RuleResults { get; private set; }

        public EvidenceSet Build(
            string analysisId,
            string repository,
            DateTimeOffset collectedAt,
            IEnumerable<RuleResult> ruleResults)
        {
            calls.Add("EvidenceBuilder.Build");
            AnalysisId = analysisId;
            Repository = repository;
            CollectedAt = collectedAt;
            RuleResults = ruleResults;

            return result;
        }
    }

    private sealed class FakeEvidenceAggregator(
        List<string> calls,
        AggregatedEvidenceSet result) : IEvidenceAggregator
    {
        public EvidenceSet? EvidenceSet { get; private set; }

        public AggregatedEvidenceSet Aggregate(EvidenceSet evidenceSet)
        {
            calls.Add("EvidenceAggregator.Aggregate");
            EvidenceSet = evidenceSet;

            return result;
        }
    }

    private sealed class FakeEvidenceCorrelator(
        List<string> calls,
        CorrelatedEvidenceSet result) : IEvidenceCorrelator
    {
        public AggregatedEvidenceSet? AggregatedEvidenceSet { get; private set; }

        public CorrelatedEvidenceSet Correlate(AggregatedEvidenceSet aggregatedEvidence)
        {
            calls.Add("EvidenceCorrelator.Correlate");
            AggregatedEvidenceSet = aggregatedEvidence;

            return result;
        }
    }

    private sealed class FakeArchitectureClassifier(
        List<string> calls,
        ArchitectureClassification result) : IArchitectureClassifier
    {
        public CorrelatedEvidenceSet? CorrelatedEvidenceSet { get; private set; }

        public InvalidOperationException? ExceptionToThrow { get; set; }

        public ArchitectureClassification Classify(CorrelatedEvidenceSet correlatedEvidence)
        {
            calls.Add("ArchitectureClassifier.Classify");
            CorrelatedEvidenceSet = correlatedEvidence;

            if (ExceptionToThrow is not null)
            {
                throw ExceptionToThrow;
            }

            return result;
        }
    }

    private sealed class FakeDiagnosisBuilder(
        List<string> calls,
        ArchitectureDiagnosis result) : IDiagnosisBuilder
    {
        public ArchitectureClassification? ArchitectureClassification { get; private set; }

        public ArchitectureDiagnosis Build(ArchitectureClassification classification)
        {
            calls.Add("DiagnosisBuilder.Build");
            ArchitectureClassification = classification;

            return result;
        }
    }
}
