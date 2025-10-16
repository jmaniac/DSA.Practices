namespace Practices.Problems
{
    internal class SmallestMissingPositioneIntegerAfterOperations
    {
        public int FindSmallestInteger(int[] nums, int value)
        {
            int n = nums.Length, res = 0;
            int[] rem = new int[value];
            foreach (int x in nums)
            {
                int r = ((x % value) + value) % value;
                rem[r]++;
            }
            while (rem[res % value]-- > 0) res++;
            return res;
        }
    }
}
