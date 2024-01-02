/**
You are given an integer array height of length n. There are n vertical lines
drawn such that the two endpoints of the iᵗʰ line are (i, 0) and (i, height[i]).

 Find two lines that together with the x-axis form a container, such that the
container contains the most water.

 Return the maximum amount of water a container can store.

 Notice that you may not slant the container.


 Example 1:


Input: height = [1,8,6,2,5,4,8,3,7]
Output: 49
Explanation: The above vertical lines are represented by array [1,8,6,2,5,4,8,3,
7]. In this case, the max area of water (blue section) the container can
contain is 49.


 Example 2:


Input: height = [1,1]
Output: 1



 Constraints:


 n == height.length
 2 <= n <= 10⁵
 0 <= height[i] <= 10⁴


 Related Topics Array Two Pointers Greedy 👍 27709 👎 1571

*/

using System;
using System.Text.Json;
using Xunit;

namespace ContainerWithMostWater
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,8,6,2,5,4,8,3,7]", 49)]
        [InlineData("[1,1]", 1)]
        public void ContainerWithMostWaterTest(string heightJson, int expectedResult)
        {
            var height = JsonSerializer.Deserialize<int[]>(heightJson)
                         ?? throw new ArgumentException("Invalid json");

            Assert.Equal(expectedResult, new Solution().MaxArea(height));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MaxArea(int[] height)
        {
            var l = 0;
            var r = height.Length - 1;
            var min = Math.Min(height[r], height[l]);
            var res = min * (r - l);
            while (l < r)
            {
                min = Math.Min(height[r], height[l]);
                res = Math.Max(res, min * (r - l));
                if (height[l] < height[r])
                {
                    l++;
                }
                else
                {
                    r--;
                }
            }

            return res;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}