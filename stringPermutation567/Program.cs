using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

class Program
{
    static void Main()
    {
        string s1 = "ab";
        string s2 = "eidbaooo";

        Console.WriteLine(checkInclusion(s1, s2));
    }

    static public bool checkInclusion(string s1, string s2)
    {
        if (s1.Length > s2.Length)
            return false;

        int[] s1Count = new int[26];
        int[] s2Count = new int[26];

        for (int i = 0; i < s1.Length; i++)
        {
            s1Count[s1[i] - 'a']++;
            s2Count[s2[i] - 'a']++;
        }

        int matches = 0;
        int l = 0;

        for (int i = 0; i < s1Count.Length; i++)
        {
            if (s1Count[i] == s2Count[i])
                matches++;
        }

        for (int r = s1.Length; r < s2.Length; r++)
        {
            if (matches == 26)
                return true;

            int indexAdd = s2[r] - 'a';
            s2Count[indexAdd]++;
            if (s2Count[indexAdd] == s1Count[indexAdd] + 1)
                matches--;
            else if (s2Count[indexAdd] == s1Count[indexAdd])
                matches++;

            int indexRemove = s2[l] - 'a';
            s2Count[indexRemove]--;
            if (s2Count[indexRemove] == s1Count[indexRemove] - 1)
                matches--;
            else if (s2Count[indexRemove] == s1Count[indexRemove])
                matches++;

            l++;
        }

        return matches == 26;
    }
}