using System;
using System.Collections.Generic;
using Xunit;

//Given a string s, return the length of the longest substring between two 
//equal characters, excluding the two characters. If there is no such substring return 
//-1. 
//
// A substring is a contiguous sequence of characters within a string. 
//
// 
// Example 1: 
//
// 
//Input: s = "aa"
//Output: 0
//Explanation: The optimal substring here is an empty substring between the two 
//'a's. 
//
// Example 2: 
//
// 
//Input: s = "abca"
//Output: 2
//Explanation: The optimal substring here is "bc".
// 
//
// Example 3: 
//
// 
//Input: s = "cbzxy"
//Output: -1
//Explanation: There are no characters that appear twice in s.
// 
//
// 
// Constraints: 
//
// 
// 1 <= s.length <= 300 
// s contains only lowercase English letters. 
// 
//
// Related Topics Hash Table String 👍 946 👎 49

namespace LargestSubstringBetweenTwoEqualCharacters
{
    public class Tests
    {
        [Theory]
        [InlineData("aa", 0)]
        [InlineData("abca", 2)]
        [InlineData("cbzxy", -1)]
        [InlineData("mgntdygtxrvxjnwksqhxuxtrv", 18)]
        public void LargestSubstringBetweenTwoEqualCharactersTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MaxLengthBetweenEqualCharacters(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxLengthBetweenEqualCharacters(string s)
        {
            var map = new Dictionary<char, (int, int)>();
            var max = -1;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (map.ContainsKey(c))
                {
                    var (firstIndex, count) = map[c];
                    map[c] = (firstIndex, count + 1);
                    max = Math.Max(i - firstIndex - 1, max);
                }
                else
                {
                    map.Add(c, (i, 1));
                }
            }

            return max;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}