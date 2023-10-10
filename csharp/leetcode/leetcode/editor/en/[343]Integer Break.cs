/**
Given an integer n, break it into the sum of k positive integers, where k >= 2,
and maximize the product of those integers.

 Return the maximum product you can get.


 Example 1:


Input: n = 2
Output: 1
Explanation: 2 = 1 + 1, 1 × 1 = 1.


 Example 2:


Input: n = 10
Output: 36
Explanation: 10 = 3 + 3 + 4, 3 × 3 × 4 = 36.



 Constraints:


 2 <= n <= 58


 Related Topics Math Dynamic Programming 👍 4877 👎 420

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace IntegerBreak
{
    public class Tests
    {
        [Theory]
        [InlineData(2, 1)]
        [InlineData(10, 36)]
        public void IntegerBreakTest(int n, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IntegerBreak(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<int, int> _memo = new();

        public int IntegerBreak(int n)
        {
            return Dfs(n, n);
        }

        private int Dfs(int n, int initial)
        {
            if (n == 1)
            {
                return 1;
            }

            if (_memo.TryGetValue(n, out var val))
            {
                return val;
            }

            var maxProduct = n == initial ? 0 : n;
            for (int i = 1; i < n; i++)
            {
                var product = Dfs(n - i, initial) * Dfs(i, initial);
                maxProduct = Math.Max(product, maxProduct);
            }

            _memo[n] = maxProduct;
            return maxProduct;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}