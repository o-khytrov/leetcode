/**
Given a string s of zeros and ones, return the maximum score after splitting
the string into two non-empty substrings (i.e. left substring and right substring).


 The score after splitting a string is the number of zeros in the left
substring plus the number of ones in the right substring.


 Example 1:


Input: s = "011101"
Output: 5
Explanation:
All possible ways of splitting s into two non-empty substrings are:
left = "0" and right = "11101", score = 1 + 4 = 5
left = "01" and right = "1101", score = 1 + 3 = 4
left = "011" and right = "101", score = 1 + 2 = 3
left = "0111" and right = "01", score = 1 + 1 = 2
left = "01110" and right = "1", score = 2 + 1 = 3


 Example 2:


Input: s = "00111"
Output: 5
Explanation: When left = "00" and right = "111", we get the maximum score = 2 +
3 = 5


 Example 3:


Input: s = "1111"
Output: 3



 Constraints:


 2 <= s.length <= 500
 The string s consists of characters '0' and '1' only.


 Related Topics String 👍 988 👎 46

*/

using System;
using Xunit;

namespace MaximumScoreAfterSplittingAString
{
    public class Tests
    {
        [Theory]
        [InlineData("011101", 5)]
        [InlineData("00111", 5)]
        [InlineData("1111", 3)]
        [InlineData("00", 1)]
        public void MaximumScoreAfterSplittingAStringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MaxScore(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxScore(string s)
        {
            var maxScore = 0;
            var ones = new int[s.Length - 1];
            var zeros = new int [s.Length - 1];
            var o = s[^1] == '1' ? 1 : 0;
            var z = s[0] == '0' ? 1 : 0;
            for (var i = 1; i < s.Length; i++)
            {
                zeros[i - 1] = z;
                if (s[i] == '0')
                {
                    z++;
                }
            }

            for (int i = s.Length - 2; i >= 0; i--)
            {
                ones[i] = o;

                if (s[i] == '1')
                {
                    o++;
                }
            }

            for (int i = 0; i < ones.Length; i++)
            {
                maxScore = Math.Max(ones[i] + zeros[i], maxScore);
            }

            return maxScore;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}