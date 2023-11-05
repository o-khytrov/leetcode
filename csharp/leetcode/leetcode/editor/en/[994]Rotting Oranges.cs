using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//You are given an m x n grid where each cell can have one of three values: 
//
// 
// 0 representing an empty cell, 
// 1 representing a fresh orange, or 
// 2 representing a rotten orange. 
// 
//
// Every minute, any fresh orange that is 4-directionally adjacent to a rotten 
//orange becomes rotten. 
//
// Return the minimum number of minutes that must elapse until no cell has a 
//fresh orange. If this is impossible, return -1. 
//
// 
// Example 1: 
// 
// 
//Input: grid = [[2,1,1],[1,1,0],[0,1,1]]
//Output: 4
// 
//
// Example 2: 
//
// 
//Input: grid = [[2,1,1],[0,1,1],[1,0,1]]
//Output: -1
//Explanation: The orange in the bottom left corner (row 2, column 0) is never 
//rotten, because rotting only happens 4-directionally.
// 
//
// Example 3: 
//
// 
//Input: grid = [[0,2]]
//Output: 0
//Explanation: Since there are already no fresh oranges at minute 0, the answer 
//is just 0.
// 
//
// 
// Constraints: 
//
// 
// m == grid.length 
// n == grid[i].length 
// 1 <= m, n <= 10 
// grid[i][j] is 0, 1, or 2. 
// 
//
// Related Topics Array Breadth-First Search Matrix 👍 11892 👎 370

namespace RottingOranges
{
    public class Tests
    {
        [Theory]
        [InlineData("[[2,1,1],[1,1,0],[0,1,1]]", 4)]
        [InlineData("[[0,2]]", 0)]
        public void RottingOrangesTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().OrangesRotting(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private void Transform(int[][] grid, int r, int c, HashSet<(int, int)> rotten, HashSet<(int, int)> fresh)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[r].Length - 1 || c < 0)
            {
                return;
            }

            if (grid[r][c] == 1)
            {
                rotten.Add((r, c));
                fresh.Remove((r, c));
                grid[r][c] = 2;
            }
        }

        public int OrangesRotting(int[][] grid)
        {
            var rotten = new HashSet<(int, int)>();
            var fresh = new HashSet<(int, int)>();
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 2)
                    {
                        rotten.Add((r, c));
                    }

                    if (grid[r][c] == 1)
                    {
                        fresh.Add((r, c));
                    }
                }
            }

            var count = 0;

            var newRotten = new HashSet<(int, int)>();
            while (fresh.Count > 0)
            {
                var initialCount = fresh.Count;
                foreach (var (r, c) in rotten)
                {
                    Transform(grid, r + 1, c, newRotten, fresh);
                    Transform(grid, r - 1, c, newRotten, fresh);
                    Transform(grid, r, c + 1, newRotten, fresh);
                    Transform(grid, r, c - 1, newRotten, fresh);
                }

                rotten.Clear();
                rotten.UnionWith(newRotten);

                if (fresh.Count == initialCount)
                {
                    break;
                }

                count++;
            }

            return fresh.Count > 0 ? -1 : count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}