/**
Given two 0-indexed integer arrays nums1 and nums2, return a list answer of
size 2 where:


 answer[0] is a list of all distinct integers in nums1 which are not present in
nums2.
 answer[1] is a list of all distinct integers in nums2 which are not present in
nums1.


 Note that the integers in the lists may be returned in any order.


 Example 1:


Input: nums1 = [1,2,3], nums2 = [2,4,6]
Output: [[1,3],[4,6]]
Explanation:
For nums1, nums1[1] = 2 is present at index 0 of nums2, whereas nums1[0] = 1
and nums1[2] = 3 are not present in nums2. Therefore, answer[0] = [1,3].
For nums2, nums2[0] = 2 is present at index 1 of nums1, whereas nums2[1] = 4
and nums2[2] = 6 are not present in nums2. Therefore, answer[1] = [4,6].

 Example 2:


Input: nums1 = [1,2,3,3], nums2 = [1,1,2,2]
Output: [[3],[]]
Explanation:
For nums1, nums1[2] and nums1[3] are not present in nums2. Since nums1[2] ==
nums1[3], their value is only included once and answer[0] = [3].
Every integer in nums2 is present in nums1. Therefore, answer[1] = [].



 Constraints:


 1 <= nums1.length, nums2.length <= 1000
 -1000 <= nums1[i], nums2[i] <= 1000


 Related Topics Array Hash Table 👍 2163 👎 89

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace FindTheDifferenceOfTwoArrays
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3]", "[2,4,6]", "[[1,3],[4,6]]")]
        public void FindTheDifferenceOfTwoArraysTest(string nums1Json, string nums2Json, string expectedResultJson)
        {
            var nums1 = JsonSerializer.Deserialize<int[]>(nums1Json)
                        ?? throw new ArgumentException("Invalid json");

            var nums2 = JsonSerializer.Deserialize<int[]>(nums2Json)
                        ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().FindDifference(nums1, nums2)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<IList<int>> FindDifference(int[] nums1, int[] nums2)
        {
            var map1 = nums1.ToHashSet();
            var map2 = nums2.ToHashSet();
            var result = new List<IList<int>>
            {
                map1.Except(map2).ToArray(),
                map2.Except(map1).ToArray()
            };
            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}