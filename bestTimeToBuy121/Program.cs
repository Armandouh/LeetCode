using System;

class Program
{
    static void Main()
    {
        int[] prices = [7, 1, 6, 3, 4];
        Console.WriteLine(MaxProfit(prices));
    }

    static int MaxProfit(int[] prices)
    {
        int maxProfit = 0;
        int l = 0;
        int r = 1;

        while (r < prices.Length)
        {
            if (prices[l] < prices[r])
            {
                int profit = prices[r] - prices[l];
                maxProfit = Math.Max(maxProfit, profit);
            }
            else
                l = r;

            r++;
        }

        if (maxProfit <= 0)
            return 0;
        
        return maxProfit;
    }
}   