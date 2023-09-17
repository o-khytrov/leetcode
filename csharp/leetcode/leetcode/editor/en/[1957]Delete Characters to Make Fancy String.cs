/**
A fancy string is a string where no three consecutive characters are equal.

 Given a string s, delete the minimum possible number of characters from s to
make it fancy.

 Return the final string after the deletion. It can be shown that the answer
will always be unique.


 Example 1:


Input: s = "leeetcode"
Output: "leetcode"
Explanation:
Remove an 'e' from the first group of 'e's to create "leetcode".
No three consecutive characters are equal, so return "leetcode".


 Example 2:


Input: s = "aaabaaaa"
Output: "aabaa"
Explanation:
Remove an 'a' from the first group of 'a's to create "aabaaaa".
Remove two 'a's from the second group of 'a's to create "aabaa".
No three consecutive characters are equal, so return "aabaa".


 Example 3:


Input: s = "aab"
Output: "aab"
Explanation: No three consecutive characters are equal, so return "aab".



 Constraints:


 1 <= s.length <= 10⁵
 s consists only of lowercase English letters.


 Related Topics String 👍 390 👎 20

*/

using System.Collections;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace DeleteCharactersToMakeFancyString
{
    public class Tests
    {
        [Theory]
        [InlineData("leeetcode", "leetcode")]
        [InlineData("aaabaaaa", "aabaa")]
        public void DeleteCharactersToMakeFancyStringTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MakeFancyString(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string MakeFancyString(string s)
        {
            var stack = new List<char>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (stack.Count >= 2)
                {
                    var s1 = stack[^1];
                    var s2 = stack[^2];
                    if (s1 == s2 && s1 == c)
                    {
                        continue;
                    }
                }

                stack.Add(c);
            }

            return new string(stack.ToArray());
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}