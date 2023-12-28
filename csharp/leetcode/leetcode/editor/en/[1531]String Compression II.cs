/**
Run-length encoding is a string compression method that works by replacing
consecutive identical characters (repeated 2 or more times) with the concatenation
of the character and the number marking the count of the characters (length of
the run). For example, to compress the string "aabccc" we replace "aa" by "a2" and
replace "ccc" by "c3". Thus the compressed string becomes "a2bc3".

 Notice that in this problem, we are not adding '1' after single characters.

 Given a string s and an integer k. You need to delete at most k characters
from s such that the run-length encoded version of s has minimum length.

 Find the minimum length of the run-length encoded version of s after deleting
at most k characters.


 Example 1:


Input: s = "aaabcccd", k = 2
Output: 4
Explanation: Compressing s without deleting anything will give us "a3bc3d" of
length 6. Deleting any of the characters 'a' or 'c' would at most decrease the
length of the compressed string to 5, for instance delete 2 'a' then we will have
s = "abcccd" which compressed is abc3d. Therefore, the optimal way is to delete
'b' and 'd', then the compressed version of s will be "a3c3" of length 4.

 Example 2:


Input: s = "aabbaa", k = 2
Output: 2
Explanation: If we delete both 'b' characters, the resulting compressed string
would be "a4" of length 2.


 Example 3:


Input: s = "aaaaaaaaaaa", k = 0
Output: 3
Explanation: Since k is zero, we cannot delete anything. The compressed string
is "a11" of length 3.



 Constraints:


 1 <= s.length <= 100
 0 <= k <= s.length
 s contains only lowercase English letters.


 Related Topics String Dynamic Programming 👍 1895 👎 135

*/

using System;
using Xunit;

namespace StringCompressionII
{
    public class Tests
    {
        [Theory]
        [InlineData("aaabcccd", 2, 4)]
        [InlineData("aabbaa", 2, 2)]
        [InlineData("aaaaaaaaaaa", 0, 3)]
        public void StringCompressionIITest(string s, int k, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().GetLengthOfOptimalCompression(s, k));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private string _s;
        private int[][] _memo = new int[101][];

        private int Count(int index, int remainingChars)
        {
            var n = _s.Length;
            var k = remainingChars;
            if (n - index <= k)
            {
                return 0;
            }

            if (_memo[index][k] != -1)
            {
                return _memo[index][k];
            }

            int ans = k > 0 ? Count(index + 1, k - 1) : 101;
            var c = 1;
            for (int j = index + 1; j <= n; j++)
            {
                ans = Math.Min(ans, 1 + ((c > 99) ? 3 : (c > 9) ? 2 : (c > 1) ? 1 : 0) + Count(j, k));
                if (j < n && _s[index] == _s[j])
                {
                    c++;
                }
                else if (--k < 0)
                {
                    break;
                }
            }

            return _memo[index][remainingChars] = ans;
        }


        public int GetLengthOfOptimalCompression(string s, int k)
        {
            _s = s;
            for (int i = 0; i < _memo.Length; i++)
            {
                _memo[i] = new int[101];
                Array.Fill(_memo[i], -1);
            }

            return Count(0, k);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}