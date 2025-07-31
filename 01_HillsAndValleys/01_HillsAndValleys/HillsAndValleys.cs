using System;
using System.Collections.Generic;

class LeetCodeProblem_01
{
    public static int CountHillValley(int[] nums)
    {
        int count = 0;
        int n = nums.Length;

        // First, remove consecutive duplicates to handle plateaus
        List<int> filtered = new List<int>();
        filtered.Add(nums[0]);
        for (int i = 1; i < n; i++)
        {
            if (nums[i] != nums[i - 1])
            {
                filtered.Add(nums[i]);
            }
        }

        // Now check for hills and valleys in the filtered list
        for (int i = 1; i < filtered.Count - 1; i++)
        {
            int left = filtered[i - 1];
            int current = filtered[i];
            int right = filtered[i + 1];

            if ((current > left && current > right) || (current < left && current < right))
            {
                count++;
            }
        }
        return count;
    }

    static void Main(string[] args)
    {
        int[] nums = {2, 4, 1, 1, 6, 5};
        Console.WriteLine(CountHillValley(nums));
    }
}