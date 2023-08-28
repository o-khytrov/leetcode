/**
Given an array arr of positive integers sorted in a strictly increasing order,
and an integer k.

 Return the kᵗʰ positive integer that is missing from this array.


 Example 1:


Input: arr = [2,3,4,7,11], k = 5
Output: 9
Explanation: The missing positive integers are [1,5,6,8,9,10,12,13,...]. The 5ᵗʰ
missing positive integer is 9.


 Example 2:


Input: arr = [1,2,3,4], k = 2
Output: 6
Explanation: The missing positive integers are [5,6,7,...]. The 2ⁿᵈ missing
positive integer is 6.



 Constraints:


 1 <= arr.length <= 1000
 1 <= arr[i] <= 1000
 1 <= k <= 1000
 arr[i] < arr[j] for 1 <= i < j <= arr.length



 Follow up:

 Could you solve this problem in less than O(n) complexity?

 Related Topics Array Binary Search 👍 5851 👎 369

*/

using System.Text.Json;
using Xunit;

namespace KthMissingPositiveNumber
{
    public class Tests
    {
        [Theory]
        [InlineData("[3,5,6]", 2, 2)]
        [InlineData("[2,3,4,7,11]", 5, 9)]
        [InlineData("[1,2]", 1, 3)]
        public void FindKthPositiveTest(string inputJson, int k, int expecterResult)
        {
            var sut = new Solution();
            var result = sut.FindKthPositive(JsonSerializer.Deserialize<int[]>(inputJson), k);
            Assert.Equal(expecterResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int BinarySearch(int[] arr, int target)
        {
            var l = 0;
            var r = arr.Length - 1;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var val = arr[mid];
                if (val == target)
                {
                    return mid;
                }

                if (val > target)
                {
                    r = mid - 1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return -1;
        }

        public int FindKthPositive(int[] arr, int k)
        {
            var missingCount = 0;
            var target = 0;
            while (missingCount < k)
            {
                target++;
                var isMissing = BinarySearch(arr, target) == -1;
                if (isMissing)
                {
                    missingCount++;
                }
            }

            return target;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}