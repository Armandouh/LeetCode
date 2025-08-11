using System;

class Program
{
    static void Main()
    {
        string s = "anagram";
        string t = "nagaram";

        Console.WriteLine(isAnagram(s, t));
    }

    static bool isAnagram(string s, string t)
    {
        Dictionary<char, int> mapS = new Dictionary<char, int>();
        Dictionary<char, int> mapT = new Dictionary<char, int>();

        foreach (char c in s)
        {
            mapS[c] = mapS.GetValueOrDefault(c, 0) + 1;
        }

        foreach (char c in t)
        {
            mapT[c] = mapT.GetValueOrDefault(c, 0) + 1;
        }

        foreach (char c in mapS.Keys)
        {
            if (mapS[c] != mapT.GetValueOrDefault(c, 0))
                return false;
        }

        return true;
    }
}