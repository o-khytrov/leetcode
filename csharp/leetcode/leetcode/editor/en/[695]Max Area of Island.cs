/**
You are given an m x n binary matrix grid. An island is a group of 1's (
representing land) connected 4-directionally (horizontal or vertical.) You may assume
all four edges of the grid are surrounded by water.

 The area of an island is the number of cells with a value 1 in the island.

 Return the maximum area of an island in grid. If there is no island, return 0.



 Example 1:


Input: grid = [[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,
1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,
0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]
Output: 6
Explanation: The answer is not 11, because the island must be connected 4-
directionally.


 Example 2:


Input: grid = [[0,0,0,0,0,0,0,0]]
Output: 0



 Constraints:


 m == grid.length
 n == grid[i].length
 1 <= m, n <= 50
 grid[i][j] is either 0 or 1.


 Related Topics Array Depth-First Search Breadth-First Search Union Find Matrix
👍 9585 👎 198

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MaxAreaOfIsland
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[[0,0,1,0,0,0,0,1,0,0,0,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,1,1,0,1,0,0,0,0,0,0,0,0],[0,1,0,0,1,1,0,0,1,0,1,0,0],[0,1,0,0,1,1,0,0,1,1,1,0,0],[0,0,0,0,0,0,0,0,0,0,1,0,0],[0,0,0,0,0,0,0,1,1,1,0,0,0],[0,0,0,0,0,0,0,1,1,0,0,0,0]]",
            6)]
        [InlineData("[[0,0,0,0,0,0,0,0]]", 0)]
        public void MaxAreaOfIslandTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MaxAreaOfIsland(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private HashSet<(int, int)> _visited = new();

        private int CountArea(int[][] grid, int r, int c)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[0].Length - 1 || c < 0)
            {
                return 0;
            }

            if (_visited.Contains((r, c)))
            {
                return 0;
            }

            _visited.Add((r, c));
            var value = grid[r][c];
            if (value == 0)
            {
                return value;
            }

            value += CountArea(grid, r + 1, c);
            value += CountArea(grid, r - 1, c);
            value += CountArea(grid, r, c + 1);
            value += CountArea(grid, r, c - 1);
            return value;
        }

        public int MaxAreaOfIsland(int[][] grid)
        {
            var maxArea = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (_visited.Contains((r, c)))
                    {
                        continue;
                    }

                    if (grid[r][c] == 1)
                    {
                        maxArea = Math.Max(maxArea, CountArea(grid, r, c));
                    }
                }
            }

            return maxArea;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}