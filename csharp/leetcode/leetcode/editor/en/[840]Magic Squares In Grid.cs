/**
A 3 x 3 magic square is a 3 x 3 grid filled with distinct numbers from 1 to 9
such that each row, column, and both diagonals all have the same sum.

 Given a row x col grid of integers, how many 3 x 3 "magic square" subgrids are
there? (Each subgrid is contiguous).


 Example 1:


Input: grid = [[4,3,8,4],[9,5,1,9],[2,7,6,2]]
Output: 1
Explanation:
The following subgrid is a 3 x 3 magic square:

while this one is not:

In total, there is only one magic square inside the given grid.


 Example 2:


Input: grid = [[8]]
Output: 0



 Constraints:


 row == grid.length
 col == grid[i].length
 1 <= row, col <= 10
 0 <= grid[i][j] <= 15


 Related Topics Array Math Matrix 👍 319 👎 1577

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MagicSquaresInGrid
{
    public class Tests
    {
        [Theory]
        [InlineData("[[4,3,8,4],[9,5,1,9],[2,7,6,2]]", 1)]
        [InlineData("[[10,3,5],[1,6,11],[7,9,2]]", 0)]
        public void MagicSquaresInGridTest(string gridJson, int expectedResult)
        {
            var grid = JsonSerializer.Deserialize<int[][]>(gridJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().NumMagicSquaresInside(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private HashSet<(int, int)> _visited = new();

        public int NumMagicSquaresInside(int[][] grid)
        {
            var uniqueNumbers = new HashSet<int>();
            var magicSquaresCount = 0;
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    if (_visited.Contains((r, c)))
                    {
                        continue;
                    }

                    uniqueNumbers.Clear();
                    if (IsCenterOfMagicSquare(grid, r, c, uniqueNumbers))
                    {
                        magicSquaresCount++;
                    }
                }
            }

            return magicSquaresCount;
        }

        private bool CheckNumber(int n, HashSet<int> uniqueNumbers)
        {
            if (n <= 0 || n > 9)
            {
                return false;
            }

            if (uniqueNumbers.Contains(n))
            {
                return false;
            }

            uniqueNumbers.Add(n);
            return true;
        }

        private bool IsCenterOfMagicSquare(int[][] grid, int r, int c, HashSet<int> uniqueNumbers)
        {
            if (r < 1 || c < 1 || grid.Length - r < 2 || grid[0].Length - c < 2)
            {
                return false;
            }

            var upLeft = grid[r - 1][c - 1];
            var up = grid[r - 1][c];
            var upRight = grid[r - 1][c + 1];

            var left = grid[r][c - 1];
            var center = grid[r][c];
            var right = grid[r][c + 1];

            var downLeft = grid[r + 1][c - 1];
            var down = grid[r + 1][c];
            var downRight = grid[r + 1][c + 1];

            if (!CheckNumber(upLeft, uniqueNumbers)) return false;
            if (!CheckNumber(up, uniqueNumbers)) return false;
            if (!CheckNumber(upRight, uniqueNumbers)) return false;
            if (!CheckNumber(left, uniqueNumbers)) return false;
            if (!CheckNumber(center, uniqueNumbers)) return false;
            if (!CheckNumber(right, uniqueNumbers)) return false;
            if (!CheckNumber(downLeft, uniqueNumbers)) return false;
            if (!CheckNumber(down, uniqueNumbers)) return false;
            if (!CheckNumber(downRight, uniqueNumbers)) return false;

            var sum = upLeft + up + upRight;
            if (left + center + right != sum)
            {
                return false;
            }

            if (downLeft + down + downRight != sum)
            {
                return false;
            }

            if (upLeft + left + downLeft != sum)
            {
                return false;
            }

            if (up + center + down != sum)
            {
                return false;
            }

            if (upRight + right + downRight != sum)
            {
                return false;
            }

            for (int row = r - 1; row < 3; row++)
            {
                for (int col = c - 1; col < 3; col++)
                {
                    _visited.Add((row, col));
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}