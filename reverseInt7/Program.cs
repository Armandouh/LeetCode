using System;

class Program
{
    static void Main()
    {
        int a = -321;
        Console.WriteLine(reverseInt(a));
    }

    static int reverseInt(int x)
    {
        int result = 0;
        int remainder = 0;

        while (x != 0)
        {
            remainder = x % 10;
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && remainder > 7))
                return 0;

            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && remainder < -8))
                return 0;
            result *= 10;
            result += remainder;
            x /= 10;
        }

        return result;
    }
}