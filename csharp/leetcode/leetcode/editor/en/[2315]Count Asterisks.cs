/**
You are given a string s, where every two consecutive vertical bars '|' are
grouped into a pair. In other words, the 1ˢᵗ and 2ⁿᵈ '|' make a pair, the 3ʳᵈ and 4ᵗ
ʰ '|' make a pair, and so forth.

 Return the number of '*' in s, excluding the '*' between each pair of '|'.

 Note that each '|' will belong to exactly one pair.


 Example 1:


Input: s = "l|*e*et|c**o|*de|"
Output: 2
Explanation: The considered characters are underlined: "l|*e*et|c**o|*de|".
The characters between the first and second '|' are excluded from the answer.
Also, the characters between the third and fourth '|' are excluded from the
answer.
There are 2 asterisks considered. Therefore, we return 2.

 Example 2:


Input: s = "iamprogrammer"
Output: 0
Explanation: In this example, there are no asterisks in s. Therefore, we return
0.


 Example 3:


Input: s = "yo|uar|e**|b|e***au|tifu|l"
Output: 5
Explanation: The considered characters are underlined: "yo|uar|e**|b|e***au|
tifu|l". There are 5 asterisks considered. Therefore, we return 5.


 Constraints:


 1 <= s.length <= 1000
 s consists of lowercase English letters, vertical bars '|', and asterisks '*'.

 s contains an even number of vertical bars '|'.


 Related Topics String 👍 545 👎 84

*/

using Xunit;

namespace CountAsterisks
{
    public class Tests
    {
        [Theory]
        [InlineData("l|*e*et|c**o|*de|", 2)]
        [InlineData("iamprogrammer", 0)]
        [InlineData("yo|uar|e**|b|e***au|tifu|l", 5)]
        public void CountAsterisksTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CountAsterisks(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int CountAsterisks(string s)
        {
            var counting = true;
            var count = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '|')
                {
                    counting = !counting;
                }

                if (c == '*' && counting)
                {
                    count++;
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}