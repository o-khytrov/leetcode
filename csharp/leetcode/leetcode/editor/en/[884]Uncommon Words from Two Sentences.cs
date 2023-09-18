/**
A sentence is a string of single-space separated words where each word consists
only of lowercase letters.

 A word is uncommon if it appears exactly once in one of the sentences, and
does not appear in the other sentence.

 Given two sentences s1 and s2, return a list of all the uncommon words. You
may return the answer in any order.


 Example 1:
 Input: s1 = "this apple is sweet", s2 = "this apple is sour"
Output: ["sweet","sour"]

 Example 2:
 Input: s1 = "apple apple", s2 = "banana"
Output: ["banana"]


 Constraints:


 1 <= s1.length, s2.length <= 200
 s1 and s2 consist of lowercase English letters and spaces.
 s1 and s2 do not have leading or trailing spaces.
 All the words in s1 and s2 are separated by a single space.


 Related Topics Hash Table String 👍 1267 👎 160

*/

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace UncommonWordsFromTwoSentences
{
    public class Tests
    {
        [Theory]
        [InlineData("this apple is sweet", "this apple is sour", "[\"sweet\",\"sour\"]")]
        [InlineData("apple apple", "banana", "[\"banana\"]")]
        public void UncommonWordsFromTwoSentencesTest(string s1, string s2, string expectedResultJson)
        {
            var result = new Solution().UncommonFromSentences(s1, s2);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string[] UncommonFromSentences(string s1, string s2)
        {
            var map = new Dictionary<string, int>();
            var words = s1.Split(" ");
            for (var i = 0; i < words.Length; i++)
            {
                if (!map.TryAdd(words[i], 1))
                {
                    map[words[i]]++;
                }
            }

            var words2 = s2.Split(" ");
            for (var i = 0; i < words2.Length; i++)
            {
                if (!map.TryAdd(words2[i], 1))
                {
                    map[words2[i]]++;
                }
            }

            return map.Where(x => x.Value == 1).Select(x => x.Key).ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}