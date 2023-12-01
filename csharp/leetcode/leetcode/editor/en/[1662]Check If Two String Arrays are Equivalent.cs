/**
Given two string arrays word1 and word2, return true if the two arrays
represent the same string, and false otherwise.

 A string is represented by an array if the array elements concatenated in
order forms the string.


 Example 1:


Input: word1 = ["ab", "c"], word2 = ["a", "bc"]
Output: true
Explanation:
word1 represents string "ab" + "c" -> "abc"
word2 represents string "a" + "bc" -> "abc"
The strings are the same, so return true.

 Example 2:


Input: word1 = ["a", "cb"], word2 = ["ab", "c"]
Output: false


 Example 3:


Input: word1  = ["abc", "d", "defg"], word2 = ["abcddefg"]
Output: true



 Constraints:


 1 <= word1.length, word2.length <= 10³
 1 <= word1[i].length, word2[i].length <= 10³
 1 <= sum(word1[i].length), sum(word2[i].length) <= 10³
 word1[i] and word2[i] consist of lowercase letters.


 Related Topics Array String 👍 2520 👎 183

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace CheckIfTwoStringArraysAreEquivalent
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"ab\", \"c\"]", "[\"a\", \"bc\"]", true)]
        [InlineData("[\"a\", \"cb\"]", "[\"ab\", \"c\"]", false)]
        [InlineData("[\"abc\", \"d\", \"defg\"]", "[\"abcddefg\"]", true)]
        public void CheckIfTwoStringArraysAreEquivalentTest(string word1Json, string word2Json, bool expectedResult)
        {
            var word1 = JsonSerializer.Deserialize<string[]>(word1Json) ?? throw new ArgumentException("Invalid Json");
            var word2 = JsonSerializer.Deserialize<string[]>(word2Json) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().ArrayStringsAreEqual(word1, word2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool ArrayStringsAreEqual(string[] word1, string[] word2)
        {
            var w1 = word1.SelectMany(x => x);
            var w2 = word2.SelectMany(x => x);
            return w1.SequenceEqual(w2);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}