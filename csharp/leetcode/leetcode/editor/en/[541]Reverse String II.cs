using System;
using System.Collections.Generic;
using Xunit;

//Given a string s and an integer k, reverse the first k characters for every 2
//k characters counting from the start of the string. 
//
// If there are fewer than k characters left, reverse all of them. If there are 
//less than 2k but greater than or equal to k characters, then reverse the first 
//k characters and leave the other as original. 
//
// 
// Example 1: 
// Input: s = "abcdefg", k = 2
//Output: "bacdfeg"
// 
// Example 2: 
// Input: s = "abcd", k = 2
//Output: "bacd"
// 
// 
// Constraints: 
//
// 
// 1 <= s.length <= 10⁴ 
// s consists of only lowercase English letters. 
// 1 <= k <= 10⁴ 
// 
//
// Related Topics Two Pointers String 👍 1735 👎 3423

namespace ReverseStringII
{
    public class Tests
    {
        [Theory]
        [InlineData("abcdefg", 2, "bacdfeg")]
        [InlineData("abcd", 4, "dcba")]
        public void ReverseStringIiTest(string s, int k, string expectedResult)
        {
            var sut = new Solution();
            var result = sut.ReverseStr(s, k);
            Assert.Equal(expectedResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public void Reverse(char[] a, int start, int end)
        {
            var l = start;
            var r = end - 1;
            while (l <= r)
            {
                (a[l], a[r]) = (a[r], a[l]);
                l++;
                r--;
            }
        }

        public string ReverseStr(string s, int k)
        {
            var reversed = s.ToCharArray();
            var c = 1;
            for (int i = 0; i < s.Length; i += k)
            {
                if (c % 2 == 1)
                {
                    Reverse(reversed, i, Math.Min(i + k, s.Length));
                }

                c++;
            }

            return new string(reversed);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}