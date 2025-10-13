namespace Practices.Problems
{
    public class RemovingAdjacentAnagrams
    {
        public IList<string> RemoveAnagrams(string[] words)
        {
            IList<string> result = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                if (i == 0 || (words[i].Length == words[i - 1].Length && AreAnagrams(words[i], words[i - 1])))
                {
                    result.Add(words[i]);
                }
            }
            return result;
        }

        private bool AreAnagrams(string word1, string word2)
        {
            int[] freq = new int[26];
            foreach (char ch in word1)
            {
                freq[ch - 'a']++;
            }
            foreach (char ch in word2)
            {
                freq[ch - 'a']--;
            }
            foreach (int x in freq)
            {
                if (x != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
