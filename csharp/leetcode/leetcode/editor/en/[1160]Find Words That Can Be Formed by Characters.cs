using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//You are given an array of strings words and a string chars. 
//
// A string is good if it can be formed by characters from chars (each 
//character can only be used once). 
//
// Return the sum of lengths of all good strings in words. 
//
// 
// Example 1: 
//
// 
//Input: words = ["cat","bt","hat","tree"], chars = "atach"
//Output: 6
//Explanation: The strings that can be formed are "cat" and "hat" so the answer 
//is 3 + 3 = 6.
// 
//
// Example 2: 
//
// 
//Input: words = ["hello","world","leetcode"], chars = "welldonehoneyr"
//Output: 10
//Explanation: The strings that can be formed are "hello" and "world" so the 
//answer is 5 + 5 = 10.
// 
//
// 
// Constraints: 
//
// 
// 1 <= words.length <= 1000 
// 1 <= words[i].length, chars.length <= 100 
// words[i] and chars consist of lowercase English letters. 
// 
//
// Related Topics Array Hash Table String 👍 1660 👎 163

namespace FindWordsThatCanBeFormedByCharacters
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"cat\",\"bt\",\"hat\",\"tree\"]", "atach", 6)]
        [InlineData("[\"hello\",\"world\",\"leetcode\"]", "welldonehoneyr", 10)]
        public void FindWordsThatCanBeFormedByCharactersTest(string wordsJson, string chars, int expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson)
                        ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().CountCharacters(words, chars));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int CountCharacters(string[] words, string chars)
        {
            var charsMap = new Dictionary<char, int>();
            foreach (var c in chars)
            {
                if (!charsMap.TryAdd(c, 1))
                {
                    charsMap[c]++;
                }
            }

            var wordMap = new Dictionary<char, int>();
            var sum = 0;
            foreach (var word in words)
            {
                wordMap.Clear();
                var isGood = true;
                foreach (var c in word)
                {
                    if (!wordMap.TryAdd(c, 1))
                    {
                        wordMap[c]++;
                    }
                }

                foreach (var kvp in wordMap)
                {
                    if (charsMap.ContainsKey(kvp.Key))
                    {
                        if (charsMap[kvp.Key] < kvp.Value)
                        {
                            isGood = false;
                            break;
                        }
                    }
                    else
                    {
                        isGood = false;
                        break;
                    }
                }

                if (isGood)
                {
                    sum += word.Length;
                }
            }

            return sum;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}