using System.Text;

namespace Practices.Problems
{
    internal class CheckDigitsEqualAfterOperations
    {
        public bool HasSameDigits(string s)
        {
            var builder = new StringBuilder(s);

            while (builder.Length > 2)
            {
                var newString = builder.ToString();
                builder.Clear();
                for (int i = 0; i < newString.Length - 1; i++)
                {
                    int sum = (newString[i] + newString[i + 1]) - 2 * '0';
                    builder.Append(sum % 10);
                }
            }

            return builder.Length == 2 && builder[0] == builder[1];
        }
    }
}
