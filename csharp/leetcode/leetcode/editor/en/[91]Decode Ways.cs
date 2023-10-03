/**
A message containing letters from A-Z can be encoded into numbers using the
following mapping:


'A' -> "1"
'B' -> "2"
...
'Z' -> "26"


 To decode an encoded message, all the digits must be grouped then mapped back
into letters using the reverse of the mapping above (there may be multiple ways).
 For example, "11106" can be mapped into:


 "AAJF" with the grouping (1 1 10 6)
 "KJF" with the grouping (11 10 6)


 Note that the grouping (1 11 06) is invalid because "06" cannot be mapped into
'F' since "6" is different from "06".

 Given a string s containing only digits, return the number of ways to decode
it.

 The test cases are generated so that the answer fits in a 32-bit integer.


 Example 1:


Input: s = "12"
Output: 2
Explanation: "12" could be decoded as "AB" (1 2) or "L" (12).


 Example 2:


Input: s = "226"
Output: 3
Explanation: "226" could be decoded as "BZ" (2 26), "VF" (22 6), or "BBF" (2 2 6
).


 Example 3:


Input: s = "06"
Output: 0
Explanation: "06" cannot be mapped to "F" because of the leading zero ("6" is
different from "06").



 Constraints:


 1 <= s.length <= 100
 s contains only digits and may contain leading zero(s).


 Related Topics String Dynamic Programming 👍 10594 👎 4354

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace DecodeWays
{
    public class Tests
    {
        [Theory]
        [InlineData("12", 2)]
        [InlineData("226", 3)]
        [InlineData("06", 0)]
        public void DecodeWaysTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().NumDecodings(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<(int, int), int> _memo;

        public Solution()
        {
            _memo = new();
        }

        private bool IsValidCode(ReadOnlySpan<char> code)
        {
            if (code.Length == 2 && code[0] == '0')
            {
                return false;
            }

            var intCode = int.Parse(code);
            return intCode is >= 1 and <= 26;
        }

        int DecodeFrom(string s, int i, int lenght)
        {
            if (_memo.ContainsKey((i, lenght)))
            {
                return _memo[(i, lenght)];
            }

            if (i == s.Length - 1 && lenght == 1 && s[i] != '0')
            {
                return 1;
            }

            if (i + lenght > s.Length)
            {
                return 0;
            }

            var span = s.AsSpan().Slice(i, lenght).ToString();


            if (!IsValidCode(span))
            {
                return 0;
            }

            if (lenght == 2 && i + lenght == s.Length)
            {
                return 1;
            }

            var oneStep = DecodeFrom(s, i + lenght, 1);
            var twoStep = DecodeFrom(s, i + lenght, 2);
            _memo[(i, lenght)] = oneStep + twoStep;
            return _memo[(i, lenght)];
        }

        public int NumDecodings(string s)
        {
            var oneStep = DecodeFrom(s, 0, 1);
            var twoStep = DecodeFrom(s, 0, 2);

            return oneStep + twoStep;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}