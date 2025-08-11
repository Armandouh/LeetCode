using System;

class Program
{
    static void Main()
    {
        string s = "ACCB";
        int k = 2;
        Console.WriteLine(CharacterReplacement(s, k));
    }

    static public int CharacterReplacement(string s, int k)
    {
        int l = 0;
        int r = 0;
        Dictionary<char, int> map = new Dictionary<char, int>();
        int maxFreq = 0;
        int result = 0;
        
        while (r < s.Length)
        {
            map[s[r]] = map.GetValueOrDefault(s[r], 0) + 1;
            maxFreq = Math.Max(maxFreq, map[s[r]]);
            
            if (r - l + 1 - maxFreq > k)
            {
                map[s[l]]--;
                l++;
            }

            int length = r - l + 1;
            result = Math.Max(length, result);
            r++;
        }

        return result;
    }
}