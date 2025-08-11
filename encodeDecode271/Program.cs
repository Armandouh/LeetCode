using System;
using System.Text;

public class Solution {
    static public void Main()
    {
        IList<string> bebo = ["Arman", "luv", "Vera"];
        string encoded = Encode(bebo);
        Console.WriteLine(encoded);
        List<string> decoded = new List<string>();
        decoded = Decode(encoded);
        foreach (var item in decoded)
        {
            Console.WriteLine(item);
        }
    }

    public static string Encode(IList<string> strs)
    {
        StringBuilder encoded = new StringBuilder();

        foreach (var item in strs)
        {
            encoded.Append(item.Length);
            encoded.Append("#");
            encoded.Append(item);
        }

        return encoded.ToString();
    }

    public static List<string> Decode(string s)
    {
        List<string> decoded = new List<string>();
        int i = 0;
        while (i < s.Length)
        {
            int j = i + 1;
            while (j < s.Length && s[j] != '#')
            {
                j++;
            }

            if (s[j] == '#')
            {
                int length = int.Parse(s.Substring(i, j - i));
                decoded.Add(s.Substring(j + 1, length));
                i = j + length + 1;
            }
        }

        return decoded;
    }
}
