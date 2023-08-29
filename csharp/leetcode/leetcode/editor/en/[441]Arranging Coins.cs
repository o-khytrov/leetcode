/**
You have n coins and you want to build a staircase with these coins. The
staircase consists of k rows where the iᵗʰ row has exactly i coins. The last row of
the staircase may be incomplete.

 Given the integer n, return the number of complete rows of the staircase you
will build.


 Example 1:


Input: n = 5
Output: 2
Explanation: Because the 3ʳᵈ row is incomplete, we return 2.


 Example 2:


Input: n = 8
Output: 3
Explanation: Because the 4ᵗʰ row is incomplete, we return 3.



 Constraints:


 1 <= n <= 2³¹ - 1


 Related Topics Math Binary Search 👍 3548 👎 1265

*/

using Xunit;

namespace ArrangingCoins
{
    public class Tests
    {
        [Theory]
        [InlineData(5, 2)]
        [InlineData(8, 3)]
        public void ArrangeCoinsTest(int n, int expectedResult)
        {
            var sut = new Solution();
            var result = sut.ArrangeCoins(n);
            Assert.Equal(expectedResult, result);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int ArrangeCoins(int n)
        {
            var rows = 0;
            var t = n;
            var cols = 1;
            while (t >= cols)
            {
                t -= cols;
                rows++;
                cols++;
            }

            return rows;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}