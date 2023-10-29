/**
You are given an n x n grid where you have placed some 1 x 1 x 1 cubes. Each
value v = grid[i][j] represents a tower of v cubes placed on top of cell (i, j).

 After placing these cubes, you have decided to glue any directly adjacent
cubes to each other, forming several irregular 3D shapes.

 Return the total surface area of the resulting shapes.

 Note: The bottom face of each shape counts toward its surface area.


 Example 1:


Input: grid = [[1,2],[3,4]]
Output: 34


 Example 2:


Input: grid = [[1,1,1],[1,0,1],[1,1,1]]
Output: 32


 Example 3:


Input: grid = [[2,2,2],[2,1,2],[2,2,2]]
Output: 46



 Constraints:


 n == grid.length == grid[i].length
 1 <= n <= 50
 0 <= grid[i][j] <= 50


 Related Topics Array Math Geometry Matrix 👍 527 👎 724

*/

using System;
using System.Text.Json;
using Xunit;

namespace SurfaceAreaOf3DShapes
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2],[3,4]]", 34)]
        [InlineData("[[1,1,1],[1,0,1],[1,1,1]]", 32)]
        [InlineData("[[2,2,2],[2,1,2],[2,2,2]]", 46)]
        public void SurfaceAreaOf3DShapesTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().SurfaceArea(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetNeighbour(int[][] grid, int r, int c)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[r].Length - 1 || c < 0)
            {
                return 0;
            }

            return grid[r][c];
        }

        public int SurfaceArea(int[][] grid)
        {
            var area = 0;
            for (int r = 0; r < grid.Length; r++)
            {
                for (int c = 0; c < grid[r].Length; c++)
                {
                    var height = grid[r][c];
                    if (height > 0)
                    {
                        var up = GetNeighbour(grid, r - 1, c);
                        var down = GetNeighbour(grid, r + 1, c);
                        var left = GetNeighbour(grid, r, c - 1);
                        var right = GetNeighbour(grid, r, c + 1);
                        var totalArea = height * 4 + 2;
                        totalArea -= Math.Min(height, right);
                        totalArea -= Math.Min(height, left);
                        totalArea -= Math.Min(height, up);
                        totalArea -= Math.Min(height, down);
                        area += totalArea;
                    }
                }
            }

            return area;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}