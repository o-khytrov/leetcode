/**
There is an m x n rectangular island that borders both the Pacific Ocean and
Atlantic Ocean. The Pacific Ocean touches the island's left and top edges, and the
Atlantic Ocean touches the island's right and bottom edges.

 The island is partitioned into a grid of square cells. You are given an m x n
integer matrix heights where heights[r][c] represents the height above sea level
of the cell at coordinate (r, c).

 The island receives a lot of rain, and the rain water can flow to neighboring
cells directly north, south, east, and west if the neighboring cell's height is
less than or equal to the current cell's height. Water can flow from any cell
adjacent to an ocean into the ocean.

 Return a 2D list of grid coordinates result where result[i] = [ri, ci] denotes
that rain water can flow from cell (ri, ci) to both the Pacific and Atlantic
oceans.


 Example 1:


Input: heights = [[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]
Output: [[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]
Explanation: The following cells can flow to the Pacific and Atlantic oceans,
as shown below:
[0,4]: [0,4] -> Pacific Ocean
[0,4] -> Atlantic Ocean
[1,3]: [1,3] -> [0,3] -> Pacific Ocean
[1,3] -> [1,4] -> Atlantic Ocean
[1,4]: [1,4] -> [1,3] -> [0,3] -> Pacific Ocean
[1,4] -> Atlantic Ocean
[2,2]: [2,2] -> [1,2] -> [0,2] -> Pacific Ocean
[2,2] -> [2,3] -> [2,4] -> Atlantic Ocean
[3,0]: [3,0] -> Pacific Ocean
[3,0] -> [4,0] -> Atlantic Ocean
[3,1]: [3,1] -> [3,0] -> Pacific Ocean
[3,1] -> [4,1] -> Atlantic Ocean
[4,0]: [4,0] -> Pacific Ocean
       [4,0] -> Atlantic Ocean
Note that there are other possible paths for these cells to flow to the Pacific
and Atlantic oceans.


 Example 2:


Input: heights = [[1]]
Output: [[0,0]]
Explanation: The water can flow from the only cell to the Pacific and Atlantic
oceans.



 Constraints:


 m == heights.length
 n == heights[r].length
 1 <= m, n <= 200
 0 <= heights[r][c] <= 10⁵


 Related Topics Array Depth-First Search Breadth-First Search Matrix 👍 6957 👎
1354

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace PacificAtlanticWaterFlow
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,2,2,3,5],[3,2,3,4,4],[2,4,5,3,1],[6,7,1,4,5],[5,1,1,2,4]]",
            "[[0,4],[1,3],[1,4],[2,2],[3,0],[3,1],[4,0]]")]
        [InlineData("[[1]]", "[[0,0]]")]
        public void PacificAtlanticWaterFlowTest(string heightsJson, string expectedResultJson)
        {
            var heights = JsonSerializer.Deserialize<int[][]>(heightsJson)
                          ?? throw new ArgumentException("Invalid json");
            var result = new Solution().PacificAtlantic(heights);
            var resultJson = JsonSerializer.Serialize(result);
            Assert.Equal(expectedResultJson, resultJson);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int Flow(int[][] heights, int r, int c, HashSet<(int, int)> _visited, int previousValue)
        {
            if (r < 0 || c < 0)
            {
                return -1;
            }

            if (r > heights.Length - 1 || c > heights[0].Length - 1)
            {
                return 1;
            }

            if (_visited.Contains((r, c)))
            {
                return 0;
            }

            var value = heights[r][c];
            if (value > previousValue)
            {
                return 0;
            }

            _visited.Add((r, c));
            var ways = new int[]
            {
                Flow(heights, r + 1, c, _visited, value),
                Flow(heights, r - 1, c, _visited, value),
                Flow(heights, r, c + 1, _visited, value),
                Flow(heights, r, c - 1, _visited, value),
            };
            if (ways.Contains(2))
            {
                return 2;
            }

            if (ways.Contains(-1) && ways.Contains(1))
            {
                return 2;
            }

            if (ways.Contains(-1))
            {
                return -1;
            }

            if (ways.Contains(1))
            {
                return 1;
            }

            return 0;
        }

        public IList<IList<int>> PacificAtlantic(int[][] heights)
        {
            var visited = new HashSet<(int, int)>();
            var result = new List<IList<int>>();

            for (int r = 0; r < heights.Length; r++)
            {
                for (int c = 0; c < heights[r].Length; c++)
                {
                    visited.Clear();

                    if (Flow(heights, r, c, visited, Int32.MaxValue) == 2)
                    {
                        result.Add(new int[2] { r, c });
                    }
                }
            }


            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}