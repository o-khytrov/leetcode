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
        [InlineData("[[100,-42,-46,-41],[31,97,10,-10],[-58,-51,82,89],[51,81,69,-51]]", -36)]
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

        private int FindPath(int[][] matrix, int col, int row)
        {
            if (row < 0 || row > matrix.Length - 1 || col < 0 || col > matrix[row].Length - 1)
            {
                return int.MaxValue;
            }

            if (row == matrix.Length - 1 && col >= 0 && col < matrix.Length)
            {
                return matrix[row][col];
            }

            if (_memo.ContainsKey((row, col)))
            {
                return _memo[(row, col)];
            }

            var downPath = FindPath(matrix, col, row + 1);
            var leftPath = FindPath(matrix, col - 1, row + 1);
            var rightPath = FindPath(matrix, col + 1, row + 1);
            var minPath = int.MaxValue;
            minPath = Math.Min(minPath, leftPath);
            minPath = Math.Min(minPath, rightPath);
            minPath = Math.Min(minPath, downPath);

            var sum = minPath + matrix[row][col];

            _memo[(row, col)] = sum;
            return sum;
        }

        public int MinFallingPathSum(int[][] matrix)
        {
            var minPathSum = int.MaxValue;
            for (int i = 0; i < matrix[0].Length; i++)
            {
                minPathSum = Math.Min(minPathSum, FindPath(matrix, i, 0));
            }

            return minPathSum;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}