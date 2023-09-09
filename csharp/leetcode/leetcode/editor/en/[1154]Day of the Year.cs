/**
Given a string date representing a Gregorian calendar date formatted as YYYY-MM-
DD, return the day number of the year.


 Example 1:


Input: date = "2019-01-09"
Output: 9
Explanation: Given date is the 9th day of the year in 2019.


 Example 2:


Input: date = "2019-02-10"
Output: 41



 Constraints:


 date.length == 10
 date[4] == date[7] == '-', and all other date[i]'s are digits
 date represents a calendar date between Jan 1ˢᵗ, 1900 and Dec 31ᵗʰ, 2019.


 Related Topics Math String 👍 386 👎 442

*/

using System;
using Xunit;

namespace DayOfTheYear
{
    public class Tests
    {
        [Theory]
        [InlineData("2019-01-09", 9)]
        public void DayOfTheYearTest(string date, int expectedOutput)
        {
            Assert.Equal(expectedOutput, new Solution().DayOfYear(date));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int DayOfYear(string date)
        {
            return DateTime.Parse(date).DayOfYear;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}