using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

//Given an n x n array of integers matrix, return the minimum sum of any 
//falling path through matrix. 
//
// A falling path starts at any element in the first row and chooses the 
//element in the next row that is either directly below or diagonally left/right. 
//Specifically, the next element from position (row, col) will be (row + 1, col - 1), (
//row + 1, col), or (row + 1, col + 1). 
//
// 
// Example 1: 
// 
// 
//Input: matrix = [[2,1,3],[6,5,4],[7,8,9]]
//Output: 13
//Explanation: There are two falling paths with a minimum sum as shown.
// 
//
// Example 2: 
// 
// 
//Input: matrix = [[-19,57],[-40,-5]]
//Output: -59
//Explanation: The falling path with a minimum sum is shown.
// 
//
// 
// Constraints: 
//
// 
// n == matrix.length == matrix[i].length 
// 1 <= n <= 100 
// -100 <= matrix[i][j] <= 100 
// 
//
// Related Topics Array Dynamic Programming Matrix 👍 5397 👎 132

namespace MinimumFallingPathSum
{
    public class Tests
    {
        [Theory]
        [InlineData("[[2,1,3],[6,5,4],[7,8,9]]", 13)]
        [InlineData("[[-19,57],[-40,-5]]", -59)]
        public void MinimumFallingPathSumTest(string matrixJson, int expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MinFallingPathSum(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<(int, int), int> _memo = new Dictionary<(int, int), int>();

        private int FindPath(int[][] matrix, int r, int c)
        {
            if (c > matrix[0].Length - 1 || c < 0)
            {
                return Int32.MaxValue;
            }

            var val = matrix[r][c];
            if (r == matrix.Length - 1)
            {
                return val;
            }

            if (_memo.ContainsKey((r, c)))
            {
                return _memo[(r, c)];
            }

            var down = FindPath(matrix, r + 1, c);
            var right = FindPath(matrix, r + 1, c + 1);
            var left = FindPath(matrix, r + 1, c - 1);
            _memo[(r, c)] = val + Math.Min(Math.Min(down, left), right);
            return _memo[(r, c)];
        }

        public int MinFallingPathSum(int[][] matrix)
        {
            var minSum = int.MaxValue;
            for (int c = 0; c < matrix[0].Length; c++)
            {
                minSum = Math.Min(minSum, FindPath(matrix, 0, c));
            }

            return minSum;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}