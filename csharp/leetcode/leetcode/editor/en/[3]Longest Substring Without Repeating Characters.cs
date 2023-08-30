/**
Given a string s, find the length of the longest substring without repeating
characters.


 Example 1:


Input: s = "abcabcbb"
Output: 3
Explanation: The answer is "abc", with the length of 3.


 Example 2:


Input: s = "bbbbb"
Output: 1
Explanation: The answer is "b", with the length of 1.


 Example 3:


Input: s = "pwwkew"
Output: 3
Explanation: The answer is "wke", with the length of 3.
Notice that the answer must be a substring, "pwke" is a subsequence and not a
substring.



 Constraints:


 0 <= s.length <= 5 * 10⁴
 s consists of English letters, digits, symbols and spaces.


 Related Topics Hash Table String Sliding Window 👍 36700 👎 1655

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace LongestSubstringWithoutRepeatingCharacters
{
    public class Tests
    {
        [Theory]
        [InlineData("abcabcbb", 3)]
        [InlineData("pwwkew", 3)]
        public void LongestSubstringWithoutRepeatingCharactersTest(string s, int expectedResult)
        {
            var sut = new Solution();
            var result = sut.LengthOfLongestSubstring(s);
            Assert.Equal(expectedResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LengthOfLongestSubstring(string s)
        {
            var set = new HashSet<char>();

            var l = 0;
            var maxLength = 0;
            for (int r = 0; r < s.Length; r++)
            {
                var c = s[r];
                while (set.Contains(s[r]))
                {
                    set.Remove(s[l]);
                    l++;
                }

                set.Add(s[r]);
                maxLength = Math.Max(maxLength, r - l + 1);
            }

            return maxLength;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}