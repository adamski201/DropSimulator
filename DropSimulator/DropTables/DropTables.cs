using DropSimulator.Models;

namespace DropSimulator.DropTables
{
    internal class KingBlackDragonTable
    {
        static readonly List<DropTableItem> DropTable =
        [
            new DropTableItem(11920, 1.0 / 1000),
            new DropTableItem(7980,  1.0 / 128),
            new DropTableItem(12653, 1.0 / 3000),
            new DropTableItem(11286, 1.0 / 5000)
        ];
    }
}
