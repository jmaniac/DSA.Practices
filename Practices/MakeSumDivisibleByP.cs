namespace Practices.Problems
{
    public class MakeSumDivisibleByP
    {
        public int MinSubarray(int[] nums, int p)
        {
            long total = nums.Sum();
            int need = (int)(total % p);
            if (need == 0) return 0;

            var prefixLookup = new Dictionary<int, int>();
            prefixLookup[0] = -1;

            long prefix = 0;
            int result = nums.Length;

            for (int i = 1; i < nums.Length; i++)
            {
                prefix = (prefix + nums[i]) % p;
                int target = (int)(prefix - need + p) % p;
                if (prefixLookup.TryGetValue(target, out int value))
                {
                    result = Math.Min(result, i - value);
                }
                prefixLookup[(int)prefix] = i;
            }

            return result == nums.Length ? -1 : result;
        }
    }
}
