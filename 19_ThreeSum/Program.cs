using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> ThreeSum(int[] nums)
    {
        var result = new List<IList<int>>();
        if (nums == null || nums.Length < 3) return result;

        Array.Sort(nums);  // Sort the array to make it easier to avoid duplicates

        for (int i = 0; i < nums.Length - 2; i++)
        {
            // Skip duplicate elements to avoid repeated triplets
            if (i > 0 && nums[i] == nums[i - 1]) continue;

            int left = i + 1;
            int right = nums.Length - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                if (sum == 0)
                {
                    result.Add(new List<int> { nums[i], nums[left], nums[right] });
                    // Skip duplicate elements for 'left' and 'right'
                    while (left < right && nums[left] == nums[left + 1]) left++;
                    while (left < right && nums[right] == nums[right - 1]) right--;
                    left++;
                    right--;
                }
                else if (sum < 0)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        int[] array = { 1, 2, 3, 4, -1, -2, -3 };
        Solution solution = new Solution();
        var triplets = solution.ThreeSum(array);

        Console.WriteLine("Triplets with sum 0:");
        foreach (var triplet in triplets)
        {
            Console.WriteLine($"[{string.Join(", ", triplet)}]");
        }
    }
}
