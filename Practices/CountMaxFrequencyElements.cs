namespace Practices.Problems
{
    public class CountMaxFrequencyElements
    {
        public int MaxFrequencyElements(int[] nums)
        {
            int maxFrequncy = 0, frequentNumberCount = 0, length = nums.Length;
            var counters = new int[101];

            if (length == 1) return 1;

            foreach (var num in nums)
            {
                counters[num]++;
            }

            maxFrequncy = counters.Max(x => x);

            if (maxFrequncy == 1)
            {
                return length;
            }

            for (int i = 1; i <= 100; i++)
            {
                //if (counters[i] < maxFrequncy) break;

                if (counters[i] == maxFrequncy)
                {
                    frequentNumberCount += counters[i];
                }
            }

            return frequentNumberCount;
        }
    }
}
