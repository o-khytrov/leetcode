using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace leetcode.Contests.Split_Array_Into_Maximum_Number_of_Subarrays;

public class Tests
{
    [Theory]
    [InlineData("[1,0,2,0,1,2]", 3)]
    [InlineData("[5,7,1,3]", 1)]
    public void MinOperationsTest(string numsJson, int expectedResult)
    {
        var nums = JsonSerializer.Deserialize<int[]>(numsJson) ?? throw new ArgumentException("Invalid json");
        Assert.Equal(expectedResult, new Solution().MaxSubarrays(nums));
    }
}

public class Solution
{
    public int MaxSubarrays(int[] nums)
    {
        var minScore = Int32.MaxValue;
        for (int i = 0; i < nums.Length; i++)
        {
            var score = nums[i];
            for (int j = i + 1; j < nums.Length; j++)
            {
                score &= nums[j];
                if (score < minScore)
                {
                    minScore = score;
                }
            }
        }
    }
}