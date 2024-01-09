/**
Given a 0-indexed n x n integer matrix grid, return the number of pairs (ri, cj)
 such that row ri and column cj are equal.

 A row and column pair is considered equal if they contain the same elements in
the same order (i.e., an equal array).


 Example 1:


Input: grid = [[3,2,1],[1,7,6],[2,7,7]]
Output: 1
Explanation: There is 1 equal row and column pair:
- (Row 2, Column 1): [2,7,7]


 Example 2:


Input: grid = [[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]
Output: 3
Explanation: There are 3 equal row and column pairs:
- (Row 0, Column 0): [3,1,2,2]
- (Row 2, Column 2): [2,4,2,2]
- (Row 3, Column 2): [2,4,2,2]



 Constraints:


 n == grid.length == grid[i].length
 1 <= n <= 200
 1 <= grid[i][j] <= 10⁵


 Related Topics Array Hash Table Matrix Simulation 👍 2026 👎 124

*/

using System.Text;
using leetcode.CommonClasses;
using Xunit;

namespace EqualRowAndColumnPairs
{
    public class Tests
    {
        [Theory]
        [InlineData("[[3,2,1],[1,7,6],[2,7,7]]", 1)]
        [InlineData("[[3,1,2,2],[1,4,4,5],[2,4,2,2],[2,4,2,2]]", 3)]
        [InlineData("[[11,1],[1,11]]", 2)]
        public void EqualRowAndColumnPairsTest(string gridJson, int expectedResult)
        {
            var grid = Helper.ToIntMatrix(gridJson);
            Assert.Equal(expectedResult, new Solution().EqualPairs(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int EqualPairs(int[][] grid)
        {
            var rows = new string[grid.Length];
            var cols = new string[grid.Length];
            for (var i = 0; i < grid.Length; i++)
            {
                var row = grid[i];
                var sb = new StringBuilder();
                foreach (var col in row)
                {
                    sb.Append(col);
                    sb.Append(',');
                }

                rows[i] = sb.ToString();
            }

            for (var c = 0; c < grid[0].Length; c++)
            {
                var sb = new StringBuilder();
                foreach (var r in grid)
                {
                    sb.Append(r[c]);
                    sb.Append(',');
                }

                cols[c] = sb.ToString();
            }

            var count = 0;
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    if (rows[r] == cols[c])
                    {
                        count++;
                    }
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}