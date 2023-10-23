/**
Given an m x n matrix, return all elements of the matrix in spiral order.


 Example 1:


Input: matrix = [[1,2,3],[4,5,6],[7,8,9]]
Output: [1,2,3,6,9,8,7,4,5]


 Example 2:


Input: matrix = [[1,2,3,4],[5,6,7,8],[9,10,11,12]]
Output: [1,2,3,4,8,12,11,10,9,5,6,7]



 Constraints:


 m == matrix.length
 n == matrix[i].length
 1 <= m, n <= 10
 -100 <= matrix[i][j] <= 100


 Related Topics Array Matrix Simulation 👍 13675 👎 1189

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace SpiralMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,3],[4,5,6],[7,8,9]]", "[1,2,3,6,9,8,7,4,5]")]
        [InlineData("[[7],[9],[6]]", "[7,9,6]")]
        [InlineData("[[2,3,4],[5,6,7],[8,9,10],[11,12,13],[14,15,16]]", "[2,3,4,7,10,13,16,15,14,11,8,5,6,9,12]")]
        public void SpiralMatrixTest(string matrixJson, string expectedResultJson)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson) ??
                         throw new ArgumentException("Invalid json");

            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().SpiralOrder(matrix)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<int> SpiralOrder(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0];
            }

            if (matrix[0].Length == 1)
            {
                return matrix.Select(x => x[0]).ToList();
            }

            var result = new List<int>();

            if (matrix == null || matrix.Length == 0)
            {
                return result;
            }

            int rows = matrix.Length, cols = matrix[0].Length;
            int left = 0, right = cols - 1, top = 0, bottom = rows - 1;

            while (left <= right && top <= bottom)
            {
                for (int i = left; i <= right; i++)
                {
                    result.Add(matrix[top][i]);
                }

                top++;

                for (int i = top; i <= bottom; i++)
                {
                    result.Add(matrix[i][right]);
                }

                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result.Add(matrix[bottom][i]);
                    }

                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result.Add(matrix[i][left]);
                    }

                    left++;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}