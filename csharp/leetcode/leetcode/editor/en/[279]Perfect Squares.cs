using System;
using System.Collections.Generic;
using Xunit;

//Given an integer n, return the least number of perfect square numbers that 
//sum to n. 
//
// A perfect square is an integer that is the square of an integer; in other 
//words, it is the product of some integer with itself. For example, 1, 4, 9, and 16 
//are perfect squares while 3 and 11 are not. 
//
// 
// Example 1: 
//
// 
//Input: n = 12
//Output: 3
//Explanation: 12 = 4 + 4 + 4.
// 
//
// Example 2: 
//
// 
//Input: n = 13
//Output: 2
//Explanation: 13 = 4 + 9.
// 
//
// 
// Constraints: 
//
// 
// 1 <= n <= 10⁴ 
// 
//
// Related Topics Math Dynamic Programming Breadth-First Search 👍 10120 👎 414

namespace PerfectSquares
{
    public class Tests
    {
        [Theory]
        [InlineData(12, 3)]
        [InlineData(13, 2)]
        public void PerfectSquaresTest(int n, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().NumSquares(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<int, int> _memo = new();

        public int NumSquares(int n)
        {
            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return 1;
            }

            if (_memo.TryGetValue(n, out var value))
            {
                return value;
            }

            int? answer = null;
            for (var i = 1; i * i <= n; i++)
            {
                var s = i * i;

                var subProblem = n - s;
                var subSolution = NumSquares(subProblem);
                if (subSolution == -1)
                {
                    continue;
                }

                if (answer.HasValue)
                {
                    answer = Math.Min(answer.Value, subSolution + 1);
                }
                else
                {
                    answer = subSolution + 1;
                }
            }


            _memo.TryAdd(n, answer.GetValueOrDefault(-1));
            return _memo[n];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}