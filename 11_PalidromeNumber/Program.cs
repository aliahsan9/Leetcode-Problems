using System;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Enter any value to check palidrome:");
        int x = int.Parse(Console.ReadLine());

        if (x < 0)
        {
            Console.WriteLine("It's not a palidrome!");
        }

        int original = x, reversed = 0;

        while (x > 0)
        {
            int digit = x % 10;
            reversed = reversed * 10 + digit;
            x /= 10;
        }
        if (original == reversed)
        {
            Console.WriteLine("It's a palidrome number.");
        }
        else
        {
            Console.WriteLine("It's not a palidrome number!");
        }
    }
}