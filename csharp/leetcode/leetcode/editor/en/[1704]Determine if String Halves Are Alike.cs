/**
You are given a string s of even length. Split this string into two halves of
equal lengths, and let a be the first half and b be the second half.

 Two strings are alike if they have the same number of vowels ('a', 'e', 'i',
'o', 'u', 'A', 'E', 'I', 'O', 'U'). Notice that s contains uppercase and
lowercase letters.

 Return true if a and b are alike. Otherwise, return false.


 Example 1:


Input: s = "book"
Output: true
Explanation: a = "bo" and b = "ok". a has 1 vowel and b has 1 vowel. Therefore,
they are alike.


 Example 2:


Input: s = "textbook"
Output: false
Explanation: a = "text" and b = "book". a has 1 vowel whereas b has 2.
Therefore, they are not alike.
Notice that the vowel o is counted twice.



 Constraints:


 2 <= s.length <= 1000
 s.length is even.
 s consists of uppercase and lowercase letters.


 Related Topics String Counting 👍 1954 👎 99

*/

using Xunit;

namespace DetermineIfStringHalvesAreAlike
{
    public class Tests
    {
        [Theory]
        [InlineData("book", true)]
        [InlineData("textbook", false)]
        public void DetermineIfStringHalvesAreAlikeTest(string s, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().HalvesAreAlike(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool IsVowel(char c)
        {
            var lc = char.ToLower(c);
            return lc is 'a' or 'e' or 'i' or 'o' or 'u';
        }

        public bool HalvesAreAlike(string s)
        {
            var l = 0;
            var r = 0;
            var m = s.Length / 2;
            for (var i = 0; i < s.Length; i++)
            {
                var c = s[i];
                var isVowel = IsVowel(c);
                if (isVowel)
                {
                    if (i >= m)
                    {
                        r++;
                    }
                    else
                    {
                        l++;
                    }
                }
            }

            return l == r;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}