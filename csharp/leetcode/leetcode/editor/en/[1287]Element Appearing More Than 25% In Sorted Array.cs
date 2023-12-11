/**
Given an integer array sorted in non-decreasing order, there is exactly one
integer in the array that occurs more than 25% of the time, return that integer.


 Example 1:


Input: arr = [1,2,2,6,6,6,6,7,10]
Output: 6


 Example 2:


Input: arr = [1,1]
Output: 1



 Constraints:


 1 <= arr.length <= 10⁴
 0 <= arr[i] <= 10⁵


 Related Topics Array 👍 1256 👎 57

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace ElementAppearingMoreThan25InSortedArray
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,2,6,6,6,6,7,10]", 6)]
        public void ElementAppearingMoreThan25InSortedArrayTest(string arrJson, int expectedResult)
        {
            Assert.Equal(expectedResult,
                new Solution().FindSpecialInteger(JsonSerializer.Deserialize<int[]>(arrJson) ??
                                                  throw new ArgumentException("Invalid json")));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int FindSpecialInteger(int[] arr)
        {
            var map = new Dictionary<int, int>();
            var threshold = arr.Length / 4;
            for (var i = 0; i < arr.Length; i++)
            {
                if (!map.TryAdd(arr[i], 1))
                {
                    map[arr[i]]++;
                }
            }

            foreach (var kvp in map)
            {
                if (kvp.Value > threshold)
                {
                    return kvp.Key;
                }
            }

            return -1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}