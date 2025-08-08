using System; // Import the System namespace for basic functionalities like Console operations
using System.Collections.Generic; // Import the namespace for using generic collections like Dictionary

public class Solution // Define a public class named Solution
{
    public int LengthOfLongestSubstring(string s) // Define a public method that returns the length of the longest substring without repeating characters
    {
        int n = s.Length; // Store the length of the input string in variable n
        int maxLength = 0;   // Initialize maxLength to 0 to keep track of the maximum length found
        Dictionary<char, int> charIndexMap = new Dictionary<char, int>(); // Create a dictionary to map characters to their latest index in the string
        int left = 0; // Initialize the left pointer of the sliding window to 0

        for (int right = 0; right < n; right++) // Iterate through the string using the right pointer
        {
            char currentChar = s[right]; // Get the character at the current right pointer

            if (charIndexMap.ContainsKey(currentChar)) // Check if the current character has already been seen
            {
                left = Math.Max(left, charIndexMap[currentChar] + 1); // Move the left pointer to one position after the last occurrence of the current character
            }

            charIndexMap[currentChar] = right; // Update the dictionary with the current character's latest index
            maxLength = Math.Max(maxLength, right - left + 1); // Update maxLength if the current window is larger
        }

        return maxLength; // Return the maximum length found
    }
}

class Program // Define a class named Program
{
    static void Main(string[] args) // Main entry point of the program
    {
        Solution solution = new Solution(); // Create an instance of the Solution class
        Console.WriteLine("Enter a string:"); // Prompt the user to enter a string
        string input = Console.ReadLine() ?? string.Empty; // Read the input string from the console, use empty string if null
        int result = solution.LengthOfLongestSubstring(input); // Call the method to get the length of the longest substring without repeating characters
        Console.WriteLine("Length of longest substring without repeating characters: " + result); // Output the result to the console
    }
}