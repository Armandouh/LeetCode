using System;
using System.Collections;
using System.Collections.ObjectModel;
using Microsoft.VisualBasic;

class Program
{
    static void Main()
    {
        string s = "pwweke";
        Console.WriteLine(LongestWithoutRepeatingChar(s));

    }

    public static int LongestWithoutRepeatingChar(string s)
    {
        int result = 0;
        HashSet<int> numSet = new HashSet<int>();

        int l = 0;
        for (int r = 0; r < s.Length; r++)
        {
            while (numSet.Contains(s[r]))
            {
                numSet.Remove(s[l]);
                l++;
            }

            numSet.Add(s[r]);
            result = Math.Max(result, r - l + 1);
        }

        return result;
    }
}