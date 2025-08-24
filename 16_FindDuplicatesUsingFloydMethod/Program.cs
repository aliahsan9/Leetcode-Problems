using System;

public class Solution
{
    public int FindDuplicate(int[] nums)
    {
        // Phase 1: Detect cycle using Floyd's Tortoise and Hare
        int slow = nums[0];
        int fast = nums[0];

        do
        {
            slow = nums[slow];          // move 1 step
            fast = nums[nums[fast]];    // move 2 steps
        } while (slow != fast);

        // Phase 2: Find the entrance of the cycle (duplicate number)
        slow = nums[0];
        while (slow != fast)
        {
            slow = nums[slow];
            fast = nums[fast];
        }

        return slow; // or fast, both are the duplicate number
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();

        // Example 1
        int[] nums1 = { 1, 3, 4, 2, 2 };
        Console.WriteLine($"Duplicate in [1,3,4,2,2]: {sol.FindDuplicate(nums1)}");

        // Example 2
        int[] nums2 = { 3, 1, 3, 4, 2 };
        Console.WriteLine($"Duplicate in [3,1,3,4,2]: {sol.FindDuplicate(nums2)}");

        // Example 3
        int[] nums3 = { 3, 3, 3, 3, 3 };
        Console.WriteLine($"Duplicate in [3,3,3,3,3]: {sol.FindDuplicate(nums3)}");
    }
}
