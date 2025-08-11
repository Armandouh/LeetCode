using System;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        int[] nums = [1, 3, -1, -3, 5, 3, 6, 7];
        int k = 3;
        int[] maxWindow = maxSlidingWindow(nums, k);

        foreach (int n in maxWindow)
        {
            Console.WriteLine(n);
        }
    }

    public static int[] maxSlidingWindow(int[] nums, int k)
    {
        List<int> result = new List<int>();
        LinkedList<int> deque = new LinkedList<int>(); //indices

        int l = 0;
        for (int r = 0; r < nums.Length; r++)
        {
            while (deque.Count > 0 && nums[deque.Last.Value] < nums[r])
                deque.RemoveLast();
            deque.AddLast(r);
            
            if (l > deque.First.Value)
                deque.RemoveFirst();
            if (r + 1 >= k)
            {
                result.Add(nums[deque.First.Value]);
                l++;
            }
        }

        return result.ToArray();
    }
}