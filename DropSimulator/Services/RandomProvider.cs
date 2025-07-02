namespace DropSimulator.Services
{
    public class RandomProvider : IRandomProvider
    {
        private readonly Random _rng = new();

        public double NextDouble() => _rng.NextDouble();
    }
}
