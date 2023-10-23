/**
You are given an n x n grid where we place some 1 x 1 x 1 cubes that are axis-
aligned with the x, y, and z axes.

 Each value v = grid[i][j] represents a tower of v cubes placed on top of the
cell (i, j).

 We view the projection of these cubes onto the xy, yz, and zx planes.

 A projection is like a shadow, that maps our 3-dimensional figure to a 2-
dimensional plane. We are viewing the "shadow" when looking at the cubes from the top,
 the front, and the side.

 Return the total area of all three projections.


 Example 1:


Input: grid = [[1,2],[3,4]]
Output: 17
Explanation: Here are the three projections ("shadows") of the shape made with
each axis-aligned plane.


 Example 2:


Input: grid = [[2]]
Output: 5


 Example 3:


Input: grid = [[1,0],[0,2]]
Output: 8



 Constraints:


 n == grid.length == grid[i].length
 1 <= n <= 50
 0 <= grid[i][j] <= 50


 Related Topics Array Math Geometry Matrix 👍 544 👎 1378

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace ProjectionAreaOf3DShapes
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2],[3,4]]", 17)]
        [InlineData("[[2]]", 5)]
        [InlineData("[[1,0],[0,2]]", 8)]
        public void ProjectionAreaOf3DShapesTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().ProjectionArea(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int ProjectionArea(int[][] grid)
        {
            var projectionArea = 0;
            var topProjection = 0;
            var rowProjection = 0;
            var columnProjections = new int[grid[0].Length];
            for (var r = 0; r < grid.Length; r++)
            {
                var maxInRow = 0;
                for (var c = 0; c < grid[r].Length; c++)
                {
                    if (grid[r][c] > 0)
                    {
                        topProjection++;
                    }

                    maxInRow = Math.Max(maxInRow, grid[r][c]);
                    columnProjections[c] = Math.Max(columnProjections[c], grid[r][c]);
                }

                rowProjection += maxInRow;
            }

            projectionArea = rowProjection + topProjection + columnProjections.Sum();
            return projectionArea;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}