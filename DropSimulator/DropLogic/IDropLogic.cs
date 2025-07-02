using DropSimulator.Models;
using DropSimulator.Services;

namespace DropSimulator.Simulators
{
    internal interface IDropLogic
    {
        IReadOnlyCollection<int> UniqueItemIds { get; }
        void RollDrops(int killCount, SimulationContext context);
    }
}