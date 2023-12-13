/**
There are n kids with candies. You are given an integer array candies, where
each candies[i] represents the number of candies the iᵗʰ kid has, and an integer
extraCandies, denoting the number of extra candies that you have.

 Return a boolean array result of length n, where result[i] is true if, after
giving the iᵗʰ kid all the extraCandies, they will have the greatest number of
candies among all the kids, or false otherwise.

 Note that multiple kids can have the greatest number of candies.


 Example 1:


Input: candies = [2,3,5,1,3], extraCandies = 3
Output: [true,true,true,false,true]
Explanation: If you give all extraCandies to:
- Kid 1, they will have 2 + 3 = 5 candies, which is the greatest among the kids.

- Kid 2, they will have 3 + 3 = 6 candies, which is the greatest among the kids.

- Kid 3, they will have 5 + 3 = 8 candies, which is the greatest among the kids.

- Kid 4, they will have 1 + 3 = 4 candies, which is not the greatest among the
kids.
- Kid 5, they will have 3 + 3 = 6 candies, which is the greatest among the kids.



 Example 2:


Input: candies = [4,2,1,1,2], extraCandies = 1
Output: [true,false,false,false,false]
Explanation: There is only 1 extra candy.
Kid 1 will always have the greatest number of candies, even if a different kid
is given the extra candy.


 Example 3:


Input: candies = [12,1,12], extraCandies = 10
Output: [true,false,true]



 Constraints:


 n == candies.length
 2 <= n <= 100
 1 <= candies[i] <= 100
 1 <= extraCandies <= 50


 Related Topics Array 👍 4113 👎 495

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace KidsWithTheGreatestNumberOfCandies
{
    public class Tests
    {
        [Theory]
        [InlineData("[2,3,5,1,3]", 3, "[true,true,true,false,true]")]
        [InlineData("[4,2,1,1,2]", 1, "[true,false,false,false,false]")]
        [InlineData("[12,1,12]", 10, "[true,false,true]")]
        public void KidsWithTheGreatestNumberOfCandiesTest(string candiesJson, int extraCandies,
            string expectedResultJson)
        {
            var candies = JsonSerializer.Deserialize<int[]>(candiesJson)
                          ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResultJson,
                JsonSerializer.Serialize(new Solution().KidsWithCandies(candies, extraCandies)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<bool> KidsWithCandies(int[] candies, int extraCandies)
        {
            var max = candies.Max();
            var result = new List<bool>();
            for (int i = 0; i < candies.Length; i++)
            {
                result.Add(candies[i] + extraCandies >= max);
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}