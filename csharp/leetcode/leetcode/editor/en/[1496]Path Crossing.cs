/**
Given a string path, where path[i] = 'N', 'S', 'E' or 'W', each representing
moving one unit north, south, east, or west, respectively. You start at the origin
(0, 0) on a 2D plane and walk on the path specified by path.

 Return true if the path crosses itself at any point, that is, if at any time
you are on a location you have previously visited. Return false otherwise.


 Example 1:


Input: path = "NES"
Output: false
Explanation: Notice that the path doesn't cross any point more than once.


 Example 2:


Input: path = "NESWW"
Output: true
Explanation: Notice that the path visits the origin twice.


 Constraints:


 1 <= path.length <= 10⁴
 path[i] is either 'N', 'S', 'E', or 'W'.


 Related Topics Hash Table String 👍 675 👎 18

*/

using System.Collections.Generic;
using Xunit;

namespace PathCrossing
{
    public class Tests
    {
        [Theory]
        [InlineData("NES", false)]
        [InlineData("NESWW", true)]
        public void PathCrossingTest(string path, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsPathCrossing(path));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private struct Point
        {
            public int X;
            public int Y;

            public Point(int x, int y)
            {
                X = x;
                Y = y;
            }
        }

        public bool IsPathCrossing(string path)
        {
            var x = 0;
            var y = 0;
            var visited = new HashSet<Point>
            {
                new(x, y)
            };

            for (int i = 0; i < path.Length; i++)
            {
                var c = path[i];
                switch (c)
                {
                    case 'N':
                        y++;
                        break;
                    case 'S':
                        y--;
                        break;
                    case 'E':
                        x++;
                        break;
                    case 'W':
                        x--;
                        break;
                }

                var point = new Point(x, y);
                if (visited.Contains(point))
                {
                    return true;
                }

                visited.Add(point);
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}