using System;

class Program
{
    static void Main()
    {
        string str1 = "sandbutsad";
        string str2 = "sad";

        Console.WriteLine(StrStr(str1, str2));
    }

    static int StrStr(string haystack, string needle)
    {
        if (needle.Length == 0 || needle.Length > haystack.Length)
            return -1;

        for (int j = 0; j < haystack.Length - needle.Length + 1; j++)
        {
            int i = 0;
            while (haystack[j + i] == needle[i])
            {
                i++;
                if (i == needle.Length)
                {
                    return j;
                }
            }
        }

        return -1;
    }
}