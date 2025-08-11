using System;

class Program
{
    static void Main()
    {
    }

    static int[] twoSum(int[] numbers, int target)
    {
        int j = numbers.Length - 1;
        int i = 0;

        while (i < j)
        {
            int sum = numbers[i] + numbers[j];
            if (sum == target) return new int[2] { i + 1, j + 1 };
            if (sum > target) j--;
            if (sum < target) i++;
        }

        return new int[2] { -1, -1 };
    }
}