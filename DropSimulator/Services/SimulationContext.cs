using DropSimulator.Models;

namespace DropSimulator.Services
{
    public class SimulationContext
    {
        public List<Drop> Drops { get; set; } = [];
        public int? GreenlogKillCount { get; private set; }

        private readonly Dictionary<int, int> _dropQuantities = [];
        private readonly Dictionary<int, int> _uniqueFirstObtainedAt = [];
        private readonly HashSet<int> _uniqueItems;

        public SimulationContext(IEnumerable<int> uniqueItems)
        {
            _uniqueItems = [.. uniqueItems];
        }

        public void AddDrop(Drop drop)
        {
            Drops.Add(drop);

            if (_dropQuantities.ContainsKey(drop.ItemId))
            {
                _dropQuantities[drop.ItemId] += 1;
            }
            else
            {
                _dropQuantities[drop.ItemId] = 1;
            }

            if (!_uniqueFirstObtainedAt.ContainsKey(drop.ItemId))
            {
                _uniqueFirstObtainedAt[drop.ItemId] = drop.KillCount;
            }

            if (GreenlogKillCount == null && _uniqueFirstObtainedAt.Count == _uniqueItems.Count)
            {
                GreenlogKillCount = drop.KillCount;
            }
        }

        public void AddDrops(IEnumerable<Drop> drops)
        {
            foreach (var drop in drops)
            {
                AddDrop(drop);
            }
        }

        public IReadOnlyDictionary<int, int> UniqueFirstObtainedAt => _uniqueFirstObtainedAt;
        public IReadOnlyDictionary<int, int> DropQuantities => _dropQuantities;
    }
}