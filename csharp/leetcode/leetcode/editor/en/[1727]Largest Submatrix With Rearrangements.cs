using System;
using System.Collections.Generic;
using System.Linq;
using leetcode.CommonClasses;
using Xunit;

//You are given a binary matrix matrix of size m x n, and you are allowed to 
//rearrange the columns of the matrix in any order. 
//
// Return the area of the largest submatrix within matrix where every element 
//of the submatrix is 1 after reordering the columns optimally. 
//
// 
// Example 1: 
// 
// 
//Input: matrix = [[0,0,1],[1,1,1],[1,0,1]]
//Output: 4
//Explanation: You can rearrange the columns as shown above.
//The largest submatrix of 1s, in bold, has an area of 4.
// 
//
// Example 2: 
// 
// 
//Input: matrix = [[1,0,1,0,1]]
//Output: 3
//Explanation: You can rearrange the columns as shown above.
//The largest submatrix of 1s, in bold, has an area of 3.
// 
//
// Example 3: 
//
// 
//Input: matrix = [[1,1,0],[1,0,1]]
//Output: 2
//Explanation: Notice that you must rearrange entire columns, and there is no 
//way to make a submatrix of 1s larger than an area of 2.
// 
//
// 
// Constraints: 
//
// 
// m == matrix.length 
// n == matrix[i].length 
// 1 <= m * n <= 10⁵ 
// matrix[i][j] is either 0 or 1. 
// 
//
// Related Topics Array Greedy Sorting Matrix 👍 1282 👎 50

namespace LargestSubmatrixWithRearrangements
{
    public class Tests
    {
        [Theory]
        [InlineData("[[0,0,1],[1,1,1],[1,0,1]]", 4)]
        [InlineData("[[1,0,1,0,1]]", 3)]
        [InlineData("[[1,1,0],[1,0,1]]", 2)]
        public void LargestSubmatrixWithRearrangementsTest(string matrixJson, int expectedResult)
        {
            var matrix = Helper.ToIntMatrix(matrixJson);
            Assert.Equal(expectedResult, new Solution().LargestSubmatrix(matrix));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LargestSubmatrix(int[][] matrix)
        {
            var prefixes = new int[matrix.Length][];
            for (int c = 0; c < matrix[0].Length; c++)
            {
                var prefix = 0;
                for (int r = 0; r < matrix.Length; r++)
                {
                    prefixes[r] ??= new int[matrix[r].Length];

                    if (matrix[r][c] == 1)
                    {
                        prefix++;
                    }
                    else
                    {
                        prefix = 0;
                    }

                    prefixes[r][c] = prefix;
                }
            }

            var maxArea = 0;
            for (int r = 0; r < prefixes.Length; r++)
            {
                Array.Sort(prefixes[r], (a, b) => b.CompareTo(a));

                for (int c = 0; c < prefixes[r].Length; c++)
                {
                    maxArea = Math.Max(maxArea, prefixes[r][c] * (c + 1));
                }
            }

            return maxArea;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}