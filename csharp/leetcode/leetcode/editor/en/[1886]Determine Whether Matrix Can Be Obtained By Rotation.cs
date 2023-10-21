/**
Given two n x n binary matrices mat and target, return true if it is possible
to make mat equal to target by rotating mat in 90-degree increments, or false
otherwise.


 Example 1:


Input: mat = [[0,1],[1,0]], target = [[1,0],[0,1]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise to make mat equal target.


 Example 2:


Input: mat = [[0,1],[1,1]], target = [[1,0],[0,1]]
Output: false
Explanation: It is impossible to make mat equal to target by rotating mat.


 Example 3:


Input: mat = [[0,0,0],[0,1,0],[1,1,1]], target = [[1,1,1],[0,1,0],[0,0,0]]
Output: true
Explanation: We can rotate mat 90 degrees clockwise two times to make mat equal
target.



 Constraints:


 n == mat.length == target.length
 n == mat[i].length == target[i].length
 1 <= n <= 10
 mat[i][j] and target[i][j] are either 0 or 1.


 Related Topics Array Matrix 👍 1346 👎 106

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace DetermineWhetherMatrixCanBeObtainedByRotation
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,1],[1,0]]", "[[1,0],[0,1]]", true)]
        [InlineData("[[0,1],[1,1]]", "[[1,0],[0,1]]", false)]
        [InlineData("[[0,0,0],[0,0,1],[0,0,1]]", "[[0,0,0],[0,0,1],[0,0,1]]", true)]
        public void DetermineWhetherMatrixCanBeObtainedByRotationTest(
            string matrix1Json,
            string matrix2Json,
            bool expectedResult)
        {
            var matrix1 = JsonSerializer.Deserialize<int[][]>(matrix1Json) ??
                          throw new ArgumentException("Invalid json");
            var matrix2 = JsonSerializer.Deserialize<int[][]>(matrix2Json) ??
                          throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().FindRotation(matrix1, matrix2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool AreSame(IReadOnlyList<int[]> mat, IReadOnlyList<int[]> target)
        {
            for (int r = 0; r < mat.Count; r++)
            {
                for (int c = 0; c < mat[r].Length; c++)
                {
                    if (mat[r][c] != target[r][c])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        private int[][] RotateMatrix(int[][] mat)
        {
            var rotated = new int[mat[0].Length][];
            var newCol = 0;
            var newRow = 0;
            for (var col = mat.Length - 1; col >= 0; col--)
            {
                newCol = 0;
                rotated[newRow] = new int[mat.Length];
                foreach (var row in mat)
                {
                    rotated[newRow][newCol] = row[col];
                    newCol++;
                }

                newRow++;
            }

            return rotated;
        }

        public bool FindRotation(int[][] mat, int[][] target)
        {
            if (AreSame(mat, target))
            {
                return true;
            }

            var rotationCount = 3;
            var source = mat;

            for (var r = 0; r < rotationCount; r++)
            {
                var rotated = RotateMatrix(source);
                if (AreSame(rotated, target))
                {
                    return true;
                }

                source = rotated;
            }


            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}