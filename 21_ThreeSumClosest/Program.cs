using System;

public class Solution
{
    public int ThreeSumClosest(int[] nums, int target)
    {
        Array.Sort(nums);
        int n = nums.Length;
        int closestSum = nums[0] + nums[1] + nums[2]; // initialize with first three

        for (int i = 0; i < n - 2; i++)
        {
            int left = i + 1;
            int right = n - 1;

            while (left < right)
            {
                int sum = nums[i] + nums[left] + nums[right];

                // update closest sum
                if (Math.Abs(sum - target) < Math.Abs(closestSum - target))
                {
                    closestSum = sum;
                }

                if (sum == target)
                {
                    return sum; // exact match
                }
                else if (sum < target)
                {
                    left++;
                }
                else
                {
                    right--;
                }
            }
        }

        return closestSum;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();

        int[] nums1 = { -1, 2, 1, -4 };
        int target1 = 1;
        Console.WriteLine("Closest sum: " + sol.ThreeSumClosest(nums1, target1)); // Output: 2

        int[] nums2 = { 0, 0, 0 };
        int target2 = 1;
        Console.WriteLine("Closest sum: " + sol.ThreeSumClosest(nums2, target2)); // Output: 0

        int[] nums3 = { 1, 1, 1, 0 };
        int target3 = -100;
        Console.WriteLine("Closest sum: " + sol.ThreeSumClosest(nums3, target3)); // Output: 2
    }
}
