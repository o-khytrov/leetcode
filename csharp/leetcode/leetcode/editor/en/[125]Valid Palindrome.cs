/**
A phrase is a palindrome if, after converting all uppercase letters into
lowercase letters and removing all non-alphanumeric characters, it reads the same
forward and backward. Alphanumeric characters include letters and numbers.

 Given a string s, return true if it is a palindrome, or false otherwise.


 Example 1:


Input: s = "A man, a plan, a canal: Panama"
Output: true
Explanation: "amanaplanacanalpanama" is a palindrome.


 Example 2:


Input: s = "race a car"
Output: false
Explanation: "raceacar" is not a palindrome.


 Example 3:


Input: s = " "
Output: true
Explanation: s is an empty string "" after removing non-alphanumeric characters.

Since an empty string reads the same forward and backward, it is a palindrome.



 Constraints:


 1 <= s.length <= 2 * 10⁵
 s consists only of printable ASCII characters.


 Related Topics Two Pointers String 👍 8257 👎 7893

*/

using Xunit;

namespace ValidPalindrome
{
    public class Tests
    {
        [Theory]
        [InlineData("A man, a plan, a canal: Panama", true)]
        [InlineData("race a car", false)]
        [InlineData(" ", true)]
        public void ValidPalindromeTest(string s, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().IsPalindrome(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsPalindrome(string s)
        {
            if (s.Length == 1)
            {
                return true;
            }

            var l = 0;
            var r = s.Length - 1;
            while (r > l)
            {
                if (!char.IsLetterOrDigit(s[l]))
                {
                    l++;
                    continue;
                }

                if (!char.IsLetterOrDigit(s[r]))
                {
                    r--;
                    continue;
                }

                if (char.ToLower(s[l]) != char.ToLower(s[r]))
                {
                    return false;
                }

                r--;
                l++;
            }

            return true;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}