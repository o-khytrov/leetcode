/**
You are given a 0-indexed m x n integer matrix mat and an integer k. You have
to cyclically right shift odd indexed rows k times and cyclically left shift even
indexed rows k times.

 Return true if the initial and final matrix are exactly the same and false
otherwise.


 Example 1:


Input: mat = [[1,2,1,2],[5,5,5,5],[6,3,6,3]], k = 2
Output: true
Explanation:


Initially, the matrix looks like the first figure.
Second figure represents the state of the matrix after one right and left
cyclic shifts to even and odd indexed rows.
Third figure is the final state of the matrix after two cyclic shifts which is
similar to the initial matrix.
Therefore, return true.


 Example 2:


Input: mat = [[2,2],[2,2]], k = 3
Output: true
Explanation: As all the values are equal in the matrix, even after performing
cyclic shifts the matrix will remain the same. Therefeore, we return true.


 Example 3:


Input: mat = [[1,2]], k = 1
Output: false
Explanation: After one cyclic shift, mat = [[2,1]] which is not equal to the
initial matrix. Therefore we return false.



 Constraints:


 1 <= mat.length <= 25
 1 <= mat[i].length <= 25
 1 <= mat[i][j] <= 25
 1 <= k <= 50


 Related Topics Array Math Matrix Simulation 👍 37 👎 34

*/

using System;
using leetcode.CommonClasses;
using Xunit;

namespace MatrixSimilarityAfterCyclicShifts
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,1,2],[5,5,5,5],[6,3,6,3]]", 2, true)]
        [InlineData("[[2,2],[2,2]]", 3, true)]
        [InlineData("[[1,2,3,4,5],[1,2,3,4,5]]", 3, false)]
        public void MatrixSimilarityAfterCyclicShiftsTest(string matJson, int k, bool expectedResult)
        {
            var matrix = Helper.ToIntMatrix(matJson);
            Assert.Equal(expectedResult, new Solution().AreSimilar(matrix, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetShifted(int[] array, int index, int shift)
        {
            var maxIndex = array.Length - 1;
            var shiftedIndex = index + shift;
            if (shiftedIndex > maxIndex)
            {
                shiftedIndex -= maxIndex + 1;
            }

            if (shiftedIndex < 0)
            {
                shiftedIndex = maxIndex + 1 - Math.Abs(shiftedIndex);
            }

            return array[shiftedIndex];
        }

        public bool AreSimilar(int[][] mat, int k)
        {
            var n = mat[0].Length;
            var shift = k % n;
            for (var r = 0; r < mat.Length; r++)
            {
                for (var c = 0; c < n; c++)
                {
                    var isEven = r % 2 == 0;
                    if (mat[r][c] != GetShifted(mat[r], c, isEven ? shift * -1 : shift))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}