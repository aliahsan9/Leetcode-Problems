using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Example input array representing fruits on trees
        int[] fruits = new int[] { 1, 2, 3, 2, 2 };

        // Create an object of Solution class to access TotalFruit method
        Solution solution = new Solution();

        // Call the method and store the result
        int result = solution.TotalFruit(fruits);

        // Print the result to console
        Console.WriteLine("Maximum number of fruits collected: " + result);
    }
}

public class Solution 
{
    public int TotalFruit(int[] fruits)
    {
        int maxFruits = 0; // This will store the maximum number of fruits we can collect
        int left = 0; // Left pointer of the sliding window

        // Dictionary to store the count of each fruit type in the current window
        Dictionary<int, int> basket = new Dictionary<int, int>();

        // Loop through the fruits array using the right pointer
        for (int right = 0; right < fruits.Length; right++)
        {
            // If this fruit type is not already in the basket, add it with count 0
            if (!basket.ContainsKey(fruits[right]))
                basket[fruits[right]] = 0;

            // Increment the count of the current fruit type
            basket[fruits[right]]++;

            // If there are more than 2 fruit types, shrink the window from the left
            while (basket.Count > 2)
            {
                // Decrease the count of the fruit at the left
                basket[fruits[left]]--;

                // If the count becomes zero, remove it from the basket
                if (basket[fruits[left]] == 0)
                    basket.Remove(fruits[left]);

                // Move the left pointer forward to shrink the window
                left++;
            }

            // Update the maxFruits with the size of the current valid window
            maxFruits = Math.Max(maxFruits, right - left + 1);
        }

        // Return the maximum fruits we can collect
        return maxFruits;
    }
}
