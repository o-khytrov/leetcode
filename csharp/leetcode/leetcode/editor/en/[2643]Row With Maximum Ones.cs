/**
Given a m x n binary matrix mat, find the 0-indexed position of the row that
contains the maximum count of ones, and the number of ones in that row.

 In case there are multiple rows that have the maximum count of ones, the row
with the smallest row number should be selected.

 Return an array containing the index of the row, and the number of ones in it.



 Example 1:


Input: mat = [[0,1],[1,0]]
Output: [0,1]
Explanation: Both rows have the same number of 1's. So we return the index of
the smaller row, 0, and the maximum count of ones (1). So, the answer is [0,1].


 Example 2:


Input: mat = [[0,0,0],[0,1,1]]
Output: [1,2]
Explanation: The row indexed 1 has the maximum count of ones (2). So we return
its index, 1, and the count. So, the answer is [1,2].


 Example 3:


Input: mat = [[0,0],[1,1],[0,0]]
Output: [1,2]
Explanation: The row indexed 1 has the maximum count of ones (2). So the answer
is [1,2].



 Constraints:


 m == mat.length
 n == mat[i].length
 1 <= m, n <= 100
 mat[i][j] is either 0 or 1.


 Related Topics Array Matrix 👍 329 👎 9

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace RowWithMaximumOnes
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,1],[1,0]]", "[0,1]")]
        [InlineData("[[0,0,0],[0,1,1]]", "[1,2]")]
        [InlineData("[[0,0],[1,1],[0,0]]", "[1,2]")]
        public void RowWithMaximumOnesTest(string matrixJson, string expectedResultJson)
        {
            var matrix = JsonSerializer.Deserialize<int[][]>(matrixJson)
                         ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().RowAndMaximumOnes(matrix)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] RowAndMaximumOnes(int[][] mat)
        {
            var counts = mat.Select(x => x.Count(i => i == 1)).ToArray();
            var result = new int[2];

            for (var i = 0; i < counts.Length; i++)
            {
                var c = counts[i];
                if (c > result[1])
                {
                    result[0] = i;
                    result[1] = c;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}