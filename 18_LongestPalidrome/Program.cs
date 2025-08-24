using System;
using System.Collections.Generic;

class Solution
{
    public int LongestPalindrome(string s)
    {
        Dictionary<char, int> freq = new Dictionary<char, int>();
        
        // Count frequencies
        foreach (char c in s)
        {
            if (freq.ContainsKey(c))
                freq[c]++;
            else
                freq[c] = 1;
        }

        int length = 0;
        bool hasOdd = false;

        foreach (int count in freq.Values)
        {
            if (count % 2 == 0)
                length += count;       // use all even counts
            else
            {
                length += count - 1;   // use pairs
                hasOdd = true;         // remember odd char for middle
            }
        }

        if (hasOdd) length += 1; // add one odd character to center

        return length;
    }

    static void Main()
    {
        Solution sol = new Solution();
        Console.WriteLine(sol.LongestPalindrome("abccccdd")); // Output: 7
        Console.WriteLine(sol.LongestPalindrome("a"));        // Output: 1
        Console.WriteLine(sol.LongestPalindrome("Aa"));       // Output: 1
    }
}
