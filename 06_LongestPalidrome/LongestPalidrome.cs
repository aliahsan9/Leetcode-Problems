using System; // Import the System namespace for basic functionalities

public class Solution // Define the Solution class
{
    // Main function to find the longest palindromic substring
    public string LongestPalindrome(string s) // Method to find the longest palindrome in string s
    {
        if (string.IsNullOrEmpty(s) || s.Length < 1) return ""; // If string is null or empty, return empty string

        int start = 0, end = 0; // Initialize start and end indices of the longest palindrome

        for (int i = 0; i < s.Length; i++) // Loop through each character in the string
        {
            int len1 = ExpandFromCenter(s, i, i); // Check for odd-length palindrome centered at i
            int len2 = ExpandFromCenter(s, i, i + 1); // Check for even-length palindrome centered between i and i+1
            int len = Math.Max(len1, len2); // Take the maximum length found

            if (len > end - start) // If the found palindrome is longer than the previous one
            {
                start = i - (len - 1) / 2; // Update start index of the palindrome
                end = i + len / 2; // Update end index of the palindrome
            }
        }

        return s.Substring(start, end - start + 1); // Return the longest palindromic substring
    }

    // Helper function to expand around a center and return length of the palindrome
    private int ExpandFromCenter(string s, int left, int right) // Expand around the center indices left and right
    {
        while (left >= 0 && right < s.Length && s[left] == s[right]) // While within bounds and characters match
        {
            left--; // Move left pointer one step to the left
            right++; // Move right pointer one step to the right
        }
        return right - left - 1; // Return the length of the palindrome found
    }
}

// Example usage
class Program // Define the Program class
{
    static void Main(string[] args) // Main entry point of the program
    {
        Solution sol = new Solution(); // Create an instance of Solution
        string input = "babad"; // Define the input string
        string result = sol.LongestPalindrome(input); // Find the longest palindromic substring
        Console.WriteLine($"Longest palindromic substring of '{input}' is '{result}'"); // Print the result
    }
}
