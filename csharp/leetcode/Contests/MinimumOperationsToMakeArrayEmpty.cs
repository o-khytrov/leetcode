using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace leetcode.Contests.MinimumOperationsToMakeArrayEmpty;

public class Tests
{
    [Theory]
    [InlineData("[2,3,3,2,2,4,2,3,4]", 4)]
    [InlineData("[2,1,2,2,3,3]", -1)]
    [InlineData("[14,12,14,14,12,14,14,12,12,12,12,14,14,12,14,14,14,12,12]", 7)]
    public void MinOperationsTest(string numsJson, int expectedResult)
    {
        var nums = JsonSerializer.Deserialize<int[]>(numsJson) ?? throw new ArgumentException("Invalid json");
        Assert.Equal(expectedResult, new Solution().MinOperations(nums));
    }
}

public class Solution
{
    public int MinOperations(int[] nums)
    {
        var count = 0;
        var map = new Dictionary<int, int>();
        for (int i = 0; i < nums.Length; i++)
        {
            var n = nums[i];
            if (!map.TryAdd(n, 1))
            {
                map[n]++;
            }
        }

        foreach (var kvp in map)
        {
            var val = kvp.Value;
            var operations = Reduce(val);
            if (operations == -1)
            {
                return -1;
            }

            count += operations;
        }

        return count;
    }

    private int Reduce(int n)
    {
        if (n < 2)
        {
            return -1;
        }

        if (n is 3 or 2)
        {
            return 1;
        }

        if (n == 4)
        {
            return 2;
        }

        if (n % 3 == 0)
        {
            return n / 3;
        }

        //5
        //8
        if (n % 3 == 2)
        {
            return n / 3 + 1;
        }

        //7 3+2+2 
        if (n % 3 == 1)
        {
            return n / 3 - 1 + 2;
        }

        return -1;
    }
}