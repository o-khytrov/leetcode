/**
Given an m x n 2D binary grid grid which represents a map of '1's (land) and '0
's (water), return the number of islands.

 An island is surrounded by water and is formed by connecting adjacent lands
horizontally or vertically. You may assume all four edges of the grid are all
surrounded by water.


 Example 1:


Input: grid = [
  ["1","1","1","1","0"],
  ["1","1","0","1","0"],
  ["1","1","0","0","0"],
  ["0","0","0","0","0"]
]
Output: 1


 Example 2:


Input: grid = [
  ["1","1","0","0","0"],
  ["1","1","0","0","0"],
  ["0","0","1","0","0"],
  ["0","0","0","1","1"]
]
Output: 3



 Constraints:


 m == grid.length
 n == grid[i].length
 1 <= m, n <= 300
 grid[i][j] is '0' or '1'.


 Related Topics Array Depth-First Search Breadth-First Search Union Find Matrix
👍 21424 👎 464

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace NumberOfIslands
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[ [\"1\",\"1\",\"1\",\"1\",\"0\"], [\"1\",\"1\",\"0\",\"1\",\"0\"], [\"1\",\"1\",\"0\",\"0\",\"0\"], [\"0\",\"0\",\"0\",\"0\",\"0\"] ]",
            1)]
        [InlineData(
            "[ [\"1\",\"1\",\"0\",\"0\",\"0\"], [\"1\",\"1\",\"0\",\"0\",\"0\"], [\"0\",\"0\",\"1\",\"0\",\"0\"], [\"0\",\"0\",\"0\",\"1\",\"1\"] ]",
            3)]
        public void NumberOfIslandsTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<char[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().NumIslands(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private HashSet<(int, int)> _visited = new();

        private void Fill(char[][] grid, int r, int c)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[0].Length - 1 || c < 0)
            {
                return;
            }

            if (grid[r][c] != '1')
            {
                return;
            }

            _visited.Add((r, c));
            grid[r][c] = '2';
            Fill(grid, r + 1, c);
            Fill(grid, r - 1, c);
            Fill(grid, r, c + 1);
            Fill(grid, r, c - 1);
        }

        public int NumIslands(char[][] grid)
        {
            var count = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] == '1')
                    {
                        if (!_visited.Contains((r, c)))
                        {
                            Fill(grid, r, c);
                            count++;
                        }
                    }
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}