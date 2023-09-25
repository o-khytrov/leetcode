using System.Collections.Generic;
using Xunit;

//The Tribonacci sequence Tn is defined as follows: 
//
// T0 = 0, T1 = 1, T2 = 1, and Tn+3 = Tn + Tn+1 + Tn+2 for n >= 0. 
//
// Given n, return the value of Tn. 
//
// 
// Example 1: 
//
// 
//Input: n = 4
//Output: 4
//Explanation:
//T_3 = 0 + 1 + 1 = 2
//T_4 = 1 + 1 + 2 = 4
// 
//
// Example 2: 
//
// 
//Input: n = 25
//Output: 1389537
// 
//
// 
// Constraints: 
//
// 
// 0 <= n <= 37 
// The answer is guaranteed to fit within a 32-bit integer, ie. answer <= 2^31 -
// 1. 
// 
//
// Related Topics Math Dynamic Programming Memoization 👍 3855 👎 170

namespace NThTribonacciNumber
{
    public class Tests
    {
        [Theory]
        [InlineData(4, 4)]
        [InlineData(25, 1389537)]
        public void NThTribonacciNumberTest(int n, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().Tribonacci(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<int, int> _memo;

        public Solution()
        {
            _memo = new Dictionary<int, int>();
        }

        public int Tribonacci(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1 || n == 2)
            {
                return 1;
            }

            if (_memo.TryGetValue(n, out var tribonacci))
            {
                return tribonacci;
            }

            _memo[n] = Tribonacci(n - 1) + Tribonacci(n - 2) + Tribonacci(n - 3);
            return _memo[n];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}