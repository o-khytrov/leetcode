/**
You are given a 0-indexed integer array nums of even length.

 As long as nums is not empty, you must repetitively:


 Find the minimum number in nums and remove it.
 Find the maximum number in nums and remove it.
 Calculate the average of the two removed numbers.


 The average of two numbers a and b is (a + b) / 2.


 For example, the average of 2 and 3 is (2 + 3) / 2 = 2.5.


 Return the number of distinct averages calculated using the above process.

 Note that when there is a tie for a minimum or maximum number, any can be
removed.


 Example 1:


Input: nums = [4,1,4,0,3,5]
Output: 2
Explanation:
1. Remove 0 and 5, and the average is (0 + 5) / 2 = 2.5. Now, nums = [4,1,4,3].
2. Remove 1 and 4. The average is (1 + 4) / 2 = 2.5, and nums = [4,3].
3. Remove 3 and 4, and the average is (3 + 4) / 2 = 3.5.
Since there are 2 distinct numbers among 2.5, 2.5, and 3.5, we return 2.


 Example 2:


Input: nums = [1,100]
Output: 1
Explanation:
There is only one average to be calculated after removing 1 and 100, so we
return 1.



 Constraints:


 2 <= nums.length <= 100
 nums.length is even.
 0 <= nums[i] <= 100


 Related Topics Array Hash Table Two Pointers Sorting 👍 323 👎 21

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace NumberOfDistinctAverages
{
    public class Tests
    {
        [Theory]
        [InlineData("[4,1,4,0,3,5]", 2)]
        [InlineData("[1,100]", 1)]
        [InlineData("[9,5,7,8,7,9,8,2,0,7]", 5)]
        public void NumberOfDistinctAveragesTest(string numsJson, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().DistinctAverages(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int DistinctAverages(int[] nums)
        {
            var avgSet = new HashSet<double>();
            var set = nums.OrderBy(x => x).ToArray();
            var l = 0;
            var r = set.Length - 1;
            while (l < r)
            {
                avgSet.Add((set[r] + set[l]) / 2d);
                l++;
                r--;
            }

            return avgSet.Count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}

