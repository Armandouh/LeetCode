using System;
using System.Collections;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using Microsoft.VisualBasic;

class Program
{
    static void Main()
    {
        string[] strs = { "eat", "tea", "tank", "natk", "sex", "esx" };
        var anagrams = anagramGroups(strs);
        foreach (var group in anagrams)
        {
            Console.WriteLine(string.Join(',', group));
        }
    }

    static IList<IList<string>> anagramGroups(string[] strs)
    {
        var groups = new Dictionary<string, IList<string>>();

        foreach (string str in strs)
        {
            int[] count = new int[26];

            foreach (char c in str)
            {
                count[c - 'a']++;
            }

            var sb = new StringBuilder();

            foreach (int n in count)
            {
                sb.Append('-');
                sb.Append(n);
            }

            var charCountStr = sb.ToString();

            if (!groups.ContainsKey(charCountStr))
                groups[charCountStr] = new List<string>();

            groups[charCountStr].Add(str);
        }

        return groups.Values.ToList();
    }
}