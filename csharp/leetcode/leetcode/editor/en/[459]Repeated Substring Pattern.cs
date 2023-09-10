using System;
using System.Linq;
using Xunit;

//Given a string s, check if it can be constructed by taking a substring of it 
//and appending multiple copies of the substring together. 
//
// 
// Example 1: 
//
// 
//Input: s = "abab"
//Output: true
//Explanation: It is the substring "ab" twice.
// 
//
// Example 2: 
//
// 
//Input: s = "aba"
//Output: false
// 
//
// Example 3: 
//
// 
//Input: s = "abcabcabcabc"
//Output: true
//Explanation: It is the substring "abc" four times or the substring "abcabc" 
//twice.
// 
//
// 
// Constraints: 
//
// 
// 1 <= s.length <= 10⁴ 
// s consists of lowercase English letters. 
// 
//
// Related Topics String String Matching 👍 6086 👎 481

namespace RepeatedSubstringPattern
{
    public class Tests
    {
        [Theory]
        [InlineData("abab", true)]
        [InlineData("abac", false)]
        [InlineData("aba", false)]
        [InlineData("abcabcabcabc", true)]
        public void RepeatedSubstringPatternTest(string s, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().RepeatedSubstringPattern(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool RepeatedSubstringPattern(string s)
        {
            if (s.Length == 1)
            {
                return false;
            }

            if (s.Length == 2)
            {
                return s[0] == s[1];
            }

            if (s.Length == 3)
            {
                return s[0] == s[1] && s[1] == s[2];
            }

            for (var i = 0; i < s.Length; i++)
            {
                var length = i + 1;
                if (s.Length % length == 0 && length < s.Length)
                {
                    var can = true;
                    for (int j = 0; j < s.Length; j++)
                    {
                        var index = 0;
                        if (j < length)
                        {
                            index = j;
                        }
                        else
                        {
                            index = j % length;
                        }

                        if (s[j] != s[index])
                        {
                            can = false;
                            break;
                        }
                    }

                    if (can)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}