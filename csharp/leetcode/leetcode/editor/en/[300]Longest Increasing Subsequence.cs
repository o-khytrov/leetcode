/**
Given an integer array nums, return the length of the longest strictly
increasing subsequence.


 Example 1:


Input: nums = [10,9,2,5,3,7,101,18]
Output: 4
Explanation: The longest increasing subsequence is [2,3,7,101], therefore the
length is 4.


 Example 2:


Input: nums = [0,1,0,3,2,3]
Output: 4


 Example 3:


Input: nums = [7,7,7,7,7,7,7]
Output: 1



 Constraints:


 1 <= nums.length <= 2500
 -10⁴ <= nums[i] <= 10⁴



 Follow up: Can you come up with an algorithm that runs in O(n log(n)) time
complexity?

 Related Topics Array Binary Search Dynamic Programming 👍 19659 👎 379

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace LongestIncreasingSubsequence
{
    public class Tests
    {
        [Theory]
        [InlineData("[10,9,2,5,3,7,101,18]", 4)]
        [InlineData("[0,1,0,3,2,3]", 4)]
        [InlineData("[7,7,7,7,7,7,7]", 1)]
        public void LongestIncreasingSubsequenceTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().LengthOfLIS(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LengthOfLIS(int[] nums)
        {
            if (nums.Length == 0)
            {
                return 0;
            }

            var n = nums.Length;
            var dp = new int[n];
            Array.Fill(dp, 1);

            for (var i = 1; i < n; ++i)
            {
                for (var j = 0; j < i; ++j)
                {
                    if (nums[i] > nums[j])
                    {
                        dp[i] = Math.Max(dp[i], dp[j] + 1);
                    }
                }
            }

            return dp.Max();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}