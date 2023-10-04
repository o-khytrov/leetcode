/**
Given an m x n binary matrix filled with 0's and 1's, find the largest square
containing only 1's and return its area.


 Example 1:


Input: matrix = [["1","0","1","0","0"],["1","0","1","1","1"],["1","1","1","1","1
"],["1","0","0","1","0"]]
Output: 4


 Example 2:


Input: matrix = [["0","1"],["1","0"]]
Output: 1


 Example 3:


Input: matrix = [["0"]]
Output: 0



 Constraints:


 m == matrix.length
 n == matrix[i].length
 1 <= m, n <= 300
 matrix[i][j] is '0' or '1'.


 Related Topics Array Dynamic Programming Matrix 👍 9578 👎 201

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace MaximalSquare
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[[\"1\",\"0\",\"1\",\"0\",\"0\"],[\"1\",\"0\",\"1\",\"1\",\"1\"],[\"1\",\"1\",\"1\",\"1\",\"1\"],[\"1\",\"0\",\"0\",\"1\",\"0\"]]",
            4)]
        [InlineData("[[\"0\",\"1\"],[\"1\",\"0\"]]", 1)]
        public void MaximalSquareTest(string matrixJson, int expectedResult)
        {
            var matrix = JsonSerializer.Deserialize<char[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MaximalSquare(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<(int, int), int> _memo;

        private static readonly int[] Directions = new int[3];

        public Solution()
        {
            _memo = new();
        }

        private int MaxSquareFrom(IReadOnlyList<char[]> matrix, int r, int c)
        {
            if (r > matrix.Count - 1)
            {
                return 0;
            }

            if (c > matrix[0].Length - 1)
            {
                return 0;
            }

            if (_memo.TryGetValue((r, c), out var length))
            {
                return length;
            }


            var down = MaxSquareFrom(matrix, r + 1, c);
            var right = MaxSquareFrom(matrix, r, c + 1);
            var diagonal = MaxSquareFrom(matrix, r + 1, c + 1);
            Directions[0] = down;
            Directions[1] = right;
            Directions[2] = diagonal;
            _memo[(r, c)] = 0;
            if (matrix[r][c] == '1')
            {
                _memo[(r, c)] = 1 + Directions.Min();
            }

            return _memo[(r, c)];
        }

        public int MaximalSquare(char[][] matrix)
        {
            MaxSquareFrom(matrix, 0, 0);
            var maxSide = _memo.Values.Max();
            return maxSide * maxSide;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}