/**
Given a string s, partition s such that every substring of the partition is a
palindrome. Return all possible palindrome partitioning of s.


 Example 1:
 Input: s = "aab"
Output: [["a","a","b"],["aa","b"]]

 Example 2:
 Input: s = "a"
Output: [["a"]]


 Constraints:


 1 <= s.length <= 16
 s contains only lowercase English letters.


 Related Topics String Dynamic Programming Backtracking 👍 11799 👎 380

*/

using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace PalindromePartitioning
{
    public class Tests
    {
        [Theory]
        [InlineData("aab", "[[\"a\",\"a\",\"b\"],[\"aa\",\"b\"]]")]
        [InlineData("cdd", "[[\"c\",\"d\",\"d\"],[\"c\",\"dd\"]]")]
        public void PalindromePartitioningTest(string s, string expectedResultJson)
        {
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().Partition(s)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private bool IsPalindrome(string s, int l, int r)
        {
            while (l < r)
            {
                if (s[l] != s[r])
                {
                    return false;
                }

                l++;
                r--;
            }

            return true;
        }

        private void Dfs(string s, List<IList<string>> palindromes, List<string> partition, int i)
        {
            if (i >= s.Length)
            {
                palindromes.Add(new List<string>(partition));
                return;
            }

            for (int j = i; j < s.Length; j++)
            {
                if (IsPalindrome(s, i, j))
                {
                    partition.Add(s[i..(j + 1)]);
                    Dfs(s, palindromes, partition, j + 1);
                    partition.RemoveAt(partition.Count - 1);
                }
            }
        }

        public IList<IList<string>> Partition(string s)
        {
            var result = new List<IList<string>>();
            Dfs(s, result, new List<string>(), 0);

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}