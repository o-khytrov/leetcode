/**
You are given a string num, representing a large integer. Return the largest-
valued odd integer (as a string) that is a non-empty substring of num, or an empty
string "" if no odd integer exists.

 A substring is a contiguous sequence of characters within a string.


 Example 1:


Input: num = "52"
Output: "5"
Explanation: The only non-empty substrings are "5", "2", and "52". "5" is the
only odd number.


 Example 2:


Input: num = "4206"
Output: ""
Explanation: There are no odd numbers in "4206".


 Example 3:


Input: num = "35427"
Output: "35427"
Explanation: "35427" is already an odd number.



 Constraints:


 1 <= num.length <= 10⁵
 num only consists of digits and does not contain any leading zeros.


 Related Topics Math String Greedy 👍 1506 👎 88

*/

using System;
using Xunit;

namespace LargestOddNumberInString
{
    public class Tests
    {
        [Theory]
        [InlineData("52", "5")]
        [InlineData("4206", "")]
        [InlineData("35427", "35427")]
        public void LargestOddNumberInStringTest(string num, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().LargestOddNumber(num));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string LargestOddNumber(string num)
        {
            var index = num.Length - 1;
            var lastDigit = num[index] - 48;
            if (lastDigit % 2 != 0)
            {
                return num;
            }

            while (index >= 0)
            {
                lastDigit = num[index] - 48;
                if (lastDigit % 2 != 0)
                {
                    break;
                }

                index--;
            }

            if (index >= 0)
            {
                return num.Substring(0, index + 1);
            }

            return string.Empty;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}