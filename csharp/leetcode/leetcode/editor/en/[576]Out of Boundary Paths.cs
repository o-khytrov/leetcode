/**
There is an m x n grid with a ball. The ball is initially at the position [
startRow, startColumn]. You are allowed to move the ball to one of the four adjacent
cells in the grid (possibly out of the grid crossing the grid boundary). You
can apply at most maxMove moves to the ball.

 Given the five integers m, n, maxMove, startRow, startColumn, return the
number of paths to move the ball out of the grid boundary. Since the answer can be
very large, return it modulo 10⁹ + 7.


 Example 1:


Input: m = 2, n = 2, maxMove = 2, startRow = 0, startColumn = 0
Output: 6


 Example 2:


Input: m = 1, n = 3, maxMove = 3, startRow = 0, startColumn = 1
Output: 12



 Constraints:


 1 <= m, n <= 50
 0 <= maxMove <= 50
 0 <= startRow < m
 0 <= startColumn < n


 Related Topics Dynamic Programming 👍 3657 👎 273

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace OutOfBoundaryPaths
{
    public class Tests
    {
        [Theory]
        [InlineData(2, 2, 2, 0, 0, 6)]
        [InlineData(1, 3, 3, 0, 1, 12)]
        public void OutOfBoundaryPathsTest(int m, int n, int maxMove, int startRow, int startColumn, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().FindPaths(m, n, maxMove, startRow, startColumn));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        int _m = 1000000007;

        public int FindPaths(int m, int n, int maxMove, int startRow, int startColumn)
        {
            var memo = new int[m][][];
            for (int i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[n][];
                for (int j = 0; j < memo[i].Length; j++)
                {
                    memo[i][j] = new int[maxMove + 1];
                    Array.Fill(memo[i][j], -1);
                }
            }

            return FindPaths(m, n, maxMove, startRow, startColumn, memo);
        }

        public int FindPaths(int m, int n, int N, int i, int j, int[][][] memo)
        {
            if (i == m || j == n || i < 0 || j < 0) return 1;
            if (N == 0) return 0;
            if (memo[i][j][N] >= 0) return memo[i][j][N];
            memo[i][j][N] = (
                (FindPaths(m, n, N - 1, i - 1, j, memo) + FindPaths(m, n, N - 1, i + 1, j, memo)) % _m +
                (FindPaths(m, n, N - 1, i, j - 1, memo) + FindPaths(m, n, N - 1, i, j + 1, memo)) % _m
            ) % _m;
            return memo[i][j][N];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}