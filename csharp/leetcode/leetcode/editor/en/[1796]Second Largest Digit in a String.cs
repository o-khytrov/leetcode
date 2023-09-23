using System.Linq;
using Xunit;

//Given an alphanumeric string s, return the second largest numerical digit 
//that appears in s, or -1 if it does not exist. 
//
// An alphanumeric string is a string consisting of lowercase English letters 
//and digits. 
//
// 
// Example 1: 
//
// 
//Input: s = "dfa12321afd"
//Output: 2
//Explanation: The digits that appear in s are [1, 2, 3]. The second largest 
//digit is 2.
// 
//
// Example 2: 
//
// 
//Input: s = "abc1111"
//Output: -1
//Explanation: The digits that appear in s are [1]. There is no second largest 
//digit. 
// 
//
// 
// Constraints: 
//
// 
// 1 <= s.length <= 500 
// s consists of only lowercase English letters and/or digits. 
// 
//
// Related Topics Hash Table String 👍 475 👎 121

namespace SecondLargestDigitInAString
{
    public class Tests
    {
        [Theory]
        [InlineData("dfa12321afd", 2)]
        [InlineData("abc1111", -1)]
        [InlineData("ck077", 0)]
        public void SecondLargestDigitInAStringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().SecondHighest(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int SecondHighest(string s)
        {
            var digits = new int[10];

            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (char.IsDigit(c))
                {
                    var index = c - 48;
                    digits[index]++;
                }
            }

            int? maxValue = null;
            for (int i = 9; i >= 0; i--)
            {
                if (digits[i] > 0)
                {
                    if (maxValue is null)
                    {
                        maxValue = digits[i];
                    }
                    else
                    {
                        return i;
                    }
                }
            }

            return -1;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}