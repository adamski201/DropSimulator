using DropSimulator.Models;
using DropSimulator.Services;

namespace DropSimulator.Simulators
{
    internal class KingBlackDragonDropLogic : IDropLogic
    {
        private readonly List<DropTableItem> DropTable =
        [
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ];

        private readonly Random _rng = new();

        public IReadOnlyCollection<int> UniqueItemIds => (IReadOnlyCollection<int>)DropTable.Select(item => item.ItemId);

        public List<DropRecord> RollDrops(int killCount, SimulationContext context)
        {
            var drops = new List<DropRecord>();

            foreach (var item in DropTable)
            {
                if (_rng.NextDouble() <= item.DropRate)
                {
                    drops.Add(new DropRecord(item.ItemId, killCount));
                }
            }

            return drops;
        }
    }
}
