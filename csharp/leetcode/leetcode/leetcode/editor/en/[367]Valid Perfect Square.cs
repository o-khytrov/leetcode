/**
Given a positive integer num, return true if num is a perfect square or false 
otherwise. 

 A perfect square is an integer that is the square of an integer. In other 
words, it is the product of some integer with itself. 

 You must not use any built-in library function, such as sqrt. 

 
 Example 1: 

 
Input: num = 16
Output: true
Explanation: We return true because 4 * 4 = 16 and 4 is an integer.
 

 Example 2: 

 
Input: num = 14
Output: false
Explanation: We return false because 3.742 * 3.742 = 14 and 3.742 is not an 
integer.
 

 
 Constraints: 

 
 1 <= num <= 2³¹ - 1 
 

 Related Topics Math Binary Search 👍 3859 👎 287

*/

using Xunit;

namespace ValidPerfectSquare
{
    public class Test
    {
        [Theory]
        [InlineData(16, true)]
        [InlineData(14, false)]
        [InlineData(2147483647, false)]
        public void TestIsPerfectSquare(int num, bool result)
        {
            Assert.Equal(result, new Solution().IsPerfectSquare(num));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsPerfectSquare(int num)
        {
            checked
            {
                if (num == 1)
                {
                    return true;
                }

                long l = 2;
                long r = num;

                while (l <= r)
                {
                    var mid = l + (r - l) / 2;
                    var square = mid * mid;
                    if (square == num)
                    {
                        return true;
                    }

                    if (square > num)
                    {
                        r = mid - 1;
                    }
                    else
                    {
                        l = mid + 1;
                    }
                }

                return false;
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}