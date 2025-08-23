using System;

class Program
{
    static void Main()
    {
        string s = "ABOBECODEBANC";
        string t = "ABC";
        Console.WriteLine($"The min substring: {minWindow(s, t)}");
    }

    public static String minWindow(string s, string t)
    {
        if (s.Length == 0 || t.Length > s.Length)
            return "";

        Dictionary<char, int> tCount = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();

        for (int i = 0; i < t.Length; i++)
            tCount[t[i]] = tCount.GetValueOrDefault(t[i], 0) + 1;

        int have = 0;
        int need = tCount.Count;
        int length = int.MaxValue;
        int l = 0;
        int r = 0;
        int[] result = new int[] { -1, -1 };
        while (r < s.Length)
        {
            window[s[r]] = window.GetValueOrDefault(s[r], 0) + 1;

            if (tCount.ContainsKey(s[r]) && tCount[s[r]] == window[s[r]])
                have++;

            while (have == need)
            {
                int current = r - l + 1;
                if (current < length)
                {
                    result = new int[] { l, r };
                    length = current;
                }
                
                char cRem = s[l];
                window[cRem]--;

                if (tCount.ContainsKey(cRem) && tCount[cRem] > window[cRem])
                    have--;
                l++;
            }

            r++;
        }

        return length == int.MaxValue ? "" : s.Substring(result[0], result[1] - result[0] + 1);
    }
}