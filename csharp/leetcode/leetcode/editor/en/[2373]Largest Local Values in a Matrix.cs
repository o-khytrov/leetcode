/**
You are given an n x n integer matrix grid.

 Generate an integer matrix maxLocal of size (n - 2) x (n - 2) such that:


 maxLocal[i][j] is equal to the largest value of the 3 x 3 matrix in grid
centered around row i + 1 and column j + 1.


 In other words, we want to find the largest value in every contiguous 3 x 3
matrix in grid.

 Return the generated matrix.


 Example 1:


Input: grid = [[9,9,8,1],[5,6,2,6],[8,2,6,4],[6,2,2,2]]
Output: [[9,9],[8,6]]
Explanation: The diagram above shows the original matrix and the generated
matrix.
Notice that each value in the generated matrix corresponds to the largest value
of a contiguous 3 x 3 matrix in grid.

 Example 2:


Input: grid = [[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]]
Output: [[2,2,2],[2,2,2],[2,2,2]]
Explanation: Notice that the 2 is contained within every contiguous 3 x 3
matrix in grid.



 Constraints:


 n == grid.length == grid[i].length
 3 <= n <= 100
 1 <= grid[i][j] <= 100


 Related Topics Array Matrix 👍 649 👎 72

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace LargestLocalValuesInAMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[9,9,8,1],[5,6,2,6],[8,2,6,4],[6,2,2,2]]", "[[9,9],[8,6]]")]
        [InlineData("[[1,1,1,1,1],[1,1,1,1,1],[1,1,2,1,1],[1,1,1,1,1],[1,1,1,1,1]]", "[[2,2,2],[2,2,2],[2,2,2]]")]
        public void LargestLocalValuesInAMatrixTest(string gridJson, string expectedResultJson)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().LargestLocal(grid)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetMaxFromArea(int[][] grid, int r, int c, int[] tmp)
        {
            r++;
            c++;
            var center = grid[r][c];
            var top = grid[r - 1][c];
            var topLeft = grid[r - 1][c - 1];
            var topRight = grid[r - 1][c + 1];
            var down = grid[r + 1][c];
            var downLeft = grid[r + 1][c - 1];
            var downRight = grid[r + 1][c + 1];
            var right = grid[r][c + 1];
            var left = grid[r][c - 1];

            tmp[0] = center;
            tmp[1] = top;
            tmp[2] = topLeft;
            tmp[3] = topRight;
            tmp[4] = down;
            tmp[5] = downLeft;
            tmp[6] = downRight;
            tmp[7] = right;
            tmp[8] = left;
            return tmp.Max();
        }

        public int[][] LargestLocal(int[][] grid)
        {
            var result = new int[grid.Length - 2][];

            var tmp = new int[9];
            for (var i = 0; i < result.Length; i++)
            {
                result[i] = new int[grid.Length - 2];
                for (var j = 0; j < result[i].Length; j++)
                {
                    result[i][j] = GetMaxFromArea(grid, i, j, tmp);
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}