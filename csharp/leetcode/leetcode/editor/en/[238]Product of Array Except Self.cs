/**
Given an integer array nums, return an array answer such that answer[i] is
equal to the product of all the elements of nums except nums[i].

 The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit
integer.

 You must write an algorithm that runs in O(n) time and without using the
division operation.


 Example 1:
 Input: nums = [1,2,3,4]
Output: [24,12,8,6]

 Example 2:
 Input: nums = [-1,1,0,-3,3]
Output: [0,0,9,0,0]


 Constraints:


 2 <= nums.length <= 10⁵
 -30 <= nums[i] <= 30
 The product of any prefix or suffix of nums is guaranteed to fit in a 32-bit
integer.



 Follow up: Can you solve the problem in O(1) extra space complexity? (The
output array does not count as extra space for space complexity analysis.)

 Related Topics Array Prefix Sum 👍 20972 👎 1219

*/

using System;
using System.Text.Json;
using Xunit;

namespace ProductOfArrayExceptSelf
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4]", "[24,12,8,6]")]
        [InlineData("[-1,1,0,-3,3]", "[0,0,9,0,0]")]
        public void ProductOfArrayExceptSelfTest(string numsJson, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().ProductExceptSelf(nums)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] ProductExceptSelf(int[] nums)
        {
            var left = new int[nums.Length];
            var right = new int[nums.Length];

            var l = 1;
            var r = 1;
            for (var i = 0; i < nums.Length; i++)
            {
                left[i] = l;
                right[nums.Length - 1 - i] = r;
                l *= nums[i];
                r *= nums[nums.Length - 1 - i];
            }

            var result = new int[nums.Length];
            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = left[i] * right[i];
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}