using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

//You are given a 0-indexed integer array nums and a target element target. 
//
// A target index is an index i such that nums[i] == target. 
//
// Return a list of the target indices of nums after sorting nums in non-
//decreasing order. If there are no target indices, return an empty list. The returned 
//list must be sorted in increasing order. 
//
// 
// Example 1: 
//
// 
//Input: nums = [1,2,5,2,3], target = 2
//Output: [1,2]
//Explanation: After sorting, nums is [1,2,2,3,5].
//The indices where nums[i] == 2 are 1 and 2.
// 
//
// Example 2: 
//
// 
//Input: nums = [1,2,5,2,3], target = 3
//Output: [3]
//Explanation: After sorting, nums is [1,2,2,3,5].
//The index where nums[i] == 3 is 3.
// 
//
// Example 3: 
//
// 
//Input: nums = [1,2,5,2,3], target = 5
//Output: [4]
//Explanation: After sorting, nums is [1,2,2,3,5].
//The index where nums[i] == 5 is 4.
// 
//
// 
// Constraints: 
//
// 
// 1 <= nums.length <= 100 
// 1 <= nums[i], target <= 100 
// 
//
// Related Topics Array Binary Search Sorting 👍 1619 👎 76

namespace FindTargetIndicesAfterSortingArray
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,5,2,3]", 2, "[1,2]")]
        [InlineData("[1,2,5,2,3]", 3, "[3]")]
        [InlineData("[1,2,5,2,3]", 5, "[4]")]
        [InlineData("[100,1,100]", 100, "[1,2]")]
        public void FindTargetIndicesAfterSortingArrayTest(string numsJson, int target, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson) ?? throw new ArgumentException("Invalid Json");

            var result = new Solution().TargetIndices(nums, target);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<int> TargetIndices(int[] nums, int target)
        {
            Array.Sort(nums);
            var result = new List<int>();
            var l = 0;
            var r = nums.Length - 1;
            while (l <= r)
            {
                var m = l + (r - l) / 2;
                var val = nums[m];
                if (val == target)
                {
                    var f = m + 1;

                    while (f <= nums.Length - 1 && nums[f] == val)
                    {
                        f++;
                    }

                    var b = m - 1;
                    while (b >= 0 && nums[b] == val)
                    {
                        b--;
                    }

                    for (var i = b + 1; i <= f - 1; i++)
                    {
                        result.Add(i);
                    }


                    return result;
                }

                if (val > target)
                {
                    r = m - 1;
                }
                else
                {
                    l = m + 1;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}