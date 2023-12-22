/**
Given a binary array nums, you should delete one element from it.

 Return the size of the longest non-empty subarray containing only 1's in the
resulting array. Return 0 if there is no such subarray.


 Example 1:


Input: nums = [1,1,0,1]
Output: 3
Explanation: After deleting the number in position 2, [1,1,1] contains 3
numbers with value of 1's.


 Example 2:


Input: nums = [0,1,1,1,0,1,1,0,1]
Output: 5
Explanation: After deleting the number in position 4, [0,1,1,1,1,1,0,1] longest
subarray with value of 1's is [1,1,1,1,1].


 Example 3:


Input: nums = [1,1,1]
Output: 2
Explanation: You must delete one element.



 Constraints:


 1 <= nums.length <= 10⁵
 nums[i] is either 0 or 1.


 Related Topics Array Dynamic Programming Sliding Window 👍 3664 👎 64

*/

using System;
using System.Text.Json;
using Xunit;

namespace LongestSubarrayOf1sAfterDeletingOneElement
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,1,0,1]", 3)]
        [InlineData("[0,1,1,1,0,1,1,0,1]", 5)]
        [InlineData("[1,1,1]", 2)]
        public void LongestSubarrayOf1sAfterDeletingOneElementTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().LongestSubarray(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LongestSubarray(int[] nums)
        {
            var zeros = 0;
            var maxValue = 0;
            var l = 0;
            var r = 0;
            while (r < nums.Length)
            {
                if (nums[r] == 0)
                {
                    zeros++;
                }

                r++;
                if (zeros > 1)
                {
                    while (l < r && zeros > 1)
                    {
                        if (nums[l] == 0)
                        {
                            zeros--;
                        }

                        l++;
                    }
                }

                maxValue = Math.Max(maxValue, r - l - zeros);
            }


            return Math.Min(nums.Length - 1, maxValue);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}