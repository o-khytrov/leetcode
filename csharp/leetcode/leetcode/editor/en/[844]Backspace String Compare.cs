/**
Given two strings s and t, return true if they are equal when both are typed
into empty text editors. '#' means a backspace character.

 Note that after backspacing an empty text, the text will continue empty.


 Example 1:


Input: s = "ab#c", t = "ad#c"
Output: true
Explanation: Both s and t become "ac".


 Example 2:


Input: s = "ab##", t = "c#d#"
Output: true
Explanation: Both s and t become "".


 Example 3:


Input: s = "a#c", t = "b"
Output: false
Explanation: s becomes "c" while t becomes "b".



 Constraints:


 1 <= s.length, t.length <= 200
 s and t only contain lowercase letters and '#' characters.



 Follow up: Can you solve it in O(n) time and O(1) space?

 Related Topics Two Pointers String Stack Simulation 👍 6673 👎 303

*/

using System.Collections.Generic;
using Xunit;

namespace BackspaceStringCompare
{
    public class Tests
    {
        [Theory]
        [InlineData("ab#c", "ad#c", true)]
        [InlineData("ab##", "c#d#", true)]
        [InlineData("a#c", "b", false)]
        [InlineData("a##c", "#a#c", true)]
        [InlineData("xywrrmp", "xywrrmu#p", true)]
        public void BackspaceStringCompareTest(string s, string t, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().BackspaceCompare(s, t));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private string Print(string s)
        {
            var stack = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '#')
                {
                    stack.TryPop(out _);
                }
                else
                {
                    stack.Push(c);
                }
            }

            return new string(stack.ToArray());
        }

        public bool BackspaceCompare(string s, string t)
        {
            var p1 = Print(s);
            var p2 = Print(t);
            return p1 == p2;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}