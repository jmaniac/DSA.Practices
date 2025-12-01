namespace Practices.Problems
{
    internal class CountPathsWithGivenXORValue
    {
        public int CountPathsWithXorValue(int[][] grid, int k)
        {
            int n = grid.Length, m = grid[0].Length;
            int[][][] dp = new int[n][][];

            // Initialize DP array with -1
            for (int i = 0; i < dp.Length; i++)
            {
                dp[i] = new int[m][];
                for (int j = 0; j < dp[i].Length; j++)
                {
                    dp[i][j] = new int[16];
                    Array.Fill(dp[i][j], -1);
                }
            }

            return DFS(grid, k, 0, 0, 0, dp) % MOD;
        }

        private const int MOD = (int)1e9 + 7;

        private int DFS(int[][] grid, int k, int i, int j, int xr, int[][][] dp)
        {
            int n = grid.Length, m = grid[0].Length;

            // Base case: out of bounds
            if (i >= n || j >= m) return 0;

            // Base case: reached the last cell
            if (i == n - 1 && j == m - 1)
            {
                return (xr ^ grid[i][j]) == k ? 1 : 0;
            }

            // If already computed, return cached value
            if (dp[i][j][xr] != -1) return dp[i][j][xr];

            // Recursive calls: move right and down
            int right = DFS(grid, k, i, j + 1, xr ^ grid[i][j], dp) % MOD;
            int down = DFS(grid, k, i + 1, j, xr ^ grid[i][j], dp) % MOD;

            // Store and return the result
            return dp[i][j][xr] = (right + down) % MOD;
        }
    }
}
