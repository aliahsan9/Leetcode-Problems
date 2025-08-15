using System;

public class Solution
{
    public int[] SortArray(int[] nums)
    {
        int n = nums.Length;

        // Step 1: Build max heap
        for (int i = n / 2 - 1; i >= 0; i--)
        {
            Heapify(nums, n, i);
        }

        // Step 2: Extract elements one by one from heap
        for (int i = n - 1; i > 0; i--)
        {
            // Move current root to end
            int temp = nums[0];
            nums[0] = nums[i];
            nums[i] = temp;

            // Heapify the reduced heap
            Heapify(nums, i, 0);
        }

        return nums; // In-place sorted array
    }

    private void Heapify(int[] arr, int heapSize, int rootIndex)
    {
        int largest = rootIndex; // Initialize largest as root
        int left = 2 * rootIndex + 1; // Left child index
        int right = 2 * rootIndex + 2; // Right child index

        // If left child is larger than root
        if (left < heapSize && arr[left] > arr[largest])
        {
            largest = left;
        }

        // If right child is larger than largest so far
        if (right < heapSize && arr[right] > arr[largest])
        {
            largest = right;
        }

        // If largest is not root
        if (largest != rootIndex)
        {
            int swap = arr[rootIndex];
            arr[rootIndex] = arr[largest];
            arr[largest] = swap;

            // Recursively heapify the affected sub-tree
            Heapify(arr, heapSize, largest);
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        
        int[] nums = { 5, 2, 3, 1 };
        Console.WriteLine("Before Sorting: " + string.Join(", ", nums));

        int[] sorted = sol.SortArray(nums);

        Console.WriteLine("After Sorting: " + string.Join(", ", sorted));
    }
}
