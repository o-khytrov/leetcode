/**
You have a set of integers s, which originally contains all the numbers from 1
to n. Unfortunately, due to some error, one of the numbers in s got duplicated
to another number in the set, which results in repetition of one number and loss
of another number.

 You are given an integer array nums representing the data status of this set
after the error.

 Find the number that occurs twice and the number that is missing and return
them in the form of an array.


 Example 1:
 Input: nums = [1,2,2,4]
Output: [2,3]

 Example 2:
 Input: nums = [1,1]
Output: [1,2]


 Constraints:


 2 <= nums.length <= 10⁴
 1 <= nums[i] <= 10⁴


 Related Topics Array Hash Table Bit Manipulation Sorting 👍 4191 👎 998

*/

using System;
using System.Text.Json;
using Xunit;

namespace SetMismatch
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,2,4]", "[2,3]")]
        [InlineData("[1,1]", "[1,2]")]
        [InlineData("[2,2]", "[2,1]")]
        public void SetMismatchTest(string numsJson, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().FindErrorNums(nums)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[] FindErrorNums(int[] nums)
        {
            var m2 = new int[nums.Length];
            for (var i = 0; i < nums.Length; i++)
            {
                m2[nums[i] - 1]++;
            }

            var r = new int[2];
            for (int i = 0; i < m2.Length; i++)
            {
                if (m2[i] == 0)
                {
                    r[1] = i + 1;
                }

                if (m2[i] > 1)
                {
                    r[0] = i + 1;
                }
            }

            return r;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}