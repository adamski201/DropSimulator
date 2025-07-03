using DropSimulator.Models;
using DropSimulator.Services;

namespace DropSimulator.Simulators
{
    public class BasicDropLogic : IDropLogic
    {
        private readonly IRandomProvider _rng;
        private readonly List<DropTableItem> dropTable;

        public BasicDropLogic(IRandomProvider rng, IEnumerable<DropTableItem> dropTable)
        {
            _rng = rng;
            this.dropTable = dropTable.ToList();
        }

        public List<Drop> RollDrops(int killCount, SimulationContext context)
        {
            List<Drop> drops = [];

            foreach (var item in dropTable)
            { 
                if (_rng.NextDouble() <= item.DropRate)
                {
                    var drop = new Drop(item.ItemId, killCount);
                    drops.Add(drop);
                }
            }

            return drops;
        }
    }
}
