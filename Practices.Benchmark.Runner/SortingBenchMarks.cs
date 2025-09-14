using BenchmarkDotNet.Attributes;
using Practices.Algorithms.Sorting;

namespace Practices.Benchmark.Runner
{
    public class SortingBenchMarks
    {
        [Benchmark(OperationsPerInvoke = 5)]
        public void SelectionSorting()
        {
            var array = new[] { 3, 5, 2, 1, 4 };
            SelectionSort.Sort(array);
        }


        [Benchmark(OperationsPerInvoke = 5)]
        public void BubbleSorting()
        {
            var array = new[] { 3, 5, 2, 1, 4 };
            BubbleSort.Sort(array);
        }
    }
}
