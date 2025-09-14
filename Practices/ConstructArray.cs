namespace Practices
{
    internal static class ConstructArray
    {
        public static long Solve(int n, int k, int x)
        {
            long[] dp = new long[n + 1];

            for (int i = 1; i <= n; i++)
            {
                dp[i] = i == 1 || i == n ? 1 : -1;
            }

            long possibilities = 0;
            // From 2 -> n-1
            for (int i = 2; i <= n - 1; i++)
            {
                dp[i] = ((k - x) * (dp[i - 1] - dp[i + 1]));// + MOD);// % MOD;
                possibilities += dp[i];
            }
            return possibilities;
        }
    }
}
