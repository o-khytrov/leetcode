/**
Given an integer array nums, find a subarray that has the largest product, and
return the product.

 The test cases are generated so that the answer will fit in a 32-bit integer.


 Example 1:


Input: nums = [2,3,-2,4]
Output: 6
Explanation: [2,3] has the largest product 6.


 Example 2:


Input: nums = [-2,0,-1]
Output: 0
Explanation: The result cannot be 2, because [-2,-1] is not a subarray.



 Constraints:


 1 <= nums.length <= 2 * 10⁴
 -10 <= nums[i] <= 10
 The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit
integer.


 Related Topics Array Dynamic Programming 👍 17448 👎 546

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace MaximumProductSubarray
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,3,-2,4]", 6)]
        [InlineData("[-2,0,-1]", 0)]
        public void MaximumProductSubarrayTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson) ??
                       throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MaxProduct(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            var maxProduct = nums.Max();
            var currentMin = 1;
            var currentMax = 1;
            var a = new int[3];

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (n == 0)
                {
                    currentMax = 1;
                    currentMin = 1;
                    continue;
                }

                var tmp = currentMax * n;
                currentMax = Math.Max(n, Math.Max(n * currentMax, n * currentMin));
                currentMin = Math.Min(n, Math.Min(tmp, n * currentMin));
                maxProduct = Math.Max(maxProduct, currentMax);
            }

            return maxProduct;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}