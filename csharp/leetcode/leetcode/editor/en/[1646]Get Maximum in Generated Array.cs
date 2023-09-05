/**
You are given an integer n. A 0-indexed integer array nums of length n + 1 is
generated in the following way:


 nums[0] = 0
 nums[1] = 1
 nums[2 * i] = nums[i] when 2 <= 2 * i <= n
 nums[2 * i + 1] = nums[i] + nums[i + 1] when 2 <= 2 * i + 1 <= n


 Return the maximum integer in the array nums.


 Example 1:


Input: n = 7
Output: 3
Explanation: According to the given rules:
  nums[0] = 0
  nums[1] = 1
  nums[(1 * 2) = 2] = nums[1] = 1
  nums[(1 * 2) + 1 = 3] = nums[1] + nums[2] = 1 + 1 = 2
  nums[(2 * 2) = 4] = nums[2] = 1
  nums[(2 * 2) + 1 = 5] = nums[2] + nums[3] = 1 + 2 = 3
  nums[(3 * 2) = 6] = nums[3] = 2
  nums[(3 * 2) + 1 = 7] = nums[3] + nums[4] = 2 + 1 = 3
Hence, nums = [0,1,1,2,1,3,2,3], and the maximum is max(0,1,1,2,1,3,2,3) = 3.


 Example 2:


Input: n = 2
Output: 1
Explanation: According to the given rules, nums = [0,1,1]. The maximum is max(0,
1,1) = 1.


 Example 3:


Input: n = 3
Output: 2
Explanation: According to the given rules, nums = [0,1,1,2]. The maximum is max(
0,1,1,2) = 2.



 Constraints:


 0 <= n <= 100


 Related Topics Array Dynamic Programming Simulation 👍 703 👎 880

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace GetMaximumInGeneratedArray
{
    public class Tests
    {
        [Theory]
        [InlineData(7, 3)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        public void GetMaximumInGeneratedArrayTest(int n, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().GetMaximumGenerated(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetNextNumber(int i, Dictionary<int, int> memo)
        {
            if (i == 0)
            {
                memo[i] = 0;
            }

            if (i == 1)
            {
                memo[i] = 1;
            }

            if (i > 1)
            {
                if (i % 2 == 0)
                {
                    memo[i] = memo[i / 2];
                }
                else
                {
                    memo[i] = memo[i / 2] + memo[i / 2 + 1];
                }
            }


            return memo[i];
        }

        public int GetMaximumGenerated(int n)
        {
            var memo = new Dictionary<int, int>();
            var next = GetNextNumber(n, memo);
            var maxValue = int.MinValue;
            for (var i = 0; i <= n; i++)
            {
                
                maxValue = Math.Max(maxValue, next);
            }

            return maxValue;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}