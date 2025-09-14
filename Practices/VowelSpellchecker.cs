namespace Practices
{
    internal static class VowelSpellchecker
    {
        public static string[] Solve(string[] wordlist, string[] queries)
        {
            var exactWords = new HashSet<string>(wordlist);
            var lowerCasedMap = new Dictionary<string, string>();
            var deVoweledMap = new Dictionary<string, string>();

            foreach (var word in wordlist)
            {
                var lower = word.ToLower();
                var devoweled = DeVowel(word);

                if (!lowerCasedMap.ContainsKey(lower))
                    lowerCasedMap.Add(lower, word);
                if (!deVoweledMap.ContainsKey(devoweled))
                    deVoweledMap.Add(devoweled, word);
            }

            List<string> correctOnes = new();

            foreach (var query in queries)
            {
                if (exactWords.Contains(query))
                {
                    correctOnes.Add(query);
                }
                else
                {
                    string lower = query.ToLower();
                    string devoweled = DeVowel(query);

                    if (lowerCasedMap.TryGetValue(lower, out string matchedLower))
                    {
                        correctOnes.Add(matchedLower);
                    }
                    else if (deVoweledMap.TryGetValue(devoweled, out string matchedDevoweled))
                    {
                        correctOnes.Add(matchedDevoweled);
                    }
                    else
                    {
                        correctOnes.Add(string.Empty);
                    }

                }

            }

            return correctOnes.ToArray();
        }

        private static bool IsVowel(char c)
        {
            return c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u';
        }

        private static string DeVowel(string s)
        {
            var result = s.ToCharArray();
            for (int i = 0; i < s.Length; i++)
            {
                if (IsVowel(s[i]))
                {
                    result[i] = '*';
                }
            }

            return new string(result);
        }
    }
}
