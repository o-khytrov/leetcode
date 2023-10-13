/**
Given an m x n matrix of distinct numbers, return all lucky numbers in the
matrix in any order.

 A lucky number is an element of the matrix such that it is the minimum element
in its row and maximum in its column.


 Example 1:


Input: matrix = [[3,7,8],[9,11,13],[15,16,17]]
Output: [15]
Explanation: 15 is the only lucky number since it is the minimum in its row and
the maximum in its column.


 Example 2:


Input: matrix = [[1,10,4,2],[9,3,8,7],[15,16,17,12]]
Output: [12]
Explanation: 12 is the only lucky number since it is the minimum in its row and
the maximum in its column.


 Example 3:


Input: matrix = [[7,8],[1,2]]
Output: [7]
Explanation: 7 is the only lucky number since it is the minimum in its row and
the maximum in its column.



 Constraints:


 m == mat.length
 n == mat[i].length
 1 <= n, m <= 50
 1 <= matrix[i][j] <= 10⁵.
 All elements in the matrix are distinct.


 Related Topics Array Matrix 👍 1586 👎 80

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace LuckyNumbersInAMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,10,4,2],[9,3,8,7],[15,16,17,12]]", "[12]")]
        [InlineData("[[7,8],[1,2]]", "[7]")]
        [InlineData("[[3,7,8],[9,11,13],[15,16,17]]", "[15]")]
        public void LuckyNumbersInAMatrixTest(string matrixJson, string expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().LuckyNumbers(matrix)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<int> LuckyNumbers(int[][] matrix)
        {
            var colMax = new int[matrix[0].Length];
            var rowMin = new int[matrix.Length];

            for (var i = 0; i < matrix.Length; i++)
            {
                rowMin[i] = matrix[i][0];
                for (var j = 0; j < matrix[i].Length; j++)
                {
                    rowMin[i] = Math.Min(rowMin[i], matrix[i][j]);
                    colMax[j] = Math.Max(colMax[j], matrix[i][j]);
                }
            }

            return colMax.Intersect(rowMin).ToList();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}