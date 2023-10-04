/**
You are a professional robber planning to rob houses along a street. Each house
has a certain amount of money stashed. All houses at this place are arranged in
a circle. That means the first house is the neighbor of the last one. Meanwhile,
 adjacent houses have a security system connected, and it will automatically
contact the police if two adjacent houses were broken into on the same night.

 Given an integer array nums representing the amount of money of each house,
return the maximum amount of money you can rob tonight without alerting the police.



 Example 1:


Input: nums = [2,3,2]
Output: 3
Explanation: You cannot rob house 1 (money = 2) and then rob house 3 (money = 2)
, because they are adjacent houses.


 Example 2:


Input: nums = [1,2,3,1]
Output: 4
Explanation: Rob house 1 (money = 1) and then rob house 3 (money = 3).
Total amount you can rob = 1 + 3 = 4.


 Example 3:


Input: nums = [1,2,3]
Output: 3



 Constraints:


 1 <= nums.length <= 100
 0 <= nums[i] <= 1000


 Related Topics Array Dynamic Programming 👍 9140 👎 132

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace HouseRobberII
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,3,2]", 3)]
        [InlineData("[1,2,3,1]", 4)]
        [InlineData("[1,2,3]", 3)]
        [InlineData("[1]", 1)]
        [InlineData("[6,6,4,8,4,3,3,10]", 27)]
        public void HouseRobberTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().Rob(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<(int, int), int> _memo;

        public Solution()
        {
            _memo = new();
        }

        private int RobFrom(int[] nums, int position, int begin)
        {
            if (_memo.TryGetValue((position, begin), out var maxValue))
            {
                return maxValue;
            }

            if (position > nums.Length - 1)
            {
                return 0;
            }

            if (position == nums.Length - 1)
            {
                if (begin == 0 && nums.Length > 1)
                {
                    return 0;
                }

                return nums[position];
            }

            var firstWay = RobFrom(nums, position + 2, begin);
            var secondWay = RobFrom(nums, position + 3, begin);
            var money = nums[position] + Math.Max(firstWay, secondWay);
            _memo[(position, begin)] = money;
            return _memo[(position, begin)];
        }

        public int Rob(int[] nums)
        {
            var firstWay = RobFrom(nums, 0, 0);
            //var firstWay = 1;
            var secondWay = RobFrom(nums, 1, 1);
            var thirdWay = RobFrom(nums, 2, 2);
            return Math.Max(firstWay, Math.Max(secondWay, thirdWay));
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}