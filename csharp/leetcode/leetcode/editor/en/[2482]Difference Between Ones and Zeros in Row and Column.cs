/**
You are given a 0-indexed m x n binary matrix grid.

 A 0-indexed m x n difference matrix diff is created with the following
procedure:


 Let the number of ones in the iᵗʰ row be onesRowi.
 Let the number of ones in the jᵗʰ column be onesColj.
 Let the number of zeros in the iᵗʰ row be zerosRowi.
 Let the number of zeros in the jᵗʰ column be zerosColj.
 diff[i][j] = onesRowi + onesColj - zerosRowi - zerosColj


 Return the difference matrix diff.


 Example 1:


Input: grid = [[0,1,1],[1,0,1],[0,0,1]]
Output: [[0,0,4],[0,0,4],[-2,-2,2]]
Explanation:
- diff[0][0] = onesRow0 + onesCol0 - zerosRow0 - zerosCol0 = 2 + 1 - 1 - 2 = 0
- diff[0][1] = onesRow0 + onesCol1 - zerosRow0 - zerosCol1 = 2 + 1 - 1 - 2 = 0
- diff[0][2] = onesRow0 + onesCol2 - zerosRow0 - zerosCol2 = 2 + 3 - 1 - 0 = 4
- diff[1][0] = onesRow1 + onesCol0 - zerosRow1 - zerosCol0 = 2 + 1 - 1 - 2 = 0
- diff[1][1] = onesRow1 + onesCol1 - zerosRow1 - zerosCol1 = 2 + 1 - 1 - 2 = 0
- diff[1][2] = onesRow1 + onesCol2 - zerosRow1 - zerosCol2 = 2 + 3 - 1 - 0 = 4
- diff[2][0] = onesRow2 + onesCol0 - zerosRow2 - zerosCol0 = 1 + 1 - 2 - 2 = -2
- diff[2][1] = onesRow2 + onesCol1 - zerosRow2 - zerosCol1 = 1 + 1 - 2 - 2 = -2
- diff[2][2] = onesRow2 + onesCol2 - zerosRow2 - zerosCol2 = 1 + 3 - 2 - 0 = 2


 Example 2:


Input: grid = [[1,1,1],[1,1,1]]
Output: [[5,5,5],[5,5,5]]
Explanation:
- diff[0][0] = onesRow0 + onesCol0 - zerosRow0 - zerosCol0 = 3 + 2 - 0 - 0 = 5
- diff[0][1] = onesRow0 + onesCol1 - zerosRow0 - zerosCol1 = 3 + 2 - 0 - 0 = 5
- diff[0][2] = onesRow0 + onesCol2 - zerosRow0 - zerosCol2 = 3 + 2 - 0 - 0 = 5
- diff[1][0] = onesRow1 + onesCol0 - zerosRow1 - zerosCol0 = 3 + 2 - 0 - 0 = 5
- diff[1][1] = onesRow1 + onesCol1 - zerosRow1 - zerosCol1 = 3 + 2 - 0 - 0 = 5
- diff[1][2] = onesRow1 + onesCol2 - zerosRow1 - zerosCol2 = 3 + 2 - 0 - 0 = 5



 Constraints:


 m == grid.length
 n == grid[i].length
 1 <= m, n <= 10⁵
 1 <= m * n <= 10⁵
 grid[i][j] is either 0 or 1.


 Related Topics Array Matrix Simulation 👍 684 👎 40

*/

using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace DifferenceBetweenOnesAndZerosInRowAndColumn
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,1,1],[1,0,1],[0,0,1]]", "[[0,0,4],[0,0,4],[-2,-2,2]]")]
        [InlineData("[[1,1,1],[1,1,1]]", "[[5,5,5],[5,5,5]]")]
        public void DifferenceBetweenOnesAndZerosInRowAndColumnTest(string gridJson, string expectedResult)
        {
            var grid = Helper.ToIntMatrix(gridJson);
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().OnesMinusZeros(grid)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[][] OnesMinusZeros(int[][] grid)
        {
            var width = grid[0].Length;
            var height = grid.Length;
            var rowOnes = new int[height];
            var colOnes = new int[width];

            for (var r = 0; r < height; r++)
            {
                for (var c = 0; c < width; c++)
                {
                    if (grid[r][c] == 1)
                    {
                        rowOnes[r]++;
                        colOnes[c]++;
                    }
                }
            }

            var result = new int[height][];
            for (var r = 0; r < height; r++)
            {
                result[r] = new int[width];

                for (var c = 0; c < width; c++)
                {
                    var ro = rowOnes[r];
                    var co = colOnes[c];
                    var rz = width - ro;
                    var cz = height - co;
                    result[r][c] = ro + co - rz - cz;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}