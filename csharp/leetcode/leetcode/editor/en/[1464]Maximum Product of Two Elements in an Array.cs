using System;
using System.Text.Json;
using Xunit;

//Given the array of integers nums, you will choose two different indices i and 
//j of that array. Return the maximum value of (nums[i]-1)*(nums[j]-1).
//
// 
// Example 1: 
//
// 
//Input: nums = [3,4,5,2]
//Output: 12 
//Explanation: If you choose the indices i=1 and j=2 (indexed from 0), you will 
//get the maximum value, that is, (nums[1]-1)*(nums[2]-1) = (4-1)*(5-1) = 3*4 = 12
//. 
// 
//
// Example 2: 
//
// 
//Input: nums = [1,5,4,5]
//Output: 16
//Explanation: Choosing the indices i=1 and j=3 (indexed from 0), you will get 
//the maximum value of (5-1)*(5-1) = 16.
// 
//
// Example 3: 
//
// 
//Input: nums = [3,7]
//Output: 12
// 
//
// 
// Constraints: 
//
// 
// 2 <= nums.length <= 500 
// 1 <= nums[i] <= 10^3 
// 
//
// Related Topics Array Sorting Heap (Priority Queue) 👍 2108 👎 210

namespace MaximumProductOfTwoElementsInAnArray
{
    public class Tests
    {
        [Theory]
        [InlineData("[3,4,5,2]", 12)]
        [InlineData("[1,5,4,5]", 16)]
        [InlineData("[3,7]", 12)]
        public void MaximumProductOfTwoElementsInAnArrayTest(string arrayJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(arrayJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MaxProduct(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxProduct(int[] nums)
        {
            Array.Sort(nums);
            return (nums[^1] - 1) * (nums[^2] - 1);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}