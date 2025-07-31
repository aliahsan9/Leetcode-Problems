using System;

public class Solution
{
    public double FindMedianSortedArrays(int[] nums1, int[] nums2)
    {
        if (nums1.Length > nums2.Length)
        {
            return FindMedianSortedArrays(nums2, nums1);
        }

        int m = nums1.Length;
        int n = nums2.Length;
        int left = 0, right = m;
        int halfLen = (m + n + 1) / 2;

        while (left <= right)
        {
            int i = (left + right) / 2;
            int j = halfLen - i;

            if (i < m && j > 0 && nums2[j - 1] > nums1[i])
            {
                left = i + 1;
            }
            else if (i > 0 && j < n && nums1[i - 1] > nums2[j])
            {
                right = i - 1;
            }
            else
            {
                int maxLeft;
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

                if ((m + n) % 2 == 1)
                {
                    return maxLeft;
                }

                int minRight;
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

                return (maxLeft + minRight) / 2.0;
            }
        }

        return 0.0;
    }
}

class Program
{
    static void Main()
    {
        var solution = new Solution();
        int[] nums1 = { 1, 3 };
        int[] nums2 = { 2 };
        double median = solution.FindMedianSortedArrays(nums1, nums2);
        Console.WriteLine("Median: " + median); // Output: Median: 2

        nums1 = new int[] { 1, 2 };
        nums2 = new int[] { 3, 4 };
        median = solution.FindMedianSortedArrays(nums1, nums2);
        Console.WriteLine("Median: " + median); // Output: Median: 2.5
    }
} 