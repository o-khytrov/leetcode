/**
You are given an array of equal-length strings words. Assume that the length of
each string is n.

 Each string words[i] can be converted into a difference integer array
difference[i] of length n - 1 where difference[i][j] = words[i][j+1] - words[i][j] where
0 <= j <= n - 2. Note that the difference between two letters is the difference
between their positions in the alphabet i.e. the position of 'a' is 0, 'b' is 1,
 and 'z' is 25.


 For example, for the string "acb", the difference integer array is [2 - 0, 1 -
2] = [2, -1].


 All the strings in words have the same difference integer array, except one.
You should find that string.

 Return the string in words that has different difference integer array.


 Example 1:


Input: words = ["adc","wzy","abc"]
Output: "abc"
Explanation:
- The difference integer array of "adc" is [3 - 0, 2 - 3] = [3, -1].
- The difference integer array of "wzy" is [25 - 22, 24 - 25]= [3, -1].
- The difference integer array of "abc" is [1 - 0, 2 - 1] = [1, 1].
The odd array out is [1, 1], so we return the corresponding string, "abc".


 Example 2:


Input: words = ["aaa","bob","ccc","ddd"]
Output: "bob"
Explanation: All the integer arrays are [0, 0] except for "bob", which
corresponds to [13, -13].



 Constraints:


 3 <= words.length <= 100
 n == words[i].length
 2 <= n <= 20
 words[i] consists of lowercase English letters.


 Related Topics Array Hash Table String 👍 346 👎 104

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace OddStringDifference
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"adc\",\"wzy\",\"abc\"]", "abc")]
        [InlineData("[\"aaa\",\"bob\",\"ccc\",\"ddd\"]", "bob")]
        public void OddStringDifferenceTest(string wordsJson, string expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().OddString(words));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string OddString(string[] words)
        {
            var map = new Dictionary<string, int>();
            var strMap = new Dictionary<string, List<int>>();

            for (var i = 0; i < words.Length; i++)
            {
                var word = words[i];

                var difference = new int[word.Length - 1];
                for (var j = 0; j < word.Length - 1; j++)
                {
                    difference[j] = (word[j + 1] - 97) - (word[j] - 97);
                }

                var str = string.Join(",", difference);

                if (!map.TryAdd(str, 1))
                {
                    map[str]++;
                }

                if (!strMap.TryAdd(str, new List<int>() { i }))
                {
                    strMap[str].Add(i);
                }
            }

            return words[strMap[map.First(x => x.Value == 1).Key][0]];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}