/**
Given a string s of lower and upper case English letters.

 A good string is a string which doesn't have two adjacent characters s[i] and
s[i + 1] where:


 0 <= i <= s.length - 2
 s[i] is a lower-case letter and s[i + 1] is the same letter but in upper-case
or vice-versa.


 To make the string good, you can choose two adjacent characters that make the
string bad and remove them. You can keep doing this until the string becomes
good.

 Return the string after making it good. The answer is guaranteed to be unique
under the given constraints.

 Notice that an empty string is also good.


 Example 1:


Input: s = "leEeetcode"
Output: "leetcode"
Explanation: In the first step, either you choose i = 1 or i = 2, both will
result "leEeetcode" to be reduced to "leetcode".


 Example 2:


Input: s = "abBAcC"
Output: ""
Explanation: We have many possible scenarios, and all lead to the same answer.
For example:
"abBAcC" --> "aAcC" --> "cC" --> ""
"abBAcC" --> "abBA" --> "aA" --> ""


 Example 3:


Input: s = "s"
Output: "s"



 Constraints:


 1 <= s.length <= 100
 s contains only lower and upper case English letters.


 Related Topics String Stack 👍 2350 👎 109

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MakeTheStringGreat
{
    public class Tests
    {
        [Theory]
        [InlineData("leEeetcode", "leetcode")]
        [InlineData("abBAcC", "")]
        [InlineData("s", "s")]
        public void MakeTheStringGreatTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MakeGood(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string MakeGood(string s)
        {
            var stack = new Stack<char>();
            stack.Push(s[0]);
            for (var i = 1; i < s.Length; i++)
            {
                var c = s[i];
                if (stack.Count > 0)
                {
                    var prev = stack.Peek();
                    if (c != prev && char.ToLower(prev) == char.ToLower(c))
                    {
                        stack.Pop();
                    }
                    else
                    {
                        stack.Push(c);
                    }
                }
                else
                {
                    stack.Push(c);
                }
            }

            return new string(stack.Reverse().ToArray());
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}