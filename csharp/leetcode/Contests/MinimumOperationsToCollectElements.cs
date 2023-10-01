using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace leetcode.Contests.MinimumOperationsToCollectElements;

public class Tests
{
    [Theory]
    [InlineData("[3,1,5,4,2]", 2, 4)]
    [InlineData("[3,1,5,4,2]", 5, 5)]
    [InlineData("[3,2,5,3,1]", 3, 4)]
    public void MinOperationsTest(string numsJson, int k, int expectedResult)
    {
        var nums = JsonSerializer.Deserialize<List<int>>(numsJson) ?? throw new ArgumentException("Invalid json");
        Assert.Equal(expectedResult, new Solution().MinOperations(nums, k));
    }
}

public class Solution
{
    public int MinOperations(IList<int> nums, int k)
    {
        var set = new HashSet<int>();
        var count = 0;
        for (int i = nums.Count - 1; i >= 0; i--)
        {
            count++;
            var n = nums[i];
            if (n <= k)
            {
                set.Add(n);
            }

            if (set.Count == k)
            {
                break;
            }
        }

        return count;
    }
}