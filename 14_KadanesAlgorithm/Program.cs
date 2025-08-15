using System;

class Program
{
    public static int MaxSubArray(int[] nums)
    {
        int currentSum = 0;
        int maxSum = int.MinValue;

        foreach (int val in nums)
        {
            currentSum += val;
            maxSum = Math.Max(currentSum, maxSum);

            if (currentSum < 0)
            {
                currentSum = 0;
            }
        }

        return maxSum;
    }

    static void Main(string[] args)
    {
        // Example test case
        int[] nums = { -2, 1, -3, 4, -1, 2, 1, -5, 4 };
        int result = MaxSubArray(nums);
        Console.WriteLine("Maximum subarray sum: " + result);
    }
}
