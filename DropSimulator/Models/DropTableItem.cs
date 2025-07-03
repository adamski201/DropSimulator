namespace DropSimulator.Models
{
    public class DropTableItem
    {
        public int ItemId { get; set; }
        public double DropRate { get; }

        public DropTableItem(int Id, double DropRate)
        {
            ItemId = Id;
            this.DropRate = DropRate;
        }
    }
}
