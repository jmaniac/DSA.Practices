namespace Practices.Problems
{
    internal class ChampagneTower
    {
        public double Solve(int poured, int query_row, int query_glass)
        {
            var tower = new double[query_row][];

            for (int i = 0; i < query_row; i++)
            {
                tower[i] = new double[i + 1];
            }

            // Whatever poured will be in the first glass
            tower[0][0] = poured;

            // Excess will Overflow and distribute lower rows
            for (int row = 1; row < query_row; row++)
            {
                for (int glass = 0; glass < tower[row].Length; glass++)
                {
                    var excess = (tower[row][glass] - 1) / 2.0;
                    if (excess > 0)
                    {
                        tower[row + 1][glass] += excess;
                        tower[row + 1][glass + 1] += excess;
                    }
                }
            }

            return Math.Min(1.0, tower[query_row][query_glass]);
        }
    }
}
