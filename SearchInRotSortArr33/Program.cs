using System;

public class Solution
{
    public static void Main()
    {
        int[] nums = [5, 1, 3];
        int target = 5;
        Console.WriteLine(Search(nums, target));
    }
    
    public static int Search(int[] nums, int target)
    {
        int l = 0;
        int r = nums.Length - 1;

        while (l <= r)
        {
            int m = (l + r) / 2;
            if (nums[m] == target)
                return m;
            // Left sorted portion
            else if (nums[l] <= nums[m])
            {
                if (target >= nums[l] && target <= nums[m])
                    r = m - 1;
                else
                    l = m + 1;
            }
            else
            {
                if (target >= nums[m] && target <= nums[r])
                    l = m + 1;
                else
                    r = m - 1;
            }
        }

        return -1;
    }
}