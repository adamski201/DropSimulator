using DropSimulator.Models;
using DropSimulator.Services;

namespace DropSimulator.Simulators
{
    public class KingBlackDragonDropLogic : IDropLogic
    {
        private readonly List<DropTableItem> DropTable =
        [
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ];

        private readonly IRandomProvider _rng;

        public KingBlackDragonDropLogic(IRandomProvider rng)
        {
            _rng = rng;
        }

        public IReadOnlyCollection<int> UniqueItemIds => DropTable.Select(item => item.ItemId).ToList();

        public void RollDrops(int killCount, SimulationContext context)
        {
            foreach (var item in DropTable)
            { 
                if (_rng.NextDouble() <= item.DropRate)
                {
                    var drop = new Drop(item.ItemId, killCount);
                    context.AddDrop(drop);
                }
            }
        }
    }
}
