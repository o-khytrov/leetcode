/**
Given two strings s and goal, return true if you can swap two letters in s so
the result is equal to goal, otherwise, return false.

 Swapping letters is defined as taking two indices i and j (0-indexed) such
that i != j and swapping the characters at s[i] and s[j].


 For example, swapping at indices 0 and 2 in "abcd" results in "cbad".



 Example 1:


Input: s = "ab", goal = "ba"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'b' to get "ba", which is equal
to goal.


 Example 2:


Input: s = "ab", goal = "ab"
Output: false
Explanation: The only letters you can swap are s[0] = 'a' and s[1] = 'b', which
results in "ba" != goal.


 Example 3:


Input: s = "aa", goal = "aa"
Output: true
Explanation: You can swap s[0] = 'a' and s[1] = 'a' to get "aa", which is equal
to goal.



 Constraints:


 1 <= s.length, goal.length <= 2 * 10⁴
 s and goal consist of lowercase letters.


 Related Topics Hash Table String 👍 3011 👎 1716

*/

using Xunit;

namespace BuddyStrings
{
    public class Tests
    {
        [Theory]
        [InlineData("ab", "ba", true)]
        [InlineData("ab", "ab", false)]
        [InlineData("aa", "aa", true)]
        [InlineData("ab", "ca", false)]
        [InlineData("abac", "abad", false)]
        public void BuddyStringsTest(string s, string goal, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().BuddyStrings(s, goal));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool BuddyStrings(string s, string goal)
        {
            if (s.Length != goal.Length)
            {
                return false;
            }

            if (s == goal)
            {
                for (int i = 0; i < s.Length; i++)
                {
                    for (int j = i + 1; j < s.Length; j++)
                    {
                        if (s[i] == s[j])
                        {
                            return true;
                        }
                    }
                }

                return false;
            }

            var c = 0;
            var sSwap = '\0';
            var gSwap = '\0';

            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != goal[i])
                {
                    if (c == 0)
                    {
                        sSwap = s[i];
                        gSwap = goal[i];
                        c++;
                        continue;
                    }

                    if (c == 1)
                    {
                        if (sSwap == goal[i] && s[i] == gSwap)
                        {
                            c++;
                            continue;
                        }

                        return false;
                    }

                    if (c == 2)
                    {
                        return false;
                    }
                }
            }

            return c is 0 or 2;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}