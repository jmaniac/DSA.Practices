namespace Practices
{
    internal static class EqualDistribution
    {
        public static int Solve(List<int> arr)
        {
            int ans = int.MaxValue;
            int minElement = arr.Min(x => x);

            //for (int count = 0; count < 3; count++)
            {
                int temp = 0;

                for (int i = 0; i < arr.Count; i++)
                {
                    int diff = arr[i] - (minElement);
                    int steps = diff / 5 + (diff % 5) / 2 + (diff % 5) % 2;
                    temp += steps;
                }
                ans = Math.Min(ans, temp);
            }
            return ans;
        }
    }
}
