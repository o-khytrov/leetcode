/**
Given an m x n integer matrix matrix, if an element is 0, set its entire row
and column to 0's.

 You must do it in place.


 Example 1:


Input: matrix = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[1,0,1],[0,0,0],[1,0,1]]


 Example 2:


Input: matrix = [[0,1,2,0],[3,4,5,2],[1,3,1,5]]
Output: [[0,0,0,0],[0,4,5,0],[0,3,1,0]]



 Constraints:


 m == matrix.length
 n == matrix[0].length
 1 <= m, n <= 200
 -2³¹ <= matrix[i][j] <= 2³¹ - 1



 Follow up:


 A straightforward solution using O(mn) space is probably a bad idea.
 A simple improvement uses O(m + n) space, but still not the best solution.
 Could you devise a constant space solution?


 Related Topics Array Hash Table Matrix 👍 13355 👎 661

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace SetMatrixZeroes
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,1,1],[1,0,1],[1,1,1]]", "[[1,0,1],[0,0,0],[1,0,1]]")]
        [InlineData("[[0,1,2,0],[3,4,5,2],[1,3,1,5]]", "[[0,0,0,0],[0,4,5,0],[0,3,1,0]]")]
        public void SetMatrixZeroesTest(string matrixJson, string expectedResultJson)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid Json");
            new Solution().SetZeroes(matrix);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private void ZeroRow(int[][] matrix, int r)
        {
            for (int c = 0; c < matrix[r].Length; c++)
            {
                matrix[r][c] = 0;
            }
        }

        private void ZeroColumn(int[][] matrix, int c)
        {
            for (int r = 0; r < matrix.Length; r++)
            {
                matrix[r][c] = 0;
            }
        }

        public void SetZeroes(int[][] matrix)
        {
            var columns = new HashSet<int>();
            var rows = new HashSet<int>();
            for (int r = 0; r < matrix.Length; r++)
            {
                for (int c = 0; c < matrix[r].Length; c++)
                {
                    if (matrix[r][c] == 0)
                    {
                        columns.Add(c);
                        rows.Add(r);
                    }
                }
            }

            foreach (var row in rows)
            {
                ZeroRow(matrix, row);
            }

            foreach (var column in columns)
            {
                ZeroColumn(matrix, column);
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}