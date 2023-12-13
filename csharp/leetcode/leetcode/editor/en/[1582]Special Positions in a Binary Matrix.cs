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
using System.Collections.Generic;
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
        public int NumSpecial(int[][] mat)
        {
            var rowMap = new Dictionary<int, int>();
            var colMap = new Dictionary<int, int>();
            var count = 0;
            for (var r = 0; r < mat.Length; r++)
            {
                for (var c = 0; c < mat[r].Length; c++)
                {
                    var val = mat[r][c];
                    if (val == 1)
                    {
                        if (!rowMap.TryAdd(r, 1))
                        {
                            rowMap[r]++;
                        }

                        if (!colMap.TryAdd(c, 1))
                        {
                            colMap[c]++;
                        }
                    }
                }
            }

            for (var r = 0; r < mat.Length; r++)
            {
                for (var c = 0; c < mat[r].Length; c++)
                {
                    var val = mat[r][c];
                    if (val == 1 && rowMap[r] == 1 && colMap[c] == 1)
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