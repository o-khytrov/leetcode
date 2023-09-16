/**
You are given a string title consisting of one or more words separated by a
single space, where each word consists of English letters. Capitalize the string by
changing the capitalization of each word such that:


 If the length of the word is 1 or 2 letters, change all letters to lowercase.
 Otherwise, change the first letter to uppercase and the remaining letters to
lowercase.


 Return the capitalized title.


 Example 1:


Input: title = "capiTalIze tHe titLe"
Output: "Capitalize The Title"
Explanation:
Since all the words have a length of at least 3, the first letter of each word
is uppercase, and the remaining letters are lowercase.


 Example 2:


Input: title = "First leTTeR of EACH Word"
Output: "First Letter of Each Word"
Explanation:
The word "of" has length 2, so it is all lowercase.
The remaining words have a length of at least 3, so the first letter of each
remaining word is uppercase, and the remaining letters are lowercase.


 Example 3:


Input: title = "i lOve leetcode"
Output: "i Love Leetcode"
Explanation:
The word "i" has length 1, so it is lowercase.
The remaining words have a length of at least 3, so the first letter of each
remaining word is uppercase, and the remaining letters are lowercase.



 Constraints:


 1 <= title.length <= 100
 title consists of words separated by a single space without any leading or
trailing spaces.
 Each word consists of uppercase and lowercase English letters and is non-empty.



 Related Topics String 👍 656 👎 45

*/

using Xunit;

namespace CapitalizeTheTitle
{
    public class Tests
    {
        [Theory]
        [InlineData("capiTalIze tHe titLe", "Capitalize The Title")]
        [InlineData("First leTTeR of EACH Word", "First Letter of Each Word")]
        public void CapitalizeTheTitleTest(string s, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CapitalizeTitle(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private void CapitalizePart(char[] a, int start, int count)
        {
            for (int j = start; j < start + count ; j++)
            {
                a[j] = char.ToLower(a[j]);
            }

            if (count > 2)
            {
                a[start] = char.ToUpper(a[start]);
            }
        }

        public string CapitalizeTitle(string title)
        {
            var a = title.ToCharArray();

            var count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                var c = a[i];
                if (char.IsWhiteSpace(c))
                {
                    if (count > 0)
                    {
                        CapitalizePart(a, start: i - count, count);
                    }

                    count = 0;
                }
                else
                {
                    count++;
                }
            }

            if (count > 0)
            {
                CapitalizePart(a, a.Length - count, count);
            }

            return new string(a);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}