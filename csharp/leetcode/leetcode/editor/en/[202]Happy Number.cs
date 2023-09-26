/**
Write an algorithm to determine if a number n is happy.

 A happy number is a number defined by the following process:


 Starting with any positive integer, replace the number by the sum of the
squares of its digits.
 Repeat the process until the number equals 1 (where it will stay), or it loops
endlessly in a cycle which does not include 1.
 Those numbers for which this process ends in 1 are happy.


 Return true if n is a happy number, and false if not.


 Example 1:


Input: n = 19
Output: true
Explanation:
1² + 9² = 82
8² + 2² = 68
6² + 8² = 100
1² + 0² + 0² = 1


 Example 2:


Input: n = 2
Output: false



 Constraints:


 1 <= n <= 2³¹ - 1


 Related Topics Hash Table Math Two Pointers 👍 9548 👎 1260

*/

using System.Collections.Generic;
using Xunit;

namespace HappyNumber
{
    public class Tests
    {
        [Theory]
        [InlineData(19, true)]
        [InlineData(2, false)]
        public void HappyNumberTest(int n, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsHappy(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int Transform(int n)
        {
            var tmp = 0;
            while (n > 0)
            {
                var digit = n % 10;
                tmp += digit * digit;
                n /= 10;
            }

            return tmp;
        }

        public bool IsHappy(int n)
        {
            var map = new HashSet<int>();
            while (true)
            {
                n = Transform(n);
                if (n == 1)
                {
                    return true;
                }

                if (map.Contains(n))
                {
                    return false;
                }

                map.Add(n);
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}