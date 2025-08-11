using System;

class Program
{
    static void Main()
    {
    }

    static int majorityElement(int[] nums)
    {
        Dictionary<int, int> freqMap = new Dictionary<int, int>();

        foreach (int n in nums)
        {
            freqMap[n] = freqMap.GetValueOrDefault(n, 0) + 1;
        }

        int goal = nums.Length / 2;

        foreach (var pair in freqMap)
        {
            if (pair.Value > goal)
                return pair.Key;
        }

        return -1;
    }
}