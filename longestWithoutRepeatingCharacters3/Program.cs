using System;

class Program
{
    static void Main()
    {
        string s = "abcabcaa";
        Console.WriteLine(lengthOfLongestSubstring(s));
    }

    static int lengthOfLongestSubstring(string s)
    {
        int maxLen = 0;
        HashSet<int> charSet = new HashSet<int>();

        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            while (charSet.Contains(s[r]))
            {
                charSet.Remove(s[l]);
                l++;
            }

            charSet.Add(s[r]);
            maxLen = Math.Max(maxLen, r - l + 1);
        }

        return maxLen;
    }
}