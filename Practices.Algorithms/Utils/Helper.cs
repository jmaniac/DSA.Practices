namespace Practices.Algorithms.Utils
{
    public static class Helper
    {
        internal static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }
    }
}
