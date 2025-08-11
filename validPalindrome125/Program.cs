using System;
using Microsoft.VisualBasic;

class Program   
{
    static void Main()
    {
        string s1 = "Mom.";
        Console.WriteLine(isPalindrome(s1));
    }

    static bool isPalindrome(string s)
    {
        s = s.ToLower();
        int i = 0;
        int j = s.Length - 1;

        while (i < j)
        {
            while (i < j && !char.IsLetterOrDigit(s[i]) )
            {
                i++;
            }
            
            while (j > i && !char.IsLetterOrDigit(s[j]))
            {
                j--;
            }

            if (s[i] != s[j])
                return false;
            i++;
            j--;
        }

        return true;
    }
}