/**
Alice and Bob are traveling to Rome for separate business meetings.

 You are given 4 strings arriveAlice, leaveAlice, arriveBob, and leaveBob.
Alice will be in the city from the dates arriveAlice to leaveAlice (inclusive),
while Bob will be in the city from the dates arriveBob to leaveBob (inclusive). Each
will be a 5-character string in the format "MM-DD", corresponding to the month
and day of the date.

 Return the total number of days that Alice and Bob are in Rome together.

 You can assume that all dates occur in the same calendar year, which is not a
leap year. Note that the number of days per month can be represented as: [31, 28,
 31, 30, 31, 30, 31, 31, 30, 31, 30, 31].


 Example 1:


Input: arriveAlice = "08-15", leaveAlice = "08-18", arriveBob = "08-16",
leaveBob = "08-19"
Output: 3
Explanation: Alice will be in Rome from August 15 to August 18. Bob will be in
Rome from August 16 to August 19. They are both in Rome together on August 16th,
17th, and 18th, so the answer is 3.


 Example 2:


Input: arriveAlice = "10-01", leaveAlice = "10-31", arriveBob = "11-01",
leaveBob = "12-31"
Output: 0
Explanation: There is no day when Alice and Bob are in Rome together, so we
return 0.



 Constraints:


 All dates are provided in the format "MM-DD".
 Alice and Bob's arrival dates are earlier than or equal to their leaving dates.

 The given dates are valid dates of a non-leap year.


 Related Topics Math String 👍 221 👎 570

*/

using System;
using Xunit;

namespace CountDaysSpentTogether
{
    public class Tests
    {
        [Theory]
        [InlineData("08-15", "08-18", "08-16", "08-19", 3)]
        [InlineData("10-01", "10-31", "11-01", "12-31", 0)]
        [InlineData("10-20", "12-22", "06-21", "07-05", 0)]
        [InlineData("09-01", "10-19", "06-19", "10-20", 49)]
        public void CountDaysSpentTogetherTest(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob,
            int expectedResult)
        {
            Assert.Equal(expectedResult,
                new Solution().CountDaysTogether(arriveAlice, leaveAlice, arriveBob, leaveBob));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private static readonly int[] DaysPerMonth = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        private int GetDayOfYear(string date)
        {
            // var month = int.Parse(date.AsSpan(0, 2));
            // var day = int.Parse(date.AsSpan(3, 2));
            // var dayOfYear = 0;
            // for (var i = 0; i < month; i++)
            // {
            //     dayOfYear += DaysPerMonth[i];
            // }
            //
            // return dayOfYear + day;
            var dateOnly = DateOnly.ParseExact(date, "MM-dd");
            return dateOnly.DayOfYear;
        }

        public int CountDaysTogether(string arriveAlice, string leaveAlice, string arriveBob, string leaveBob)
        {
            var arriveAliceDate = GetDayOfYear(arriveAlice);
            var leaveAliceDate = GetDayOfYear(leaveAlice);
            var arriveBobDate = GetDayOfYear(arriveBob);
            var leaveBobDate = GetDayOfYear(leaveBob);

            if (arriveAliceDate > leaveBobDate)
            {
                return 0;
            }

            if (arriveBobDate > leaveAliceDate)
            {
                return 0;
            }

            return Math.Min(leaveBobDate, leaveAliceDate) + 1 - Math.Max(arriveBobDate, arriveAliceDate);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}