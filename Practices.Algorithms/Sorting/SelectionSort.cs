using Practices.Algorithms.Utils;

namespace Practices.Algorithms.Sorting
{
    public static class SelectionSort
    {
        public static void Sort(int[] array)
        {
            int length = array.Length;

            // Loop through all the Elements till Last but one
            for (int i = 0; i <= length - 2; i++)
            {
                // We are Selecting the right one for the place of i
                int min = i;
                for (int j = i + 1; j <= length - 1; j++)
                {
                    // If the jth element is lesser than the assumed minimum
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }
                // On each run, place the minimum of the i -> length at i
                Helper.Swap(ref array[i], ref array[min]);
            }
        }
    }
}
