/**
According to Wikipedia's article: "The Game of Life, also known simply as Life,
is a cellular automaton devised by the British mathematician John Horton Conway
in 1970."

 The board is made up of an m x n grid of cells, where each cell has an initial
state: live (represented by a 1) or dead (represented by a 0). Each cell
interacts with its eight neighbors (horizontal, vertical, diagonal) using the
following four rules (taken from the above Wikipedia article):


 Any live cell with fewer than two live neighbors dies as if caused by under-
population.
 Any live cell with two or three live neighbors lives on to the next generation.

 Any live cell with more than three live neighbors dies, as if by over-
population.
 Any dead cell with exactly three live neighbors becomes a live cell, as if by
reproduction.


 The next state is created by applying the above rules simultaneously to every
cell in the current state, where births and deaths occur simultaneously. Given
the current state of the m x n grid board, return the next state.


 Example 1:


Input: board = [[0,1,0],[0,0,1],[1,1,1],[0,0,0]]
Output: [[0,0,0],[1,0,1],[0,1,1],[0,1,0]]


 Example 2:


Input: board = [[1,1],[1,0]]
Output: [[1,1],[1,1]]



 Constraints:


 m == board.length
 n == board[i].length
 1 <= m, n <= 25
 board[i][j] is 0 or 1.



 Follow up:


 Could you solve it in-place? Remember that the board needs to be updated
simultaneously: You cannot update some cells first and then use their updated values
to update other cells.
 In this question, we represent the board using a 2D array. In principle, the
board is infinite, which would cause problems when the active area encroaches
upon the border of the array (i.e., live cells reach the border). How would you
address these problems?


 Related Topics Array Matrix Simulation 👍 6055 👎 515

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace GameOfLife
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,1,0],[0,0,1],[1,1,1],[0,0,0]]", "[[0,0,0],[1,0,1],[0,1,1],[0,1,0]]")]
        [InlineData("[[1,1],[1,0]]", "[[1,1],[1,1]]")]
        public void GameOfLifeTest(string boardJson, string expectedResultJson)
        {
            var board = JsonSerializer.Deserialize<int[][]>(boardJson)
                        ?? throw new ArgumentException("Invalid Json");
            new Solution().GameOfLife(board);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(board));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetNeighbour(int[][] grid, int r, int c)
        {
            if (r > grid.Length - 1 || r < 0 || c > grid[r].Length - 1 || c < 0)
            {
                return 0;
            }

            return grid[r][c];
        }

        private int GetNeighboursCount(int[][] grid, int r, int c)
        {
            var up = GetNeighbour(grid, r - 1, c);
            var upLeft = GetNeighbour(grid, r - 1, c - 1);
            var upRight = GetNeighbour(grid, r - 1, c + 1);
            var left = GetNeighbour(grid, r, c - 1);
            var right = GetNeighbour(grid, r, c + 1);
            var down = GetNeighbour(grid, r + 1, c);
            var downLeft = GetNeighbour(grid, r + 1, c - 1);
            var downRight = GetNeighbour(grid, r + 1, c + 1);
            return up + upLeft + upRight + left + right + downLeft + downRight + down;
        }

        public void GameOfLife(int[][] board)
        {
            var toDie = new HashSet<(int, int)>();
            var toLive = new HashSet<(int, int)>();
            for (var r = 0; r < board.Length; r++)
            {
                for (var c = 0; c < board[r].Length; c++)
                {
                    var neighbours = GetNeighboursCount(board, r, c);
                    if (board[r][c] == 1)
                    {
                        if (neighbours < 2)
                        {
                            toDie.Add((r, c));
                        }

                        if (neighbours > 3)
                        {
                            toDie.Add((r, c));
                        }
                    }
                    else
                    {
                        if (neighbours == 3)
                        {
                            toLive.Add((r, c));
                        }
                    }
                }
            }

            foreach (var (r, c) in toDie)
            {
                board[r][c] = 0;
            }

            foreach (var (r, c) in toLive)
            {
                board[r][c] = 1;
            }

            toDie.Clear();
            toLive.Clear();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}