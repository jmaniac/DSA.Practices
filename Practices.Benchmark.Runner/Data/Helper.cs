using Bogus;

namespace Practices.Benchmark.Runner.Data
{
    internal static class DataHelper
    {

        public static int[] GetRandomArray()
        {
            Randomizer.Seed = new Random();

            var faker = new Faker();

            return Enumerable.Range(1, int.MaxValue).Select(_ => faker.Random.Int(1)).ToArray();
        }
    }
}
