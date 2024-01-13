/**
You are given two strings of the same length s and t. In one step you can
choose any character of t and replace it with another character.

 Return the minimum number of steps to make t an anagram of s.

 An Anagram of a string is a string that contains the same characters with a
different (or the same) ordering.


 Example 1:


Input: s = "bab", t = "aba"
Output: 1
Explanation: Replace the first 'a' in t with b, t = "bba" which is anagram of s.



 Example 2:


Input: s = "leetcode", t = "practice"
Output: 5
Explanation: Replace 'p', 'r', 'a', 'i' and 'c' from t with proper characters
to make t anagram of s.


 Example 3:


Input: s = "anagram", t = "mangaar"
Output: 0
Explanation: "anagram" and "mangaar" are anagrams.



 Constraints:


 1 <= s.length <= 5 * 10⁴
 s.length == t.length
 s and t consist of lowercase English letters only.


 Related Topics Hash Table String Counting 👍 2266 👎 94

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MinimumNumberOfStepsToMakeTwoStringsAnagram
{
    public class Tests
    {
        [Theory]
        [InlineData("bab", "aba", 1)]
        [InlineData("leetcode", "practice", 5)]
        [InlineData("anagram", "mangaar", 0)]
        public void MinimumNumberOfStepsToMakeTwoStringsAnagramTest(string s, string t, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MinSteps(s, t));
        }
    }


//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<char, int> BuildMap(string s)
        {
            var map = new Dictionary<char, int>();
            foreach (var c in s)
            {
                if (!map.TryAdd(c, 1))
                {
                    map[c]++;
                }
            }

            return map;
        }

        public int MinSteps(string s, string t)
        {
            var map1 = BuildMap(s);
            var map2 = BuildMap(t);
            var count = 0;

            for (var c = 'a'; c <= 'z'; c++)
            {
                map1.TryGetValue(c, out var v1);
                map2.TryGetValue(c, out var v2);
                var diff = Math.Abs(v1 - v2);
                count += diff;
            }

            return count / 2;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}