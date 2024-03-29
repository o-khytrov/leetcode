/**
You are given a string word that consists of digits and lowercase English
letters.

 You will replace every non-digit character with a space. For example, "a123bc34
d8ef34" will become " 123 34 8 34". Notice that you are left with some integers
that are separated by at least one space: "123", "34", "8", and "34".

 Return the number of different integers after performing the replacement
operations on word.

 Two integers are considered different if their decimal representations without
any leading zeros are different.


 Example 1:


Input: word = "a123bc34d8ef34"
Output: 3
Explanation: The three different integers are "123", "34", and "8". Notice that
"34" is only counted once.


 Example 2:


Input: word = "leet1234code234"
Output: 2


 Example 3:


Input: word = "a1b01c001"
Output: 1
Explanation: The three integers "1", "01", and "001" all represent the same
integer because
the leading zeros are ignored when comparing their decimal values.



 Constraints:


 1 <= word.length <= 1000
 word consists of digits and lowercase English letters.


 Related Topics Hash Table String 👍 562 👎 88

*/

using System;
using System.Collections.Generic;
using Xunit;

namespace NumberOfDifferentIntegersInAString
{
    public class Tests
    {
        [Theory]
        [InlineData("a123bc34d8ef34", 3)]
        [InlineData("leet1234code234", 2)]
        [InlineData("a1b01c001", 1)]
        public void NumberOfDifferentIntegersInAStringTest(string s, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().NumDifferentIntegers(s));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int NumDifferentIntegers(string word)
        {
            var set = new HashSet<string>();
            var isDigit = false;
            var span = word.AsSpan();
            var start = 0;
            for (int i = 0; i < span.Length; i++)
            {
                var c = span[i];
                if (char.IsDigit(c))
                {
                    if (!isDigit)
                    {
                        isDigit = true;
                        start = i;
                    }
                }
                else
                {
                    if (isDigit)
                    {
                        set.Add(span.Slice(start, i - start).TrimStart('0').ToString());
                    }

                    isDigit = false;
                }
            }

            if (isDigit)
            {
                set.Add(span.Slice(start, span.Length - start).TrimStart('0').ToString());
            }

            return set.Count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}