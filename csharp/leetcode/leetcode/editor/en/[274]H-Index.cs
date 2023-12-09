/**
Given an array of integers citations where citations[i] is the number of
citations a researcher received for their iᵗʰ paper, return the researcher's h-index.

 According to the definition of h-index on Wikipedia: The h-index is defined as
the maximum value of h such that the given researcher has published at least h
papers that have each been cited at least h times.


 Example 1:


Input: citations = [3,0,6,1,5]
Output: 3
Explanation: [3,0,6,1,5] means the researcher has 5 papers in total and each of
them had received 3, 0, 6, 1, 5 citations respectively.
Since the researcher has 3 papers with at least 3 citations each and the
remaining two with no more than 3 citations each, their h-index is 3.


 Example 2:


Input: citations = [1,3,1]
Output: 1



 Constraints:


 n == citations.length
 1 <= n <= 5000
 0 <= citations[i] <= 1000


 Related Topics Array Sorting Counting Sort 👍 888 👎 329

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace HIndex
{
    public class Tests
    {
        [Theory]
        [InlineData("[3,0,6,1,5]", 3)]
        [InlineData("[1,3,1]", 1)]
        public void HIndexTest(string citationsJson, int expectedResult)
        {
            var citations = JsonSerializer.Deserialize<int[]>(citationsJson)
                            ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().HIndex(citations));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int HIndex(int[] citations)
        {
            Array.Sort(citations, (a, b) => b.CompareTo(a));
            var c = 0;
            var maxH = 0;
            var h = 0;
            for (var i = 0; i < citations.Length; i++)
            {
                if (citations[i] >= i + 1)
                {
                    h = i + 1;
                    maxH = Math.Max(h, maxH);
                }
            }

            return maxH;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}