/**
You are given a 0-indexed 1-dimensional (1D) integer array original, and two
integers, m and n. You are tasked with creating a 2-dimensional (2D) array with m
rows and n columns using all the elements from original.

 The elements from indices 0 to n - 1 (inclusive) of original should form the
first row of the constructed 2D array, the elements from indices n to 2 * n - 1 (
inclusive) should form the second row of the constructed 2D array, and so on.

 Return an m x n 2D array constructed according to the above procedure, or an
empty 2D array if it is impossible.


 Example 1:


Input: original = [1,2,3,4], m = 2, n = 2
Output: [[1,2],[3,4]]
Explanation: The constructed 2D array should contain 2 rows and 2 columns.
The first group of n=2 elements in original, [1,2], becomes the first row in
the constructed 2D array.
The second group of n=2 elements in original, [3,4], becomes the second row in
the constructed 2D array.


 Example 2:


Input: original = [1,2,3], m = 1, n = 3
Output: [[1,2,3]]
Explanation: The constructed 2D array should contain 1 row and 3 columns.
Put all three elements in original into the first row of the constructed 2D
array.


 Example 3:


Input: original = [1,2], m = 1, n = 1
Output: []
Explanation: There are 2 elements in original.
It is impossible to fit 2 elements in a 1x1 2D array, so return an empty 2D
array.



 Constraints:


 1 <= original.length <= 5 * 10⁴
 1 <= original[i] <= 10⁵
 1 <= m, n <= 4 * 10⁴


 Related Topics Array Matrix Simulation 👍 704 👎 51

*/

using System;
using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace Convert1DArrayInto2DArray
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4]", 2, 2, "[[1,2],[3,4]]")]
        [InlineData("[1,2,3]", 1, 3, "[[1,2,3]]")]
        [InlineData("[1,2]", 1, 1, "[]")]
        [InlineData("[3]", 1, 2, "[]")]
        public void Convert1DArrayInto2DArrayTest(string inputJson, int m, int n, string expectedResultJson)
        {
            var grid = JsonSerializer.Deserialize<int[]>(inputJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().Construct2DArray(grid, m, n)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[][] Construct2DArray(int[] original, int m, int n)
        {
            var result = new int[m][];
            if (m * n != original.Length)
            {
                return new List<int[]>().ToArray();
            }

            var i = 0;
            var r = 0;
            var c = 0;

            result[r] = new int[n];

            while (i < original.Length)
            {
                result[r][c] = original[i];

                i++;
                c++;
                if (c > n - 1 && r < m - 1)
                {
                    r++;
                    result[r] = new int[n];
                    c = 0;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}