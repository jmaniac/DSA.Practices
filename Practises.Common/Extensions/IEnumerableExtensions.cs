namespace Practises.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static string AsString(this IEnumerable<int> collection)
        {
            return string.Join(", ", collection);
        }
    }
}
