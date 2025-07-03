using DropSimulator.Services;

namespace DropSimulator.Tests.TestUtilities
{
    internal class SequencedRandomProvider : IRandomProvider
    {
        private readonly Queue<double> chances;

        public SequencedRandomProvider(IEnumerable<double> chances)
        {
            this.chances = new Queue<double>(chances);
        }

        public double NextDouble() => chances.Dequeue();
    }
}
