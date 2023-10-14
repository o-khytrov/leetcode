/**
A square matrix is said to be an X-Matrix if both of the following conditions
hold:


 All the elements in the diagonals of the matrix are non-zero.
 All other elements are 0.


 Given a 2D integer array grid of size n x n representing a square matrix,
return true if grid is an X-Matrix. Otherwise, return false.


 Example 1:


Input: grid = [[2,0,0,1],[0,3,1,0],[0,5,2,0],[4,0,0,2]]
Output: true
Explanation: Refer to the diagram above.
An X-Matrix should have the green elements (diagonals) be non-zero and the red
elements be 0.
Thus, grid is an X-Matrix.


 Example 2:


Input: grid = [[5,7,0],[0,3,1],[0,5,0]]
Output: false
Explanation: Refer to the diagram above.
An X-Matrix should have the green elements (diagonals) be non-zero and the red
elements be 0.
Thus, grid is not an X-Matrix.



 Constraints:


 n == grid.length == grid[i].length
 3 <= n <= 100
 0 <= grid[i][j] <= 10⁵


 Related Topics Array Matrix 👍 448 👎 19

*/

using System;
using System.Text.Json;
using Xunit;

namespace CheckIfMatrixIsXMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[2,0,0,1],[0,3,1,0],[0,5,2,0],[4,0,0,2]]", true)]
        [InlineData("[[5,7,0],[0,3,1],[0,5,0]]", false)]
        [InlineData("[[5,0,0,1],[0,4,1,5],[0,5,2,0],[4,1,0,2]]", false)]
        [InlineData("[[2,0,0,0,1],[0,4,0,1,5],[0,0,5,0,0],[0,5,0,2,0],[4,0,0,0,2]]", false)]
        public void CheckIfMatrixIsXMatrixTest(string matrixJson, bool expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().CheckXMatrix(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool CheckXMatrix(int[][] grid)
        {
            var result = true;

            var l = 0;
            var r = grid.Length - 1;
            for (var i = 0; i < grid.Length; i++)
            {
                var left = l + i;
                var right = r - i;
                for (int j = 0; j < grid[i].Length; j++)
                {
                    if (j == left || j == right)
                    {
                        if (grid[i][j] == 0)
                        {
                            return false;
                        }
                    }
                    else
                    {
                        if (grid[i][j] != 0)
                        {
                            return false;
                        }
                    }
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}