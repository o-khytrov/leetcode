/**
You have n dice, and each die has k faces numbered from 1 to k.

 Given three integers n, k, and target, return the number of possible ways (out
of the kⁿ total ways) to roll the dice, so the sum of the face-up numbers
equals target. Since the answer may be too large, return it modulo 10⁹ + 7.


 Example 1:


Input: n = 1, k = 6, target = 3
Output: 1
Explanation: You throw one die with 6 faces.
There is only one way to get a sum of 3.


 Example 2:


Input: n = 2, k = 6, target = 7
Output: 6
Explanation: You throw two dice, each with 6 faces.
There are 6 ways to get a sum of 7: 1+6, 2+5, 3+4, 4+3, 5+2, 6+1.


 Example 3:


Input: n = 30, k = 30, target = 500
Output: 222616187
Explanation: The answer must be returned modulo 10⁹ + 7.



 Constraints:


 1 <= n, k <= 30
 1 <= target <= 1000


 Related Topics Dynamic Programming 👍 4404 👎 138

*/

using System.Collections.Generic;
using Xunit;

namespace NumberOfDiceRollsWithTargetSum
{
    public class Tests
    {
        [Theory]
        [InlineData(1, 6, 3, 1)]
        [InlineData(2, 6, 7, 6)]
        [InlineData(30, 30, 500, 222616187)]
        public void NumberOfDiceRollsWithTargetSumTest(int n, int k, int target, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().NumRollsToTarget(n, k, target));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int _target;
        private int _faces;

        private readonly int _mod = 1000000007;
        private Dictionary<(int, int ), int> _memo = new();

        private int Roll(int remaining, int sum)
        {
            var counter = 0;
            if (remaining == 0)
            {
                return sum == _target ? 1 : 0;
            }

            if (_memo.ContainsKey((remaining, sum)))
            {
                return _memo[(remaining, sum)];
            }

            for (var i = 1; i <= _faces; i++)
            {
                counter += Roll(remaining - 1, sum + i);
                counter %= _mod;
            }

            _memo[(remaining, sum)] = counter;
            return _memo[(remaining, sum)];
        }

        public int NumRollsToTarget(int n, int k, int target)
        {
            _target = target;
            _faces = k;
            var count = Roll(n, 0);
            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}