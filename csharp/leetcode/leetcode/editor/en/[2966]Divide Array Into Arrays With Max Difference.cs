/**
You are given an integer array nums of size n and a positive integer k.

 Divide the array into one or more arrays of size 3 satisfying the following
conditions:


 Each element of nums should be in exactly one array.
 The difference between any two elements in one array is less than or equal to
k.


 Return a 2D array containing all the arrays. If it is impossible to satisfy
the conditions, return an empty array. And if there are multiple answers, return
any of them.


 Example 1:


Input: nums = [1,3,4,8,7,9,3,5,1], k = 2
Output: [[1,1,3],[3,4,5],[7,8,9]]
Explanation: We can divide the array into the following arrays: [1,1,3], [3,4,5]
 and [7,8,9].
The difference between any two elements in each array is less than or equal to 2
.
Note that the order of elements is not important.


 Example 2:


Input: nums = [1,3,3,2,7,3], k = 3
Output: []
Explanation: It is not possible to divide the array satisfying all the
conditions.



 Constraints:


 n == nums.length
 1 <= n <= 10⁵
 n is a multiple of 3.
 1 <= nums[i] <= 10⁵
 1 <= k <= 10⁵


 Related Topics Array Greedy Sorting 👍 648 👎 158

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace DivideArrayIntoArraysWithMaxDifference
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,3,4,8,7,9,3,5,1]", 2, "[[1,1,3],[3,4,5],[7,8,9]]")]
        [InlineData("[1,3,3,2,7,3]", 3, "[]")]
        public void DivideArrayIntoArraysWithMaxDifferenceTest(string numsJson, int k, string expectedResult)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().DivideArray(nums, k)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int[][] DivideArray(int[] nums, int k)
        {
            Array.Sort(nums);
            var result = new List<int[]>();
            var a = new List<int>();
            for (int i = 0; i < nums.Length; i++)
            {
                a.Add(nums[i]);
                if (a.Count == 3)
                {
                    if (Math.Abs(a.Max() - a.Min()) <= k)
                    {
                        result.Add(a.ToArray());
                        a = new List<int>();
                    }
                    else
                    {
                        return Array.Empty<int[]>();
                    }
                }
            }

            return result.ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}