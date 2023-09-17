/**
Given a binary string s without leading zeros, return true if s contains at
most one contiguous segment of ones. Otherwise, return false.


 Example 1:


Input: s = "1001"
Output: false
Explanation: The ones do not form a contiguous segment.


 Example 2:


Input: s = "110"
Output: true


 Constraints:


 1 <= s.length <= 100
 s[i] is either '0' or '1'.
 s[0] is '1'.


 Related Topics String 👍 299 👎 889

*/

using Xunit;

namespace CheckIfBinaryStringHasAtMostOneSegmentOfOnes
{
    public class Tests
    {
        [Theory]
        [InlineData("1001", false)]
        [InlineData("110", true)]
        [InlineData("1", true)]
        [InlineData("10", true)]
        public void CheckIfBinaryStringHasAtMostOneSegmentOfOnesTest(string s, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CheckOnesSegment(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool CheckOnesSegment(string s)
        {
            var ones = 0;
            for (int i = 0; i < s.Length; i++)
            {
                var c = s[i];
                if (c == '1')
                {
                    ones++;
                }
            }

            if (ones == 1)
            {
                return true;
            }

            for (int i = 1; i < s.Length - 1; i++)
            {
                if (s[i] == '0' && s[i + 1] == '1')
                {
                    return false;
                }
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}