using ArchInspector.Engine.Evidence;

namespace ArchInspector.Engine.Tests.Evidence;

public sealed class EvidenceTraceTests
{
    [Fact]
    public void Constructor_WithRequiredFields_ShouldCreateTrace()
    {
        var trace = new EvidenceTrace("repo", "src/file.cs");

        Assert.Equal("repo", trace.Repository);
        Assert.Equal("src/file.cs", trace.FilePath);
        Assert.Null(trace.Project);
        Assert.Null(trace.LineStart);
    }

    [Fact]
    public void Constructor_WithAllFields_ShouldCreateTrace()
    {
        var trace = new EvidenceTrace(
            "repo",
            "src/file.cs",
            "project",
            "module",
            "namespace",
            "symbol",
            10,
            20);

        Assert.Equal("project", trace.Project);
        Assert.Equal("module", trace.Module);
        Assert.Equal("namespace", trace.Namespace);
        Assert.Equal("symbol", trace.Symbol);
        Assert.Equal(10, trace.LineStart);
        Assert.Equal(20, trace.LineEnd);
    }

    [Fact]
    public void Constructor_WithEmptyRepository_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new EvidenceTrace(" ", "src/file.cs"));
    }

    [Fact]
    public void Constructor_WithEmptyFilePath_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new EvidenceTrace("repo", " "));
    }

    [Fact]
    public void Constructor_WithEmptyOptionalFields_ShouldNormalizeThemToNull()
    {
        var trace = new EvidenceTrace("repo", "src/file.cs", " ", "", "\t", null);

        Assert.Null(trace.Project);
        Assert.Null(trace.Module);
        Assert.Null(trace.Namespace);
        Assert.Null(trace.Symbol);
    }

    [Fact]
    public void Constructor_WithLineStartEqualToZero_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new EvidenceTrace("repo", "src/file.cs", lineStart: 0));
    }

    [Fact]
    public void Constructor_WithLineEndEqualToZero_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new EvidenceTrace("repo", "src/file.cs", lineEnd: 0));
    }

    [Fact]
    public void Constructor_WithLineEndLessThanLineStart_ShouldThrow()
    {
        Assert.Throws<ArgumentOutOfRangeException>(() => new EvidenceTrace("repo", "src/file.cs", lineStart: 4, lineEnd: 3));
    }
}
