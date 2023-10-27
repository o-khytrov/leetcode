/**
Given an m x n matrix board containing 'X' and 'O', capture all regions that
are 4-directionally surrounded by 'X'.

 A region is captured by flipping all 'O's into 'X's in that surrounded region.



 Example 1:


Input: board = [["X","X","X","X"],["X","O","O","X"],["X","X","O","X"],["X","O",
"X","X"]]
Output: [["X","X","X","X"],["X","X","X","X"],["X","X","X","X"],["X","O","X","X"]
]
Explanation: Notice that an 'O' should not be flipped if:
- It is on the border, or
- It is adjacent to an 'O' that should not be flipped.
The bottom 'O' is on the border, so it is not flipped.
The other three 'O' form a surrounded region, so they are flipped.


 Example 2:


Input: board = [["X"]]
Output: [["X"]]



 Constraints:


 m == board.length
 n == board[i].length
 1 <= m, n <= 200
 board[i][j] is 'X' or 'O'.


 Related Topics Array Depth-First Search Breadth-First Search Union Find Matrix
👍 8031 👎 1666

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace SurroundedRegions
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[[\"X\",\"X\",\"X\",\"X\"],[\"X\",\"O\",\"O\",\"X\"],[\"X\",\"X\",\"O\",\"X\"],[\"X\",\"O\",\"X\",\"X\"]]",
            "[[\"X\",\"X\",\"X\",\"X\"],[\"X\",\"X\",\"X\",\"X\"],[\"X\",\"X\",\"X\",\"X\"],[\"X\",\"O\",\"X\",\"X\"]]")]
        [InlineData("[[\"X\"]]", "[[\"X\"]]")]
        [InlineData(
            "[[\"O\",\"O\",\"O\",\"O\",\"X\",\"X\"],[\"O\",\"O\",\"O\",\"O\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"O\",\"X\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"O\",\"O\",\"O\"]]",
            "[[\"O\",\"O\",\"O\",\"O\",\"X\",\"X\"],[\"O\",\"O\",\"O\",\"O\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"O\",\"X\",\"O\"],[\"O\",\"X\",\"O\",\"X\",\"O\",\"O\"],[\"O\",\"X\",\"O\",\"O\",\"O\",\"O\"]]")]
        public void SurroundedRegionsTest(string boardJson, string expectedResultJson)
        {
            var board = JsonSerializer.Deserialize<char[][]>(boardJson)
                        ?? throw new ArgumentException("Invalid Json");
            new Solution().Solve(board);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(board));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly HashSet<(int, int)> _visited = new();

        private bool IsInSurroundedRegion(char[][] board, int r, int c)
        {
            if (r > board.Length - 1 || c > board[0].Length - 1 || r < 0 || c < 0)
            {
                return false;
            }

            if (board[r][c] == 'X')
            {
                return true;
            }

            if (_visited.Contains((r, c)))
            {
                return true;
            }

            _visited.Add((r, c));

            var result = IsInSurroundedRegion(board, r + 1, c) &&
                         IsInSurroundedRegion(board, r - 1, c) &&
                         IsInSurroundedRegion(board, r, c + 1) &&
                         IsInSurroundedRegion(board, r, c - 1);

            return result;
        }

        public void Solve(char[][] board)
        {
            for (int r = 0; r < board.Length; r++)
            {
                for (int c = 0; c < board[r].Length; c++)
                {
                    if (board[r][c] == 'O')
                    {
                        var region = new HashSet<(int, int)>();
                        _visited.Clear();
                        if (IsInSurroundedRegion(board, r, c))
                        {
                            foreach (var point in _visited)
                            {
                                board[point.Item1][point.Item2] = 'X';
                            }
                        }
                    }
                }
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}