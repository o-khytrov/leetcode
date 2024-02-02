/**
An integer has sequential digits if and only if each digit in the number is one
more than the previous digit.

 Return a sorted list of all the integers in the range [low, high] inclusive
that have sequential digits.


 Example 1:
 Input: low = 100, high = 300
Output: [123,234]

 Example 2:
 Input: low = 1000, high = 13000
Output: [1234,2345,3456,4567,5678,6789,12345]


 Constraints:


 10 <= low <= high <= 10^9


 Related Topics Enumeration 👍 2439 👎 148

*/

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace SequentialDigits
{
    public class Tests
    {
        [Theory]
        [InlineData(100, 300, "[123,234]")]
        [InlineData(1000, 13000, "[1234,2345,3456,4567,5678,6789,12345]")]
        public void SequentialDigitsTest(int low, int high, string expectedResultJson)
        {
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().SequentialDigits(low, high)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<int> SequentialDigits(int low, int high)
        {
            var minLength = low.ToString().Length;
            var maxLength = high.ToString().Length;
            var result = new HashSet<int>();
            for (var length = minLength; length <= maxLength; length++)
            {
                for (var d = 1; d < 10; d++)
                {
                    var r = Enumerable.Range(d, length).ToArray();
                    var number = 0;
                    var p = 1;
                    for (int i = r.Length - 1; i >= 0; i--)
                    {
                        if (r[i] > 9)
                        {
                            continue;
                        }

                        number += r[i] * p;
                        p *= 10;
                    }

                    if (number >= low && number <= high)
                    {
                        result.Add(number);
                    }
                }
            }

            return result
                .OrderBy(x => x).ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}