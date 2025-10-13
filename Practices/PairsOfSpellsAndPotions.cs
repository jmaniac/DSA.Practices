namespace Practices.Problems
{
    internal class PairsOfSpellsAndPotions
    {
        public int[] SuccessfulPairs(int[] spells, int[] potions, long success)
        {
            int[] sucessPairs = new int[spells.Length];
            Array.Sort(potions);

            for (int i = 0; i < spells.Length; i++)
            {
                sucessPairs[i] = potions.Length - BinarySearch(potions, spells[i], success);
            }
            return sucessPairs;
        }

        private int BinarySearch(int[] potions, long spell, long success)
        {
            var left = 0;
            var right = potions.Length;

            while (left < right)
            {
                var mid = left + (right - left) / 2;

                if (potions[mid] * spell >= success)
                    right = mid;
                else
                    left = mid + 1;
            }
            return left;
        }
    }
}
