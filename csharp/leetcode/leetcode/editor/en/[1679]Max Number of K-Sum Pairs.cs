/**
You are given an integer array nums and an integer k.

 In one operation, you can pick two numbers from the array whose sum equals k
and remove them from the array.

 Return the maximum number of operations you can perform on the array.


 Example 1:


Input: nums = [1,2,3,4], k = 5
Output: 2
Explanation: Starting with nums = [1,2,3,4]:
- Remove numbers 1 and 4, then nums = [2,3]
- Remove numbers 2 and 3, then nums = []
There are no more pairs that sum up to 5, hence a total of 2 operations.

 Example 2:


Input: nums = [3,1,3,4,3], k = 6
Output: 1
Explanation: Starting with nums = [3,1,3,4,3]:
- Remove the first two 3's, then nums = [1,4,3]
There are no more pairs that sum up to 6, hence a total of 1 operation.


 Constraints:


 1 <= nums.length <= 10⁵
 1 <= nums[i] <= 10⁹
 1 <= k <= 10⁹


 Related Topics Array Hash Table Two Pointers Sorting 👍 2861 👎 68

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MaxNumberOfKSumPairs
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4]", 5, 2)]
        [InlineData("[3,1,3,4,3]", 6, 1)]
        [InlineData("[4,4,1,3,1,3,2,2,5,5,1,5,2,1,2,3,5,4]", 2, 2)]
        public void MaxNumberOfKSumPairsTest(string numsJson, int k, int expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MaxOperations(nums, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private void Reduce(Dictionary<int, int> map, int key)
        {
            if (!map.ContainsKey(key))
            {
                return;
            }

            map[key]--;
            if (map[key] == 0)
            {
                map.Remove(key);
            }
        }

        public int MaxOperations(int[] nums, int k)
        {
            var map = new Dictionary<int, int>();
            foreach (var u in nums)
            {
                if (!map.TryAdd(u, 1))
                {
                    map[u]++;
                }
            }

            var count = 0;
            for (int i = 0; i < nums.Length; i++)
            {
                var first = nums[i];
                if (map.ContainsKey(k - first) && map.ContainsKey(first))
                {
                    if (k - first == first && map[first] < 2)
                    {
                        continue;
                    }

                    Reduce(map, first);
                    Reduce(map, k - first);

                    count++;
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}