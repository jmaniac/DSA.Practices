namespace Practices.Problems
{
    internal class LargestPerimeterTriangle
    {
        public int LargestPerimeter(int[] nums)
        {
            int length = nums.Length;

            if (length < 3) return 0;

            // Reverse Sort aka Descending Order
            Array.Sort(nums, Comparer<int>.Create((a, b) => b - a));

            for (int i = 0; i < length - 2; i++)
            {
                if (nums[i] < nums[i + 1] + nums[i + 2])
                    return nums[i] + nums[i + 1] + nums[i + 2];
            }

            return 0;
        }
    }
}
