/**
Given a 2D integer array matrix, return the transpose of matrix.

 The transpose of a matrix is the matrix flipped over its main diagonal,
switching the matrix's row and column indices.




 Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [[1,4,7],[2,5,8],[3,6,9]]


 Example 2:


Input: matrix = [[1,2,3],[4,5,6]]
Output: [[1,4],[2,5],[3,6]]



 Constraints:


 m == matrix.length
 n == matrix[i].length
 1 <= m, n <= 1000
 1 <= m * n <= 10⁵
 -10⁹ <= matrix[i][j] <= 10⁹


 Related Topics Array Matrix Simulation 👍 3310 👎 433

*/

using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace TransposeMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", "[[1,4,7],[2,5,8],[3,6,9]]")]
        public void TransposeMatrixTest(string matrixJson, string expectedResultJson)
        {
            Assert.Equal(expectedResultJson,
                JsonSerializer.Serialize(new Solution().Transpose(Helper.ToIntMatrix(matrixJson))));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[][] Transpose(int[][] matrix)
        {
            var transposed = new int[matrix[0].Length][];
            for (var r = 0; r < matrix.Length; r++)
            {
                for (var c = 0; c < matrix[r].Length; c++)
                {
                    if (transposed[c] is null)
                    {
                        transposed[c] = new int[matrix.Length];
                    }

                    transposed[c][r] = matrix[r][c];
                }
            }

            return transposed;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}