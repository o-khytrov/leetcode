/**
You are given a 0-indexed array of strings details. Each element of details
provides information about a given passenger compressed into a string of length 15.
The system is such that:


 The first ten characters consist of the phone number of passengers.
 The next character denotes the gender of the person.
 The following two characters are used to indicate the age of the person.
 The last two characters determine the seat allotted to that person.


 Return the number of passengers who are strictly more than 60 years old.


 Example 1:


Input: details = ["7868190130M7522","5303914400F9211","9273338290F4010"]
Output: 2
Explanation: The passengers at indices 0, 1, and 2 have ages 75, 92, and 40.
Thus, there are 2 people who are over 60 years old.


 Example 2:


Input: details = ["1313579440F2036","2921522980M5644"]
Output: 0
Explanation: None of the passengers are older than 60.



 Constraints:


 1 <= details.length <= 100
 details[i].length == 15
 details[i] consists of digits from '0' to '9'.
 details[i][10] is either 'M' or 'F' or 'O'.
 The phone numbers and seat numbers of the passengers are distinct.


 Related Topics Array String 👍 207 👎 10

*/

using System;
using System.Text.Json;
using Xunit;

namespace NumberOfSeniorCitizens
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"7868190130M7522\",\"5303914400F9211\",\"9273338290F4010\"]", 2)]
        [InlineData("[\"1313579440F2036\",\"2921522980M5644\"]", 0)]
        [InlineData("[\"5612624052M0130\",\"5378802576M6424\",\"5447619845F0171\",\"2941701174O9078\"]", 2)]
        public void NumberOfSeniorCitizensTest(string detailJson, int expectedResult)
        {
            var details = JsonSerializer.Deserialize<string[]>(detailJson) ??
                          throw new ArgumentException("Input not valid");
            Assert.Equal(expectedResult, new Solution().CountSeniors(details));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int CountSeniors(string[] details)
        {
            //7868190130 M 75 22
            var count = 0;
            foreach (var p in details)
            {
                var age = p.AsSpan().Slice(11, 2);
                var intAge = int.Parse(age);

                if (intAge > 60)
                {
                    count++;
                }
            }

            return count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}