/**
Given two strings s1 and s2, return true if s2 contains a permutation of s1, or
false otherwise.

 In other words, return true if one of s1's permutations is the substring of s2.



 Example 1:


Input: s1 = "ab", s2 = "eidbaooo"
Output: true
Explanation: s2 contains one permutation of s1 ("ba").


 Example 2:


Input: s1 = "ab", s2 = "eidboaoo"
Output: false



 Constraints:


 1 <= s1.length, s2.length <= 10⁴
 s1 and s2 consist of lowercase English letters.


 Related Topics Hash Table Two Pointers String Sliding Window 👍 10528 👎 345

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PermutationInString
{
    public class Tests
    {
        [Theory]
        [InlineData("ab", "eidbaooo", true)]
        public void PermutationInStringTest(string s1, string s2, bool expectedResult)
        {
            var sut = new Solution();
            var result = sut.CheckInclusion(s1, s2);
            Assert.Equal(expectedResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool CheckInclusion(string s1, string s2)
        {
            if (s1.Length > s2.Length)
            {
                return false;
            }

            var map = new int[26];

            for (var i = 0; i < s1.Length; i++)
            {
                map[s1[i] - 97]++;
            }

            var l = 0;
            var r = 0;
            var tmpMap = new int[26];

            for (r = 0; r < s1.Length; r++)
            {
                tmpMap[s2[r] - 97]++;
            }

            if (map.SequenceEqual(tmpMap))
            {
                return true;
            }

            while (r < s2.Length)
            {
                tmpMap[s2[r++] - 97]++;
                tmpMap[s2[l++] - 97]--;

                if (map.SequenceEqual(tmpMap))
                {
                    return true;
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}