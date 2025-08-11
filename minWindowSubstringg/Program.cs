using System;

class Program
{
    static void Main()
    {
            
    }

    public String minWindow(string s, string t)
    {
        if (t.Length > s.Length || t.Length == 0)
            return "";

        Dictionary<char, int> tCount = new Dictionary<char, int>();
        Dictionary<char, int> window = new Dictionary<char, int>();

        foreach (char c in t)
            tCount[c] = tCount.GetValueOrDefault(c, 0) + 1;

        int have = 0;
        int need = tCount.Count;

        int resLen = int.MaxValue;
        int[] res = new int[2] { -1, -1 };

        int l = 0;

        for (int r = 0; r < s.Length; r++)
        {
            char cAdd = s[r];
            window[cAdd] = window.GetValueOrDefault(cAdd, 0) + 1;

            if (tCount.ContainsKey(cAdd) && tCount[cAdd] == window[cAdd])
                have++;

            while (have == need)
            {
                char cRem = s[l];
                window[cRem]--;

                if (tCount.ContainsKey(cRem) && tCount[cRem] > window[cRem])
                    have--;

                if (r - l + 1 < resLen)
                {
                    res = new int[] { l, r };
                    resLen = r - l + 1;
                }

                l++;
            }
        }

        if (resLen == int.MaxValue)
            return "";

        int lenght = res[1] - res[0] + 1;

        return s.Substring(res[0], lenght);
    }
}