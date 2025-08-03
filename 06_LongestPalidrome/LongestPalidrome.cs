using System;

public class Solution
{
    // Main function to find the longest palindromic substring
    public string LongestPalindrome(string s)
    {
        if (string.IsNullOrEmpty(s) || s.Length < 1) return "";

        int start = 0, end = 0;

        for (int i = 0; i < s.Length; i++)
        {
            int len1 = ExpandFromCenter(s, i, i);
            int len2 = ExpandFromCenter(s, i, i + 1);
            int len = Math.Max(len1, len2);

            if (len > end - start)
            {
                start = i - (len - 1) / 2;
                end = i + len / 2;
            }
        }

        return s.Substring(start, end - start + 1);
    }

    // Helper function to expand around a center and return length of the palindrome
    private int ExpandFromCenter(string s, int left, int right)
    {
        while (left >= 0 && right < s.Length && s[left] == s[right])
        {
            left--;
            right++;
        }
        return right - left - 1;
    }
}

// Example usage
class Program
{
    static void Main(string[] args)
    {
        Solution sol = new Solution();
        string input = "babad";
        string result = sol.LongestPalindrome(input);
        Console.WriteLine($"Longest palindromic substring of '{input}' is '{result}'");
    }
}
