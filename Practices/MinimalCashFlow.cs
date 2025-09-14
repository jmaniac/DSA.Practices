namespace Practices
{
    public static class MinimalCashFlow
    {
        public static int[][] Solve(int[][] cashflow)
        {
            int n = cashflow.Length;
            int[][] result = new int[n][];
            // Declare the Priority Queues for the debitors and creditors
            var debitors = new PriorityQueue<int, int>();
            var creditors = new PriorityQueue<int, int>();

            // Traverse through the given cash flow to fill the Queues
            for (int personId = 0; personId < cashflow.Length; personId++)
            {
                int netAmount = 0;
                // If i owes j then the representation will be cashFlow[i][j]
                // So any traverse on second dimensions for the crdits
                // Take all the Creditors
                // Add all incoming money
                for (int fromPerson = 0; fromPerson < n; fromPerson++)
                {
                    netAmount += cashflow[fromPerson][personId];
                }
                // Take all the Debits .. Outgoing money for the person
                for (int toPerson = 0; toPerson < n; toPerson++)
                {
                    netAmount -= cashflow[personId][toPerson];
                }

                if (netAmount < 0)
                {
                    // debitors.
                    debitors.Enqueue(personId, Math.Abs(netAmount));
                }

                if (netAmount > 0)
                {
                    creditors.Enqueue(personId, netAmount);
                }

            }

            // Init result
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            // Loop till all debitors settle theirs
            while (debitors.Count > 0)
            {
                debitors.TryDequeue(out int debitorId, out int debitAmount);
                creditors.TryDequeue(out int creditorId, out int creditAmount);

                int tranferAmount = Math.Min(creditAmount, debitAmount);

                result[debitorId][creditorId] = tranferAmount;

                debitAmount -= tranferAmount;
                creditAmount -= tranferAmount;

                if (debitAmount > 0)
                {
                    debitors.Enqueue(debitorId, debitAmount);
                }

                if (creditAmount > 0)
                {
                    creditors.Enqueue(creditorId, creditAmount);
                }

            }


            return result;
        }
    }
}
