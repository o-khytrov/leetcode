/**
You are given a string num representing a large integer. An integer is good if
it meets the following conditions:


 It is a substring of num with length 3.
 It consists of only one unique digit.


 Return the maximum good integer as a string or an empty string "" if no such
integer exists.

 Note:


 A substring is a contiguous sequence of characters within a string.
 There may be leading zeroes in num or a good integer.



 Example 1:


Input: num = "6777133339"
Output: "777"
Explanation: There are two distinct good integers: "777" and "333".
"777" is the largest, so we return "777".


 Example 2:


Input: num = "2300019"
Output: "000"
Explanation: "000" is the only good integer.


 Example 3:


Input: num = "42352338"
Output: ""
Explanation: No substring of length 3 consists of only one unique digit.
Therefore, there are no good integers.



 Constraints:


 3 <= num.length <= 1000
 num only consists of digits.


 Related Topics String 👍 339 👎 19

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Largest3SameDigitNumberInString
{
    public class Tests
    {
        [Theory]
        [InlineData("6777133339", "777")]
        [InlineData("2300019", "000")]
        [InlineData("42352338", "")]
        public void Largest3SameDigitNumberInStringTest(string num, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().LargestGoodInteger(num));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string LargestGoodInteger(string num)
        {
            var goodInts = new List<int>();
            var numsSpan = num.AsSpan();
            for (var i = 0; i < num.Length - 2; i++)
            {
                if (num[i] == num[i + 1] && num[i + 1] == num[i + 2])
                {
                    goodInts.Add(int.Parse(numsSpan.Slice(i, 3)));
                }
            }

            return goodInts.Count > 0 ? goodInts.Max().ToString().PadLeft(3, '0') : string.Empty;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}