/**
You are given a 0-indexed string word, consisting of lowercase English letters.
You need to select one index and remove the letter at that index from word so
that the frequency of every letter present in word is equal.

 Return true if it is possible to remove one letter so that the frequency of
all letters in word are equal, and false otherwise.

 Note:


 The frequency of a letter x is the number of times it occurs in the string.
 You must remove exactly one letter and cannot chose to do nothing.



 Example 1:


Input: word = "abcc"
Output: true
Explanation: Select index 3 and delete it: word becomes "abc" and each
character has a frequency of 1.


 Example 2:


Input: word = "aazz"
Output: false
Explanation: We must delete a character, so either the frequency of "a" is 1
and the frequency of "z" is 2, or vice versa. It is impossible to make all present
letters have equal frequency.



 Constraints:


 2 <= word.length <= 100
 word consists of lowercase English letters only.


 Related Topics Hash Table String Counting 👍 539 👎 1027

*/

using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace RemoveLetterToEqualizeFrequency
{
    public class Tests
    {
        [Theory]
        [InlineData("abcc", true)]
        [InlineData("abbccc", false)]
        [InlineData("aazz", false)]
        [InlineData("bac", true)]
        [InlineData("adbc", true)]
        [InlineData("cccaa", true)]
        [InlineData("zz", true)]
        [InlineData("cccd", true)]
        [InlineData("cbccca", false)]
        [InlineData("ceeeec", false)]
        public void RemoveLetterToEqualizeFrequencyTest(string word, bool expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().EqualFrequency(word));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public bool EqualFrequency(string word)
        {
            var map = new Dictionary<char, int>();

            for (int i = 0; i < word.Length; i++)
            {
                var c = word[i];
                if (!map.TryAdd(c, 1))
                {
                    map[c]++;
                }
            }

            var frequencyGroups = map.GroupBy(x => x.Value).ToList();

            /* abcc
              {"a":1,"b":1,"c":2}
             [
               { "frequency":2, items:[ {"c":2} ] },
               { "frequency":1, items:[ {"a":1}, {"b":1} ] }
             ]

             cccaa
              {"a":2,"c":3}
             [
               { "frequency":2, items:[ {"a":2} ] },
               { "frequency":3, items:[ {"c":3} ] }
             ]
            */
            var groupNumber = frequencyGroups.Count;
            if (groupNumber == 1)
            {
                return map.Values.All(x => x == 1) || map.Values.Count() == 1;
                ;
            }

            if (frequencyGroups.Count != 2)
            {
                return false;
            }

            var first = frequencyGroups[0];
            var second = frequencyGroups[1];
            // only two characters with different frequency
            var firstCount = first.Count();
            var secondCount = second.Count();
            var firstFrequency = frequencyGroups[0].Key;
            var secondFrequency = frequencyGroups[1].Key;


            if (firstCount == 1)
            {
                if (firstFrequency == 1 || firstFrequency - 1 == secondFrequency)
                {
                    return true;
                }
            }

            if (secondCount == 1)
            {
                if (secondFrequency == 1 || secondFrequency - 1 == firstFrequency)
                {
                    return true;
                }
            }

            return false;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}