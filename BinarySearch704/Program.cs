using System;
using System.Numerics;
using System.Runtime.InteropServices;

class Program
{
    public static void Main()
    {
        int[] arr = [-1, 0, 3, 5, 9, 12];
        Console.WriteLine(Search(arr, 9));
    }

    public static int Search(int[] arr, int target)
    {
        int low = 0;
        int high = arr.Length - 1;
        while (low <= high)
        {
            int middle = (low + high) / 2;
            if (arr[middle] == target)
                return middle;
            else if (arr[middle] < target)
                low = middle + 1;
            else
                high = middle - 1;
        }

        return -1;
    }
}