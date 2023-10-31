/**
Given an m x n matrix board where each cell is a battleship 'X' or empty '.',
return the number of the battleships on board.

 Battleships can only be placed horizontally or vertically on board. In other
words, they can only be made of the shape 1 x k (1 row, k columns) or k x 1 (k
rows, 1 column), where k can be of any size. At least one horizontal or vertical
cell separates between two battleships (i.e., there are no adjacent battleships).



 Example 1:


Input: board = [["X",".",".","X"],[".",".",".","X"],[".",".",".","X"]]
Output: 2


 Example 2:


Input: board = [["."]]
Output: 0



 Constraints:


 m == board.length
 n == board[i].length
 1 <= m, n <= 200
 board[i][j] is either '.' or 'X'.



 Follow up: Could you do it in one-pass, using only O(1) extra memory and
without modifying the values board?

 Related Topics Array Depth-First Search Matrix 👍 2154 👎 932

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace BattleshipsInABoard
{
    public class Tests
    {
        [Theory]
        [InlineData("[[\"X\",\".\",\".\",\"X\"],[\".\",\".\",\".\",\"X\"],[\".\",\".\",\".\",\"X\"]]", 2)]
        [InlineData("[[\".\"]]", 0)]
        public void BattleshipsInABoardTest(string boardJson, int expectedResult)
        {
            var board = JsonSerializer.Deserialize<char[][]>(boardJson)
                        ?? throw new ArgumentException("Invalid Json");

            Assert.Equal(expectedResult, new Solution().CountBattleships(board));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        HashSet<(int, int)> _visited = new();

        private void Explore(char[][] board, int r, int c)
        {
            if (r > board.Length - 1 || r < 0 || c > board[r].Length - 1 || c < 0)
            {
                return;
            }

            if (_visited.Contains((r, c)))
            {
                return;
            }

            if (board[r][c] != 'X') return;
            _visited.Add((r, c));
            Explore(board, r + 1, c);
            Explore(board, r - 1, c);

            Explore(board, r, c + 1);
            Explore(board, r, c - 1);
        }

        public int CountBattleships(char[][] board)
        {
            var count = 0;

            for (var r = 0; r < board.Length; r++)
            {
                for (var c = 0; c < board[r].Length; c++)
                {
                    if (_visited.Contains((r, c)))
                    {
                        continue;
                    }

                    if (board[r][c] == 'X')
                    {
                        Explore(board, r, c);
                        count++;
                    }
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}