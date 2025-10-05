namespace Practices.Problems
{
    internal class PacificAtlanticWaterFlow
    {
        private readonly static int[] directionsX = [1, -1, 0, 0];
        private readonly static int[] directionsY = [0, 0, 1, -1];

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            HashSet<(int, int)> visited = [];

            List<IList<int>> ans = [];
            for (int i = 0; i < heights.Length; i++)
            {
                for (int j = 0; j < heights[i].Length; j++)
                {
                    visited.Clear();
                    var (Pacific, Atlantic) = Solve(i, j);
                    if (Pacific && Atlantic) ans.Add([i, j]);
                }
            }

            return ans;

            (bool Pacific, bool Atlantic) Solve(int row, int col, int? height = null)
            {
                // First Row and First Column => Pacific
                if (row < 0 || col < 0) return (true, false);

                // last Row and Last Coumn => Atlantic
                if (row >= heights.Length || col >= heights[row].Length) return (false, true);

                // Already visited or neighboring is heigher than the current
                if (visited.Contains((row, col)) || height != null && heights[row][col] > height.Value) return (false, false);

                visited.Add((row, col));
                bool flowsToPacific = false, flowsToAtlantic = false;
                for (int t = 0; t < 4; t++)
                {
                    int nextRow = row + directionsX[t], nextCol = col + directionsY[t];
                    var (tp, ta) = Solve(nextRow, nextCol, heights[row][col]);
                    flowsToPacific = flowsToPacific || tp; flowsToAtlantic = flowsToAtlantic || ta;
                }


                return (flowsToPacific, flowsToAtlantic);
            }
        }
    }
}
