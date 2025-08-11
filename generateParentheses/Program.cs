using System;

class Program
{
    static void Main()
    {
    }

    public static IList<string> GenerateParenthesis(int n)
    {
        List<string> result = new List<string>();
        Backtrack(result, "", 0, 0, n);
        return result;
    }

    public static void Backtrack(IList<string> result, string current, int open, int close, int max)
    {
        if (open == max && close == max)
        {
            result.Add(current);
            return;
        }

        if (open < max)
        {
            Backtrack(result, current + "(", open + 1, close, max);
        }

        if (close < open)
        {
            Backtrack(result, current + ")", open, close + 1, max);
        }
    }
}