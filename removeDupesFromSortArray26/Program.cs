using System;
using System.Net.Security;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 1, 2, 3, 3, 4 };

        int k = removeDupes(nums);

        Console.WriteLine(k);
    }

    static int removeDupes(int[] arr)
    {
        int j = 1;

        for (int i = 1; i < arr.Length; i++)
        {
            if (arr[i] != arr[i-1])
            {
                arr[j] = arr[i];
                j++;
            }
        }

        return j;
    }
}