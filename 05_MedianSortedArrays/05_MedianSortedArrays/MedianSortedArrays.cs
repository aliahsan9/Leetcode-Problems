using System;

// Main solution class
public class Solution
{
    // Finds the median of two sorted arrays
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        // Ensure nums1 is the smaller array for binary search efficiency
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int left = 0, right = m;
        int halfLen = (m + n + 1) / 2; // Half length for partitioning

        // Binary search on the smaller array
        while (left <= right)
        {
            int i = (left + right) / 2; // Partition index for nums1
            int j = halfLen - i;        // Partition index for nums2

            // If nums1's right partition is too small, move right
            if (i < m && j > 0 && nums2[j - 1] > nums1[i])
            {
                left = i + 1;
            }
            // If nums1's left partition is too big, move left
            else if (i > 0 && j < n && nums1[i - 1] > nums2[j])
            {
                right = i - 1;
            }
            // Correct partition found
            else
            {
                int maxLeft;
                // Handle edge cases for maxLeft
                if (i == 0)
                {
                    maxLeft = nums2[j - 1];
                }
                else if (j == 0)
                {
                    maxLeft = nums1[i - 1];
                }
                else
                {
                    maxLeft = Math.Max(nums1[i - 1], nums2[j - 1]);
                }

                // If total length is odd, median is maxLeft
                if ((m + n) % 2 == 1)
                {
                    return maxLeft;
                }

                int minRight;
                // Handle edge cases for minRight
                if (i == m)
                {
                    minRight = nums2[j];
                }
                else if (j == n)
                {
                    minRight = nums1[i];
                }
                else
                {
                    minRight = Math.Min(nums1[i], nums2[j]);
                }

                // If total length is even, median is average of maxLeft and minRight
                return (maxLeft + minRight) / 2.0;
            }
        }

        // Should not reach here for valid input
        return 0.0;
    }
}

// Test program
class Program
{
    static void Main()
    {
        var solution = new Solution();

        // Test case 1
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        double median = solution.FindMedianSortedArrays(nums1, nums2);
        Console.WriteLine("Median: " + median); // Output: Median: 2

        // Test case 2
        nums1 = new int[] { 1, 2 };
        nums2 = new int[] { 3, 4 };
        median = solution.FindMedianSortedArrays(nums1, nums2);
        Console.WriteLine("Median: " + median); // Output: Median: 2.5
    }
}