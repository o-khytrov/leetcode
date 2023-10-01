using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//Given a m x n grid filled with non-negative numbers, find a path from top 
//left to bottom right, which minimizes the sum of all numbers along its path. 
//
// Note: You can only move either down or right at any point in time. 
//
// 
// Example 1: 
// 
// 
//Input: grid = [[1,3,1],[1,5,1],[4,2,1]]
//Output: 7
//Explanation: Because the path 1 → 3 → 1 → 1 → 1 minimizes the sum.
// 
//
// Example 2: 
//
// 
//Input: grid = [[1,2,3],[4,5,6]]
//Output: 12
// 
//
// 
// Constraints: 
//
// 
// m == grid.length 
// n == grid[i].length 
// 1 <= m, n <= 200 
// 0 <= grid[i][j] <= 200 
// 
//
// Related Topics Array Dynamic Programming Matrix 👍 11716 👎 151

namespace MinimumPathSum
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,3,1],[1,5,1],[4,2,1]]", 7)]
        [InlineData("[[1,2,3],[4,5,6]]", 12)]
        public void MinimumPathSumTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MinPathSum(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<(int, int), int> _memo;

        public Solution()
        {
            _memo = new();
        }

        private int MinPathSumFrom(int[][] grid, int r, int c)
        {
            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                return grid[r][c];
            }

            if (r == grid.Length - 1)
            {
                return grid[r][c] + MinPathSumFrom(grid, r, c + 1);
            }

            if (c == grid[0].Length - 1)
            {
                return grid[r][c] + MinPathSumFrom(grid, r + 1, c);
            }

            var memoKey = (r, c);
            if (_memo.ContainsKey(memoKey))
            {
                return _memo[memoKey];
            }

            var rightPathSum = _memo.ContainsKey((r, c + 1)) ? _memo[(r, c + 1)] : MinPathSumFrom(grid, r, c + 1);
            var downPathSum = _memo.ContainsKey((r + 1, c)) ? _memo[(r + 1, c)] : MinPathSumFrom(grid, r + 1, c);

            _memo[memoKey] = grid[r][c] + Math.Min(rightPathSum, downPathSum);
            return _memo[memoKey];
        }

        public int MinPathSum(int[][] grid)
        {
            return MinPathSumFrom(grid, 0, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}