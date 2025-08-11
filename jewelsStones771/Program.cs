using System;

class Program
{
    static void Main()
    {
        string jewels = "aA";
        string stones = "aAAbbbb";

        Console.WriteLine(jewelStones(jewels, stones));

    }

    static int jewelStones(string jewels, string stones)
    {
        Dictionary<char, int> map = new Dictionary<char, int>();
        int output = 0;

        foreach (char i in jewels)
        {
            map.Add(i, i);
        }

        foreach (char x in stones)
        {
            if (map.ContainsKey(x))
            {
                output++;
            }
        }

        return output;
    }
}