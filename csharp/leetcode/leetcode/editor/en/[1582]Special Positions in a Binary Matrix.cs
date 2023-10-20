/**
Given an m x n binary matrix mat, return the number of special positions in mat.


 A position (i, j) is called special if mat[i][j] == 1 and all other elements
in row i and column j are 0 (rows and columns are 0-indexed).


 Example 1:


Input: mat = [[1,0,0],[0,0,1],[1,0,0]]
Output: 1
Explanation: (1, 2) is a special position because mat[1][2] == 1 and all other
elements in row 1 and column 2 are 0.


 Example 2:


Input: mat = [[1,0,0],[0,1,0],[0,0,1]]
Output: 3
Explanation: (0, 0), (1, 1) and (2, 2) are special positions.



 Constraints:


 m == mat.length
 n == mat[i].length
 1 <= m, n <= 100
 mat[i][j] is either 0 or 1.


 Related Topics Array Matrix 👍 702 👎 25

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace SpecialPositionsInABinaryMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,0,0],[0,0,1],[1,0,0]]", 1)]
        [InlineData("[[1,0,0],[0,1,0],[0,0,1]]", 3)]
        [InlineData("[[0,0,0,0,0,1,0,0],[0,0,0,0,1,0,0,1],[0,0,0,0,1,0,0,0],[1,0,0,0,1,0,0,0],[0,0,1,1,0,0,0,0]]", 1)]
        public void SpecialPositionsInABinaryMatrixTest(string matrixJson, int expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().NumSpecial(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int CheckRow(int[] row)
        {
            var found = 0;
            var index = -1;
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == 1)
                {
                    if (index >= 0)
                    {
                        return -1;
                    }

                    index = i;
                }
            }

            return index;
        }

        public int NumSpecial(int[][] mat)
        {
            var count = 0;
            for (int r = 0; r < mat.Length; r++)
            {
                var i = CheckRow(mat[r]);
                if (i != -1)
                {
                    var sum = 0;
                    for (int j = 0; j < mat.Length; j++)
                    {
                        sum += mat[j][i];
                    }

                    if (sum == 1)
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}