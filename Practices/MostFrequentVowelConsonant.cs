namespace Practices
{
    internal static class MostFrequentVowelConsonant
    {
        public static int Solve(string s)
        {
            Dictionary<char, int> vowelFrequencies = new();
            Dictionary<char, int> consonantFrequencies = new();

            foreach (var c in s)
            {
                if (IsVowel(c))
                {
                    Increment(vowelFrequencies, c);
                }
                else
                {
                    Increment(consonantFrequencies, c);
                }

            }

            int vowelMax = vowelFrequencies.Count > 0 ? vowelFrequencies.Max(kv => kv.Value) : 0;
            int consanantMax = consonantFrequencies.Count > 0 ? consonantFrequencies.Max(kv => kv.Value) : 0;

            return vowelMax + consanantMax;
        }

        private static void Increment(Dictionary<char, int> freqCollection, char c)
        {
            if (freqCollection.ContainsKey(c))
            {
                freqCollection[c]++;
            }
            else
            {
                freqCollection.Add(c, 1);
            }
        }

        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

    }
}
