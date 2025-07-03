using DropSimulator.Models;
using DropSimulator.Simulators;

namespace DropSimulator.Services
{
    internal class BossSimulator
    {
        private readonly IDropLogic _dropLogic;
        private readonly List<DropTableItem> _dropTable;
        private readonly IReadOnlyCollection<int> _uniqueItems;

        public BossSimulator(IDropLogic dropLogic, IEnumerable<DropTableItem> dropTable)
        {
            _dropLogic = dropLogic;
            _dropTable = dropTable.ToList();
            _uniqueItems = _dropTable.Select(item => item.ItemId).ToList();
        }

        public SimulationResult RunSimulation(int numKills)
        {
            var context = new SimulationContext(_uniqueItems);

            for (int kc = 1; kc <= numKills; kc++)
            {
                var drops = _dropLogic.RollDrops(kc, context);
                context.AddDrops(drops);
            }

            return new SimulationResult(
                numKills,
                context.GreenlogKillCount,
                context.Drops,
                context.DropQuantities,
                context.UniqueFirstObtainedAt
            );
        }
    }
}
