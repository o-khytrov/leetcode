/**
Given an m x n matrix mat, return an array of all the elements of the array in
a diagonal order.


 Example 1:


Input: mat = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,4,7,5,3,6,8,9]


 Example 2:


Input: mat = [[1,2],[3,4]]
Output: [1,2,3,4]



 Constraints:


 m == mat.length
 n == mat[i].length
 1 <= m, n <= 10⁴
 1 <= m * n <= 10⁴
 -10⁵ <= mat[i][j] <= 10⁵


 Related Topics Array Matrix Simulation 👍 3186 👎 638

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace DiagonalTraverse
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", "[1,2,4,7,5,3,6,8,9]")]
        [InlineData("[[1,2],[3,4]]", "[1,2,3,4]")]
        [InlineData("[[2,5],[8,4],[0,-1]]", "[2,5,8,0,4,-1]")]
        [InlineData("[[1,2,3,4],[5,6,7,8],[9,10,11,12],[13,14,15,16]]", "[1,2,5,9,6,3,4,7,10,13,14,11,8,12,15,16]")]
        public void DiagonalTraverseTest(string matrixJson, string expectedResultJson)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson) ??
                         throw new ArgumentException("Invalid Json");

            var result = new Solution().FindDiagonalOrder(matrix);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] FindDiagonalOrder(int[][] mat)
        {
            var result = new List<int>();

            var d = 0;
            for (int r = 0; r < mat.Length; r++)
            {
                var row = r;
                var col = 0;
                var tmp = new List<int>();
                while (row >= 0 && col < mat[r].Length)
                {
                    tmp.Add(mat[row][col]);
                    col++;
                    row--;
                }

                if (d % 2 != 0)
                {
                    tmp.Reverse();
                }

                result.AddRange(tmp);
                d++;
            }

            for (int c = 1; c < mat[0].Length; c++)
            {
                var row = mat.Length - 1;
                var col = c;
                var tmp = new List<int>();
                while (row >= 0 && col < mat[row].Length)
                {
                    tmp.Add(mat[row][col]);
                    col++;
                    row--;
                }

                if (d % 2 != 0)
                {
                    tmp.Reverse();
                }

                result.AddRange(tmp);
                d++;
            }

            return result.ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}