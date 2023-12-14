/**
For two strings s and t, we say "t divides s" if and only if s = t + ... + t (i.
e., t is concatenated with itself one or more times).

 Given two strings str1 and str2, return the largest string x such that x
divides both str1 and str2.


 Example 1:


Input: str1 = "ABCABC", str2 = "ABC"
Output: "ABC"


 Example 2:


Input: str1 = "ABABAB", str2 = "ABAB"
Output: "AB"


 Example 3:


Input: str1 = "LEET", str2 = "CODE"
Output: ""



 Constraints:


 1 <= str1.length, str2.length <= 1000
 str1 and str2 consist of English uppercase letters.


 Related Topics Math String 👍 4589 👎 1056

*/

using System;
using Xunit;

namespace GreatestCommonDivisorOfStrings
{
    public class Tests
    {
        [Theory]
        [InlineData("ABCABC", "ABC", "ABC")]
        [InlineData("ABABAB", "ABAB", "AB")]
        [InlineData("LEET", "CODE", "")]
        public void GreatestCommonDivisorOfStringsTest(string str1, string str2, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().GcdOfStrings(str1, str2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool IsCommonDivisor(string str1, string str2, int k)
        {
            var len1 = str1.Length;
            var len2 = str2.Length;
            if (len1 % k > 0 || len2 % k > 0)
            {
                return false;
            }
            else
            {
                var strBase = str1.Substring(0, k);
                return string.IsNullOrEmpty(str1.Replace(strBase, "")) &&
                       string.IsNullOrEmpty(str2.Replace(strBase, ""));
            }
        }

        public string GcdOfStrings(string str1, string str2)
        {
            var l1 = 0;
            var maxL = 0;
            var minLength = Math.Min(str1.Length, str2.Length);
            while (l1 < minLength && str1[l1] == str2[l1])
            {
                if (IsCommonDivisor(str1, str2, l1 + 1))
                {
                    maxL = Math.Max(l1 + 1, maxL);
                }

                l1++;
            }

            return maxL > 0 ? str1[..maxL] : string.Empty;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}