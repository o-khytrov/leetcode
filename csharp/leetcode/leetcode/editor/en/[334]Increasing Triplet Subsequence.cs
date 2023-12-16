/**
Given an integer array nums, return true if there exists a triple of indices (i,
 j, k) such that i < j < k and nums[i] < nums[j] < nums[k]. If no such indices
exists, return false.


 Example 1:


Input: nums = [1,2,3,4,5]
Output: true
Explanation: Any triplet where i < j < k is valid.


 Example 2:


Input: nums = [5,4,3,2,1]
Output: false
Explanation: No triplet exists.


 Example 3:


Input: nums = [2,1,5,0,4,6]
Output: true
Explanation: The triplet (3, 4, 5) is valid because nums[3] == 0 < nums[4] == 4
< nums[5] == 6.



 Constraints:


 1 <= nums.length <= 5 * 10⁵
 -2³¹ <= nums[i] <= 2³¹ - 1



Follow up: Could you implement a solution that runs in
O(n) time complexity and
O(1) space complexity?

 Related Topics Array Greedy 👍 7622 👎 418

*/

using System;
using System.Text.Json;
using Xunit;

namespace IncreasingTripletSubsequence
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4,5]", true)]
        [InlineData("[5,4,3,2,1]", false)]
        [InlineData("[2,1,5,0,4,6]", true)]
        public void IncreasingTripletSubsequenceTest(string numsJson, bool expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("invalid json");
            Assert.Equal(expectedResult, new Solution().IncreasingTriplet(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IncreasingTriplet(int[] nums)
        {
            var leftMins = new int[nums.Length];
            var rightMaxs = new int[nums.Length];
            var min = nums[0];
            var max = nums[^1];
            for (var i = 1; i < nums.Length; i++)
            {
                min = Math.Min(min, nums[i]);
                leftMins[i] = min;
            }

            for (var i = nums.Length - 2; i >= 0; i--)
            {
                max = Math.Max(max, nums[i]);
                rightMaxs[i] = max;
            }

            for (var i = 1; i < nums.Length - 1; i++)
            {
                if (leftMins[i] < nums[i] && rightMaxs[i] > nums[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}