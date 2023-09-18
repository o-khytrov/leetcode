/**
You are given a string sentence that consist of words separated by spaces. Each
word consists of lowercase and uppercase letters only.

 We would like to convert the sentence to "Goat Latin" (a made-up language
similar to Pig Latin.) The rules of Goat Latin are as follows:


 If a word begins with a vowel ('a', 'e', 'i', 'o', or 'u'), append "ma" to the
end of the word.



 For example, the word "apple" becomes "applema".


 If a word begins with a consonant (i.e., not a vowel), remove the first letter
and append it to the end, then add "ma".

 For example, the word "goat" becomes "oatgma".


 Add one letter 'a' to the end of each word per its word index in the sentence,
starting with 1.

 For example, the first word gets "a" added to the end, the second word gets
"aa" added to the end, and so on.




 Return the final sentence representing the conversion from sentence to Goat
Latin.


 Example 1:
 Input: sentence = "I speak Goat Latin"
Output: "Imaa peaksmaaa oatGmaaaa atinLmaaaaa"

 Example 2:
 Input: sentence = "The quick brown fox jumped over the lazy dog"
Output: "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa
hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa"


 Constraints:


 1 <= sentence.length <= 150
 sentence consists of English letters and spaces.
 sentence has no leading or trailing spaces.
 All the words in sentence are separated by a single space.


 Related Topics String 👍 844 👎 1211

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GoatLatin
{
    public class Tests
    {
        [Theory]
        [InlineData("I speak Goat Latin", "Imaa peaksmaaa oatGmaaaa atinLmaaaaa")]
        [InlineData("The quick brown fox jumped over the lazy dog",
            "heTmaa uickqmaaa rownbmaaaa oxfmaaaaa umpedjmaaaaaa overmaaaaaaa hetmaaaaaaaa azylmaaaaaaaaa ogdmaaaaaaaaaa")]
        public void GoatLatinTest(string sentence, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().ToGoatLatin(sentence));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly HashSet<char> Vowels = new() { 'a', 'e', 'i', 'o', 'u' };

        public string ToGoatLatin(string sentence)
        {
            var words = sentence.Split(" ");
            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i].ToList();

                if (Vowels.Contains(char.ToLower(word[0])))
                {
                    word.Add('m');
                    word.Add('a');
                }
                else
                {
                    word.Add(word[0]);
                    word.RemoveAt(0);
                    word.Add('m');
                    word.Add('a');
                }

                for (var j = 0; j < i + 1; j++)
                {
                    word.Add('a');
                }

                words[i] = new string(word.ToArray());
            }

            return string.Join(" ", words);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}