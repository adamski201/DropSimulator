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
            this._uniqueItems = _dropLogic.UniqueItemIds;
        }

        public SimulationResult RunSimulation(int numKills)
        {
            var result = new SimulationResult();
            var context = new SimulationContext();

            for (int kc = 1; kc <= numKills; kc++)
            {
                var drops = _dropLogic.RollDrops(kc, context);

                foreach (var drop in drops)
                {
                    context.Drops.Add(drop);
                }
            }



            return result;
        }
    }
}
