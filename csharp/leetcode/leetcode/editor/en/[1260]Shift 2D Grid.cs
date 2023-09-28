/**
Given a 2D grid of size m x n and an integer k. You need to shift the grid k
times.

 In one shift operation:


 Element at grid[i][j] moves to grid[i][j + 1].
 Element at grid[i][n - 1] moves to grid[i + 1][0].
 Element at grid[m - 1][n - 1] moves to grid[0][0].


 Return the 2D grid after applying shift operation k times.


 Example 1:


Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 1
Output: [[9,1,2],[3,4,5],[6,7,8]]


 Example 2:


Input: grid = [[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]], k = 4
Output: [[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]


 Example 3:


Input: grid = [[1,2,3],[4,5,6],[7,8,9]], k = 9
Output: [[1,2,3],[4,5,6],[7,8,9]]



 Constraints:


 m == grid.length
 n == grid[i].length
 1 <= m <= 50
 1 <= n <= 50
 -1000 <= grid[i][j] <= 1000
 0 <= k <= 100


 Related Topics Array Matrix Simulation 👍 1675 👎 333

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace Shift2DGrid
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", 1, "[[9,1,2],[3,4,5],[6,7,8]]")]
        [InlineData("[[3,8,1,9],[19,7,2,5],[4,6,11,10],[12,0,21,13]]", 4,
            "[[12,0,21,13],[3,8,1,9],[19,7,2,5],[4,6,11,10]]")]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", 9,
            "[[1,2,3],[4,5,6],[7,8,9]]")]
        public void Shift2DGridTest(string gridJson, int k, string expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().ShiftGrid(grid, k)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<IList<int>> ShiftGrid(int[][] grid, int k)
        {
            for (var i = 0; i < k; i++)
            {
                var tmp = grid[^1][^1];

                for (var r = 0; r < grid.Length; r++)
                {
                    for (var c = 0; c < grid[r].Length; c++)
                    {
                        (grid[r][c], tmp) = (tmp, grid[r][c]);
                    }
                }
            }

            return grid;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}