/**
An image smoother is a filter of the size 3 x 3 that can be applied to each
cell of an image by rounding down the average of the cell and the eight surrounding
cells (i.e., the average of the nine cells in the blue smoother). If one or
more of the surrounding cells of a cell is not present, we do not consider it in
the average (i.e., the average of the four cells in the red smoother).

 Given an m x n integer matrix img representing the grayscale of an image,
return the image after applying the smoother on each cell of it.


 Example 1:


Input: img = [[1,1,1],[1,0,1],[1,1,1]]
Output: [[0,0,0],[0,0,0],[0,0,0]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor(3/4) = floor(0.75) = 0
For the points (0,1), (1,0), (1,2), (2,1): floor(5/6) = floor(0.83333333) = 0
For the point (1,1): floor(8/9) = floor(0.88888889) = 0


 Example 2:


Input: img = [[100,200,100],[200,50,200],[100,200,100]]
Output: [[137,141,137],[141,138,141],[137,141,137]]
Explanation:
For the points (0,0), (0,2), (2,0), (2,2): floor((100+200+200+50)/4) = floor(137
.5) = 137
For the points (0,1), (1,0), (1,2), (2,1): floor((200+200+50+200+100+100)/6) =
floor(141.666667) = 141
For the point (1,1): floor((50+200+200+200+200+100+100+100+100)/9) = floor(138.8
88889) = 138



 Constraints:


 m == img.length
 n == img[i].length
 1 <= m, n <= 200
 0 <= img[i][j] <= 255


 Related Topics Array Matrix 👍 715 👎 2317

*/

using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace ImageSmoother
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,1,1],[1,0,1],[1,1,1]]", "[[0,0,0],[0,0,0],[0,0,0]]")]
        public void ImageSmootherTest(string imgJson, string expectedResult)
        {
            var img = Helper.ToIntMatrix(imgJson);
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().ImageSmoother(img)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int[] _kernel = new int [9];

        private int GetValue(int[][] img, int x, int y)
        {
            if (x < 0 || x > img.Length - 1 || y < 0 || y > img[x].Length - 1)
            {
                return -1;
            }

            return img[x][y];
        }

        private int Smooth(int[][] img, int x, int y)
        {
            _kernel[0] = GetValue(img, x - 1, y - 1);
            _kernel[1] = GetValue(img, x, y - 1);
            _kernel[2] = GetValue(img, x + 1, y - 1);

            _kernel[3] = GetValue(img, x - 1, y);
            _kernel[4] = GetValue(img, x, y);
            _kernel[5] = GetValue(img, x + 1, y);

            _kernel[6] = GetValue(img, x - 1, y + 1);
            _kernel[7] = GetValue(img, x, y + 1);
            _kernel[8] = GetValue(img, x + 1, y + 1);
            var sum = 0;
            var count = 0;
            for (int i = 0; i < 9; i++)
            {
                if (_kernel[i] != -1)
                {
                    count++;
                    sum += _kernel[i];
                }
            }

            return sum / count;
        }

        public int[][] ImageSmoother(int[][] img)
        {
            var smoothed = new int[img.Length][];
            for (var r = 0; r < img.Length; r++)
            {
                smoothed[r] = new int [img[r].Length];
                for (var c = 0; c < img[r].Length; c++)
                {
                    smoothed[r][c] = Smooth(img, r, c);
                }
            }

            return smoothed;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}