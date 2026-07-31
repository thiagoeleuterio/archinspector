using ArchInspector.Engine.Builder;
using ArchInspector.Engine.Evidence;
using ArchInspector.Engine.Rules;

namespace ArchInspector.Engine.Tests.Builder;

public sealed class IEvidenceBuilderTests
{
    [Fact]
    public void IEvidenceBuilder_ShouldBeInterface()
    {
        Assert.True(typeof(IEvidenceBuilder).IsInterface);
    }

    [Fact]
    public void IEvidenceBuilder_ShouldDeclareExactlyOnePublicMethod()
    {
        var method = Assert.Single(typeof(IEvidenceBuilder).GetMethods());

        Assert.Equal("Build", method.Name);
    }

    [Fact]
    public void Build_ShouldReturnEvidenceSet()
    {
        var method = Assert.Single(typeof(IEvidenceBuilder).GetMethods());

        Assert.Equal(typeof(EvidenceSet), method.ReturnType);
    }

    [Fact]
    public void Build_ShouldDeclareExpectedParametersInOrder()
    {
        var method = Assert.Single(typeof(IEvidenceBuilder).GetMethods());

        var parameters = method.GetParameters();

        Assert.Collection(
            parameters,
            parameter =>
            {
                Assert.Equal("analysisId", parameter.Name);
                Assert.Equal(typeof(string), parameter.ParameterType);
            },
            parameter =>
            {
                Assert.Equal("repository", parameter.Name);
                Assert.Equal(typeof(string), parameter.ParameterType);
            },
            parameter =>
            {
                Assert.Equal("collectedAt", parameter.Name);
                Assert.Equal(typeof(DateTimeOffset), parameter.ParameterType);
            },
            parameter =>
            {
                Assert.Equal("ruleResults", parameter.Name);
                Assert.Equal(typeof(IEnumerable<RuleResult>), parameter.ParameterType);
            });
    }
}
