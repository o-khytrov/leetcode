using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;
using Xunit.Sdk;

//You are given an n x n binary matrix grid where 1 represents land and 0 
//represents water. 
//
// An island is a 4-directionally connected group of 1's not connected to any 
//other 1's. There are exactly two islands in grid. 
//
// You may change 0's to 1's to connect the two islands to form one island. 
//
// Return the smallest number of 0's you must flip to connect the two islands. 
//
// 
// Example 1: 
//
// 
//Input: grid = [[0,1],[1,0]]
//Output: 1
// 
//
// Example 2: 
//
// 
//Input: grid = [[0,1,0],[0,0,0],[0,0,1]]
//Output: 2
// 
//
// Example 3: 
//
// 
//Input: grid = [[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]
//Output: 1
// 
//
// 
// Constraints: 
//
// 
// n == grid.length == grid[i].length 
// 2 <= n <= 100 
// grid[i][j] is either 0 or 1. 
// There are exactly two islands in grid. 
// 
//
// Related Topics Array Depth-First Search Breadth-First Search Matrix 👍 5135 ?
//? 191

namespace ShortestBridge
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,1],[1,0]]", 1)]
        [InlineData("[[0,1,0],[0,0,0],[0,0,1]]", 2)]
        [InlineData("[[1,1,1,1,1],[1,0,0,0,1],[1,0,1,0,1],[1,0,0,0,1],[1,1,1,1,1]]", 1)]
        [InlineData("[[0,1,0,0,0,0],[0,1,1,1,0,0],[0,0,0,0,0,0],[0,0,0,0,0,0],[0,0,0,0,0,0],[1,1,0,0,0,0]]", 3)]
        public void ShortestBridgeTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().ShortestBridge(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int ShortestBridge(int[][] grid)
        {
            var island1 = new HashSet<(int, int)>();
            var island2 = new HashSet<(int, int)>();
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        if (island1.Count == 0)
                        {
                            Explore(grid, r, c, island1);
                            continue;
                        }

                        if (!island1.Contains((r, c)) && island2.Count == 0)
                        {
                            Explore(grid, r, c, island2);
                            goto exit;
                        }
                    }
                }
            }

            exit:
            var minDistance = int.MaxValue;
            foreach (var point in island1)
            {
                foreach (var remotePoint in island2)
                {
                    var distance = Math.Abs(point.Item1 - remotePoint.Item1) +
                                   Math.Abs(point.Item2 - remotePoint.Item2)-1;
                    minDistance = Math.Min(distance, minDistance);
                }
            }

            return minDistance;
        }


        private void Explore(int[][] grid, int r, int c, HashSet<(int, int)> visited)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[0].Length - 1 || c < 0)
            {
                return;
            }

            if (grid[r][c] == 0)
            {
                return;
            }

            if (visited.Contains((r, c)))
            {
                return;
            }

            visited.Add((r, c));
            Explore(grid, r + 1, c, visited);
            Explore(grid, r - 1, c, visited);
            Explore(grid, r, c + 1, visited);
            Explore(grid, r, c - 1, visited);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}