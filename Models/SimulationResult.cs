namespace DropSimulator.Models
{
    internal class SimulationResult
    {
        public int KillCount { get; }
        public int? GreenlogKillCount { get; }
        public bool IsGreenlogged { get; }
        public List<Drop> Drops { get; }
        public IReadOnlyDictionary<int, int> DropQuantities { get; }
        public IReadOnlyDictionary<int, int> DropFirstObtainedAt { get; }

        public SimulationResult(
            int killCount,
            int? greenlogKillCount,
            IEnumerable<Drop> drops,
            IReadOnlyDictionary<int, int> dropQuantities,
            IReadOnlyDictionary<int, int> uniqueFirstObtainedAt
        )
        {
            KillCount = killCount;
            GreenlogKillCount = greenlogKillCount;
            Drops = drops.ToList();
            DropQuantities = new Dictionary<int, int>(dropQuantities);
            DropFirstObtainedAt = new Dictionary<int, int>(uniqueFirstObtainedAt);

            IsGreenlogged = GreenlogKillCount > 0;
        }
    }
}
