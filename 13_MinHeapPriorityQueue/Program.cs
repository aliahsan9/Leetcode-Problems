using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Example input
        int[] nums = { 3, 2, 1, 5, 6, 4 };
        int k = 2;

        Solution solution = new Solution();
        int result = solution.FindKthLargest(nums, k);

        Console.WriteLine($"The {k}th largest element is: {result}");
    }
}

public class Solution
{
    public int FindKthLargest(int[] nums, int k)
    {
        // Min-heap to store k largest elements
        PriorityQueue<int, int> minHeap = new PriorityQueue<int, int>();

        foreach (int num in nums)
        {
            minHeap.Enqueue(num, num); // Add element to heap

            if (minHeap.Count > k)
            {
                minHeap.Dequeue(); // Remove smallest if size exceeds k
            }
        }

        // Root of heap is the k-th largest
        return minHeap.Peek();
    }
}
