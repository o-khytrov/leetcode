/**
Given two strings first and second, consider occurrences in some text of the
form "first second third", where second comes immediately after first, and third
comes immediately after second.

 Return an array of all the words third for each occurrence of "first second
third".


 Example 1:
 Input: text = "alice is a good girl she is a good student", first = "a",
second = "good"
Output: ["girl","student"]

 Example 2:
 Input: text = "we will we will rock you", first = "we", second = "will"
Output: ["we","rock"]


 Constraints:


 1 <= text.length <= 1000
 text consists of lowercase English letters and spaces.
 All the words in text a separated by a single space.
 1 <= first.length, second.length <= 10
 first and second consist of lowercase English letters.


 Related Topics String 👍 458 👎 347

*/

using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace OccurrencesAfterBigram
{
    public class Tests
    {
        [Theory]
        [InlineData("alice is a good girl she is a good student", "a", "good", "[\"girl\",\"student\"]")]
        [InlineData("we will we will rock you", "we", "will", "[\"we\",\"rock\"]")]
        public void OccurrencesAfterBigramTest(string text, string first, string second, string expectedResultJson)
        {
            var result = new Solution().FindOcurrences(text, first, second);
            var resultJson = JsonSerializer.Serialize(result);
            Assert.Equal(expectedResultJson, resultJson);
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string[] FindOcurrences(string text, string first, string second)
        {
            var result = new List<string>();
            var words = text.Split(" ");

            for (var i = 0; i < words.Length; i++)
            {
                if (i >= 2 && words[i - 1] == second && words[i - 2] == first)
                {
                    result.Add(words[i]);
                }
            }

            return result.ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}