using DropSimulator.Services;
using DropSimulator.Simulators;
using FluentAssertions;

namespace DropSimulator.Tests.Services;

public class KingBlackDragonDropLogicTests
{
    class MockRandomProvider : IRandomProvider
    {
        public double NextDouble() => 0;
    }

    [Fact]
    public void AddDrops_ShouldUpdateContextCorrectly()
    {
        var rng = new MockRandomProvider();
        var dropLogic = new KingBlackDragonDropLogic(rng);
        var simulationContext = new SimulationContext(dropLogic.UniqueItemIds);

        dropLogic.RollDrops(1, simulationContext);

        simulationContext.Drops.Should().HaveCount(dropLogic.UniqueItemIds.Count);
        simulationContext.UniqueFirstObtainedAt.Should().HaveCount(dropLogic.UniqueItemIds.Count);
        simulationContext.GreenlogKillCount.Should().Be(1);
    }
}
