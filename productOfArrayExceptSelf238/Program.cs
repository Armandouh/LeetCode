using System;
using System.Net.NetworkInformation;

class Program
{
    static void Main()
    {
        int[] arr = { 2, 3, 4, 7 };
        int[] output = productExceptSelf(arr);
        foreach (var item in output)
        {
            Console.WriteLine(item);
        }
    }

    static int[] productExceptSelf(int[] nums)
    {
        int[] output = new int[nums.Length];

        int prefix = 1;

        for (int i = 0; i < nums.Length; i++)
        {
            output[i] = prefix;
            prefix *= nums[i];
        }

        int postifx = 1;
        for (int i = nums.Length - 1; i >= 0; i--)
        {
            output[i] *= postifx;
            postifx *= nums[i];
        }

        return output;
    }
}