using System;
using System.Collections.Generic;

public class Solution
{
    public IList<IList<int>> Generate(int numRows)
    {
        IList<IList<int>> triangle = new List<IList<int>>();

        for (int i = 0; i < numRows; i++)
        {
            List<int> row = new List<int>();

            for (int j = 0; j <= i; j++)
            {
                if (j == 0 || j == i)
                {
                    row.Add(1);
                }
                else
                {
                    int sum = triangle[i - 1][j - 1] + triangle[i - 1][j];
                    row.Add(sum);
                }
            }

            triangle.Add(row);
        }

        return triangle;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        int numRows = 5; // Example input
        var triangle = solution.Generate(numRows);

        foreach (var row in triangle)
        {
            Console.WriteLine(string.Join(" ", row));
        }
    }
}
