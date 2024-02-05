/**
Given an integer array arr, partition the array into (contiguous) subarrays of
length at most k. After partitioning, each subarray has their values changed to
become the maximum value of that subarray.

 Return the largest sum of the given array after partitioning. Test cases are
generated so that the answer fits in a 32-bit integer.


 Example 1:


Input: arr = [1,15,7,9,2,5,10], k = 3
Output: 84
Explanation: arr becomes [15,15,15,9,10,10,10]


 Example 2:


Input: arr = [1,4,1,5,7,3,6,1,9,9,3], k = 4
Output: 83


 Example 3:


Input: arr = [1], k = 1
Output: 1



 Constraints:


 1 <= arr.length <= 500
 0 <= arr[i] <= 10⁹
 1 <= k <= arr.length


 Related Topics Array Dynamic Programming 👍 4027 👎 291

*/

using System;
using System.Text.Json;
using Xunit;

namespace PartitionArrayForMaximumSum
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,15,7,9,2,5,10]", 3, 84)]
        [InlineData("[1,4,1,5,7,3,6,1,9,9,3]", 4, 83)]
        [InlineData("[1]", 1, 1)]
        public void PartitionArrayForMaximumSumTest(string arrJson, int k, int expectedResult)
        {
            var arr = JsonSerializer.Deserialize<int[]>(arrJson)
                      ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MaxSumAfterPartitioning(arr, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int _k;

        private int Recursion(int[] arr, int index, int subLength)
        {
            if (index > arr.Length - 1)
            {
                return 0;
            }

            if (index == arr.Length - 1)
            {
                return arr[index];
            }

            var maxIndex = index + subLength;
            maxIndex = Math.Min(maxIndex, arr.Length - 1);

            var subArrayMaxValue = 0;
            var c = 0;
            for (var i = index; i < maxIndex; i++)
            {
                subArrayMaxValue = Math.Max(subArrayMaxValue, arr[i]);
                c++;
            }

            subArrayMaxValue *= c;
            var result = 0;

            for (var l = 1; l <= _k; l++)
            {
                var tmp = Recursion(arr, index + subLength, l);
                result = Math.Max(result, tmp);
            }

            return result + subArrayMaxValue;
        }

        public int MaxSumAfterPartitioning(int[] arr, int k)
        {
            _k = k;
            var result = 0;
            for (var l = 1; l <= k; l++)
            {
                result = Math.Max(result, Recursion(arr, 0, l));
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}