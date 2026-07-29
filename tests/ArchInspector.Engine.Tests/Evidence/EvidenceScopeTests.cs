using ArchInspector.Engine.Evidence;

namespace ArchInspector.Engine.Tests.Evidence;

public sealed class EvidenceScopeTests
{
    [Fact]
    public void Constructor_WithOnlyRepository_ShouldCreateScope()
    {
        var scope = new EvidenceScope(repository: "repo");

        Assert.Equal("repo", scope.Repository);
        Assert.Null(scope.Project);
        Assert.Null(scope.Module);
        Assert.Null(scope.Component);
    }

    [Fact]
    public void Constructor_WithOnlyProject_ShouldCreateScope()
    {
        var scope = new EvidenceScope(project: "project");

        Assert.Null(scope.Repository);
        Assert.Equal("project", scope.Project);
        Assert.Null(scope.Module);
        Assert.Null(scope.Component);
    }

    [Fact]
    public void Constructor_WithAllFields_ShouldCreateScope()
    {
        var scope = new EvidenceScope("repo", "project", "module", "component");

        Assert.Equal("repo", scope.Repository);
        Assert.Equal("project", scope.Project);
        Assert.Equal("module", scope.Module);
        Assert.Equal("component", scope.Component);
    }

    [Fact]
    public void Constructor_WithEmptyFields_ShouldNormalizeThemToNull()
    {
        var scope = new EvidenceScope("repo", " ", "", "\t");

        Assert.Equal("repo", scope.Repository);
        Assert.Null(scope.Project);
        Assert.Null(scope.Module);
        Assert.Null(scope.Component);
    }

    [Fact]
    public void Constructor_WithAllFieldsEmpty_ShouldThrow()
    {
        Assert.Throws<ArgumentException>(() => new EvidenceScope(" ", "", "\t", null));
    }
}
