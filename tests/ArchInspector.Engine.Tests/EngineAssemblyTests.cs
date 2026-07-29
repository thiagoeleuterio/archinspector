using ArchInspector.Engine;

namespace ArchInspector.Engine.Tests;

public sealed class EngineAssemblyTests
{
    [Fact]
    public void EngineAssembly_ShouldBeLoadable()
    {
        var assembly = typeof(EngineAssemblyMarker).Assembly;

        Assert.Equal("ArchInspector.Engine", assembly.GetName().Name);
    }
}
