using System;

public class Solution
{
    public int Trap(int[] height)
    {
        int left = 0, right = height.Length - 1;
        int leftMax = 0, rightMax = 0;
        int water = 0;

        while (left < right)
        {
            if (height[left] < height[right])
            {
                if (height[left] >= leftMax)
                {
                    leftMax = height[left];
                }
                else
                {
                    water += leftMax - height[left];
                }
                left++;
            }
            else
            {
                if (height[right] >= rightMax)
                {
                    rightMax = height[right];
                }
                else
                {
                    water += rightMax - height[right];
                }
                right--;
            }
        }

        return water;
    }

    // Test code
    public static void Main(string[] args)
    {
        Solution sol = new Solution();

        int[] height1 = { 0,1,0,2,1,0,1,3,2,1,2,1 };
        Console.WriteLine(sol.Trap(height1)); // Output: 6

        int[] height2 = { 4,2,0,3,2,5 };
        Console.WriteLine(sol.Trap(height2)); // Output: 9
    }
}
