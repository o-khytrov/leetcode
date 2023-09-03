/**
You are given an alphanumeric string s. (Alphanumeric string is a string
consisting of lowercase English letters and digits).

 You have to find a permutation of the string where no letter is followed by
another letter and no digit is followed by another digit. That is, no two adjacent
characters have the same type.

 Return the reformatted string or return an empty string if it is impossible to
reformat the string.


 Example 1:


Input: s = "a0b1c2"
Output: "0a1b2c"
Explanation: No two adjacent characters have the same type in "0a1b2c". "a0b1c2
", "0a1b2c", "0c2a1b" are also valid permutations.


 Example 2:


Input: s = "leetcode"
Output: ""
Explanation: "leetcode" has only characters so we cannot separate them by
digits.


 Example 3:


Input: s = "1229857369"
Output: ""
Explanation: "1229857369" has only digits so we cannot separate them by
characters.



 Constraints:


 1 <= s.length <= 500
 s consists of only lowercase English letters and/or digits.


 Related Topics String 👍 547 👎 97

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace ReformatTheString
{
    public class Tests
    {
        [Theory]
        [InlineData("a0b1c2", "0a1b2c")]
        [InlineData("leetcode", "")]
        [InlineData("1229857369", "")]
        [InlineData("covid2019", "c2o0v1i9d")]
        public void ReformatTheStringTest(string s, string expectedOutput)
        {
            Assert.Equal(expectedOutput, new Solution().Reformat(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string Reformat(string s)
        {
            var reversed = new char[s.Length];


            var digits = new Queue<char>();
            var letters = new Queue<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (char.IsDigit(s[i]))
                {
                    digits.Enqueue(s[i]);
                }
                else
                {
                    letters.Enqueue(s[i]);
                }
            }

            if (Math.Abs(digits.Count - letters.Count) > 1)
            {
                return "";
            }

            Queue<char> maxQue;
            Queue<char> minQue;
            if (digits.Count >= letters.Count)
            {
                maxQue = digits;
                minQue = letters;
            }
            else
            {
                maxQue = letters;
                minQue = digits;
            }

            for (int i = 0; i < reversed.Length; i++)
            {
                if (i % 2 == 0)
                {
                    reversed[i] = maxQue.Dequeue();
                }
                else
                {
                    reversed[i] = minQue.Dequeue();
                }
            }

            return new string(reversed);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}