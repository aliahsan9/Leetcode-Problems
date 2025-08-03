using System; // Import the System namespace for basic functionalities like Console
using System.Collections.Generic; // Import the namespace for using List<T>

class LeetCodeProblem_01 // Define a class named LeetCodeProblem_01
{
    // Method to count hills and valleys in an integer array
    public static int CountHillValley(int[] nums)
    {
        int count = 0; // Initialize the counter for hills and valleys 
        int n = nums.Length; // Store the length of the input array

        // First, remove consecutive duplicates to handle plateaus
        List<int> filtered = new List<int>(); // Create a new list to store filtered values
        filtered.Add(nums[0]); // Add the first element to the filtered list

        for (int i = 1; i < n; i++) // Loop through the array starting from the second element
        {
            if (nums[i] != nums[i - 1]) // If the current element is not equal to the previous one
            {
                filtered.Add(nums[i]); // Add it to the filtered list
            }
        }

        // Now check for hills and valleys in the filtered list
        for (int i = 1; i < filtered.Count - 1; i++) // Loop through filtered list, skipping first and last elements
        {
            int left = filtered[i - 1]; // Get the left neighbor
            int current = filtered[i]; // Get the current element
            int right = filtered[i + 1]; // Get the right neighbor

            // Check if current is a hill (greater than both neighbors) or a valley (less than both neighbors)
            if ((current > left && current > right) || (current < left && current < right))
            {
                count++; // Increment the count if it's a hill or valley
            }
        }
        return count; // Return the total count of hills and valleys
    }

    static void Main(string[] args) // Main method: entry point of the program
    {
        int[] nums = {2, 4, 1, 1, 6, 5}; // Define an example array
        Console.WriteLine(CountHillValley(nums)); // Call the method and print the result
    }
}