using Practices.Problems;
using Practises.Common.Extensions;

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


            // Replace Non-Coprime Numbers in Array
            //Console.WriteLine(ReplaceNonCoprimes.Solve([517, 11, 121, 517, 3, 51, 3, 1887, 5]).AsString());
            //Console.WriteLine(ReplaceNonCoprimes.Solve([31, 97561, 97561, 97561, 97561, 97561, 97561, 97561, 97561]).AsString());
            Console.WriteLine(ReplaceNonCoprimes.Solve([8303, 361, 8303, 361, 437, 361, 8303, 8303, 8303, 6859, 19, 19, 361, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 70121, 1271, 31, 961, 31, 7, 2009, 7, 2009, 2009, 49, 7, 7, 8897, 1519, 31, 1519, 217]).AsString());

            // Largest Area Triangle
            var largestArea = new LargestAreaTriangle().LargestTriangleArea([[1, 0], [0, 0], [0, 1]]);

            // Water Bottles
            var numWaterBottles = new WaterBottles().NumWaterBottles(9, 3);
            numWaterBottles = new WaterBottles().NumWaterBottles(15, 4);

            Console.WriteLine(new CheckDigitsEqualAfterOperations().HasSameDigits("3902"));

            // Exit
            Console.ReadKey();
        }
    }
}
