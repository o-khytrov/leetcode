/**
Given an array of integers nums and an integer target, return indices of the
two numbers such that they add up to target.

 You may assume that each input would have exactly one solution, and you may
not use the same element twice.

 You can return the answer in any order.


 Example 1:


Input: nums = [2,7,11,15], target = 9
Output: [0,1]
Explanation: Because nums[0] + nums[1] == 9, we return [0, 1].


 Example 2:


Input: nums = [3,2,4], target = 6
Output: [1,2]


 Example 3:


Input: nums = [3,3], target = 6
Output: [0,1]



 Constraints:


 2 <= nums.length <= 10⁴
 -10⁹ <= nums[i] <= 10⁹
 -10⁹ <= target <= 10⁹
 Only one valid answer exists.



Follow-up: Can you come up with an algorithm that is less than
O(n²)
 time complexity?

 Related Topics Array Hash Table 👍 50886 👎 1640

*/

using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace TwoSum
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,7,11,15]", 9, "[0,1]")]
        public void TwoSumTest(string numsJson, int target, string expectedResultJson)
        {
            var sut = new Solution();
            var nums = JsonSerializer.Deserialize<int[]>(numsJson);
            var result = sut.TwoSum(nums, target);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            var map = new Dictionary<int, int>();
            var result = new int[2];

            for (int i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                var dif = target - n;
                if (map.ContainsKey(dif))
                {
                    result[0] = map[dif];
                    result[1] = i;
                    return result;
                }

                map.TryAdd(n, i);
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}