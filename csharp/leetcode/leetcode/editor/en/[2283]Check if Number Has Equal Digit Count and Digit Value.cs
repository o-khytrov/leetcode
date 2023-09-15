/**
You are given a 0-indexed string num of length n consisting of digits.

 Return true if for every index i in the range 0 <= i < n, the digit i occurs
num[i] times in num, otherwise return false.


 Example 1:


Input: num = "1210"
Output: true
Explanation:
num[0] = '1'. The digit 0 occurs once in num.
num[1] = '2'. The digit 1 occurs twice in num.
num[2] = '1'. The digit 2 occurs once in num.
num[3] = '0'. The digit 3 occurs zero times in num.
The condition holds true for every index in "1210", so return true.


 Example 2:


Input: num = "030"
Output: false
Explanation:
num[0] = '0'. The digit 0 should occur zero times, but actually occurs twice in
num.
num[1] = '3'. The digit 1 should occur three times, but actually occurs zero
times in num.
num[2] = '0'. The digit 2 occurs zero times in num.
The indices 0 and 1 both violate the condition, so return false.



 Constraints:


 n == num.length
 1 <= n <= 10
 num consists of digits.


 Related Topics Hash Table String Counting 👍 518 👎 62

*/

using System.Collections.Generic;
using Xunit;

namespace CheckIfNumberHasEqualDigitCountAndDigitValue
{
    public class Tests
    {
        [Theory]
        [InlineData("1210", true)]
        [InlineData("030", false)]
        public void CheckIfNumberHasEqualDigitCountAndDigitValueTest(string num, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().DigitCount(num));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool DigitCount(string num)
        {
            var map = new Dictionary<int, int>();
            var numbers = new int[num.Length];
            for (var i = 0; i < 10; i++)
            {
                map.Add(i, 0);
            }

            for (int i = 0; i < num.Length; i++)
            {
                var number = int.Parse(num[i].ToString());
                numbers[i] = number;
                map[number]++;
            }


            for (int i = 0; i < numbers.Length; i++)
            {
                if (map[i] != numbers[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}