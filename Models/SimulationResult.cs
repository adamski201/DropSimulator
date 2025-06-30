
namespace DropSimulator.Models
{
    internal class SimulationResult
    {
        public int KillCount { get; set; }
        public int? GreenlogKillCount { get; set; }
        public List<DropRecord> Drops { get; } = new();
        public Dictionary<int, int> DropQuantities { get; } = new();
        public Dictionary<int, int> DropFirstObtainedAt { get; } = new();

        internal void AddDrop(DropRecord drop)
        {
            Drops.Add(drop);
            var currentKc = drop.KillCount;

            if (DropQuantities.ContainsKey(drop.Id))
            {
                DropQuantities[drop.Id] += 1;
            }
            else
            {
                DropQuantities[drop.Id] = 1;
            }

            if (!DropFirstObtainedAt.ContainsKey(drop.Id))
            {
                DropFirstObtainedAt[drop.Id] = currentKc;
            }
        }
    }
}
