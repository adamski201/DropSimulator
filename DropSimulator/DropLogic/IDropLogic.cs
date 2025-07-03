using DropSimulator.Models;
using DropSimulator.Services;

namespace DropSimulator.Simulators
{
    internal interface IDropLogic
    {
        List<Drop> RollDrops(int killCount, SimulationContext context);
    }
}