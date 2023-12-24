/**
Two strings are considered close if you can attain one from the other using the
following operations:


 Operation 1: Swap any two existing characters.



 For example, abcde -> aecdb


 Operation 2: Transform every occurrence of one existing character into another
existing character, and do the same with the other character.

 For example, aacabb -> bbcbaa (all a's turn into b's, and all b's turn into
a's)




 You can use the operations on either string as many times as necessary.

 Given two strings, word1 and word2, return true if word1 and word2 are close,
and false otherwise.


 Example 1:


Input: word1 = "abc", word2 = "bca"
Output: true
Explanation: You can attain word2 from word1 in 2 operations.
Apply Operation 1: "abc" -> "acb"
Apply Operation 1: "acb" -> "bca"


 Example 2:


Input: word1 = "a", word2 = "aa"
Output: false
Explanation: It is impossible to attain word2 from word1, or vice versa, in any
number of operations.


 Example 3:


Input: word1 = "cabbba", word2 = "abbccc"
Output: true
Explanation: You can attain word2 from word1 in 3 operations.
Apply Operation 1: "cabbba" -> "caabbb"
Apply Operation 2: "caabbb" -> "baaccc"
Apply Operation 2: "baaccc" -> "abbccc"



 Constraints:


 1 <= word1.length, word2.length <= 10⁵
 word1 and word2 contain only lowercase English letters.


 Related Topics Hash Table String Sorting 👍 2779 👎 166

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DetermineIfTwoStringsAreClose
{
    public class Tests
    {
        [Theory]
        [InlineData("abc", "bca", true)]
        [InlineData("a", "aa", false)]
        [InlineData("cabbba", "abbccc", true)]
        [InlineData("uau", "ssx", false)]
        public void DetermineIfTwoStringsAreCloseTest(string word1, string word2, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CloseStrings(word1, word2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<char, int> BuildHashMap(string s)
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

        public bool CloseStrings(string word1, string word2)
        {
            var map1 = BuildHashMap(word1);
            var map2 = BuildHashMap(word2);
            var charsCount1 = map1.Values.ToArray();
            var charsCount2 = map2.Values.ToArray();
            var keys1 = map1.Keys.ToHashSet();
            var keys2 = map2.Keys.ToHashSet();
            Array.Sort(charsCount1);
            Array.Sort(charsCount2);

            return charsCount1.SequenceEqual(charsCount2) && keys1.SetEquals(keys2);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}