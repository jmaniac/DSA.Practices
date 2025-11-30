namespace Practices.Problems
{
    internal class SimpleBankSystem
    {
        private long[] accountBalance;

        public SimpleBankSystem(long[] balance)
        {
            accountBalance = balance;
        }

        public bool Transfer(int account1, int account2, long money)
        {
            if (account1 > accountBalance.Length || account2 > accountBalance.Length || accountBalance[account1 - 1] < money) return false;
            accountBalance[account1 - 1] -= money;
            accountBalance[account2 - 1] += money;
            return true;
        }

        public bool Deposit(int account, long money)
        {
            if (account > accountBalance.Length) return false;
            accountBalance[account - 1] += money;
            return true;
        }

        public bool Withdraw(int account, long money)
        {
            if (account > accountBalance.Length || accountBalance[account - 1] < money) return false;
            accountBalance[account - 1] -= money;
            return true;
        }
    }
}
