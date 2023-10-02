using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

//Given a triangle array, return the minimum path sum from top to bottom. 
//
// For each step, you may move to an adjacent number of the row below. More 
//formally, if you are on index i on the current row, you may move to either index i 
//or index i + 1 on the next row. 
//
// 
// Example 1: 
//
// 
//Input: triangle = [[2],[3,4],[6,5,7],[4,1,8,3]]
//Output: 11
//Explanation: The triangle looks like:
//   2
//  3 4
// 6 5 7
//4 1 8 3
//The minimum path sum from top to bottom is 2 + 3 + 5 + 1 = 11 (underlined 
//above).
// 
//
// Example 2: 
//
// 
//Input: triangle = [[-10]]
//Output: -10
// 
//
// 
// Constraints: 
//
// 
// 1 <= triangle.length <= 200 
// triangle[0].length == 1 
// triangle[i].length == triangle[i - 1].length + 1 
// -10⁴ <= triangle[i][j] <= 10⁴ 
// 
//
// 
//Follow up: Could you do this using only 
//O(n) extra space, where 
//n is the total number of rows in the triangle?
//
// Related Topics Array Dynamic Programming 👍 8948 👎 516

namespace Triangle
{
    public class Tests
    {
        [Theory]
        [InlineData("[[2],[3,4],[6,5,7],[4,1,8,3]]", 11)]
        public void TriangleTest(string triangleJson, int expectedResult)
        {
            var triangles = JsonSerializer.Deserialize<List<IList<int>>>(triangleJson)
                            ?? throw new ArgumentException("Invalid Json");

            Assert.Equal(expectedResult, new Solution().MinimumTotal(triangles));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private Dictionary<(int, int), int> _memo;

        public Solution()
        {
            _memo = new Dictionary<(int, int), int>();
        }

        private int MinimumTotalFromLevel(IList<IList<int>> triangle, int level, int position)
        {
            if (_memo.ContainsKey((level, position)))
            {
                return _memo[(level, position)];
            }

            if (level == triangle.Count - 1)
            {
                return triangle[level][position];
            }

            var downRightPosition = position + 1;
            var downLeftPathTotal = MinimumTotalFromLevel(triangle, level + 1, position);
            var downRightPathTotal = MinimumTotalFromLevel(triangle, level + 1, downRightPosition);
            var minPath = Math.Min(downLeftPathTotal, downRightPathTotal);

            _memo[(level, position)] = triangle[level][position] + minPath;

            return _memo[(level, position)];
        }

        public int MinimumTotal(IList<IList<int>> triangle)
        {
            return MinimumTotalFromLevel(triangle, 0, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}