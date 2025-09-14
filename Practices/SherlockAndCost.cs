namespace Practices
{
    internal static class SherlockAndCost
    {
        public static int Solve(List<int> B)
        {
            int count = B.Count;
            int[] dp = new int[2];

            for (int i = 1; i < count; i++)
            {
                int previousDp0 = dp[0], previousDp1 = dp[1];

                // This is possibility of Taking the lowest previous number and highest current number
                dp[0] = Math.Max(previousDp0, previousDp1 + Math.Abs(1 - B[i - 1]));
                // This is the possibility of Taking the as is vs the lowest next number and highest current number
                dp[1] = Math.Max(previousDp0 + Math.Abs(B[i] - 1), previousDp1 + Math.Abs(B[i] - B[i - 1]));

            }

            return Math.Max(dp[0], dp[1]);
        }
    }
}
