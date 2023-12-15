using System;
using System.Text.Json;
using Xunit;

//You have a long flowerbed in which some of the plots are planted, and some 
//are not. However, flowers cannot be planted in adjacent plots. 
//
// Given an integer array flowerbed containing 0's and 1's, where 0 means empty 
//and 1 means not empty, and an integer n, return true if n new flowers can be 
//planted in the flowerbed without violating the no-adjacent-flowers rule and false 
//otherwise. 
//
// 
// Example 1: 
// Input: flowerbed = [1,0,0,0,1], n = 1
//Output: true
// 
// Example 2: 
// Input: flowerbed = [1,0,0,0,1], n = 2
//Output: false
// 
// 
// Constraints: 
//
// 
// 1 <= flowerbed.length <= 2 * 10⁴ 
// flowerbed[i] is 0 or 1. 
// There are no two adjacent flowers in flowerbed. 
// 0 <= n <= flowerbed.length 
// 
//
// Related Topics Array Greedy 👍 6090 👎 1076

namespace CanPlaceFlowers
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,0,0,0,1]", 1, true)]
        [InlineData("[1,0,0,0,1]", 2, false)]
        public void CanPlaceFlowersTest(string flowerbedJson, int n, bool expectedResult)
        {
            var flowerbed = JsonSerializer.Deserialize<int[]>(flowerbedJson)
                            ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().CanPlaceFlowers(flowerbed, n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int GetValue(int[] n, int index)
        {
            if (index >= 0 && index < n.Length)
            {
                return n[index];
            }

            return 0;
        }

        private bool IsFree(int[] flowerbed, int index)
        {
            return GetValue(flowerbed, index) == 0
                   && GetValue(flowerbed, index - 1) == 0
                   && GetValue(flowerbed, index + 1) == 0;
        }

        public bool CanPlaceFlowers(int[] flowerbed, int n)
        {
            if (n == 0)
            {
                return true;
            }

            if (flowerbed.Length == 1)
            {
                return flowerbed[0] == 0;
            }

            for (var i = 0; i < flowerbed.Length; i++)
            {
                if (IsFree(flowerbed, i))
                {
                    n--;
                    flowerbed[i] = 1;
                }

                if (n == 0)
                {
                    break;
                }
            }

            return n == 0;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}