/**
You are given a 0-indexed array of string words and two integers left and right.


 A string is called a vowel string if it starts with a vowel character and ends
with a vowel character where vowel characters are 'a', 'e', 'i', 'o', and 'u'.

 Return the number of vowel strings words[i] where i belongs to the inclusive
range [left, right].


 Example 1:


Input: words = ["are","amy","u"], left = 0, right = 2
Output: 2
Explanation:
- "are" is a vowel string because it starts with 'a' and ends with 'e'.
- "amy" is not a vowel string because it does not end with a vowel.
- "u" is a vowel string because it starts with 'u' and ends with 'u'.
The number of vowel strings in the mentioned range is 2.


 Example 2:


Input: words = ["hey","aeo","mu","ooo","artro"], left = 1, right = 4
Output: 3
Explanation:
- "aeo" is a vowel string because it starts with 'a' and ends with 'o'.
- "mu" is not a vowel string because it does not start with a vowel.
- "ooo" is a vowel string because it starts with 'o' and ends with 'o'.
- "artro" is a vowel string because it starts with 'a' and ends with 'o'.
The number of vowel strings in the mentioned range is 3.



 Constraints:


 1 <= words.length <= 1000
 1 <= words[i].length <= 10
 words[i] consists of only lowercase English letters.
 0 <= left <= right < words.length


 Related Topics Array String 👍 269 👎 18

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CountTheNumberOfVowelStringsInRange
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"are\",\"amy\",\"u\"]", 0, 2, 2)]
        public void CountTheNumberOfVowelStringsInRangeTest(string wordsJson, int left, int right, int expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson) ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().VowelStrings(words, left, right));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly HashSet<char> Map = new() { 'a', 'e', 'i', 'o', 'u' };

        public int VowelStrings(string[] words, int left, int right)
        {
            var count = 0;
            for (var i = left; i <= right; i++)
            {
                var word = words[i];
                if (Map.Contains(word[0]) && Map.Contains(word[^1]))
                {
                    count++;
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}