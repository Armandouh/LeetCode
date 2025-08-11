using System;
using System.Reflection;

class Program
{
    static void Main()
    {
        string s = "aaa";
        Console.WriteLine(CountSubstrings(s));
    }

    static int CountSubstrings(string s)
    {
        int result = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int l = i;
            int r = i;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
                result++;
            }

            l = i;
            r = i + 1;
            while (l >= 0 && r < s.Length && s[l] == s[r])
            {
                l--;
                r++;
                result++;
            }
        }

        return result;
    }
}