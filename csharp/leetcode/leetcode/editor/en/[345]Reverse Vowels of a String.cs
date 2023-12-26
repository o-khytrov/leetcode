/**
Given a string s, reverse only all the vowels in the string and return it.

 The vowels are 'a', 'e', 'i', 'o', and 'u', and they can appear in both lower
and upper cases, more than once.


 Example 1:
 Input: s = "hello"
Output: "holle"

 Example 2:
 Input: s = "leetcode"
Output: "leotcede"


 Constraints:


 1 <= s.length <= 3 * 10⁵
 s consist of printable ASCII characters.


 Related Topics Two Pointers String 👍 4240 👎 2720

*/

using System.Collections.Generic;
using System.Text;
using Xunit;

namespace ReverseVowelsOfAString
{
    public class Tests
    {
        [Theory]
        [InlineData("hello", "holle")]
        [InlineData("leetcode", "leotcede")]
        [InlineData("a.", "a.")]
        public void ReverseVowelsOfAStringTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().ReverseVowels(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static bool IsVowel(char c)
        {
            var lower = char.ToLower(c);
            return
                lower is 'a' or 'e' or 'i' or 'o' or 'u';
        }


        public string ReverseVowels(string s)
        {
            var sb = new StringBuilder();
            var r = s.Length - 1;
            var l = 0;
            while (l < s.Length || r >= 0)
            {
                if (l < s.Length && !IsVowel(s[l]))
                {
                    sb.Append(s[l]);
                    l++;
                }
                else
                {
                    if (r >= 0 && IsVowel(s[r]))
                    {
                        sb.Append(s[r]);
                        l++;
                    }

                    r--;
                }
            }

            return sb.ToString();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}