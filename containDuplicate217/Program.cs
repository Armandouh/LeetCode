using System;

class Program
{
    static void Main()
    {
        int[] nums = { 1, 2, 3, 4 };
        Console.WriteLine(containDupes(nums));
    }

    static bool containDupes(int[] arr)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (int x in arr)
        {
            count[x] = count.GetValueOrDefault(x, 0) + 1;
        }

        foreach (var val in count.Values)
        {
            if (val > 1)
                return true;
        }

        return false;
    }
}