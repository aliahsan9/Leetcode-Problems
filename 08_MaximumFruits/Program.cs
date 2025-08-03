using System;

public class Solution
{
    public int MaxTotalFruits(int[][] fruits, int startPos, int k)
    {
        int n = fruits.Length;
        int maxFruits = 0;
        int left = 0, total = 0;

        for (int right = 0; right < n; right++)
        {
            total += fruits[right][1]; // Add fruits in current window

            // Move left pointer to ensure we are within step limit
            while (left <= right && !CanReach(fruits[left][0], fruits[right][0], startPos, k))
            {
                total -= fruits[left][1];
                left++;
            }

            maxFruits = Math.Max(maxFruits, total);
        }

        return maxFruits;
    }

    // Helper function to check if range [leftPos, rightPos] is reachable from startPos within k steps
    private bool CanReach(int leftPos, int rightPos, int startPos, int k)
    {
        int option1 = Math.Abs(startPos - leftPos) + (rightPos - leftPos);
        int option2 = Math.Abs(startPos - rightPos) + (rightPos - leftPos);
        return Math.Min(option1, option2) <= k;
    }

    // Main method for local testing in VS Code
    public static void Main(string[] args)
    {
        var solution = new Solution();

        // Example 1
        int[][] fruits1 = new int[][]
        {
            new int[] {2, 8},
            new int[] {6, 3},
            new int[] {8, 6}
        };
        int startPos1 = 5, k1 = 4;
        Console.WriteLine("Output 1: " + solution.MaxTotalFruits(fruits1, startPos1, k1)); // Expected: 9

        // Example 2
        int[][] fruits2 = new int[][]
        {
            new int[] {0, 9},
            new int[] {4, 1},
            new int[] {5, 7},
            new int[] {6, 2},
            new int[] {7, 4},
            new int[] {10, 9}
        };
        int startPos2 = 5, k2 = 4;
        Console.WriteLine("Output 2: " + solution.MaxTotalFruits(fruits2, startPos2, k2)); // Expected: 14

        // Example 3
        int[][] fruits3 = new int[][]
        {
            new int[] {0, 3},
            new int[] {6, 4},
            new int[] {8, 5}
        };
        int startPos3 = 3, k3 = 2;
        Console.WriteLine("Output 3: " + solution.MaxTotalFruits(fruits3, startPos3, k3)); // Expected: 0
    }
}
