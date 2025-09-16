namespace Practices.Problems
{
    internal static class ReplaceNonCoprimes
    {
        public static IList<int> Solve(int[] nums)
        {
            //var result = new List<int>(nums);

            //for (int i = 0; i < nums.Length - 1; i++)
            //{
            //    if (IsNonCoPrime(nums[i], nums[i + 1]))
            //    {
            //        int lcm = LCM(nums[i], nums[i + 1]);
            //        nums[i + 1] = lcm;
            //        nums[i] = 0;
            //        //result.Add(lcm);
            //    }
            //}

            List<int> result = new List<int>();

            foreach (var x in nums)
            {
                int current = x;

                while (result.Count > 0)
                {
                    int popped = result[result.Count - 1];
                    int gcd = GCD(popped, current);
                    if (gcd == 1) break;
                    result.RemoveAt(result.Count - 1);
                    current = LCM(popped, current);
                }
                result.Add(current);
            }

            return result;
        }

        public static IList<int> Reduce(IList<int> nums)
        {
            for (int i = 0; i < nums.Count - 1; i++)
            {
                if (IsNonCoPrime(nums[i], nums[i + 1]))
                {
                    int lcm = LCM(nums[i], nums[i + 1]);
                    nums[i + 1] = lcm;
                    nums[i] = 0;
                }
            }

            nums = nums.Where(x => x > 0).ToArray();

            return !CanReduce(nums) ? nums : Reduce(nums);
        }

        public static bool CanReduce(IList<int> nums)
        {
            int lcmSum = 0;
            for (int i = 0; i < nums.Count - 1; i++)
            {
                lcmSum += GCD(nums[i], nums[i + 1]);
            }

            return lcmSum != nums.Count - 1;
        }

        private static bool IsNonCoPrime(int x, int y)
        {
            return (x % 2 == 0 && y % 2 == 0) || GCD(x, y) != 1;
        }

        private static int LCM(int x, int y)
        {
            return x == y ? x : (int)(((long)x * (long)y) / GCD(x, y));
        }

        private static int GCD(int x, int y)
        {
            int m = x, n = y, r;

            while (n != 0)
            {
                r = m % n;
                m = n;
                n = r;
            }
            return m;
        }
    }
}
