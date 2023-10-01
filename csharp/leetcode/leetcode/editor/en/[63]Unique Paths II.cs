using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//You are given an m x n integer array grid. There is a robot initially located 
//at the top-left corner (i.e., grid[0][0]). The robot tries to move to the 
//bottom-right corner (i.e., grid[m - 1][n - 1]). The robot can only move either down 
//or right at any point in time. 
//
// An obstacle and space are marked as 1 or 0 respectively in grid. A path that 
//the robot takes cannot include any square that is an obstacle. 
//
// Return the number of possible unique paths that the robot can take to reach 
//the bottom-right corner. 
//
// The testcases are generated so that the answer will be less than or equal to 
//2 * 10⁹. 
//
// 
// Example 1: 
// 
// 
//Input: obstacleGrid = [[0,0,0],[0,1,0],[0,0,0]]
//Output: 2
//Explanation: There is one obstacle in the middle of the 3x3 grid above.
//There are two ways to reach the bottom-right corner:
//1. Right -> Right -> Down -> Down
//2. Down -> Down -> Right -> Right
// 
//
// Example 2: 
// 
// 
//Input: obstacleGrid = [[0,1],[0,0]]
//Output: 1
// 
//
// 
// Constraints: 
//
// 
// m == obstacleGrid.length 
// n == obstacleGrid[i].length 
// 1 <= m, n <= 100 
// obstacleGrid[i][j] is 0 or 1. 
// 
//
// Related Topics Array Dynamic Programming Matrix 👍 8223 👎 481

namespace UniquePathsII
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,0,0],[0,1,0],[0,0,0]]", 2)]
        [InlineData("[[0,1],[0,0]]", 1)]
        [InlineData("[[0,0],[0,1]]", 0)]
        public void UniquePathsIiTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");

            Assert.Equal(expectedResult, new Solution().UniquePathsWithObstacles(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<(int, int), int> _memo;

        public Solution()
        {
            _memo = new Dictionary<(int, int), int>();
        }

        private int GetUniquePathsFrom(int[][] grid, int r, int c)
        {
            if (r == grid.Length - 1 && c == grid[0].Length - 1)
            {
                return grid[r][c] == 1 ? 0 : 1;
            }

            if (grid[r][c] == 1)
            {
                return 0;
            }

            if (r == grid.Length - 1)
            {
                return GetUniquePathsFrom(grid, r, c + 1);
            }

            if (c == grid[0].Length - 1)
            {
                return GetUniquePathsFrom(grid, r + 1, c);
            }

            var memoKey = (r, c);

            var downPaths = _memo.ContainsKey((r + 1, c)) ? _memo[(r + 1, c)] : GetUniquePathsFrom(grid, r + 1, c);
            var rightPaths = _memo.ContainsKey((r, c + 1)) ? _memo[(r, c + 1)] : GetUniquePathsFrom(grid, r, c + 1);
            _memo[memoKey] = downPaths + rightPaths;
            return _memo[memoKey];
        }

        public int UniquePathsWithObstacles(int[][] obstacleGrid)
        {
            return GetUniquePathsFrom(obstacleGrid, 0, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}