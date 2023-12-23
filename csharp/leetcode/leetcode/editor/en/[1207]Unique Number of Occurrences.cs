/**
Given an array of integers arr, return true if the number of occurrences of
each value in the array is unique or false otherwise.


 Example 1:


Input: arr = [1,2,2,1,1,3]
Output: true
Explanation: The value 1 has 3 occurrences, 2 has 2 and 3 has 1. No two values
have the same number of occurrences.

 Example 2:


Input: arr = [1,2]
Output: false


 Example 3:


Input: arr = [-3,0,1,-3,1,1,1,-3,10,0]
Output: true



 Constraints:


 1 <= arr.length <= 1000
 -1000 <= arr[i] <= 1000


 Related Topics Array Hash Table 👍 4395 👎 104

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace UniqueNumberOfOccurrences
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2]", false)]
        [InlineData("[-3,0,1,-3,1,1,1,-3,10,0]", true)]
        public void UniqueNumberOfOccurrencesTest(string arrJson, bool expectedResult)
        {
            var arr = JsonSerializer.Deserialize<int[]>(arrJson)
                      ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().UniqueOccurrences(arr));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool UniqueOccurrences(int[] arr)
        {
            var map = new Dictionary<int, int>();
            for (int i = 0; i < arr.Length; i++)
            {
                var val = arr[i];
                if (!map.TryAdd(val, 1))
                {
                    map[val]++;
                }
            }

            var set = new HashSet<int>();
            foreach (var kvp in map)
            {
                if (set.Contains(kvp.Value))
                {
                    return false;
                }

                set.Add(kvp.Value);
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}