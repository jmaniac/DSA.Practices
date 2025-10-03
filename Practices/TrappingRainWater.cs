namespace Practices.Problems
{
    public class TrappingRainWater
    {
        public int TrapRainWater(int[][] heightMap)
        {
            // Direction arrays
            int[] dRow = { 0, 0, -1, 1 };
            int[] dCol = { -1, 1, 0, 0 };

            int numOfRows = heightMap.Length;
            int numOfCols = heightMap[0].Length;

            bool[][] visited = new bool[numOfRows][];

            // Priority queue (min-heap) to process boundary cells in increasing height order
            PriorityQueue<Cell, int> boundary = new PriorityQueue<Cell, int>();

            // Add the first and last column cells to the boundary and mark them as visited
            for (int i = 0; i < numOfRows; i++)
            {
                visited[i] = new bool[numOfCols];
                boundary.Enqueue(new Cell(heightMap[i][0], i, 0), heightMap[i][0]);
                boundary.Enqueue(new Cell(heightMap[i][numOfCols - 1], i, numOfCols - 1), heightMap[i][numOfCols - 1]);
                // Mark left and right boundary cells as visited
                visited[i][0] = visited[i][numOfCols - 1] = true;
            }

            // Add the first and last row cells to the boundary and mark them as visited
            for (int i = 0; i < numOfCols; i++)
            {
                boundary.Enqueue(new Cell(heightMap[0][i], 0, i), heightMap[0][i]);
                boundary.Enqueue(new Cell(heightMap[numOfRows - 1][i], numOfRows - 1, i), heightMap[numOfRows - 1][i]);
                // Mark top and bottom boundary cells as visited
                visited[0][i] = visited[numOfRows - 1][i] = true;
            }

            // Initialize the total water volume to 0
            int totalWaterVolume = 0;

            // Process cells in the boundary (min-heap will always pop the smallest height)
            while (boundary.Count > 0)
            {
                // Pop the cell with the smallest height from the boundary
                Cell currentCell = boundary.Dequeue();

                int currentRow = currentCell.Row;
                int currentCol = currentCell.Col;
                int minBoundaryHeight = currentCell.Height;

                // Explore all 4 neighboring cells
                for (int direction = 0; direction < 4; direction++)
                {
                    // Calculate the row and column of the neighbor
                    int neighborRow = currentRow + dRow[direction];
                    int neighborCol = currentCol + dCol[direction];

                    // Check if the neighbor is within the grid bounds and not yet visited
                    if (
                        IsValidCell(
                            neighborRow,
                            neighborCol,
                            numOfRows,
                            numOfCols
                        ) &&
                        !visited[neighborRow][neighborCol]
                    )
                    {
                        // Get the height of the neighbor cell
                        int neighborHeight = heightMap[neighborRow][neighborCol];

                        // If the neighbor's height is less than the current boundary height, water can be trapped
                        if (neighborHeight < minBoundaryHeight)
                        {
                            // Add the trapped water volume
                            totalWaterVolume += minBoundaryHeight - neighborHeight;
                        }

                        // Push the neighbor into the boundary with updated height (to prevent water leakage)
                        int h = Math.Max(neighborHeight, minBoundaryHeight);
                        boundary.Enqueue(
                            new Cell(
                                h,
                                neighborRow,
                                neighborCol
                            ),
                            h
                        );
                        visited[neighborRow][neighborCol] = true;
                    }
                }
            }

            // Return the total amount of trapped water
            return totalWaterVolume;
        }

        // Class to store the height and coordinates of a cell in the grid
        class Cell : IComparable<Cell>
        {
            public int Height { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }

            // Constructor to initialize a cell
            public Cell(int height, int row, int col)
            {
                this.Height = height;
                this.Row = row;
                this.Col = col;
            }

            // Overload the compareTo method to make the priority queue a min-heap based on height
            public int CompareTo(Cell other)
            {
                // Min-heap comparison
                return this.Height - other.Height;
            }
        }

        // Helper function to check if a cell is valid (within grid bounds)
        private bool IsValidCell(
            int row,
            int col,
            int numOfRows,
            int numOfCols
        )
        {
            return row >= 0 && col >= 0 && row < numOfRows && col < numOfCols;
        }
    }
}
