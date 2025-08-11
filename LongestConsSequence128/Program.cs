using System;

class Program
{
    static void Main()
    {
        int[] nums = { 100, 4, 200, 1, 3, 2, 1, 5 };
        Console.WriteLine(LongestConsecutive(nums));
    }

    static int LongestConsecutive(int[] nums)
    {
        HashSet<int> numSet = new HashSet<int>();
        int result = 0;

        foreach (var item in nums)
            numSet.Add(item);

        int i = 0;
        foreach (var item in numSet)
        {
            int currentLen = 1;
            if (!numSet.Contains(item - 1))
            {
                while (numSet.Contains(item + currentLen))
                    currentLen++;

                result = Math.Max(result, currentLen);
            }
        }

        return result;
    }
}