/**
You are given an array of strings words (0-indexed).

 In one operation, pick two distinct indices i and j, where words[i] is a non-
empty string, and move any character from words[i] to any position in words[j].

 Return true if you can make every string in words equal using any number of
operations, and false otherwise.


 Example 1:


Input: words = ["abc","aabc","bc"]
Output: true
Explanation: Move the first 'a' in words[1] to the front of words[2],
to make words[1] = "abc" and words[2] = "abc".
All the strings are now equal to "abc", so return true.


 Example 2:


Input: words = ["ab","a"]
Output: false
Explanation: It is impossible to make all the strings equal using the operation.




 Constraints:


 1 <= words.length <= 100
 1 <= words[i].length <= 100
 words[i] consists of lowercase English letters.


 Related Topics Hash Table String Counting 👍 418 👎 44

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace RedistributeCharactersToMakeAllStringsEqual
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"abc\",\"aabc\",\"bc\"]", true)]
        [InlineData("[\"ab\",\"a\"]", false)]
        public void RedistributeCharactersToMakeAllStringsEqualTest(string wordsJson, bool expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MakeEqual(words));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool MakeEqual(string[] words)
        {
            var map = new Dictionary<char, int>();
            for (int i = 0; i < words.Length; i++)
            {
                for (int j = 0; j < words[i].Length; j++)
                {
                    var c = words[i][j];
                    if (!map.TryAdd(c, 1))
                    {
                        map[c]++;
                    }
                }
            }

            foreach (var kvp in map)
            {
                if (kvp.Value < words.Length || kvp.Value % words.Length != 0)
                {
                    return false;
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}