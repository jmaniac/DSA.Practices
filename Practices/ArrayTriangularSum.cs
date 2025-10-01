using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class ArrayTriangularSum
    {
        public int TriangularSum(int[] nums)
        {
            if (nums.Length == 1) return nums[0];

            int[] result = new int[nums.Length - 1];

            for (int i = 0; i < nums.Length -1; i++)
            {
                result[i] = (nums[i] + nums[i+1]) % 10;
            }

            return TriangularSum(result);
        }
    }
}
