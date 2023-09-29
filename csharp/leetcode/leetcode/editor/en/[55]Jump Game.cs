using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//You are given an integer array nums. You are initially positioned at the 
//array's first index, and each element in the array represents your maximum jump 
//length at that position. 
//
// Return true if you can reach the last index, or false otherwise. 
//
// 
// Example 1: 
//
// 
//Input: nums = [2,3,1,1,4]
//Output: true
//Explanation: Jump 1 step from index 0 to 1, then 3 steps to the last index.
// 
//
// Example 2: 
//
// 
//Input: nums = [3,2,1,0,4]
//Output: false
//Explanation: You will always arrive at index 3 no matter what. Its maximum 
//jump length is 0, which makes it impossible to reach the last index.
// 
//
// 
// Constraints: 
//
// 
// 1 <= nums.length <= 10⁴ 
// 0 <= nums[i] <= 10⁵ 
// 
//
// Related Topics Array Dynamic Programming Greedy 👍 17873 👎 1017

namespace JumpGame
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,3,1,1,4]", true)]
        [InlineData("[3,2,1,0,4]", false)]
        public void JumpGameTest(string inputJson, bool expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(inputJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().CanJump(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<int, bool> _memo;

        public Solution()
        {
            _memo = new Dictionary<int, bool>();
        }

        private bool CanJumpFrom(int[] nums, int i)
        {
            if (_memo.ContainsKey(i))
            {
                return _memo[i];
            }

            var max = nums[i];
            if (i == nums.Length - 1)
            {
                return true;
            }

            for (var j = 1; j <= max; j++)
            {
                if (CanJumpFrom(nums, i + j))
                {
                    return true;
                }
            }

            _memo[i] = false;
            return _memo[i];
        }

        public bool CanJump(int[] nums)
        {
            return CanJumpFrom(nums, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}