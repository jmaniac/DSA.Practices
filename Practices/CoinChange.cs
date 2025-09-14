namespace Practices
{
    internal static class CoinChange
    {
        public static long Solve(int target, List<long> coins)
        {
            // Init the DP for the storing the Values       
            long[] dp = new long[target + 1];

            // Ways to change the denaominations to get 0 amount is 1 
            dp[0] = 1;

            // For all Denominations
            foreach (int c in coins)
            {
                // Loop from denomination till Target 
                // Keep this in hand :)
                for (int j = c; j <= target; j++)
                {
                    // If denomination is greater than what you have in hand
                    if (j >= c)
                    {
                        // The ways to chnage is the sum of way that you can chnage the coin in hand 
                        // And the ways for remaining amount
                        // way to change for 10 = ways to change by 1 + ways to change by 9
                        dp[j] = dp[j] + dp[j - c];
                    }
                }
            }
            return dp[target];
        }
    }
}
