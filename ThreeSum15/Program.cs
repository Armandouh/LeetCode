using System;

class Program
{
    static void Main()
    {
        int[] nums = { -1, 0, 1, 2, -1, -4 };
        IList<IList<int>> triplets = threeSum(nums);
        foreach (var item in triplets)
        {
            Console.WriteLine(String.Join(',', item));
        }

    }

    static public IList<IList<int>> threeSum(int[] nums)
    {
        IList<IList<int>> output = new List<IList<int>>();
        Array.Sort(nums);

        for (int i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
                i++;

            int j = i + 1;
            int k = nums.Length - 1;

            while (j < k)
            {
                int sum = nums[i] + nums[j] + nums[k];

                if (sum > 0)
                {
                    k--;
                }
                else if (sum < 0)
                {
                    j++;
                }
                else
                {
                    output.Add([nums[i], nums[j], nums[k]]);
                    j++;
                    k--;
                    while (j < k && nums[j] == nums[j - 1]) j++;
                    while (j < k && nums[k] == nums[k + 1]) k--;
                } 
            }
        }

        return output;
    }
}