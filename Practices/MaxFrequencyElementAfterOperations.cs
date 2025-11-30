namespace Practices.Problems
{
    internal class MaxFrequencyElementAfterOperations
    {
        public int MaxFrequency(int[] nums, int k, int numOperations)
        {
            if (nums.Length == 0)
                return 0;
            Array.Sort(nums);
            int n = nums.Length;
            Dictionary<int, int> freq = new();
            foreach (int x in nums)
            {
                if (!freq.TryGetValue(x, out int value)) freq.Add(x, 1);
                else freq[x] = ++value;
            }

            int ans = 1;

            foreach (var e in freq.ToList())
            {
                int key = e.Key, val = e.Value;
                int low = key - k, high = key + k;

                int left = LowerBound(nums, low);
                int right = UpperBound(nums, high);

                int inRange = right - left;
                int visited = inRange - val;
                int minLoop = Math.Min(visited, numOperations);
                ans = Math.Max(ans, val + minLoop);
            }

            int l = 0;
            for (int r = 0; r < n; r++)
            {
                while (l <= r && nums[r] - nums[l] > 2 * k) l++;
                int w = r - l + 1;
                ans = Math.Max(ans, Math.Min(w, numOperations));
            }
            return ans;
        }

        private int LowerBound(int[] a, int target)
        {
            int l = 0, r = a.Length;
            while (l < r)
            {
                int m = (l + r) >>> 1;
                if (a[m] < target) l = m + 1; else r = m;
            }
            return l;
        }


        private int UpperBound(int[] a, int target)
        {
            int l = 0, r = a.Length;
            while (l < r)
            {
                int m = (l + r) >>> 1;
                if (a[m] <= target) l = m + 1; else r = m;
            }
            return l;
        }
    }
}
