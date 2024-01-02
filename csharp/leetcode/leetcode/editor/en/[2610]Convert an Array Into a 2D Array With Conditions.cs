/**
You are given an integer array nums. You need to create a 2D array from nums
satisfying the following conditions:


 The 2D array should contain only the elements of the array nums.
 Each row in the 2D array contains distinct integers.
 The number of rows in the 2D array should be minimal.


 Return the resulting array. If there are multiple answers, return any of them.


 Note that the 2D array can have a different number of elements on each row.


 Example 1:


Input: nums = [1,3,4,1,2,3,1]
Output: [[1,3,4,2],[1,3],[1]]
Explanation: We can create a 2D array that contains the following rows:
- 1,3,4,2
- 1,3
- 1
All elements of nums were used, and each row of the 2D array contains distinct
integers, so it is a valid answer.
It can be shown that we cannot have less than 3 rows in a valid array.

 Example 2:


Input: nums = [1,2,3,4]
Output: [[4,3,2,1]]
Explanation: All elements of the array are distinct, so we can keep all of them
in the first row of the 2D array.



 Constraints:


 1 <= nums.length <= 200
 1 <= nums[i] <= nums.length


 Related Topics Array Hash Table 👍 817 👎 34

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace ConvertAnArrayIntoA2DArrayWithConditions
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,3,4,1,2,3,1]", "[[1,3,4,2],[1,3],[1]]")]
        public void ConvertAnArrayIntoA2DArrayWithConditionsTest(string numsJson, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().FindMatrix(nums)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<IList<int>> FindMatrix(int[] nums)
        {
            var map = new Dictionary<int, int>();
            for (var i = 0; i < nums.Length; i++)
            {
                var n = nums[i];
                if (!map.TryAdd(n, 1))
                {
                    map[n]++;
                }
            }

            var result = new List<IList<int>>();
            var count = nums.Length;
            while (count > 0)
            {
                var row = new List<int>();
                foreach (var kvp in map)
                {
                    if (kvp.Value > 0)
                    {
                        map[kvp.Key]--;

                        row.Add(kvp.Key);
                        count--;
                    }
                }

                result.Add(row);
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}