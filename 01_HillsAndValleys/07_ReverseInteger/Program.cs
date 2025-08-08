using System;

public class Solution
{
    public int Reverse(int x)
    {
        int result = 0;

        while (x != 0)
        {
            int digit = x % 10;
            x /= 10;

            // Check for overflow/underflow
            if (result > int.MaxValue / 10 || (result == int.MaxValue / 10 && digit > 7))
                return 0;
            if (result < int.MinValue / 10 || (result == int.MinValue / 10 && digit < -8))
                return 0;

            result = result * 10 + digit;
        }

        return result;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a 32-bit signed integer:");
        if (int.TryParse(Console.ReadLine(), out int input))
        {
            Solution sol = new Solution();
            int reversed = sol.Reverse(input);
            Console.WriteLine($"Reversed Integer: {reversed}");
        }
        else
        {
            Console.WriteLine("Invalid input! Please enter a valid 32-bit signed integer.");
        }
    }
}
