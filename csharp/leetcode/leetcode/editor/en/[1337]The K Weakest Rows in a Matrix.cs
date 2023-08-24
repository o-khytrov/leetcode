/**
You are given an m x n binary matrix mat of 1's (representing soldiers) and 0's 
(representing civilians). The soldiers are positioned in front of the civilians.
 That is, all the 1's will appear to the left of all the 0's in each row. 

 A row i is weaker than a row j if one of the following is true: 

 
 The number of soldiers in row i is less than the number of soldiers in row j. 
 Both rows have the same number of soldiers and i < j. 
 

 Return the indices of the k weakest rows in the matrix ordered from weakest to 
strongest. 

 
 Example 1: 

 
Input: mat = 
[[1,1,0,0,0],
 [1,1,1,1,0],
 [1,0,0,0,0],
 [1,1,0,0,0],
 [1,1,1,1,1]], 
k = 3
Output: [2,0,3]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 2 
- Row 1: 4 
- Row 2: 1 
- Row 3: 2 
- Row 4: 5 
The rows ordered from weakest to strongest are [2,0,3,1,4].
 

 Example 2: 

 
Input: mat = 
[[1,0,0,0],
 [1,1,1,1],
 [1,0,0,0],
 [1,0,0,0]], 
k = 2
Output: [0,2]
Explanation: 
The number of soldiers in each row is: 
- Row 0: 1 
- Row 1: 4 
- Row 2: 1 
- Row 3: 1 
The rows ordered from weakest to strongest are [0,2,3,1].
 

 
 Constraints: 

 
 m == mat.length 
 n == mat[i].length 
 2 <= n, m <= 100 
 1 <= k <= m 
 matrix[i][j] is either 0 or 1. 
 

 Related Topics Array Binary Search Sorting Heap (Priority Queue) Matrix 👍 3385
 👎 204

*/

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace TheKWeakestRowsInAMatrix
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,1,0,0,0], [1,1,1,1,0], [1,0,0,0,0], [1,1,0,0,0], [1,1,1,1,1]]", 3, "[2,0,3]")]
        [InlineData("[[1,1,1,1,1],[1,0,0,0,0],[1,1,0,0,0],[1,1,1,1,0],[1,1,1,1,1]]", 3, "[1,2,3]")]
        public void KWeakestRowsTest(string matrixJson, int k, string expectedResultJson)
        {
            var sut = new Solution();
            var input = JsonSerializer.Deserialize<int[][]>(matrixJson);
            var result = sut.KWeakestRows(input, k);
            var resultJson = JsonSerializer.Serialize(result);
            Assert.Equal(expectedResultJson, resultJson);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int CountOnes(int[] nums)
        {
            var l = 1;
            var r = nums.Length - 1;
            var c = 0;
            while (l <= r)
            {
                var mid = l + (r - l) / 2;
                var v = nums[mid];
                if (v == 0 && nums[mid - 1] == 1)
                {
                    c = mid;
                }

                if (v == 1 && mid == nums.Length - 1)
                {
                    c = nums.Length;
                    break;
                }

                if (v == 1)
                {
                    l = mid + 1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return c;
        }

        public int[] KWeakestRows(int[][] mat, int k)
        {
            var map = new Dictionary<int, int>();

            for (var i = 0; i < mat.Length; i++)
            {
                var row = mat[i];
                var onesCount = CountOnes(row);
                map.Add(i, onesCount);
            }

            return map.OrderBy(x => x.Value).ThenBy(x => x.Key).Take(k).Select(x => x.Key).ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}