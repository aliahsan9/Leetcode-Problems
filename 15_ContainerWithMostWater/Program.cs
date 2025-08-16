using System;

class Program
{
    static int MaxArea(int[] height)
    {
        int leftPointer = 0, rightPointer = height.Length - 1;
        int maxWater = 0;

        while (leftPointer < rightPointer)
        {
            int minHeight = Math.Min(height[leftPointer], height[rightPointer]);
            int width = rightPointer - leftPointer;
            int area = minHeight * width;

            maxWater = Math.Max(area, maxWater);

            if (height[leftPointer] < height[rightPointer])
                leftPointer++;
            else
                rightPointer--;
        }
        return maxWater;
    }

    public static void Main(string[] args)
    {
        int[] height = {1, 8, 6, 2, 5, 4, 8, 3, 7};
        int result = MaxArea(height);
        Console.WriteLine("Maximum water is: " + result);
    }
}
