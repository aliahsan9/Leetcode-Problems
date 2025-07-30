using System;
using System.Collections.Generic;

public class Solution
{
    public int LengthOfLongestSubstring(string s)
    {
        int n = s.Length;
        int maxLength = 0;   
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>();
        int left = 0;

        for (int right = 0; right < n; right++)
        {
            char currentChar = s[right];

            if (charIndexMap.ContainsKey(currentChar))
            {
                left = Math.Max(left, charIndexMap[currentChar] + 1);
            }

            charIndexMap[currentChar] = right;
            maxLength = Math.Max(maxLength, right - left + 1);
        }

        return maxLength;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Solution solution = new Solution();
        Console.WriteLine("Enter a string:");
        string input = Console.ReadLine() ?? string.Empty;
        int result = solution.LengthOfLongestSubstring(input);
        Console.WriteLine("Length of longest substring without repeating characters: " + result);
    }
}