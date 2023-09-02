/**
Given a string s, reverse the string according to the following rules:


 All the characters that are not English letters remain in the same position.
 All the English letters (lowercase or uppercase) should be reversed.


 Return s after reversing it.


 Example 1:
 Input: s = "ab-cd"
Output: "dc-ba"

 Example 2:
 Input: s = "a-bC-dEf-ghIj"
Output: "j-Ih-gfE-dCba"

 Example 3:
 Input: s = "Test1ng-Leet=code-Q!"
Output: "Qedo1ct-eeLg=ntse-T!"


 Constraints:


 1 <= s.length <= 100
 s consists of characters with ASCII values in the range [33, 122].
 s does not contain '\"' or '\\'.


 Related Topics Two Pointers String 👍 2053 👎 66

*/

using System.Collections.Generic;
using Xunit;

namespace ReverseOnlyLetters
{
    public class Tests
    {
        [Theory]
        [InlineData("ab-cd", "dc-ba")]
        [InlineData("a-bC-dEf-ghIj", "j-Ih-gfE-dCba")]
        public void ReverseOnlyLettersTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().ReverseOnlyLetters(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string ReverseOnlyLetters(string s)
        {
            var reversed = new char[s.Length];

            var stack = new Stack<char>();
            for (var i = 0; i < s.Length; i++)
            {
                if (!char.IsLetter(s[i]))
                {
                    reversed[i] = s[i];
                }
                else
                {
                    stack.Push(s[i]);
                }
            }


            for (var i = 0; i < reversed.Length; i++)
            {
                if (reversed[i] == '\0')
                {
                    reversed[i] = stack.Pop();
                }
            }

            return new string(reversed);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}