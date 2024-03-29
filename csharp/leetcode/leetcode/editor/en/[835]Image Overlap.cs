using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

//You are given two images, img1 and img2, represented as binary, square 
//matrices of size n x n. A binary matrix has only 0s and 1s as values. 
//
// We translate one image however we choose by sliding all the 1 bits left, 
//right, up, and/or down any number of units. We then place it on top of the other 
//image. We can then calculate the overlap by counting the number of positions that 
//have a 1 in both images. 
//
// Note also that a translation does not include any kind of rotation. Any 1 
//bits that are translated outside of the matrix borders are erased. 
//
// Return the largest possible overlap. 
//
// 
// Example 1: 
// 
// 
//Input: img1 = [[1,1,0],[0,1,0],[0,1,0]], img2 = [[0,0,0],[0,1,1],[0,0,1]]
//Output: 3
//Explanation: We translate img1 to right by 1 unit and down by 1 unit.
//
//The number of positions that have a 1 in both images is 3 (shown in red).
//
// 
//
// Example 2: 
//
// 
//Input: img1 = [[1]], img2 = [[1]]
//Output: 1
// 
//
// Example 3: 
//
// 
//Input: img1 = [[0]], img2 = [[0]]
//Output: 0
// 
//
// 
// Constraints: 
//
// 
// n == img1.length == img1[i].length 
// n == img2.length == img2[i].length 
// 1 <= n <= 30 
// img1[i][j] is either 0 or 1. 
// img2[i][j] is either 0 or 1. 
// 
//
// Related Topics Array Matrix 👍 1291 👎 467

namespace ImageOverlap
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,1,0],[0,1,0],[0,1,0]]", "[[0,0,0],[0,1,1],[0,0,1]]", 3)]
        [InlineData("[[1]]", "[[1]]", 1)]
        [InlineData("[[0]]", "[[0]]", 0)]
        public void ImageOverlapTest(string img1Json, string img2Json, int expectedResult)
        {
            var img1 = JsonSerializer.Deserialize<int[][]>(img1Json) ??
                       throw new ArgumentException("Invalid Json");

            var img2 = JsonSerializer.Deserialize<int[][]>(img2Json) ??
                       throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().LargestOverlap(img1, img2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int LargestOverlap(int[][] img1, int[][] img2)
        {
            var ones1 = new List<(int, int)>();
            var ones2 = new List<(int, int)>();
            var freq = new Dictionary<(int, int), int>();
            for (int r = 0; r < img1.Length; r++)
            {
                for (int c = 0; c < img1[r].Length; c++)
                {
                    if (img1[r][c] == 1)
                    {
                        ones1.Add((r, c));
                    }

                    if (img2[r][c] == 1)
                    {
                        ones2.Add((r, c));
                    }
                }
            }

            foreach (var point in ones1)
            {
                foreach (var remotePoint in ones2)
                {
                    var d = (remotePoint.Item1 - point.Item1, remotePoint.Item2 - point.Item2);
                    if (!freq.TryAdd(d, 1)) freq[d]++;
                }
            }

            var max = 0;
            if (freq.Count > 0)
            {
                max = freq.Values.Max();
            }

            return max;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}