/**
Given a string s and an integer k, return the maximum number of vowel letters
in any substring of s with length k.

 Vowel letters in English are 'a', 'e', 'i', 'o', and 'u'.


 Example 1:


Input: s = "abciiidef", k = 3
Output: 3
Explanation: The substring "iii" contains 3 vowel letters.


 Example 2:


Input: s = "aeiou", k = 2
Output: 2
Explanation: Any substring of length 2 contains 2 vowels.


 Example 3:


Input: s = "leetcode", k = 3
Output: 2
Explanation: "lee", "eet" and "ode" contain 2 vowels.



 Constraints:


 1 <= s.length <= 10⁵
 s consists of lowercase English letters.
 1 <= k <= s.length


 Related Topics String Sliding Window 👍 3265 👎 110

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace MaximumNumberOfVowelsInASubstringOfGivenLength
{
    public class Tests
    {
        [Theory]
        [InlineData("abciiidef", 3, 3)]
        [InlineData("aeiou", 2, 2)]
        [InlineData("leetcode", 3, 2)]
        public void MaximumNumberOfVowelsInASubstringOfGivenLengthTest(string s, int k, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MaxVowels(s, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly HashSet<char> Vowels = new() { 'a', 'e', 'i', 'o', 'u' };

        public int MaxVowels(string s, int k)
        {
            var maxVowelCount = 0;
            var count = 0;
            //count vowels in the first window
            for (int i = 0; i < k; i++)
            {
                if (Vowels.Contains(s[i]))
                {
                    count++;
                }
            }

            maxVowelCount = count;
            for (var i = k; i < s.Length; i++)
            {
                if (Vowels.Contains(s[i]))
                {
                    count++;
                }

                if (Vowels.Contains(s[i - k]))
                {
                    count--;
                }

                maxVowelCount = Math.Max(count, maxVowelCount);
            }

            return maxVowelCount;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}