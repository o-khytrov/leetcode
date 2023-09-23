using System;
using System.Text.Json;
using Xunit;

//Given a string s and an array of strings words, determine whether s is a 
//prefix string of words. 
//
// A string s is a prefix string of words if s can be made by concatenating the 
//first k strings in words for some positive k no larger than words.length. 
//
// Return true if s is a prefix string of words, or false otherwise. 
//
// 
// Example 1: 
//
// 
//Input: s = "iloveleetcode", words = ["i","love","leetcode","apples"]
//Output: true
//Explanation:
//s can be made by concatenating "i", "love", and "leetcode" together.
// 
//
// Example 2: 
//
// 
//Input: s = "iloveleetcode", words = ["apples","i","love","leetcode"]
//Output: false
//Explanation:
//It is impossible to make s using a prefix of arr. 
//
// 
// Constraints: 
//
// 
// 1 <= words.length <= 100 
// 1 <= words[i].length <= 20 
// 1 <= s.length <= 1000 
// words[i] and s consist of only lowercase English letters. 
// 
//
// Related Topics Array String 👍 435 👎 81

namespace CheckIfStringIsAPrefixOfArray
{
    public class Tests
    {
        [Theory]
        [InlineData("iloveleetcode", "[\"i\",\"love\",\"leetcode\",\"apples\"]", true)]
        [InlineData("iloveleetcode", "[\"apples\",\"i\",\"love\",\"leetcode\"]", false)]
        [InlineData("a", "[\"aa\",\"aaaa\",\"banana\"]", false)]
        [InlineData("aaa", "[\"aa\",\"aaa\",\"fjaklfj\"]", false)]
        [InlineData("onxs", "[\"onx\",\"s\",\"i\"]", true)]
        [InlineData("ccccccccc", "[\"c\",\"cc\"]", false)]
        [InlineData("aaaaaaa", "[\"a\",\"a\",\"a\",\"a\",\"a\",\"a\",\"a\"]", true)]
        public void CheckIfStringIsAPrefixOfArrayTest(string s, string wordsJson, bool expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().IsPrefixString(s, words));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsPrefixString(string s, string[] words)
        {
            var w = 0;
            var l = 0;
            var totalLenght = words[w].Length;
            for (var i = 0; i < s.Length; i++, l++)
            {
                if (l > words[w].Length - 1)
                {
                    w++;
                    if (w > words.Length - 1)
                    {
                        return false;
                    }

                    totalLenght += words[w].Length;

                    l = 0;
                }

                if (totalLenght > s.Length)
                {
                    return false;
                }


                if (w > words.Length - 1)
                {
                    return false;
                }


                var c = s[i];
                if (c != words[w][l])
                {
                    return false;
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}