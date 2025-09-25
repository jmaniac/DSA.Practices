using System;
using System.Collections.Generic;
using System.Text;

namespace Practices.Problems
{
    internal class TriangleMinimumSum
    {
        public int MinimumTotal(IList<IList<int>> triangle)
        {
            int rowCount = triangle.Count;

            if (rowCount == 0) return 0;

            for (int row = 1; row < triangle.Count; row++)
            {
                for (int col = 0; col <= row; col++)
                {
                    if (col == 0)
                    {
                        triangle[row][col] += triangle[row - 1][col];
                    }
                    else if (col == row)
                    {
                        triangle[row][col] += triangle[row - 1][col - 1];
                    }
                    else
                    {
                        triangle[row][col] += Math.Min(triangle[row - 1][col], triangle[row - 1][col - 1]);
                    }
                }
            }

            return triangle.Last().Min();
        }
    }
}
