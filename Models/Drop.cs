namespace DropSimulator.Models
{
    public class Drop
    {
        public int ItemId { get; set; }
        public int KillCount { get; set; }

        public Drop(int Id, int Killcount)
        {
            this.ItemId = Id;
            this.KillCount = Killcount;
        }
    }
}