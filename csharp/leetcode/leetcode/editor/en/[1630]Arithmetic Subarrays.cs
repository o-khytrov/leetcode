using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

//A sequence of numbers is called arithmetic if it consists of at least two 
//elements, and the difference between every two consecutive elements is the same. 
//More formally, a sequence s is arithmetic if and only if s[i+1] - s[i] == s[1] - s[
//0] for all valid i. 
//
// For example, these are arithmetic sequences: 
//
// 
//1, 3, 5, 7, 9
//7, 7, 7, 7
//3, -1, -5, -9 
//
// The following sequence is not arithmetic: 
//
// 
//1, 1, 2, 5, 7 
//
// You are given an array of n integers, nums, and two arrays of m integers 
//each, l and r, representing the m range queries, where the iᵗʰ query is the range [
//l[i], r[i]]. All the arrays are 0-indexed. 
//
// Return a list of boolean elements answer, where answer[i] is true if the 
//subarray nums[l[i]], nums[l[i]+1], ... , nums[r[i]] can be rearranged to form an 
//arithmetic sequence, and false otherwise. 
//
// 
// Example 1: 
//
// 
//Input: nums = [4,6,5,9,3,7], l = [0,0,2], r = [2,3,5]
//Output: [true,false,true]
//Explanation:
//In the 0ᵗʰ query, the subarray is [4,6,5]. This can be rearranged as [6,5,4], 
//which is an arithmetic sequence.
//In the 1ˢᵗ query, the subarray is [4,6,5,9]. This cannot be rearranged as an 
//arithmetic sequence.
//In the 2ⁿᵈ query, the subarray is [5,9,3,7]. This can be rearranged as [3,5,7,
//9], which is an arithmetic sequence. 
//
// Example 2: 
//
// 
//Input: nums = [-12,-9,-3,-12,-6,15,20,-25,-20,-15,-10], l = [0,1,6,4,8,7], r =
// [4,4,9,7,9,10]
//Output: [false,true,false,false,true,true]
// 
//
// 
// Constraints: 
//
// 
// n == nums.length 
// m == l.length 
// m == r.length 
// 2 <= n <= 500 
// 1 <= m <= 500 
// 0 <= l[i] < r[i] < n 
// -10⁵ <= nums[i] <= 10⁵ 
// 
//
// Related Topics Array Sorting 👍 1666 👎 184

namespace ArithmeticSubarrays
{
    public class Tests
    {
        [Theory]
        [InlineData("[4,6,5,9,3,7]", "[0,0,2]", "[2,3,5]", "[true,false,true]")]
        public void ArithmeticSubarraysTest(string numsJson, string lJson, string rJson, string expectedResultJson)
        {
            var nums = JsonSerializer.Deserialize<int[]>(numsJson)
                       ?? throw new ArgumentException("Invalid json");

            var l = JsonSerializer.Deserialize<int[]>(lJson)
                    ?? throw new ArgumentException("Invalid json");

            var r = JsonSerializer.Deserialize<int[]>(rJson)
                    ?? throw new ArgumentException("Invalid json");
            var result = new Solution().CheckArithmeticSubarrays(nums, l, r);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool IsArithmetic(int[] array)
        {
            var dif = array[1] - array[0];
            for (int i = 1; i < array.Length; i++)
            {
                var d = array[i] - array[i - 1];
                if (d != dif)
                {
                    return false;
                }
            }

            return true;
        }

        public IList<bool> CheckArithmeticSubarrays(int[] nums, int[] l, int[] r)
        {
            var result = new List<bool>();
            for (int i = 0; i < l.Length; i++)
            {
                
                var subarray = nums.AsMemory().Slice(l[i],r[i]-l[i]+1).ToArray().OrderBy(x => x).ToArray();
                result.Add(IsArithmetic(subarray));
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}
