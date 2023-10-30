/**
Write an efficient algorithm that searches for a value target in an m x n
integer matrix matrix. This matrix has the following properties:


 Integers in each row are sorted in ascending from left to right.
 Integers in each column are sorted in ascending from top to bottom.



 Example 1:


Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,
21,23,26,30]], target = 5
Output: true


 Example 2:


Input: matrix = [[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,
21,23,26,30]], target = 20
Output: false



 Constraints:


 m == matrix.length
 n == matrix[i].length
 1 <= n, m <= 300
 -10⁹ <= matrix[i][j] <= 10⁹
 All the integers in each row are sorted in ascending order.
 All the integers in each column are sorted in ascending order.
 -10⁹ <= target <= 10⁹


 Related Topics Array Binary Search Divide and Conquer Matrix 👍 11349 👎 186

*/

using System;
using System.Text.Json;
using Xunit;

namespace SearchA2DMatrixII
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]", 5, true)]
        [InlineData("[[1,4,7,11,15],[2,5,8,12,19],[3,6,9,16,22],[10,13,14,17,24],[18,21,23,26,30]]", 20, false)]
        [InlineData("[[-5]]", -2, false)]
        [InlineData("[[-1,3]]", 3, true)]
        [InlineData("[[5],[6]]", 6, true)]
        [InlineData("[[1,4],[2,5]]", 2, true)]
        public void SearchA2DMatrixIITest(string matrixJson, int target, bool expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().SearchMatrix(matrix, target));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool BinarySearch(int[] array, int target)
        {
            var l = 0;
            var r = array.Length - 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var val = array[mid];
                if (val == target)
                {
                    return true;
                }

                if (val > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return false;
        }

        public bool SearchMatrix(int[][] matrix, int target)
        {
            foreach (var array in matrix)
            {
                if (target >= array[0] && target <= array[^1])
                {
                    if (BinarySearch(array, target))
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}