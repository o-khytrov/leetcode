/**
Given a string paragraph and a string array of the banned words banned, return
the most frequent word that is not banned. It is guaranteed there is at least
one word that is not banned, and that the answer is unique.

 The words in paragraph are case-insensitive and the answer should be returned
in lowercase.


 Example 1:


Input: paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.",
banned = ["hit"]
Output: "ball"
Explanation:
"hit" occurs 3 times, but it is a banned word.
"ball" occurs twice (and no other word does), so it is the most frequent non-
banned word in the paragraph.
Note that words in the paragraph are not case sensitive,
that punctuation is ignored (even if adjacent to words, such as "ball,"),
and that "hit" isn't the answer even though it occurs more because it is banned.



 Example 2:


Input: paragraph = "a.", banned = []
Output: "a"



 Constraints:


 1 <= paragraph.length <= 1000
 paragraph consists of English letters, space ' ', or one of the symbols: "!?',;
.".
 0 <= banned.length <= 100
 1 <= banned[i].length <= 10
 banned[i] consists of only lowercase English letters.


 Related Topics Hash Table String Counting 👍 1608 👎 2965

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MostCommonWord
{
    public class Tests
    {
        [Theory]
        [InlineData("Bob hit a ball, the hit BALL flew far after it was hit.", new string[] { "hit" }, "ball")]
        [InlineData("a.", new string[] { }, "a")]
        [InlineData("Bob", new string[] { }, "bob")]
        [InlineData("Bob. hIt, baLl", new string[] { "bob", "hit" }, "ball")]
        public void MostCommonWordTest(string s, string[] banned, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MostCommonWord(s, banned));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string MostCommonWord(string paragraph, string[] banned)
        {
            var comparer = StringComparer.OrdinalIgnoreCase;
            var bannedSet = banned.ToHashSet(comparer);
            var words = new List<string>();

            for (int i = 0; i < paragraph.Length; i++)
            {
                var p = i;
                var l = 0;
                while (p < paragraph.Length && char.IsLetter(paragraph[p]))
                {
                    p++;
                    l++;
                }

                if (p > i)
                {
                    words.Add(paragraph.Substring(i, l));
                    i = p;
                }
            }

            var map = new Dictionary<string, int>(comparer);
            var mostFrequent = words[0];
            var maxFreq = 0;
            foreach (var word in words)
            {
                if (!bannedSet.Contains(word))
                {
                    if (!map.TryAdd(word, 1))
                    {
                        map[word]++;
                    }

                    if (map[word] > maxFreq)
                    {
                        maxFreq = map[word];
                        mostFrequent = word;
                    }
                }
            }

            return mostFrequent.ToLower();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}