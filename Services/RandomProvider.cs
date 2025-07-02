namespace DropSimulator.Services
{
    internal class RandomProvider : IRandomProvider
    {
        private readonly Random _rng = new();

        public double NextDouble() => _rng.NextDouble();
    }
}
