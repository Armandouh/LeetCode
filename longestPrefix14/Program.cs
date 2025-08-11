using System;
using System.Text;

class Program
{
    static void Main()
    {
        String[] sheeeeseh = { "Gor", "Garik", "Grno" };
        string result = LongestPref(sheeeeseh);

        Console.WriteLine(result);
    }

    static String LongestPref(string[] arr)
    {
        StringBuilder result = new StringBuilder();

        Array.Sort(arr);

        char[] first = arr[0].ToCharArray();
        char[] last = arr[arr.Length - 1].ToCharArray();

        for (int i = 0; i <= first.Length - 1; i++)
        {
            if (first[i] != last[i])
            {
                break;
            }
            else
            {
                result.Append(first[i]);
            }
        }

        return result.ToString();
    }
}