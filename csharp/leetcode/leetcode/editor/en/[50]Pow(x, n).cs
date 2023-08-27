//Implement pow(x, n), which calculates x raised to the power n (i.e., xⁿ). 
//
// 
// Example 1: 
//
// 
//Input: x = 2.00000, n = 10
//Output: 1024.00000
// 
//
// Example 2: 
//
// 
//Input: x = 2.10000, n = 3
//Output: 9.26100
// 
//
// Example 3: 
//
// 
//Input: x = 2.00000, n = -2
//Output: 0.25000
//Explanation: 2⁻² = 1/2² = 1/4 = 0.25
// 
//
// 
// Constraints: 
//
// 
// -100.0 < x < 100.0 
// -2³¹ <= n <= 2³¹-1 
// n is an integer. 
// Either x is not zero or n > 0. 
// -10⁴ <= xⁿ <= 10⁴ 
// 
//
// Related Topics Math Recursion 👍 8651 👎 8510

using System;
using Xunit;

namespace MyPow
{
    public class Tests
    {
        [Theory]
        [InlineData(2d, 10, 1024d)]
        [InlineData(2d, -2, 0.25000d)]
        [InlineData(0.44528d, 0, 1d)]
        public void MyPowTest(double x, int n, double expectedResult)
        {
            var sut = new Solution();
            var result = sut.MyPow(x, n);
            Assert.Equal(expectedResult, result);
        }
    }
//leetcode submit region begin(Prohibit modification and deletion)

    public class Solution
    {
        public double Power(double x, long n)
        {
            if (n == 0)
            {
                return 1;
            }

            if (x == 0)
            {
                return 0;
            }

            var res = Power(x * x, n / 2);
            return n % 2 == 0 ? res : res * x;
        }

        public double MyPow(double x, int n)
        {
            var pow = (long) n;
            var res = Power(x, pow);

            return n >= 0 ? res : 1 / res;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}