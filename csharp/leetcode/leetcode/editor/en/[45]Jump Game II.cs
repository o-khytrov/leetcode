/**
You are given a 0-indexed array of integers nums of length n. You are initially
positioned at nums[0].

 Each element nums[i] represents the maximum length of a forward jump from
index i. In other words, if you are at nums[i], you can jump to any nums[i + j]
where:


 0 <= j <= nums[i] and
 i + j < n


 Return the minimum number of jumps to reach nums[n - 1]. The test cases are
generated such that you can reach nums[n - 1].


 Example 1:


Input: nums = [2,3,1,1,4]
Output: 2
Explanation: The minimum number of jumps to reach the last index is 2. Jump 1
step from index 0 to 1, then 3 steps to the last index.


 Example 2:


Input: nums = [2,3,0,1,4]
Output: 2



 Constraints:


 1 <= nums.length <= 10⁴
 0 <= nums[i] <= 1000
 It's guaranteed that you can reach nums[n - 1].


 Related Topics Array Dynamic Programming Greedy 👍 13499 👎 480

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace JumpGameII
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,3,1,1,4]", 2)]
        [InlineData("[2,3,0,1,4]", 2)]
        [InlineData("[1,2]", 1)]
        [InlineData("[2,1]", 1)]
        public void JumpGameIITest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().Jump(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<int, int> _memo = new();

        private int JumpFrom(int[] nums, int p)
        {
            if (p == nums.Length - 1)
            {
                return 0;
            }

            if (p > nums.Length - 1)
            {
                return -1;
            }

            if (_memo.TryGetValue(p, out var val))
            {
                return val;
            }

            var maxDistance = nums[p];
            var minJumpsNumber = nums.Length - p;
            for (var i = 1; i <= maxDistance; i++)
            {
                var subSolution = JumpFrom(nums, p + i);
                if (subSolution != -1)
                {
                    minJumpsNumber = Math.Min(minJumpsNumber, subSolution + 1);
                }
            }

            _memo[p] = minJumpsNumber;
            return _memo[p];
        }

        public int Jump(int[] nums)
        {
            return JumpFrom(nums, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}