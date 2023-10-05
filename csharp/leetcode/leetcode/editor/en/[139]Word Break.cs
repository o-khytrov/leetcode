/**
Given a string s and a dictionary of strings wordDict, return true if s can be
segmented into a space-separated sequence of one or more dictionary words.

 Note that the same word in the dictionary may be reused multiple times in the
segmentation.


 Example 1:


Input: s = "leetcode", wordDict = ["leet","code"]
Output: true
Explanation: Return true because "leetcode" can be segmented as "leet code".


 Example 2:


Input: s = "applepenapple", wordDict = ["apple","pen"]
Output: true
Explanation: Return true because "applepenapple" can be segmented as "apple pen
apple".
Note that you are allowed to reuse a dictionary word.


 Example 3:


Input: s = "catsandog", wordDict = ["cats","dog","sand","and","cat"]
Output: false



 Constraints:


 1 <= s.length <= 300
 1 <= wordDict.length <= 1000
 1 <= wordDict[i].length <= 20
 s and wordDict[i] consist of only lowercase English letters.
 All the strings of wordDict are unique.


 Related Topics Array Hash Table String Dynamic Programming Trie Memoization 👍
16292 👎 708

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace WordBreak
{
    public class Tests
    {
        [Theory]
        [InlineData("leetcode", "[\"leet\",\"code\"]", true)]
        [InlineData("applepenapple", "[\"apple\",\"pen\"]", true)]
        [InlineData("catsandog", "[\"cats\",\"dog\",\"sand\",\"and\",\"cat\"]", false)]
        [InlineData("cars", "[\"car\",\"ca\",\"rs\"]", true)]
        public void WordBreakTest(string s, string dictJson, bool expectedResult)
        {
            var dict = JsonSerializer.Deserialize<List<string>>(dictJson)
                       ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().WordBreak(s, dict));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<string, bool> _memo = new();

        private bool Match(string s, IList<string> wordDict)
        {
            if (_memo.TryGetValue(s, out var result))
            {
                return result;
            }
            foreach (var word in wordDict)
            {
                if (s == word)
                {
                    return true;
                }

                if (s.StartsWith(word))
                {
                    _memo[s] = Match(s.Substring(word.Length, s.Length - word.Length), wordDict);
                    if (_memo[s])
                    {
                        return true;
                    }
                }
            }

            _memo[s] = false;
            return _memo[s];
        }

        public bool WordBreak(string s, IList<string> wordDict)
        {
            return Match(s, wordDict);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}