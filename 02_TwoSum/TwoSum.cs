// Import the System namespace for basic functionalities
using System;
// Import the System.Collections.Generic namespace for using generic collections like Dictionary
using System.Collections.Generic;

// Define the Solution class
public class Solution
{
    // Define the TwoSum method which takes an array of integers and a target integer, returns an array of two integers
    public int[] TwoSum(int[] nums, int target)
    {
        // Create a dictionary to store numbers and their indices for quick lookup
        Dictionary<int, int> numMap = new Dictionary<int, int>();

        // Iterate through the nums array using index i
        for (int i = 0; i < nums.Length; i++)
        {
            // Calculate the complement value needed to reach the target
            int complement = target - nums[i];

            // Check if the complement exists in the dictionary
            if (numMap.ContainsKey(complement))
            {
                // If found, return the indices of the complement and current number as the result
                return new int[] { numMap[complement], i };
            }

            // If the current number is not already in the dictionary, add it with its index
            if (!numMap.ContainsKey(nums[i]))
            {
                numMap.Add(nums[i], i);
            }
        }

        // If no solution is found, throw an exception indicating failure
        throw new ArgumentException("No two sum solution found");
    }
}

// Define the Program class containing the Main method
public class Program
{
    // Main method: entry point of the program
    public static void Main(string[] args)
    {
        // Create an instance of the Solution class
        Solution solution = new Solution();

        // Define the input array of numbers
        int[] nums = { 2, 7, 11, 15 };
        // Define the target sum value
        int target = 9;

        // Call the TwoSum method to find the indices of two numbers that add up to the target
        int[] result = solution.TwoSum(nums, target);

        // Print the result indices to the console
        Console.WriteLine($"Indices: [{result[0]}, {result[1]}]");
    }
}