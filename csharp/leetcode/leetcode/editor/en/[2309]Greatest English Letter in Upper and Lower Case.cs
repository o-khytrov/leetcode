/**
Given a string of English letters s, return the greatest English letter which
occurs as both a lowercase and uppercase letter in s. The returned letter should
be in uppercase. If no such letter exists, return an empty string.

 An English letter b is greater than another letter a if b appears after a in
the English alphabet.


 Example 1:


Input: s = "lEeTcOdE"
Output: "E"
Explanation:
The letter 'E' is the only letter to appear in both lower and upper case.


 Example 2:


Input: s = "arRAzFif"
Output: "R"
Explanation:
The letter 'R' is the greatest letter to appear in both lower and upper case.
Note that 'A' and 'F' also appear in both lower and upper case, but 'R' is
greater than 'F' or 'A'.


 Example 3:


Input: s = "AbCdEfGhIjK"
Output: ""
Explanation:
There is no letter that appears in both lower and upper case.



 Constraints:


 1 <= s.length <= 1000
 s consists of lowercase and uppercase English letters.


 Related Topics Hash Table String Enumeration 👍 425 👎 27

*/

using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using Xunit;

namespace GreatestEnglishLetterInUpperAndLowerCase
{
    public class Tests
    {
        [Theory]
        [InlineData("lEeTcOdE", "E")]
        [InlineData("arRAzFif", "R")]
        [InlineData("AbCdEfGhIjK", "")]
        public void GreatestEnglishLetterInUpperAndLowerCaseTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().GreatestLetter(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string GreatestLetter(string s)
        {
            var map = new Dictionary<char, int>();
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsLower(c))
                {
                    var upper = char.ToUpper(c);
                    if (!map.TryAdd(upper, 1))
                    {
                        if (map[upper] == 3)
                        {
                            map[upper] += 1;
                        }
                    }
                }

                if (char.IsUpper(c))
                {
                    if (!map.TryAdd(c, 3))
                    {
                        if (map[c] == 1)
                        {
                            map[c] += 3;
                        }
                    }
                }
            }

            var maxLetter = ' ';
            foreach (var kvp in map)
            {
                if (kvp.Value == 4)
                {
                    maxLetter = maxLetter > kvp.Key ? maxLetter : kvp.Key;
                }
            }

            return maxLetter == ' ' ? "" : maxLetter.ToString();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}