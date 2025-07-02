using DropSimulator.Models;
using DropSimulator.Simulators;

namespace DropSimulator.Services
{
    internal class BossSimulator
    {
        private readonly IDropLogic _dropLogic;
        private readonly IReadOnlyCollection<int> _uniqueItems;

        public BossSimulator(IDropLogic dropLogic)
        {
            _dropLogic = dropLogic;
            _uniqueItems = _dropLogic.UniqueItemIds;
        }

        public SimulationResult RunSimulation(int numKills)
        {
            var context = new SimulationContext(_uniqueItems);

            for (int kc = 1; kc <= numKills; kc++)
            {
                var drops = _dropLogic.RollDrops(kc, context);

                context.AddDrops(drops);
            }

            var result = new SimulationResult(numKills, context.GreenlogKillCount, context.Drops, context.DropQuantities, context.UniqueFirstObtainedAt);

            return result;
        }
    }
}
