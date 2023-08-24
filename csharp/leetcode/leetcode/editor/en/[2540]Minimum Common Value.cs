/**
Given two integer arrays nums1 and nums2, sorted in non-decreasing order, 
return the minimum integer common to both arrays. If there is no common integer 
amongst nums1 and nums2, return -1. 

 Note that an integer is said to be common to nums1 and nums2 if both arrays 
have at least one occurrence of that integer. 

 
 Example 1: 

 
Input: nums1 = [1,2,3], nums2 = [2,4]
Output: 2
Explanation: The smallest element common to both arrays is 2, so we return 2.
 

 Example 2: 

 
Input: nums1 = [1,2,3,6], nums2 = [2,3,4,5]
Output: 2
Explanation: There are two common elements in the array 2 and 3 out of which 2 
is the smallest, so 2 is returned.
 

 
 Constraints: 

 
 1 <= nums1.length, nums2.length <= 10⁵ 
 1 <= nums1[i], nums2[j] <= 10⁹ 
 Both nums1 and nums2 are sorted in non-decreasing order. 
 

 Related Topics Array Hash Table Two Pointers Binary Search 👍 442 👎 9

*/

using System.Text.Json;
using Xunit;

namespace MinimumCommonValue
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3]", "[2,4]", 2)]
        public void MinimumCommonValueTest(string nums1Json, string nums2Json, int expectedResult)
        {
            var sut = new Solution();
            var nums1 = JsonSerializer.Deserialize<int[]>(nums1Json);
            var nums2 = JsonSerializer.Deserialize<int[]>(nums2Json);
            var result = sut.GetCommon(nums1, nums2);
            
            Assert.Equal(expectedResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int GetCommon(int[] nums1, int[] nums2)
        {
            return -1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}