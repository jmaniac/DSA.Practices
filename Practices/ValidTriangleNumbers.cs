using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class ValidTriangleNumbers
    {
        public int TriangleNumber(int[] nums)
        {
            int length = nums.Length, triangleCount =0;

            if (length < 3) return 0;
            
            Array.Sort(nums);

            for (int i = 0; i < length - 2; i++)
            {
                // We are taking two elements
                int k = i + 2;
                if (nums[i] == 0) continue;
                for (int j = i+1; j < length - 1; j++)
                {
                    k = BinarySearch(nums, k, length - 1, nums[i] + nums[j]);
                    triangleCount += k - j - 1;
                }
            }

            return triangleCount;
        }

        public int BinarySearch(int[] nums, int left, int right, int searchTerm)
        {
            while (left <= right && right < nums.Length)
            {
                int mid = (left + right) / 2;
                if (nums[mid] >= searchTerm)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
