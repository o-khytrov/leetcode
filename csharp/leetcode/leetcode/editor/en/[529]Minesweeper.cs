/**
Let's play the minesweeper game (Wikipedia, online game)!

 You are given an m x n char matrix board representing the game board where:


 'M' represents an unrevealed mine,
 'E' represents an unrevealed empty square,
 'B' represents a revealed blank square that has no adjacent mines (i.e., above,
 below, left, right, and all 4 diagonals),
 digit ('1' to '8') represents how many mines are adjacent to this revealed
square, and
 'X' represents a revealed mine.


 You are also given an integer array click where click = [clickr, clickc]
represents the next click position among all the unrevealed squares ('M' or 'E').

 Return the board after revealing this position according to the following
rules:


 If a mine 'M' is revealed, then the game is over. You should change it to 'X'.

 If an empty square 'E' with no adjacent mines is revealed, then change it to a
revealed blank 'B' and all of its adjacent unrevealed squares should be
revealed recursively.
 If an empty square 'E' with at least one adjacent mine is revealed, then
change it to a digit ('1' to '8') representing the number of adjacent mines.
 Return the board when no more squares will be revealed.



 Example 1:


Input: board = [["E","E","E","E","E"],["E","E","M","E","E"],["E","E","E","E",
"E"],["E","E","E","E","E"]], click = [3,0]
Output: [["B","1","E","1","B"],["B","1","M","1","B"],["B","1","1","1","B"],["B",
"B","B","B","B"]]


 Example 2:


Input: board = [["B","1","E","1","B"],["B","1","M","1","B"],["B","1","1","1",
"B"],["B","B","B","B","B"]], click = [1,2]
Output: [["B","1","E","1","B"],["B","1","X","1","B"],["B","1","1","1","B"],["B",
"B","B","B","B"]]



 Constraints:


 m == board.length
 n == board[i].length
 1 <= m, n <= 50
 board[i][j] is either 'M', 'E', 'B', or a digit from '1' to '8'.
 click.length == 2
 0 <= clickr < m
 0 <= clickc < n
 board[clickr][clickc] is either 'M' or 'E'.


 Related Topics Array Depth-First Search Breadth-First Search Matrix 👍 1875 👎
1028

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace Minesweeper
{
    public class Tests
    {
        [Theory]
        [InlineData(
            "[[\"E\",\"E\",\"E\",\"E\",\"E\"],[\"E\",\"E\",\"M\",\"E\",\"E\"],[\"E\",\"E\",\"E\",\"E\",\"E\"],[\"E\",\"E\",\"E\",\"E\",\"E\"]]",
            "[3,0]",
            "[[\"B\",\"1\",\"E\",\"1\",\"B\"],[\"B\",\"1\",\"M\",\"1\",\"B\"],[\"B\",\"1\",\"1\",\"1\",\"B\"],[\"B\",\"B\",\"B\",\"B\",\"B\"]]")]
        [InlineData(
            "[[\"B\",\"1\",\"E\",\"1\",\"B\"],[\"B\",\"1\",\"M\",\"1\",\"B\"],[\"B\",\"1\",\"1\",\"1\",\"B\"],[\"B\",\"B\",\"B\",\"B\",\"B\"]]",
            "[1,2]",
            "[[\"B\",\"1\",\"E\",\"1\",\"B\"],[\"B\",\"1\",\"X\",\"1\",\"B\"],[\"B\",\"1\",\"1\",\"1\",\"B\"],[\"B\",\"B\",\"B\",\"B\",\"B\"]]")]
        public void MinesweeperTest(string boardJson, string clickJson, string expectedResultJson)
        {
            var board = JsonSerializer.Deserialize<char[][]>(boardJson)
                        ?? throw new ArgumentException("Invalid json");
            var click = JsonSerializer.Deserialize<int[]>(clickJson)
                        ?? throw new ArgumentException("Invalid json");
            var result = new Solution().UpdateBoard(board, click);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private char GetNeighbour(char[][] board, int r, int c)
        {
            if (r > board.Length - 1 || r < 0 || c > board[0].Length - 1 || c < 0)
            {
                return 'O';
            }

            return board[r][c];
        }

        private int GetAdjacentMinesCount(char[][] board, int r, int c)
        {
            var count = 0;
            var upLeft = GetNeighbour(board, r - 1, c - 1);
            var up = GetNeighbour(board, r - 1, c);
            var upRight = GetNeighbour(board, r - 1, c + 1);

            var left = GetNeighbour(board, r, c - 1);
            var right = GetNeighbour(board, r, c + 1);

            var downLeft = GetNeighbour(board, r + 1, c - 1);
            var down = GetNeighbour(board, r + 1, c);
            var downRight = GetNeighbour(board, r + 1, c + 1);
            count += upLeft == 'M' ? 1 : 0;
            count += up == 'M' ? 1 : 0;
            count += upRight == 'M' ? 1 : 0;
            count += left == 'M' ? 1 : 0;
            count += right == 'M' ? 1 : 0;
            count += downLeft == 'M' ? 1 : 0;
            count += down == 'M' ? 1 : 0;
            count += downRight == 'M' ? 1 : 0;
            return count;
        }

        private void Fill(char[][] board, int r, int c, HashSet<(int, int)> visited)
        {
            if (r > board.Length - 1 || r < 0 || c > board[0].Length - 1 || c < 0)
            {
                return;
            }

            if (visited.Contains((r, c)))
            {
                return;
            }

            visited.Add((r, c));
            var mines = GetAdjacentMinesCount(board, r, c);
            if (mines > 0)
            {
                board[r][c] = (char) (mines + 48);
            }
            else
            {
                board[r][c] = 'B';
                Fill(board, r - 1, c - 1, visited);
                Fill(board, r - 1, c, visited);
                Fill(board, r - 1, c + 1, visited);

                Fill(board, r, c - 1, visited);
                Fill(board, r, c + 1, visited);

                Fill(board, r + 1, c - 1, visited);
                Fill(board, r + 1, c, visited);
                Fill(board, r + 1, c + 1, visited);
            }
        }

        public char[][] UpdateBoard(char[][] board, int[] click)
        {
            var visited = new HashSet<(int, int)>();
            var r = click[0];
            var c = click[1];
            if (board[r][c] == 'M')
            {
                board[r][c] = 'X';
            }

            if (board[r][c] == 'E')
            {
                Fill(board, r, c, visited);
            }


            return board;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}