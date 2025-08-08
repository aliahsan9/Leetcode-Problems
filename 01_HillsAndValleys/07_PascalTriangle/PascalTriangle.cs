using System; // Import the System namespace for basic classes like Console
using System.Collections.Generic; // Import the namespace for generic collections like List and IList

public class Solution // Define a public class named Solution
{
    public IList<IList<int>> Generate(int numRows) // Method to generate Pascal's Triangle with numRows rows
    {
        IList<IList<int>> triangle = new List<IList<int>>(); // Create a list to hold all rows of the triangle

        for (int i = 0; i < numRows; i++) // Loop through each row index from 0 to numRows-1
        {
            List<int> row = new List<int>(); // Create a new list to hold the current row

            for (int j = 0; j <= i; j++) // Loop through each element in the current row
            {
                if (j == 0 || j == i) // If it's the first or last element in the row
                {
                    row.Add(1); // Add 1 to the row (edges of Pascal's Triangle are always 1)
                }
                else // For other elements in the row
                {
                    int sum = triangle[i - 1][j - 1] + triangle[i - 1][j]; // Sum the two elements above from the previous row
                    row.Add(sum); // Add the calculated sum to the current row
                }
            }

            triangle.Add(row); // Add the completed row to the triangle
        }

        return triangle; // Return the completed triangle
    }
}

class Program // Define the main Program class
{
    static void Main(string[] args) // Main entry point of the program
    {
        Solution solution = new Solution(); // Create an instance of the Solution class
        int numRows = 5; // Example input: number of rows for Pascal's Triangle
        var triangle = solution.Generate(numRows); // Generate the triangle using the solution

        foreach (var row in triangle) // Loop through each row in the triangle
        {
            Console.WriteLine(string.Join(" ", row)); // Print the row as space-separated numbers
        }
    }
}
