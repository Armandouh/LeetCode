using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main()
    {
        int[] heights = [2, 1, 5, 6, 2, 3];
        Console.WriteLine(LargestRect(heights));
    }

    public static int LargestRect(int[] heights)
    {
        int maxArea = 0;
        Stack<(int position, int height)> MonoStack = new Stack<(int, int)>();
        for (int i = 0; i < heights.Length; i++)
        {
            int start = i;
            while (MonoStack.Count != 0 && heights[i] < MonoStack.Peek().height)
            {
                int poppedP = MonoStack.Peek().position;
                int poppedH = MonoStack.Peek().height;
                int width = i - poppedP;
                int Area = width * poppedH;
                maxArea = Math.Max(maxArea, Area);
                MonoStack.Pop();
                start = poppedP;
            }
            MonoStack.Push((start, heights[i]));
        }

        if (MonoStack.Count != 0)
        {
            for (int i = MonoStack.Count; i > 0; i--)
            {
                int Area = (heights.Length - MonoStack.Peek().position) * MonoStack.Peek().height;
                MonoStack.Pop();
                maxArea = Math.Max(Area, maxArea);
            }
        }

        return maxArea;
    }
}