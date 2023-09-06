/**
You are given two strings s1 and s2, both of length 4, consisting of lowercase
English letters.

 You can apply the following operation on any of the two strings any number of
times:


 Choose any two indices i and j such that j - i = 2, then swap the two
characters at those indices in the string.


 Return true if you can make the strings s1 and s2 equal, and false otherwise.


 Example 1:


Input: s1 = "abcd", s2 = "cdab"
Output: true
Explanation: We can do the following operations on s1:
- Choose the indices i = 0, j = 2. The resulting string is s1 = "cbad".
- Choose the indices i = 1, j = 3. The resulting string is s1 = "cdab" = s2.


 Example 2:


Input: s1 = "abcd", s2 = "dacb"
Output: false
Explanation: It is not possible to make the two strings equal.



 Constraints:


 s1.length == s2.length == 4
 s1 and s2 consist only of lowercase English letters.


 Related Topics String 👍 110 👎 9

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace CheckIfStringsCanBeMadeEqualWithOperationsI
{
    public class Tests
    {
        [Theory]
        [InlineData("abcd", "cdab", true)]
        [InlineData("abcd", "dacb", false)]
        [InlineData("bnxw", "bwxn", true)]
        public void CheckIfStringsCanBeMadeEqualWithOperationsITest(string s1, string s2, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CanBeEqual(s1, s2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool CanBeEqual(string s1, string s2)
        {
            if (s1 == s2)
            {
                return true;
            }

            var a1 = s1.ToCharArray();
            var a2 = s2.ToCharArray();

            // first swap
            (a1[0], a1[2]) = (a1[2], a1[0]);
            if (a1.SequenceEqual(a2))
            {
                return true;
            }

            //restore first swap 
            (a1[2], a1[0]) = (a1[0], a1[2]);

            // second swap
            (a1[1], a1[3]) = (a1[3], a1[1]);
            if (a1.SequenceEqual(a2))
            {
                return true;
            }

            //restore second swap
            (a1[3], a1[1]) = (a1[1], a1[3]);

            //both swaps
            (a1[0], a1[2]) = (a1[2], a1[0]);
            (a1[1], a1[3]) = (a1[3], a1[1]);
            if (a1.SequenceEqual(a2))
            {
                return true;
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}