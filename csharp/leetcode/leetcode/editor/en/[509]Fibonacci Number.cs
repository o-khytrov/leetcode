/**
The Fibonacci numbers, commonly denoted F(n) form a sequence, called the
Fibonacci sequence, such that each number is the sum of the two preceding ones,
starting from 0 and 1. That is,


F(0) = 0, F(1) = 1
F(n) = F(n - 1) + F(n - 2), for n > 1.


 Given n, calculate F(n).


 Example 1:


Input: n = 2
Output: 1
Explanation: F(2) = F(1) + F(0) = 1 + 0 = 1.


 Example 2:


Input: n = 3
Output: 2
Explanation: F(3) = F(2) + F(1) = 1 + 1 = 2.


 Example 3:


Input: n = 4
Output: 3
Explanation: F(4) = F(3) + F(2) = 2 + 1 = 3.



 Constraints:


 0 <= n <= 30


 Related Topics Math Dynamic Programming Recursion Memoization 👍 7438 👎 327

*/

using System.Collections.Generic;
using Xunit;

namespace FibonacciNumber
{
    public class Tests
    {
        [Theory]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        public void FibonacciNumberTest(int n, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().Fib(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int Fib(int n, Dictionary<int, int> memo)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n <= 2)
            {
                return 1;
            }

            if (memo.TryGetValue(n, out var fib))
            {
                return fib;
            }

            memo[n] = Fib(n - 1, memo) + Fib(n - 2, memo);
            return memo[n];
        }

        public int Fib(int n)
        {
            return Fib(n, new Dictionary<int, int>());
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}