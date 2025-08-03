using System; // Importing System namespace for basic functions like Console
using System.Collections.Generic; // For using List<T>
using System.Text; // For using StringBuilder

// Solution class containing the Convert method
public class Solution
{
    // Convert method that converts string into Zigzag pattern
    public string Convert(string s, int numRows)
    {
        // If numRows is 1 or string is too short to zigzag, return original string
        if (numRows == 1 || s.Length <= numRows)
            return s;

        // List to hold StringBuilders for each row in zigzag
        List<StringBuilder> rows = new List<StringBuilder>();
        
        // Initialize rows based on minimum of numRows or string length
        for (int i = 0; i < Math.Min(numRows, s.Length); i++)
            rows.Add(new StringBuilder());

        int currentRow = 0;     // Track which row we are appending to
        bool goingDown = false; // Direction control: down or up

        // Loop through each character in the input string
        foreach (char c in s)
        {
            // Append current character to the appropriate row
            rows[currentRow].Append(c);

            // Change direction if we're at the top or bottom row
            if (currentRow == 0 || currentRow == numRows - 1)
                goingDown = !goingDown;

            // Move currentRow up or down based on direction
            currentRow += goingDown ? 1 : -1;
        }

        // StringBuilder to hold the final result
        StringBuilder result = new StringBuilder();

        // Combine all rows into a single string
        foreach (StringBuilder row in rows)
            result.Append(row);

        // Return the zigzag converted string
        return result.ToString();
    }
}

// Program class containing the Main method for testing
class Program
{
    // Main entry point of the program
    static void Main(string[] args)
    {
        var solution = new Solution(); // Create an instance of Solution

        // Test the Convert method with various inputs
        Console.WriteLine(solution.Convert("PAYPALISHIRING", 3)); // Output: "PAHNAPLSIIGYIR"
        Console.WriteLine(solution.Convert("PAYPALISHIRING", 4)); // Output: "PINALSIGYAHRPI"
        Console.WriteLine(solution.Convert("A", 1));              // Output: "A"
    }
}
