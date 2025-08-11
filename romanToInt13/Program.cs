using System;

class Program
{
    static void Main()
    {
        String romanNum = "XXIV";
        int converted = RomanToInteger(romanNum);

        Console.WriteLine(converted);
    }

    private static Dictionary<char, int> RomanMap = new Dictionary<char, int>()
    {
        { 'I', 1 },
        { 'V', 5 },
        { 'X', 10 },
        { 'L', 50 },
        { 'C', 100 },
        { 'D', 500 },
        { 'M', 1000 }
    };

    public static int RomanToInteger(string roman)
    {
        int result = 0;
        for (int i = 0; i < roman.Length; i++)
        {
            if (i + 1 < roman.Length && RomanMap[roman[i + 1]] > RomanMap[roman[i]]) result -= RomanMap[roman[i]];

            else result += RomanMap[roman[i]];
        }

        return result;
    }
}