public class Solution
{
    static void Main()
    {
        int[] nums = { 3, 4, 5, 1, 2 };
        Console.WriteLine(FindMin(nums));
    }

    static public int FindMin(int[] nums)
    {
        int l = 0;
        int r = nums.Length - 1;
        int res = int.MaxValue;

        while (l <= r)
        {
            int m = (l + r) / 2;
            res = Math.Min(nums[m], res);

            if (nums[l] < nums[r])
            {
                res = Math.Min(nums[l], res);
                break;  
            }
            
            else if (nums[m] >= nums[l])
                l = m + 1;
            else
                r = m - 1;
        }

        return res;
    }
}