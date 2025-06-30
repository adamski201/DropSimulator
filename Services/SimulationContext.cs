using DropSimulator.Models;

namespace DropSimulator.Services
{
    internal class SimulationContext
    {
        public List<DropRecord> Drops { get; set; } = [];

        private readonly HashSet<int> _uniqueItems; // Provided from outside or set at construction
        private readonly Dictionary<int, int> _uniqueFirstObtainedAt = new();

        public int? GreenlogKillCount { get; private set; }
    }
}