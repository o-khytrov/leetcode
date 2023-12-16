/**
Given two strings s and t, return true if t is an anagram of s, and false
otherwise.

 An Anagram is a word or phrase formed by rearranging the letters of a
different word or phrase, typically using all the original letters exactly once.


 Example 1:
 Input: s = "anagram", t = "nagaram"
Output: true

 Example 2:
 Input: s = "rat", t = "car"
Output: false


 Constraints:


 1 <= s.length, t.length <= 5 * 10⁴
 s and t consist of lowercase English letters.



 Follow up: What if the inputs contain Unicode characters? How would you adapt
your solution to such a case?

 Related Topics Hash Table String Sorting 👍 11225 👎 355

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace ValidAnagram
{
    public class Tests
    {
        [Theory]
        [InlineData("anagram", "nagaram", true)]
        [InlineData("rat", "car", false)]
        public void ValidAnagramTest(string s, string t, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsAnagram(s, t));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsAnagram(string s, string t)
        {
            return
                new string(s.ToCharArray().OrderBy(x => x).ToArray()) ==
                new string(t.ToCharArray().OrderBy(x => x).ToArray());
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}