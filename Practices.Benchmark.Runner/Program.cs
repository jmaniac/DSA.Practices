using Practices.Algorithms.Sorting;
using Practices.Algorithms.Utils;

namespace Practices.Benchmark.Runner
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var array = new[] { 3, 5, 2, 1, 4 };
            Console.WriteLine(array.AsString());

            BubbleSort.Sort(array);
            Console.WriteLine(array.AsString());

            array = new[] { 3, 5, 2, 1, 4 };
            SelectionSort.Sort(array);
            Console.WriteLine(array.AsString());

            Console.ReadKey();
        }
    }
}
