namespace Practices
{
    public static class DivideChoclate
    {
        public static int Solve(int length, int breadth, int cutLength, int cutBreadth)
        {
            int max = 1001;

            // Dynamic programming to save the wastage area when a part is cut
            int[,] dp = new int[max, max];
            //Init all to -1
            for (int i = 0; i < max; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    dp[i, j] = -1;
                }

            }

            // Store if this cut is valid
            // Where only x * y and y * x cuts are valid
            bool[,] cutValid = new bool[max, max];
            cutValid[cutLength, cutBreadth] = true;
            cutValid[cutBreadth, cutLength] = true;

            // For area of l x b 
            // Try vertical and horizontal cuts
            for (int l = 1; l <= length; l++)
            {
                for (int b = 1; b <= breadth; b++)
                {
                    // if the cut is valid there is no wastage
                    if (cutValid[l, b])
                    {
                        dp[l, b] = 0;
                        continue;
                    }

                    // If the cut fully is Invalid, the whole cuit part id Invalid
                    int cutArea = l * b;


                    // Horizontal Cuts
                    for (int i = 1; i < b; i++)
                    {
                        // The cut will be the min of this cutArea
                        // Area between this and previous 
                        cutArea = Math.Min(dp[l, i] + dp[l, b - i], cutArea);
                    }


                    // Vertical Cuts
                    for (int i = 1; i < l; i++)
                    {
                        // The cut will be the min of this cutArea
                        // Area between this and previous 
                        cutArea = Math.Min(dp[i, b] + dp[l - i, b], cutArea);
                    }

                    dp[l, b] = cutArea;

                }
            }

            return dp[length, breadth];
        }
    }
}
