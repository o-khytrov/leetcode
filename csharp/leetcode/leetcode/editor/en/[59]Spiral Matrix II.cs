/**
Given a positive integer n, generate an n x n matrix filled with elements from 1
 to n² in spiral order.


 Example 1:


Input: n = 3
Output: [[1,2,3],[8,9,4],[7,6,5]]


 Example 2:


Input: n = 1
Output: [[1]]



 Constraints:


 1 <= n <= 20


 Related Topics Array Matrix Simulation 👍 6069 👎 244

*/

using System.Text.Json;
using Xunit;

namespace SpiralMatrixII
{
    public class Tests
    {
        [Theory]
        [InlineData(3, "[[1,2,3],[8,9,4],[7,6,5]]")]
        public void SpiralMatrixIITest(int n, string expectedResultJson)
        {
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().GenerateMatrix(n)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[][] GenerateMatrix(int n)
        {
            var result = new int[n][];
            for (int i = 0; i < n; i++)
            {
                result[i] = new int[n];
            }

            var num = 1;
            int rows = n, cols = n;
            int left = 0, right = cols - 1, top = 0, bottom = rows - 1;

            while (num <= n*n)
            {
                for (int i = left; i <= right; i++)
                {
                    result[top][i] = num;
                    num++;
                }

                top++;

                for (int i = top; i <= bottom; i++)
                {
                    result[i][right] = num;
                    num++;
                }

                right--;

                if (top <= bottom)
                {
                    for (int i = right; i >= left; i--)
                    {
                        result[bottom][i] = num;
                        num++;
                    }

                    bottom--;
                }

                if (left <= right)
                {
                    for (int i = bottom; i >= top; i--)
                    {
                        result[i][left] = num;
                        num++;
                    }

                    left++;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}