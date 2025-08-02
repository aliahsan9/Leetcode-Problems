using System;
using System.Collections.Generic;
using System.Linq;

public class Solution
{
    public long MinCost(int[] basket1, int[] basket2)
    {
        var count = new Dictionary<int, int>();
        long minVal = int.MaxValue;

        // Step 1: Count frequency difference and find the smallest value
        for (int i = 0; i < basket1.Length; i++)
        {
            if (!count.ContainsKey(basket1[i])) count[basket1[i]] = 0;
            count[basket1[i]]++;
            minVal = Math.Min(minVal, basket1[i]);

            if (!count.ContainsKey(basket2[i])) count[basket2[i]] = 0;
            count[basket2[i]]--;
            minVal = Math.Min(minVal, basket2[i]);
        }

        // Step 2: Find all elements with unbalanced counts
        var extra = new List<int>();
        foreach (var kvp in count)
        {
            if (kvp.Value % 2 != 0)
                return -1; // Cannot make both baskets equal

            // Add half of the surplus to the list
            for (int i = 0; i < Math.Abs(kvp.Value) / 2; i++)
                extra.Add(kvp.Key);
        }

        // Step 3: Sort and calculate the minimum cost
        extra.Sort();
        long cost = 0;

        // Only half the list needs to be processed (the other half pairs up)
        for (int i = 0; i < extra.Count / 2; i++)
        {
            cost += Math.Min(extra[i], 2 * minVal);
        }

        return cost;
    }
}

class Program
{
    static void Main(string[] args)
    {
        var solution = new Solution();

        int[] basket1 = { 4, 2, 2, 2 };
        int[] basket2 = { 1, 4, 1, 2 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(basket1, basket2)); // Example Output: 1

        int[] b1 = { 1, 2, 3 };
        int[] b2 = { 2, 3, 1 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(b1, b2)); // Output: 0 (Already same)

        int[] b3 = { 1, 1, 2 };
        int[] b4 = { 2, 2, 1 };
        Console.WriteLine("Minimum Cost: " + solution.MinCost(b3, b4)); // Output: 1
    }
}
