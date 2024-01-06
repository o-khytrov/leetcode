/**
We have n jobs, where every job is scheduled to be done from startTime[i] to
endTime[i], obtaining a profit of profit[i].

 You're given the startTime, endTime and profit arrays, return the maximum
profit you can take such that there are no two jobs in the subset with overlapping
time range.

 If you choose a job that ends at time X you will be able to start another job
that starts at time X.


 Example 1:




Input: startTime = [1,2,3,3], endTime = [3,4,5,6], profit = [50,10,40,70]
Output: 120
Explanation: The subset chosen is the first and fourth job.
Time range [1-3]+[3-6] , we get profit of 120 = 50 + 70.


 Example 2:




Input: startTime = [1,2,3,4,6], endTime = [3,5,10,6,9], profit = [20,20,100,70,6
0]
Output: 150
Explanation: The subset chosen is the first, fourth and fifth job.
Profit obtained 150 = 20 + 70 + 60.


 Example 3:




Input: startTime = [1,1,1], endTime = [2,3,4], profit = [5,6,4]
Output: 6



 Constraints:


 1 <= startTime.length == endTime.length == profit.length <= 5 * 10⁴
 1 <= startTime[i] < endTime[i] <= 10⁹
 1 <= profit[i] <= 10⁴


 Related Topics Array Binary Search Dynamic Programming Sorting 👍 5919 👎 76

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace MaximumProfitInJobScheduling
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,3]", "[3,4,5,6]", "[50,10,40,70]", 120)]
        [InlineData("[1,2,3,4,6]", "[3,5,10,6,9]", "[20,20,100,70,60]", 150)]
        public void MaximumProfitInJobSchedulingTest(string startTimeJson, string endTimeJson, string profitJson,
            int expectedResult)
        {
            var startTime = JsonSerializer.Deserialize<int[]>(startTimeJson)
                            ?? throw new ArgumentException("Invalid json");

            var endTime = JsonSerializer.Deserialize<int[]>(endTimeJson)
                          ?? throw new ArgumentException("Invalid json");

            var profit = JsonSerializer.Deserialize<int[]>(profitJson)
                         ?? throw new ArgumentException("Invalid json");

            Assert.Equal(expectedResult, new Solution().JobScheduling(startTime, endTime, profit));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private class Job
        {
            public int StartTime { get; set; }
            public int EndTime { get; set; }
            public int Profit { get; set; }
        }

        private Job[] _jobs;


        public int JobScheduling(int[] startTime, int[] endTime, int[] profit)
        {
            _jobs = new Job[startTime.Length];
            for (var i = 0; i < startTime.Length; i++)
            {
                _jobs[i] = new Job() { StartTime = startTime[i], EndTime = endTime[i], Profit = profit[i] };
            }

            _jobs = _jobs.OrderBy(x => x.EndTime).ToArray();
            var dp = new int[_jobs.Length + 1];
            for (var i = 0; i < _jobs.Length; i++)
            {
                var lastNonConflictJob = UpperBound(i, _jobs[i].StartTime);
                dp[i + 1] = Math.Max(dp[i], dp[lastNonConflictJob] + _jobs[i].Profit);
            }

            return dp[_jobs.Length];
        }

        private int UpperBound(int i, int targetTime)
        {
            var low = 0;
            var high = i;
            while (low < high)
            {
                var mid = (low + high) / 2;
                if (_jobs[mid].EndTime <= targetTime)
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid;
                }
            }

            return low;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}