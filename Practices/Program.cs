namespace Practices
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // MincashFlow
            int[][] transaction = new int[][] {
                                                new int[] {0, 1000, 2000},
                                                new int[] {0, 0, 5000},
                                                new int[] {0, 0, 0}
                                    };

            var result = MinimalCashFlow.Solve(transaction);

            Console.WriteLine(result);

            // Divide Choclate
            Console.WriteLine(DivideChoclate.Solve(10, 10, 1, 2));
            //Console.WriteLine(DivideChoclate.Solve(10, 10, 1, 1));
            //Console.WriteLine(DivideChoclate.Solve(10, 10, 3, 5));


            // Coins Change
            Console.WriteLine(CoinChange.Solve(3, [8, 3, 1, 2]));

            // Equal Distribution
            Console.WriteLine(EqualDistribution.Solve([2, 2, 3, 7]));

            // Sherlock and Cost
            //Console.WriteLine(SherlockAndCost.Solve([100, 2, 100, 2, 100]));
            Console.WriteLine(SherlockAndCost.Solve([4, 7, 9]));

            // Construct Array
            Console.WriteLine(ConstructArray.Solve(761, 99, 1));

            // Sum of Most frequent Vowel and Consonant
            Console.WriteLine(MostFrequentVowelConsonant.Solve("aeiaeia"));

            // Vowel Spell Checker
            VowelSpellchecker.Solve(["KiTe", "kite", "hare", "Hare"], ["kite", "Kite", "KiTe", "Hare", "HARE", "Hear", "hear", "keti", "keet", "keto"]);


            // Exit
            Console.ReadKey();
        }
    }
}
