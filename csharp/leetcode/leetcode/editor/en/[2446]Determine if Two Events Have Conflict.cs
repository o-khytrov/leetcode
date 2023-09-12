/**
You are given two arrays of strings that represent two inclusive events that
happened on the same day, event1 and event2, where:


 event1 = [startTime1, endTime1] and
 event2 = [startTime2, endTime2].


 Event times are valid 24 hours format in the form of HH:MM.

 A conflict happens when two events have some non-empty intersection (i.e.,
some moment is common to both events).

 Return true if there is a conflict between two events. Otherwise, return false.



 Example 1:


Input: event1 = ["01:15","02:00"], event2 = ["02:00","03:00"]
Output: true
Explanation: The two events intersect at time 2:00.


 Example 2:


Input: event1 = ["01:00","02:00"], event2 = ["01:20","03:00"]
Output: true
Explanation: The two events intersect starting from 01:20 to 02:00.


 Example 3:


Input: event1 = ["10:00","11:00"], event2 = ["14:00","15:00"]
Output: false
Explanation: The two events do not intersect.



 Constraints:


 evnet1.length == event2.length == 2.
 event1[i].length == event2[i].length == 5
 startTime1 <= endTime1
 startTime2 <= endTime2
 All the event times follow the HH:MM format.


 Related Topics Array String 👍 394 👎 53

*/

using System;
using System.Text.Json;
using Xunit;

namespace DetermineIfTwoEventsHaveConflict
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"01:15\",\"02:00\"]", "[\"02:00\",\"03:00\"]", true)]
        public void DetermineIfTwoEventsHaveConflictTest(string event1Json, string event2Json, bool expectedResult)
        {
            var event1 = JsonSerializer.Deserialize<string[]>(event1Json) ??
                         throw new ArgumentException("Invalid json");
            var event2 = JsonSerializer.Deserialize<string[]>(event2Json) ??
                         throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().HaveConflict(event1, event2));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private TimeOnly ParseTime(string time)
        {
            return TimeOnly.ParseExact(time, "HH:mm");
        }

        public bool HaveConflict(string[] event1, string[] event2)
        {
            var start1 = ParseTime(event1[0]);
            var end1 = ParseTime(event1[1]);

            var start2 = ParseTime(event2[0]);
            var end2 = ParseTime(event2[1]);

            return start2 >= start1 && start2 <= end1 || start1 >= start2 && start1 <= end2;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}