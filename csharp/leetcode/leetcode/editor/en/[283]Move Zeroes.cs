using System;
using System.Text.Json;
using Xunit;

//Given an integer array nums, move all 0's to the end of it while maintaining 
//the relative order of the non-zero elements. 
//
// Note that you must do this in-place without making a copy of the array. 
//
// 
// Example 1: 
// Input: nums = [0,1,0,3,12]
//Output: [1,3,12,0,0]
// 
// Example 2: 
// Input: nums = [0]
//Output: [0]
// 
// 
// Constraints: 
//
// 
// 1 <= nums.length <= 10⁴ 
// -2³¹ <= nums[i] <= 2³¹ - 1 
// 
//
// 
//Follow up: Could you minimize the total number of operations done?
//
// Related Topics Array Two Pointers 👍 15897 👎 411

namespace MoveZeroes
{
    public class Tests
    {
        [Theory]
        [InlineData("[0,1,0,3,12]", "[1,3,12,0,0]")]
        public void MoveZeroesTest(string numsJson, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            new Solution().MoveZeroes(nums);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public void MoveZeroes(int[] nums)
        {
            var insertPosition = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                if (nums[i] != 0)
                {
                    nums[insertPosition++] = nums[i];
                }
            }

            while (insertPosition < nums.Length)
            {
                nums[insertPosition++] = 0;
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}