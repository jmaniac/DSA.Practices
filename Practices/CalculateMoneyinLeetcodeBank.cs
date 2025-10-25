namespace Practices.Problems
{
    internal class CalculateMoneyinLeetcodeBank
    {
        public int TotalMoney(int n)
        {
            int total = 0, nDays = 7;
            for (int i = 1; i <= n; i++)
            {
                int rem = i % nDays, q = i / nDays;
                total += (q + (rem == 0 ? nDays - 1 : rem));
            }
            return total;
        }
    }
}
