/**
You are given an integer array cost where cost[i] is the cost of iᵗʰ step on a
staircase. Once you pay the cost, you can either climb one or two steps.

 You can either start from the step with index 0, or the step with index 1.

 Return the minimum cost to reach the top of the floor.


 Example 1:


Input: cost = [10,15,20]
Output: 15
Explanation: You will start at index 1.
- Pay 15 and climb two steps to reach the top.
The total cost is 15.


 Example 2:


Input: cost = [1,100,1,1,1,100,1,1,100,1]
Output: 6
Explanation: You will start at index 0.
- Pay 1 and climb two steps to reach index 2.
- Pay 1 and climb two steps to reach index 4.
- Pay 1 and climb two steps to reach index 6.
- Pay 1 and climb one step to reach index 7.
- Pay 1 and climb two steps to reach index 9.
- Pay 1 and climb one step to reach the top.
The total cost is 6.



 Constraints:


 2 <= cost.length <= 1000
 0 <= cost[i] <= 999


 Related Topics Array Dynamic Programming 👍 10269 👎 1570

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MinCostClimbingStairs
{
    public class Tests
    {
        [Theory]
        [InlineData("[10,15,20]", 15)]
        [InlineData("[1,100,1,1,1,100,1,1,100,1]", 6)]
        public void MinCostClimbingStairsTest(string costJson, int expectedResult)
        {
            var cost = JsonSerializer.Deserialize<int[]>(costJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MinCostClimbingStairs(cost));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<int, int> _memo;

        public Solution()
        {
            _memo = new();
        }

        private int MinCostFrom(int[] cost, int from, int total)
        {
            if (_memo.TryGetValue(from, out var costFrom))
            {
                return costFrom;
            }

            if (from > cost.Length - 1)
            {
                _memo[from] = total;
                return _memo[from];
            }

            var oneStepCost = MinCostFrom(cost, from + 1, total);
            var twoStepCost = MinCostFrom(cost, from + 2, total);
            total += cost[from];
            total += Math.Min(oneStepCost, twoStepCost);

            _memo[from] = total;
            return _memo[from];
        }

        public int MinCostClimbingStairs(int[] cost)
        {
            var one = MinCostFrom(cost, 0, 0);
            var two = MinCostFrom(cost, 1, 0);
            return Math.Min(one, two);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}