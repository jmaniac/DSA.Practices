namespace Practices.Problems
{
    internal class ContainerWithMostWater
    {
        public int MaxArea(int[] height)
        {
            int maxArea = 0;

            for (int left = 0, right = height.Length - 1; left < right;)
            {
                int currentArea = Math.Min(height[left], height[right]) * (right - left);
                maxArea = Math.Max(maxArea, currentArea);
                if (height[left] < height[right])
                    left++;
                else
                    right--;
            }

            return maxArea;
        }
    }
}
