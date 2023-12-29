/**
You want to schedule a list of jobs in d days. Jobs are dependent (i.e To work
on the iᵗʰ job, you have to finish all the jobs j where 0 <= j < i).

 You have to finish at least one task every day. The difficulty of a job
schedule is the sum of difficulties of each day of the d days. The difficulty of a day
is the maximum difficulty of a job done on that day.

 You are given an integer array jobDifficulty and an integer d. The difficulty
of the iᵗʰ job is jobDifficulty[i].

 Return the minimum difficulty of a job schedule. If you cannot find a schedule
for the jobs return -1.


 Example 1:


Input: jobDifficulty = [6,5,4,3,2,1], d = 2
Output: 7
Explanation: First day you can finish the first 5 jobs, total difficulty = 6.
Second day you can finish the last job, total difficulty = 1.
The difficulty of the schedule = 6 + 1 = 7


 Example 2:


Input: jobDifficulty = [9,9,9], d = 4
Output: -1
Explanation: If you finish a job per day you will still have a free day. you
cannot find a schedule for the given jobs.


 Example 3:


Input: jobDifficulty = [1,1,1], d = 3
Output: 3
Explanation: The schedule is one job per day. total difficulty will be 3.



 Constraints:


 1 <= jobDifficulty.length <= 300
 0 <= jobDifficulty[i] <= 1000
 1 <= d <= 10


 Related Topics Array Dynamic Programming 👍 2945 👎 272

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace MinimumDifficultyOfAJobSchedule
{
    public class Tests
    {
        [Theory]
        [InlineData("[6,5,4,3,2,1]", 2, 7)]
        [InlineData("[9,9,9]", 4, -1)]
        [InlineData("[1,1,1]", 3, 3)]
        public void MinimumDifficultyOfAJobScheduleTest(string jobDifficultyJson, int d, int expectedResult)
        {
            var jobDifficulty = JsonSerializer.Deserialize<int[]>(jobDifficultyJson)
                                ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().MinDifficulty(jobDifficulty, d));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private int[] _jobDifficulty;

        private int Recursion(int daysLeft, int startJob, int[][] memo)
        {
            if (memo[daysLeft][startJob] != 0)
            {
                return memo[daysLeft][startJob];
            }

            if (daysLeft == 1)
            {
                var num = 0;
                for (var i = startJob; i < _jobDifficulty.Length; i++)
                {
                    num = Math.Min(num, _jobDifficulty[i]);
                }

                memo[daysLeft][startJob] = num;
                return num;
            }

            var maxDifficulty = _jobDifficulty[startJob];
            daysLeft--;
            var stop = _jobDifficulty.Length - daysLeft + 1;
            var result = int.MaxValue;
            for (int i = 1; i < stop; i++)
            {
                maxDifficulty = Math.Max(maxDifficulty, _jobDifficulty[startJob + i - 1]);

                result = Math.Min(result, Recursion(daysLeft, startJob + i, memo) + maxDifficulty);
            }

            return memo[daysLeft + 1][startJob] = result;
        }

        private void Recursion(int[] jd, int daysLeft, int idx, int[][] memo)
        {
            var len = jd.Length;
            if (memo[daysLeft][idx] != 0)
            {
                return;
            }

            if (daysLeft == 1)
            {
                var num = 0;
                for (var i = idx; i < len; i++)
                {
                    num = Math.Max(num, jd[i]);
                }

                memo[daysLeft][idx] = num;
                return;
            }

            var max = jd[idx];
            daysLeft--;
            var stop = len - idx - daysLeft + 1;

            var res = int.MaxValue;
            for (var i = 1; i < stop; i++)
            {
                max = Math.Max(max, jd[idx + i - 1]);
                var other = memo[daysLeft][idx + i];
                if (other == 0)
                {
                    Recursion(jd, daysLeft, idx + i, memo);
                    other = memo[daysLeft][idx + i];
                }

                res = Math.Min(res, other + max);
            }

            memo[daysLeft + 1][idx] = res;
        }

        public int MinDifficulty(int[] jobDifficulty, int d)
        {
            if (jobDifficulty.Length < d)
            {
                return -1;
            }

            var len = jobDifficulty.Length;
            var sum = 0;
            for (var i = 0; i < jobDifficulty.Length; i++)
            {
                sum += jobDifficulty[i];
            }

            if (sum == 0)
            {
                return 0;
            }

            var memo = new int[d + 1][];
            for (var i = 0; i < memo.Length; i++)
            {
                memo[i] = new int[len];
            }

            Recursion(jobDifficulty, d, 0, memo);

            return memo[d][0];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}