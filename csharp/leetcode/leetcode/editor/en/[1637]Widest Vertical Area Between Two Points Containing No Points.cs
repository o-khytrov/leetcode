/**
Given n points on a 2D plane where points[i] = [xi, yi], Return the widest
vertical area between two points such that no points are inside the area.

 A vertical area is an area of fixed-width extending infinitely along the y-
axis (i.e., infinite height). The widest vertical area is the one with the maximum
width.

 Note that points on the edge of a vertical area are not considered included in
the area.


 Example 1:


Input: points = [[8,7],[9,9],[7,4],[9,7]]
Output: 1
Explanation: Both the red and the blue area are optimal.


 Example 2:


Input: points = [[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]
Output: 3



 Constraints:


 n == points.length
 2 <= n <= 10⁵
 points[i].length == 2
 0 <= xi, yi <= 10⁹


 Related Topics Array Sorting 👍 534 👎 1042

*/

using System;
using System.Linq;
using leetcode.CommonClasses;
using Xunit;

namespace WidestVerticalAreaBetweenTwoPointsContainingNoPoints
{
    public class Tests
    {
        [Theory]
        [InlineData("[[8,7],[9,9],[7,4],[9,7]]", 1)]
        [InlineData("[[3,1],[9,0],[1,0],[1,4],[5,3],[8,8]]", 3)]
        public void WidestVerticalAreaBetweenTwoPointsContainingNoPointsTest(string pointsJson, int expectedResult)
        {
            var points = Helper.ToIntMatrix(pointsJson);
            Assert.Equal(expectedResult, new Solution().MaxWidthOfVerticalArea(points));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxWidthOfVerticalArea(int[][] points)
        {
            var sorted = points.OrderBy(x => x[0]).ToArray();
            var maxArea = 0;
            for (var i = 1; i < sorted.Length; i++)
            {
                var area = sorted[i][0] - sorted[i - 1][0];
                maxArea = Math.Max(maxArea, area);
            }

            return maxArea;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}