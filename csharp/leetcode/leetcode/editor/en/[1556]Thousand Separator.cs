/**
Given an integer n, add a dot (".") as the thousands separator and return it in
string format.


 Example 1:


Input: n = 987
Output: "987"


 Example 2:


Input: n = 1234
Output: "1.234"



 Constraints:


 0 <= n <= 2³¹ - 1


 Related Topics String 👍 448 👎 32

*/

using System.Collections.Generic;
using Xunit;

namespace ThousandSeparator
{
    public class Tests
    {
        [Theory]
        [InlineData(987, "987")]
        [InlineData(1234, "1.234")]
        [InlineData(0, "0")]
        public void ThousandSeparatorTest(int n, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().ThousandSeparator(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string ThousandSeparator(int n)
        {
            if (n == 0)
            {
                return "0";
            }

            var sb = new Stack<char>();
            var c = 0;
            while (n > 0)
            {
                if (c == 3)
                {
                    sb.Push('.');
                    c = 0;
                }

                sb.Push((char) (n % 10 + 48));

                n /= 10;
                c++;
            }


            return new string(sb.ToArray());
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}