/**
You are given a string s consisting only of the characters '0' and '1'. In one
operation, you can change any '0' to '1' or vice versa.

 The string is called alternating if no two adjacent characters are equal. For
example, the string "010" is alternating, while the string "0100" is not.

 Return the minimum number of operations needed to make s alternating.


 Example 1:


Input: s = "0100"
Output: 1
Explanation: If you change the last character to '1', s will be "0101", which
is alternating.


 Example 2:


Input: s = "10"
Output: 0
Explanation: s is already alternating.


 Example 3:


Input: s = "1111"
Output: 2
Explanation: You need two operations to reach "0101" or "1010".



 Constraints:


 1 <= s.length <= 10⁴
 s[i] is either '0' or '1'.


 Related Topics String 👍 951 👎 27

*/

using System;
using Xunit;

namespace MinimumChangesToMakeAlternatingBinaryString
{
    public class Tests
    {
        [Theory]
        [InlineData("0100", 1)]
        [InlineData("10", 0)]
        [InlineData("1111", 2)]
        [InlineData("10010100", 3)]
        [InlineData("0000111", 3)]
        public void MinimumChangesToMakeAlternatingBinaryStringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().MinOperations(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private void Flip(char[] a, int index)
        {
            if (a[index] == '1')
            {
                a[index] = '0';
            }
            else
            {
                a[index] = '1';
            }
        }

        public int MinOperations(string s)
        {
            var a = s.ToCharArray();
            var previous = a[0];
            var operations1 = 0;
            var operations2 = 0;
            for (var i = 1; i < a.Length; i++)
            {
                if (a[i] == previous)
                {
                    Flip(a, i);
                    operations1++;
                }

                previous = a[i];
            }

            a = s.ToCharArray();
            Flip(a, 0);
            operations2++;

            previous = a[0];
            for (int i = 1; i < a.Length; i++)
            {
                if (a[i] == previous)
                {
                    Flip(a, i);
                    operations2++;
                }

                previous = a[i];
            }


            return Math.Min(operations1, operations2);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}