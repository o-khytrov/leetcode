using System;
using leetcode.CommonClasses;
using Xunit;

//There is a city composed of n x n blocks, where each block contains a single 
//building shaped like a vertical square prism. You are given a 0-indexed n x n 
//integer matrix grid where grid[r][c] represents the height of the building located 
//in the block at row r and column c. 
//
// A city's skyline is the outer contour formed by all the building when 
//viewing the side of the city from a distance. The skyline from each cardinal direction 
//north, east, south, and west may be different. 
//
// We are allowed to increase the height of any number of buildings by any 
//amount (the amount can be different per building). The height of a 0-height building 
//can also be increased. However, increasing the height of a building should not 
//affect the city's skyline from any cardinal direction. 
//
// Return the maximum total sum that the height of the buildings can be 
//increased by without changing the city's skyline from any cardinal direction. 
//
// 
// Example 1: 
// 
// 
//Input: grid = [[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]
//Output: 35
//Explanation: The building heights are shown in the center of the above image.
//The skylines when viewed from each cardinal direction are drawn in red.
//The grid after increasing the height of buildings without affecting skylines 
//is:
//gridNew = [ [8, 4, 8, 7],
//            [7, 4, 7, 7],
//            [9, 4, 8, 7],
//            [3, 3, 3, 3] ]
// 
//
// Example 2: 
//
// 
//Input: grid = [[0,0,0],[0,0,0],[0,0,0]]
//Output: 0
//Explanation: Increasing the height of any building will result in the skyline 
//changing.
// 
//
// 
// Constraints: 
//
// 
// n == grid.length 
// n == grid[r].length 
// 2 <= n <= 50 
// 0 <= grid[r][c] <= 100 
// 
//
// Related Topics Array Greedy Matrix 👍 2463 👎 503

namespace MaxIncreaseToKeepCitySkyline
{
    public class Tests
    {
        [Theory]
        [InlineData("[[3,0,8,4],[2,4,5,7],[9,2,6,3],[0,3,1,0]]", 35)]
        [InlineData("[[0,0,0],[0,0,0],[0,0,0]]", 0)]
        public void MaxIncreaseToKeepCitySkylineTest(string gridJson, int expectedResult)
        {
            var grid = Helper.ToIntMatrix(gridJson);
            Assert.Equal(expectedResult, new Solution().MaxIncreaseKeepingSkyline(grid));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxIncreaseKeepingSkyline(int[][] grid)
        {
            var northSkyline = new int[grid[0].Length];
            var westSkyline = new int[grid.Length];

            var total = 0;
            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    northSkyline[c] = Math.Max(northSkyline[c], grid[r][c]);
                    westSkyline[r] = Math.Max(westSkyline[r], grid[r][c]);
                }
            }

            for (var r = 0; r < grid.Length; r++)
            {
                for (var c = 0; c < grid[r].Length; c++)
                {
                    var height = grid[r][c];
                    var maxHeight = Math.Min(westSkyline[r], northSkyline[c]);
                    if (height < maxHeight)
                    {
                        total += maxHeight - height;
                    }
                }
            }

            return total;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}