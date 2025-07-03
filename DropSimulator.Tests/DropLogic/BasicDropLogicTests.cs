using DropSimulator.Models;
using DropSimulator.Services;
using DropSimulator.Simulators;
using DropSimulator.Tests.TestUtilities;
using FluentAssertions;
using System.Collections.Generic;

namespace DropSimulator.Tests.Services;

public class BasicDropLogicTests
{
    [Fact]
    public void RollDrops_ReturnsAllDrops_WhenAllDropsRolled()
    {
        var rng = new SequencedRandomProvider([0, 0, 0, 0]);
        var dropTable = new List < DropTableItem >
            ([
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ]);
        var dropLogic = new BasicDropLogic(rng, dropTable);
        var simulationContext = new SimulationContext(dropTable.Select(item => item.ItemId).ToList());

        var drops = dropLogic.RollDrops(1, simulationContext);

        drops.Should().HaveCount(dropTable.Count);
    }

    [Fact]
    public void RollDrops_ReturnsEmpty_WhenNoDropsRolled()
    {
        var rng = new SequencedRandomProvider([1, 1, 1, 1]);
        var dropTable = new List<DropTableItem>
            ([
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ]);
        var dropLogic = new BasicDropLogic(rng, dropTable);
        var simulationContext = new SimulationContext(dropTable.Select(item => item.ItemId).ToList());

        var drops = dropLogic.RollDrops(1, simulationContext);

        drops.Should().BeEmpty();
    }

    [Fact]
    public void RollDrops_ReturnsTwo_WhenTwoDropsRolled()
    {
        var rng = new SequencedRandomProvider([0, 1, 0, 1]);
        var dropTable = new List<DropTableItem>
            ([
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ]);
        var dropLogic = new BasicDropLogic(rng, dropTable);
        var simulationContext = new SimulationContext(dropTable.Select(item => item.ItemId).ToList());

        var drops = dropLogic.RollDrops(1, simulationContext);
        drops.Should().HaveCount(2);
    }
}
