using System;

class Program
{
    static void Main()
    {
        int[] heights = [1, 8, 6, 2, 5, 4, 8, 3, 7];
        Console.WriteLine(maxArea(heights));
    }

    public static int maxArea(int[] heights)
    {
        int result = 0;
        int l = 0;
        int r = heights.Length - 1;

        while (l < r)
        {
            int width = r - l;
            int length = Math.Min(heights[l], heights[r]);
            int area = width * length;
            result = Math.Max(result, area);

            if (l < r && heights[l] < heights[r])
                l++;
            else
                r--;
        }

        return result;
    }
}