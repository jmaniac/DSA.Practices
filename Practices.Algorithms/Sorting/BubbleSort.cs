using Practices.Algorithms.Utils;

namespace Practices.Algorithms.Sorting
{
    public static class BubbleSort
    {
        public static void Sort(int[] array)
        {
            int length = array.Length;

            // Loop through all the Elements till Last but one
            for (int i = 0; i <= length - 2; i++)
            {
                for (int j = 0; j <= length - 2 - i; j++)
                {
                    if (array[j + 1] < array[j])
                    {
                        Helper.Swap(ref array[j], ref array[j + 1]);
                    }
                }
            }
        }
    }
}
