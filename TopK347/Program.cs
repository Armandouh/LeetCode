using System;

class Program
{
    static void Main()
    {
        int[] nums = { 4, 6, 6, 2, 1, 5, 6, 5 };
        int[] frequents = TopK(nums, 3);
        foreach (int n in frequents)
            Console.WriteLine(n);
    }

    public static int[] TopK(int[] nums, int k)
    {
        Dictionary<int, int> count = new Dictionary<int, int>();

        foreach (var n in nums)
            count[n] = count.GetValueOrDefault(n, 0) + 1;

        List<int>[] buckets = new List<int>[nums.Length + 1];

        foreach (var item in count)
        {
            if (buckets[item.Value] == null)
                buckets[item.Value] = new List<int>();
            buckets[item.Value].Add(item.Key);
        }

        List<int> result = new List<int>();
        for (int i = buckets.Length - 1; i >= 0; i--)
        {
            if (buckets[i] != null)
            {
                foreach (int n in buckets[i])
                {
                    result.Add(n);
                    if (result.Count == k)
                        return result.ToArray();
                }
            }
        }

        return result.ToArray();
    }
}