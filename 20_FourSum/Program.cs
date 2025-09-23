using System;
using System.Collections.Generic;

public class Solution {
    public IList<IList<int>> FourSum(int[] nums, int target) {
        Array.Sort(nums);
        var res = new List<IList<int>>();
        int n = nums.Length;

        for (int i = 0; i < n - 3; i++) {
            if (i > 0 && nums[i] == nums[i - 1]) continue; // Skip duplicates for i

            for (int j = i + 1; j < n - 2; j++) {
                if (j > i + 1 && nums[j] == nums[j - 1]) continue; // Skip duplicates for j

                int left = j + 1, right = n - 1;
                while (left < right) {
                    long sum = (long)nums[i] + nums[j] + nums[left] + nums[right];

                    if (sum == target) {
                        res.Add(new List<int> { nums[i], nums[j], nums[left], nums[right] });

                        // Skip duplicates for left
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        // Skip duplicates for right
                        while (left < right && nums[right] == nums[right - 1]) right--;

                        left++;
                        right--;
                    }
                    else if (sum < target) {
                        left++;
                    }
                    else {
                        right--;
                    }
                }
            }
        }

        return res;
    }
}
public class Program {
    public static void Main() {
        var sol = new Solution();

        var result1 = sol.FourSum(new int[] { 1, 0, -1, 0, -2, 2 }, 0);
        PrintResult(result1);
        // Output: [-2,-1,1,2], [-2,0,0,2], [-1,0,0,1]

        var result2 = sol.FourSum(new int[] { 2, 2, 2, 2, 2 }, 8);
        PrintResult(result2);
        // Output: [2,2,2,2]
    }

    private static void PrintResult(IList<IList<int>> res) {
        foreach (var quad in res) {
            Console.WriteLine("[" + string.Join(",", quad) + "]");
        }
    }
}
