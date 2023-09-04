/**
Given a positive integer num represented as a string, return the integer num
without trailing zeros as a string.


 Example 1:


Input: num = "51230100"
Output: "512301"
Explanation: Integer "51230100" has 2 trailing zeros, we remove them and return
integer "512301".


 Example 2:


Input: num = "123"
Output: "123"
Explanation: Integer "123" has no trailing zeros, we return integer "123".



 Constraints:


 1 <= num.length <= 1000
 num consists of only digits.
 num doesn't have any leading zeros.


 Related Topics String 👍 227 👎 7

*/

using Xunit;

namespace RemoveTrailingZerosFromAString
{
    public class Tests
    {
        [Theory]
        [InlineData("51230100", "512301")]
        [InlineData("123", "123")]
        public void RemoveTrailingZerosFromAStringTest(string num, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().RemoveTrailingZeros(num));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string RemoveTrailingZeros(string num)
        {
            var i = num.Length - 1;
            while (i >= 0)
            {
                if (num[i] != '0')
                {
                    break;
                }

                i--;
            }

            if (i == num.Length - 1)
            {
                return num;
            }

            return num.Substring(0, i+1);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}