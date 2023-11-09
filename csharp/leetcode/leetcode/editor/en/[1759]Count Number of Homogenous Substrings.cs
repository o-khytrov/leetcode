using Xunit;

//Given a string s, return the number of homogenous substrings of s. Since the 
//answer may be too large, return it modulo 10⁹ + 7. 
//
// A string is homogenous if all the characters of the string are the same. 
//
// A substring is a contiguous sequence of characters within a string. 
//
// 
// Example 1: 
//
// 
//Input: s = "abbcccaa"
//Output: 13
//Explanation: The homogenous substrings are listed as below:
//"a"   appears 3 times.
//"aa"  appears 1 time.
//"b"   appears 2 times.
//"bb"  appears 1 time.
//"c"   appears 3 times.
//"cc"  appears 2 times.
//"ccc" appears 1 time.
//3 + 1 + 2 + 1 + 3 + 2 + 1 = 13. 
//
// Example 2: 
//
// 
//Input: s = "xy"
//Output: 2
//Explanation: The homogenous substrings are "x" and "y". 
//
// Example 3: 
//
// 
//Input: s = "zzzzz"
//Output: 15
// 
//
// 
// Constraints: 
//
// 
// 1 <= s.length <= 10⁵ 
// s consists of lowercase letters. 
// 
//
// Related Topics Math String 👍 1153 👎 77

namespace CountNumberOfHomogenousSubstrings
{
    public class Tests
    {
        [Theory]
        [InlineData("abbcccaa", 13)]
        [InlineData("xy", 2)]
        public void CountNumberOfHomogenousSubstringsTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CountHomogenous(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int CountHomogenous(string s)
        {
            long count = 0;
            var start = 0;
            var appeared = 0;
            for (var i = 0; i < s.Length; i++)
            {
                if (s[i] != s[start])
                {
                    appeared = i - start;
                    while (appeared > 0)
                    {
                        count += appeared;
                        appeared--;
                    }

                    start = i;
                }
            }

            appeared = s.Length - start;
            while (appeared > 0)
            {
                count += appeared;
                appeared--;
            }

            return (int) (count % 1000000007);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}