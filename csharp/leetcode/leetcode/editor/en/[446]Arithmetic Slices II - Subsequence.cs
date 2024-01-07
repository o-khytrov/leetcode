/**
Given an integer array nums, return the number of all the arithmetic
subsequences of nums.

 A sequence of numbers is called arithmetic if it consists of at least three
elements and if the difference between any two consecutive elements is the same.


 For example, [1, 3, 5, 7, 9], [7, 7, 7, 7], and [3, -1, -5, -9] are arithmetic
sequences.
 For example, [1, 1, 2, 5, 7] is not an arithmetic sequence.


 A subsequence of an array is a sequence that can be formed by removing some
elements (possibly none) of the array.


 For example, [2,5,10] is a subsequence of [1,2,1,2,4,1,5,10].


 The test cases are generated so that the answer fits in 32-bit integer.


 Example 1:


Input: nums = [2,4,6,8,10]
Output: 7
Explanation: All arithmetic subsequence slices are:
[2,4,6]
[4,6,8]
[6,8,10]
[2,4,6,8]
[4,6,8,10]
[2,4,6,8,10]
[2,6,10]


 Example 2:


Input: nums = [7,7,7,7,7]
Output: 16
Explanation: Any subsequence of this array is arithmetic.



 Constraints:


 1 <= nums.length <= 1000
 -2³¹ <= nums[i] <= 2³¹ - 1


 Related Topics Array Dynamic Programming 👍 2703 👎 130

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace ArithmeticSlicesIISubsequence
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,4,6,8,10]", 7)]
        [InlineData("[7,7,7,7,7]", 16)]
        public void ArithmeticSlicesIiSubsequenceTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().NumberOfArithmeticSlices(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int NumberOfArithmeticSlices(int[] nums)
        {
            var dp = new int[nums.Length][];

            var map = new Dictionary<long, List<int>>();
            for (var i = 0; i < nums.Length; i++)
            {
                dp[i] = new int[nums.Length];
                if (!map.ContainsKey(nums[i]))
                {
                    map.Add(nums[i], new List<int>());
                }

                map[nums[i]].Add(i);
            }

            var sum = 0;
            for (var i = 1; i < nums.Length; i++)
            {
                for (var j = i + 1; j < nums.Length; j++)
                {
                    long a = 2l * nums[i] - nums[j];
                    if (map.ContainsKey(a))
                    {
                        foreach (var k in map[a])
                        {
                            if (k < i)
                            {
                                dp[i][j] += dp[k][i] + 1;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    sum += dp[i][j];
                }
            }

            return sum;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}