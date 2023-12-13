/**
You are given two strings word1 and word2. Merge the strings by adding letters
in alternating order, starting with word1. If a string is longer than the other,
append the additional letters onto the end of the merged string.

 Return the merged string.


 Example 1:


Input: word1 = "abc", word2 = "pqr"
Output: "apbqcr"
Explanation: The merged string will be merged as so:
word1:  a   b   c
word2:    p   q   r
merged: a p b q c r


 Example 2:


Input: word1 = "ab", word2 = "pqrs"
Output: "apbqrs"
Explanation: Notice that as word2 is longer, "rs" is appended to the end.
word1:  a   b
word2:    p   q   r   s
merged: a p b q   r   s


 Example 3:


Input: word1 = "abcd", word2 = "pq"
Output: "apbqcd"
Explanation: Notice that as word1 is longer, "cd" is appended to the end.
word1:  a   b   c   d
word2:    p   q
merged: a p b q c   d



 Constraints:


 1 <= word1.length, word2.length <= 100
 word1 and word2 consist of lowercase English letters.


 Related Topics Two Pointers String 👍 3321 👎 66

*/

using System.Text;
using Xunit;

namespace MergeStringsAlternately
{
    public class Tests
    {
        [Theory]
        [InlineData("abc", "pqr", "apbqcr")]
        [InlineData("ab", "pqrs", "apbqrs")]
        [InlineData("abcd", "pq", "apbqcd")]
        public void MergeStringsAlternatelyTest(string word1, string word2, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MergeAlternately(word1, word2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string MergeAlternately(string word1, string word2)
        {
            var sb = new StringBuilder();
            var p1 = 0;
            var p2 = 0;
            while (p1 < word1.Length || p2 < word2.Length)
            {
                if (p1 < word1.Length)
                {
                    sb.Append(word1[p1]);
                    p1++;
                }

                if (p2 < word2.Length)
                {
                    sb.Append(word2[p2]);
                    
                    p2++;
                }
            }

            return sb.ToString();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}