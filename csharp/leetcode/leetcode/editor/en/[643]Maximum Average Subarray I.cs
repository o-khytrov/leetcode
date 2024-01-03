/**
You are given an integer array nums consisting of n elements, and an integer k.


 Find a contiguous subarray whose length is equal to k that has the maximum
average value and return this value. Any answer with a calculation error less than 1
0⁻⁵ will be accepted.


 Example 1:


Input: nums = [1,12,-5,-6,50,3], k = 4
Output: 12.75000
Explanation: Maximum average is (12 - 5 - 6 + 50) / 4 = 51 / 4 = 12.75


 Example 2:


Input: nums = [5], k = 1
Output: 5.00000



 Constraints:


 n == nums.length
 1 <= k <= n <= 10⁵
 -10⁴ <= nums[i] <= 10⁴


 Related Topics Array Sliding Window 👍 3238 👎 269

*/

using System;
using System.Text.Json;
using Xunit;

namespace MaximumAverageSubarrayI
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,12,-5,-6,50,3]", 4, 12.75)]
        [InlineData("[5]", 1, 5)]
        public void MaximumAverageSubarrayITest(string arrayJson, int k, double expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(arrayJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().FindMaxAverage(nums, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public double FindMaxAverage(int[] nums, int k)
        {
            var sum = 0;

            var r = 0;
            for (r = 0; r < k; r++)
            {
                sum += nums[r];
            }

            var maxAvg = sum / (double) k;
            for (; r < nums.Length; r++)
            {
                sum += nums[r];
                sum -= nums[r - k];
                var avg = sum / (double) k;
                maxAvg = Math.Max(maxAvg, avg);
            }


            return maxAvg;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}