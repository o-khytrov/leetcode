/**
You are given an integer array coins representing coins of different
denominations and an integer amount representing a total amount of money.

 Return the fewest number of coins that you need to make up that amount. If
that amount of money cannot be made up by any combination of the coins, return -1.

 You may assume that you have an infinite number of each kind of coin.


 Example 1:


Input: coins = [1,2,5], amount = 11
Output: 3
Explanation: 11 = 5 + 5 + 1


 Example 2:


Input: coins = [2], amount = 3
Output: -1


 Example 3:


Input: coins = [1], amount = 0
Output: 0



 Constraints:


 1 <= coins.length <= 12
 1 <= coins[i] <= 2³¹ - 1
 0 <= amount <= 10⁴


 Related Topics Array Dynamic Programming Breadth-First Search 👍 17669 👎 397

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace CoinChange
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,5]", 11, 3)]
        [InlineData("[2]", 3, -1)]
        [InlineData("[1]", 0, 0)]
        public void CoinChangeTest(string coinsJson, int amount, int expectedResult)
        {
            var coins = JsonSerializer.Deserialize<int[]>(coinsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().CoinChange(coins, amount));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<int, int> _memo = new();

        public int CoinChange(int[] coins, int amount)
        {
            if (amount == 0)
            {
                return 0;
            }

            if (_memo.TryGetValue(amount, out var value))
            {
                return value;
            }

            int? answer = null;
            for (var i = 0; i < coins.Length; i++)
            {
                var coinValue = coins[i];
                var subProblem = amount - coinValue;
                if (subProblem < 0)
                {
                    continue;
                }

                var subSolution = CoinChange(coins, subProblem);
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

            _memo.TryAdd(amount, answer.GetValueOrDefault(-1));
            return _memo[amount];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}