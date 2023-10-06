/**
Given strings s1, s2, and s3, find whether s3 is formed by an interleaving of s1
 and s2.

 An interleaving of two strings s and t is a configuration where s and t are
divided into n and m substrings respectively, such that:


 s = s1 + s2 + ... + sn
 t = t1 + t2 + ... + tm
 |n - m| <= 1
 The interleaving is s1 + t1 + s2 + t2 + s3 + t3 + ... or t1 + s1 + t2 + s2 + t3
 + s3 + ...


 Note: a + b is the concatenation of strings a and b.


 Example 1:


Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbcbcac"
Output: true
Explanation: One way to obtain s3 is:
Split s1 into s1 = "aa" + "bc" + "c", and s2 into s2 = "dbbc" + "a".
Interleaving the two splits, we get "aa" + "dbbc" + "bc" + "a" + "c" =
"aadbbcbcac".
Since s3 can be obtained by interleaving s1 and s2, we return true.


 Example 2:


Input: s1 = "aabcc", s2 = "dbbca", s3 = "aadbbbaccc"
Output: false
Explanation: Notice how it is impossible to interleave s2 with any other string
to obtain s3.


 Example 3:


Input: s1 = "", s2 = "", s3 = ""
Output: true



 Constraints:


 0 <= s1.length, s2.length <= 100
 0 <= s3.length <= 200
 s1, s2, and s3 consist of lowercase English letters.



 Follow up: Could you solve it using only O(s2.length) additional memory space?


 Related Topics String Dynamic Programming 👍 7807 👎 444

*/

using System.Collections.Generic;
using Xunit;

namespace InterleavingString
{
    public class Tests
    {
        [Theory]
        [InlineData("aabcc", "dbbca", "aadbbcbcac", true)]
        [InlineData("aabcc", "dbbca", "aadbbbaccc", false)]
        [InlineData("", "", "", true)]
        public void InterleavingStringTest(string s1, string s2, string s3, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsInterleave(s1, s2, s3));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Dictionary<(int, int), bool> _memo = new();

        private bool Dfs(string s1, string s2, string s3, int i, int j)
        {
            if (i == s1.Length && j == s2.Length)
            {
                return true;
            }

            if (_memo.TryGetValue((i, j), out var val))
            {
                return val;
            }

            if (i < s1.Length && s1[i] == s3[i + j] && Dfs(s1, s2, s3, i + 1, j))
            {
                return true;
            }

            if (j < s2.Length && s2[j] == s3[i + j] && Dfs(s1, s2, s3, i, j + 1))
            {
                return true;
            }

            _memo[(i, j)] = false;
            return false;
        }

        public bool IsInterleave(string s1, string s2, string s3)
        {
            if (s1 == s2 && s1 == s3 && s3 == string.Empty)
            {
                return true;
            }

            if (s1.Length + s2.Length != s3.Length)
            {
                return false;
            }

            return Dfs(s1, s2, s3, 0, 0);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}