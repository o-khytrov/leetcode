using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using Xunit;

//Given an array of strings nums containing n unique binary strings each of 
//length n, return a binary string of length n that does not appear in nums. If there 
//are multiple answers, you may return any of them. 
//
// 
// Example 1: 
//
// 
//Input: nums = ["01","10"]
//Output: "11"
//Explanation: "11" does not appear in nums. "00" would also be correct.
// 
//
// Example 2: 
//
// 
//Input: nums = ["00","01"]
//Output: "11"
//Explanation: "11" does not appear in nums. "10" would also be correct.
// 
//
// Example 3: 
//
// 
//Input: nums = ["111","011","001"]
//Output: "101"
//Explanation: "101" does not appear in nums. "000", "010", "100", and "110" 
//would also be correct.
// 
//
// 
// Constraints: 
//
// 
// n == nums.length 
// 1 <= n <= 16 
// nums[i].length == n 
// nums[i] is either '0' or '1'. 
// All the strings of nums are unique. 
// 
//
// Related Topics Array String Backtracking 👍 1358 👎 52

namespace FindUniqueBinaryString
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"01\",\"10\"]", "11")]
        [InlineData("[\"00\",\"01\"]", "11")]
        [InlineData("[\"111\",\"011\",\"001\"]", "101")]
        public void FindUniqueBinaryStringTest(string numsJson, string expectedResult)
        {
            var nums = JsonSerializer.Deserialize<string[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().FindDifferentBinaryString(nums));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private IEnumerable<string> GetProduct(int n)
        {
            var max = Convert.ToInt32(new string('1', n), 2);
            for (int i = 0; i <= max; i++)
            {
                var bin = Convert.ToString(i, 2).PadLeft(n, '0');
                yield return bin;
            }
        }

        public string FindDifferentBinaryString(string[] nums)
        {
            var set = new HashSet<string>(nums);
            var n = nums.Length;
            foreach (var s in GetProduct(n))
            {
                if (!set.Contains(s))
                {
                    return s;
                }
            }

            return string.Empty;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}