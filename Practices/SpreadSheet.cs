namespace Practices.Problems
{
    public class Spreadsheet
    {
        private readonly Dictionary<string, int> cells;
        public Spreadsheet(int rows)
        {
            cells = new Dictionary<string, int>();
            //for (int row = 1; row <= rows; row++)
            //{
            //    for (char column = 'A'; column <= 'Z'; column++)
            //    {
            //        cells.Add($"{column}{row}", 0);
            //    }
            //}
        }

        public void SetCell(string cell, int value)
        {
            cells[cell] = value;
        }

        public void ResetCell(string cell)
        {
            cells.Remove(cell);
        }

        public int GetValue(string formula)
        {
            int i = formula.IndexOf('+');
            string cell1 = formula[1..i];
            string cell2 = formula[(i + 1)..];

            int val1 = char.IsLetter(cell1[0]) ? cells.GetValueOrDefault(cell1)
                                           : int.Parse(cell1);
            int val2 = char.IsLetter(cell2[0]) ? cells.GetValueOrDefault(cell2)
                                           : int.Parse(cell2);
            return val1 + val2;
        }
    }
}
