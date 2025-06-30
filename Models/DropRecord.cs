namespace DropSimulator.Models
{
    public class DropRecord
    {
        public int Id { get; set; }
        public int KillCount { get; set; }

        public DropRecord(int Id, int Killcount)
        {
            this.Id = Id;
            this.KillCount = Killcount;
        }
    }
}