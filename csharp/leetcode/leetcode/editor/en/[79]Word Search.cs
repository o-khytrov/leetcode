/**
Given an m x n grid of characters board and a string word, return true if word
exists in the grid.

 The word can be constructed from letters of sequentially adjacent cells, where
adjacent cells are horizontally or vertically neighboring. The same letter cell
may not be used more than once.


 Example 1:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
"ABCCED"
Output: true


 Example 2:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
"SEE"
Output: true


 Example 3:


Input: board = [["A","B","C","E"],["S","F","C","S"],["A","D","E","E"]], word =
"ABCB"
Output: false



 Constraints:


 m == board.length
 n = board[i].length
 1 <= m, n <= 6
 1 <= word.length <= 15
 board and word consists of only lowercase and uppercase English letters.



 Follow up: Could you use search pruning to make your solution faster with a
larger board?

 Related Topics Array Backtracking Matrix 👍 14582 👎 598

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace WordSearch
{
    public class Tests
    {
        [Theory]
        [InlineData("[[\"A\",\"B\",\"C\",\"E\"],[\"S\",\"F\",\"C\",\"S\"],[\"A\",\"D\",\"E\",\"E\"]]", "ABCCED", true)]
        [InlineData("[[\"A\",\"B\",\"C\",\"E\"],[\"S\",\"F\",\"C\",\"S\"],[\"A\",\"D\",\"E\",\"E\"]]", "SEE", true)]
        [InlineData("[[\"A\",\"B\",\"C\",\"E\"],[\"S\",\"F\",\"C\",\"S\"],[\"A\",\"D\",\"E\",\"E\"]]", "ABCB", false)]
        [InlineData("[[\"A\",\"B\",\"C\",\"E\"],[\"S\",\"F\",\"E\",\"S\"],[\"A\",\"D\",\"E\",\"E\"]]", "ABCESEEEFS",
            true)]
        public void WordSearchTest(string boardJson, string word, bool expectedResult)
        {
            var board = JsonSerializer.Deserialize<char[][]>(boardJson)
                        ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().Exist(board, word));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool Search(char[][] board, string word, int r, int c, int index)
        {
            if (r > board.Length - 1 || r < 0 || c > board[r].Length - 1 || c < 0 || index > word.Length - 1)
            {
                return false;
            }

            if (_visited.Contains((r, c)))
            {
                return false;
            }

            if (board[r][c] != word[index])
            {
                return false;
            }

            _visited.Add((r, c));
            if (index == word.Length - 1)
            {
                return true;
            }


            var down = Search(board, word, r + 1, c, index + 1);
            var up = Search(board, word, r - 1, c, index + 1);
            var right = Search(board, word, r, c + 1, index + 1);
            var left = Search(board, word, r, c - 1, index + 1);
            var res = up || down || right || left;
            if (!res)
            {
                _visited.Remove((r, c));
            }

            return res;
        }

        private readonly HashSet<(int, int)> _visited = new();

        public bool Exist(char[][] board, string word)
        {
            for (var r = 0; r < board.Length; r++)
            {
                for (var c = 0; c < board[r].Length; c++)
                {
                    if (board[r][c] == word[0])
                    {
                        _visited.Clear();
                        if (Search(board, word, r, c, 0))
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}