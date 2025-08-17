using System;
using System.Xml;

class Program
{
    static void Main()
    {
        //int[] arr = { 3, 6, 7, 11 };
        //Console.WriteLine(minEatingSpeed(arr, 8));

        int[] piles = { 30, 11, 23, 4, 20 };
        Console.WriteLine(minEatingSpeed(piles, 5));
        
        //int[] piles2 = { 30, 11, 23, 4, 20 };
        //Console.WriteLine(minEatingSpeed(piles2, 6));
    }

    public static int minEatingSpeed(int[] piles, int h)
    {
        int k = 1;

        int l = 1;
        int r = piles.Max();

        while (l <= r)
        {
            int m = (l + r) / 2;
            if (canEat(piles, h, m))
            {
                k = m;
                r = m - 1;
            }
            else
            {
                l = m + 1;
            }
        }

        return k;
    }

    public static bool canEat(int[] piles, int h, int k)
    {
        double total = 0;
        foreach (int n in piles)
        {
            double hour = (double)n / k;
            double rounded = Math.Ceiling(hour);
            total += rounded;
        }

        return total <= h;
    }
}