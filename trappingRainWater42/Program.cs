using System;

class Program
{
    static void Main()
    {
        
    }

    static public int Trap(int[] heights)
    {
        int l = 0;
        int r = heights.Length - 1;

        int maxL = heights[l];
        int maxR = heights[r];

        int result = 0;

        while (l < r)
        {
            if (heights[l] < heights[r])
            {
                maxL = Math.Max(maxL, heights[l]);
                result += maxL - heights[l];
                l++;
            }
            else
            {
                maxR = Math.Max(maxR, heights[r]);
                result += maxR - heights[r];
                r--;
            }
        }

        return result;
    }
}