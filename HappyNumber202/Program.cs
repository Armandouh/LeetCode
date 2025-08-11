using System;

class Program
{
    static void Main()
    {
        int n = 19;
        Console.WriteLine(selfSumOfSquare(n));
        Console.WriteLine(happyNumber(n));
    }

    static bool happyNumber(int n)
    {
        HashSet<int> visited = new HashSet<int>();
        while (!visited.Contains(n))
        {
            visited.Add(n);
            n = selfSumOfSquare(n);
            if (n == 1)
                return true;
        }
        
        return false;
    }

    static int selfSumOfSquare(int n)
    {
        int result = 0;

        while (n != 0)
        {
            int digit = n % 10;
            int square = digit * digit;
            result += square;
            n /= 10;
        }

        return result;
    }
}