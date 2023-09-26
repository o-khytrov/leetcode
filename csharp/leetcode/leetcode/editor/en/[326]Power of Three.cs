/**
Given an integer n, return true if it is a power of three. Otherwise, return
false.

 An integer n is a power of three, if there exists an integer x such that n == 3
ˣ.


 Example 1:


Input: n = 27
Output: true
Explanation: 27 = 3³


 Example 2:


Input: n = 0
Output: false
Explanation: There is no x where 3ˣ = 0.


 Example 3:


Input: n = -1
Output: false
Explanation: There is no x where 3ˣ = (-1).



 Constraints:


 -2³¹ <= n <= 2³¹ - 1



Follow up: Could you solve it without loops/recursion?

 Related Topics Math Recursion 👍 2878 👎 261

*/

using System;
using Xunit;

namespace PowerOfThree
{
    public class Tests
    {
        [Theory]
        [InlineData(27, true)]
        [InlineData(0, false)]
        [InlineData(-1, false)]
        public void PowerOfThreeTest(int n, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsPowerOfThree(n));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsPowerOfThree(int n)
        {
            /*
            if (n == 0)
            {
                return false;
            }

            while (n % 3 == 0)
            {
                n /= 3;
            }

            return n == 1;
            */
            var magicNumber = Math.Pow(3, Math.Floor(Math.Log(Int32.MaxValue) / Math.Log(3)));
            return n > 0 && magicNumber % n == 0;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}