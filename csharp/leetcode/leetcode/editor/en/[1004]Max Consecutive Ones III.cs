/**
Given a binary array nums and an integer k, return the maximum number of
consecutive 1's in the array if you can flip at most k 0's.


 Example 1:


Input: nums = [1,1,1,0,0,0,1,1,1,1,0], k = 2
Output: 6
Explanation: [1,1,1,0,0,1,1,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.

 Example 2:


Input: nums = [0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1], k = 3
Output: 10
Explanation: [0,0,1,1,1,1,1,1,1,1,1,1,0,0,0,1,1,1,1]
Bolded numbers were flipped from 0 to 1. The longest subarray is underlined.



 Constraints:


 1 <= nums.length <= 10⁵
 nums[i] is either 0 or 1.
 0 <= k <= nums.length


 Related Topics Array Binary Search Sliding Window Prefix Sum 👍 7919 👎 104

*/

using System;
using System.Text.Json;
using Xunit;

namespace MaxConsecutiveOnesIII
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,1,1,0,0,0,1,1,1,1,0]", 2, 6)]
        [InlineData("[0,0,1,1,0,0,1,1,1,0,1,1,0,0,0,1,1,1,1]", 3, 10)]
        [InlineData("[0,0,0,0]", 0, 0)]
        [InlineData("[0,0,1,1,1,0,0]", 0, 3)]
        [InlineData("[0,0,0,1]", 4, 4)]
        public void MaxConsecutiveOnesIIITest(string numsJson, int k, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().LongestOnes(nums, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LongestOnes(int[] nums, int k)
        {
            var longestOnes = 0;
            var l = 0;
            var zeros = 0;
            for (var r = 0; r < nums.Length; r++)
            {
                var val = nums[r];
                if (val == 0)
                {
                    zeros++;
                }

                while (l < r && zeros > k)
                {
                    if (nums[l] == 0)
                    {
                        zeros--;
                    }

                    l++;
                }

                var length = r - l + 1;
                var ones = length - zeros;

                if (ones==0 && k==0)
                {
                    length = 0;
                }
                longestOnes = Math.Max(longestOnes, length);
            }

            return longestOnes;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}