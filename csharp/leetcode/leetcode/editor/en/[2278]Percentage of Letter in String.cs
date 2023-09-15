/**
Given a string s and a character letter, return the percentage of characters in
s that equal letter rounded down to the nearest whole percent.


 Example 1:


Input: s = "foobar", letter = "o"
Output: 33
Explanation:
The percentage of characters in s that equal the letter 'o' is 2 / 6 * 100% = 33
% when rounded down, so we return 33.


 Example 2:


Input: s = "jjjj", letter = "k"
Output: 0
Explanation:
The percentage of characters in s that equal the letter 'k' is 0%, so we return
0.


 Constraints:


 1 <= s.length <= 100
 s consists of lowercase English letters.
 letter is a lowercase English letter.


 Related Topics String 👍 442 👎 49

*/

using Xunit;

namespace PercentageOfLetterInString
{
    public class Tests
    {
        [Theory]
        [InlineData("foobar", 'o', 33)]
        [InlineData("jjjj", 'k', 0)]
        public void PercentageOfLetterInStringTest(string s, char letter, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().PercentageLetter(s, letter));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int PercentageLetter(string s, char letter)
        {
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == letter)
                {
                    count++;
                }
            }

            return count * 100 / s.Length;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}