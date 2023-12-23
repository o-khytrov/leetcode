/**
Given an encoded string, return its decoded string.

 The encoding rule is: k[encoded_string], where the encoded_string inside the
square brackets is being repeated exactly k times. Note that k is guaranteed to
be a positive integer.

 You may assume that the input string is always valid; there are no extra white
spaces, square brackets are well-formed, etc. Furthermore, you may assume that
the original data does not contain any digits and that digits are only for those
repeat numbers, k. For example, there will not be input like 3a or 2[4].

 The test cases are generated so that the length of the output will never
exceed 10⁵.


 Example 1:


Input: s = "3[a]2[bc]"
Output: "aaabcbc"


 Example 2:


Input: s = "3[a2[c]]"
Output: "accaccacc"


 Example 3:


Input: s = "2[abc]3[cd]ef"
Output: "abcabccdcdcdef"



 Constraints:


 1 <= s.length <= 30
 s consists of lowercase English letters, digits, and square brackets '[]'.
 s is guaranteed to be a valid input.
 All the integers in s are in the range [1, 300].


 Related Topics String Stack Recursion 👍 12133 👎 560

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualBasic;
using Xunit;

namespace DecodeString
{
    public class Tests
    {
        [Theory]
        [InlineData("3[a]2[bc]", "aaabcbc")]
        [InlineData("3[a2[c]]", "accaccacc")]
        [InlineData("2[abc]3[cd]ef", "abcabccdcdcdef")]
        public void DecodeStringTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().DecodeString(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private StringBuilder Decode(ReadOnlySpan<char> s, int n)
        {
            var internalSb = new StringBuilder();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];

                if (char.IsDigit(c))
                {
                    var t = i;
                    while (char.IsDigit(s[t]))
                    {
                        t++;
                    }

                    var strNumber = s.Slice(i, t - i);
                    var number = int.Parse(strNumber);
                    var open = 1;
                    var p = t + 1;
                    while (p < s.Length && open > 0)
                    {
                        if (s[p] == ']')
                        {
                            open--;
                        }

                        if (s[p] == '[')
                        {
                            open++;
                        }

                        p++;
                    }

                    var length = p - 2 - t;
                    var inner = s.Slice(t + 1, length);

                    var decoded = Decode(inner, number);
                    internalSb.Append(decoded);
                    i = t + length;
                }
                else if (char.IsLetter(c))
                {
                    internalSb.Append(c);
                }
            }


            var tmp = internalSb.ToString();
            for (var i = 0; i < n - 1; i++)
            {
                internalSb.Append(tmp);
            }

            return internalSb;
        }

        public string DecodeString(string s)
        {
            var span = s.AsSpan();
            return Decode(span, 1).ToString();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}