using System; // For Console and other basic utilities
using System.Collections.Generic; // For Dictionary and List
using System.Linq; // For LINQ methods (not used here, but imported)

// Class containing the solution method
public class Solution
{
    // Method to calculate the minimum cost to make both baskets equal
    public long MinCost(int[] basket1, int[] basket2)
    {
        var count = new Dictionary<int, int>(); // To track the difference in item counts between both baskets
        long minVal = int.MaxValue; // To store the smallest item value from both baskets

        // Step 1: Count the frequency difference and find the smallest item
        for (int i = 0; i < basket1.Length; i++)
        {
            // Count the item from basket1
            if (!count.ContainsKey(basket1[i])) count[basket1[i]] = 0;
            count[basket1[i]]++; // Increment count for basket1 item
            minVal = Math.Min(minVal, basket1[i]); // Track smallest value

            // Count the item from basket2
            if (!count.ContainsKey(basket2[i])) count[basket2[i]] = 0;
            count[basket2[i]]--; // Decrement count for basket2 item
            minVal = Math.Min(minVal, basket2[i]); // Track smallest value again
        }

        var extra = new List<int>(); // List to store unbalanced items

        // Step 2: Check for unbalanced items
        foreach (var kvp in count)
        {
            // If any item has an odd difference, it's impossible to balance
            if (kvp.Value % 2 != 0)
                return -1;

            // Add half of the extra (surplus) items to the 'extra' list
            for (int i = 0; i < Math.Abs(kvp.Value) / 2; i++)
                extra.Add(kvp.Key);
        }

        // Step 3: Sort the extra list to handle the smallest items first
        extra.Sort();

        long cost = 0; // Initialize total cost

        // Only the first half of the list needs to be processed (they pair with the second half)
        for (int i = 0; i < extra.Count / 2; i++)
        {
            // Cost is minimum of replacing with this item or using two smallest items
            cost += Math.Min(extra[i], 2 * minVal);
        }

        return cost; // Return the final minimum cost
    }
}

// Main program class to test the solution
class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution(); // Create an instance of Solution

        // Test case 1
        int[] basket1 = { 4, 2, 2, 2 };
        int[] basket2 = { 1, 4, 1, 2 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(basket1, basket2)); // Expected Output: 1

        // Test case 2 (already same)
        int[] b1 = { 1, 2, 3 };
        int[] b2 = { 2, 3, 1 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(b1, b2)); // Expected Output: 0

        // Test case 3 (only 1 swap needed)
        int[] b3 = { 1, 1, 2 };
        int[] b4 = { 2, 2, 1 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(b3, b4)); // Expected Output: 1
    }
}
