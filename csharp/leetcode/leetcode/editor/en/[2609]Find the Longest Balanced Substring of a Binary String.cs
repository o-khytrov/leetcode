/**
You are given a binary string s consisting only of zeroes and ones.

 A substring of s is considered balanced if all zeroes are before ones and the
number of zeroes is equal to the number of ones inside the substring. Notice
that the empty substring is considered a balanced substring.

 Return the length of the longest balanced substring of s.

 A substring is a contiguous sequence of characters within a string.


 Example 1:


Input: s = "01000111"
Output: 6
Explanation: The longest balanced substring is "000111", which has length 6.


 Example 2:


Input: s = "00111"
Output: 4
Explanation: The longest balanced substring is "0011", which has length 4.


 Example 3:


Input: s = "111"
Output: 0
Explanation: There is no balanced substring except the empty substring, so the
answer is 0.



 Constraints:


 1 <= s.length <= 50
 '0' <= s[i] <= '1'


 Related Topics String 👍 315 👎 18

*/

using System;
using Xunit;

namespace FindTheLongestBalancedSubstringOfABinaryString
{
    public class Tests
    {
        [Theory]
        [InlineData("01000111", 6)]
        [InlineData("01", 2)]
        [InlineData("001", 2)]
        public void FindTheLongestBalancedSubstringOfABinaryStringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().FindTheLongestBalancedSubstring(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int FindTheLongestBalancedSubstring(string s)
        {
            var map = new int[s.Length][];
            for (var i = 0; i < map.Length; i++)
            {
                map[i] = new int[2];
            }

            var r = s.Length - 1;
            var ones = 0;
            var zeros = 0;
            for (var l = 0; l < s.Length; l++, r--)
            {
                if (s[l] == '0')
                {
                    zeros++;
                }
                else
                {
                    zeros = 0;
                }

                map[l][0] = zeros;
                if (s[r] == '1')
                {
                    ones++;
                }
                else
                {
                    ones = 0;
                }

                map[r][1] = ones;
            }

            var maxBalanceLength = 0;
            for (var i = 0; i < map.Length; i++)
            {
                if (i < map.Length - 1 && map[i][0] > 0 && map[i + 1][1] > 0)
                {
                    maxBalanceLength = Math.Max(maxBalanceLength, Math.Min(map[i][0], map[i + 1][1]) * 2);
                }
            }

            return maxBalanceLength;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}