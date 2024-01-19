/**
In the world of Dota2, there are two parties: the Radiant and the Dire.

 The Dota2 senate consists of senators coming from two parties. Now the Senate
wants to decide on a change in the Dota2 game. The voting for this change is a
round-based procedure. In each round, each senator can exercise one of the two
rights:


 Ban one senator's right: A senator can make another senator lose all his
rights in this and all the following rounds.
 Announce the victory: If this senator found the senators who still have rights
to vote are all from the same party, he can announce the victory and decide on
the change in the game.


 Given a string senate representing each senator's party belonging. The
character 'R' and 'D' represent the Radiant party and the Dire party. Then if there are
n senators, the size of the given string will be n.

 The round-based procedure starts from the first senator to the last senator in
the given order. This procedure will last until the end of voting. All the
senators who have lost their rights will be skipped during the procedure.

 Suppose every senator is smart enough and will play the best strategy for his
own party. Predict which party will finally announce the victory and change the
Dota2 game. The output should be "Radiant" or "Dire".


 Example 1:


Input: senate = "RD"
Output: "Radiant"
Explanation:
The first senator comes from Radiant and he can just ban the next senator's
right in round 1.
And the second senator can't exercise any rights anymore since his right has
been banned.
And in round 2, the first senator can just announce the victory since he is the
only guy in the senate who can vote.


 Example 2:


Input: senate = "RDD"
Output: "Dire"
Explanation:
The first senator comes from Radiant and he can just ban the next senator's
right in round 1.
And the second senator can't exercise any rights anymore since his right has
been banned.
And the third senator comes from Dire and he can ban the first senator's right
in round 1.
And in round 2, the third senator can just announce the victory since he is the
only guy in the senate who can vote.



 Constraints:


 n == senate.length
 1 <= n <= 10⁴
 senate[i] is either 'R' or 'D'.


 Related Topics String Greedy Queue 👍 2158 👎 1679

*/

using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Dota2Senate
{
    public class Tests
    {
        [Theory]
        [InlineData("RD", "Radiant")]
        [InlineData("RDD", "Dire")]
        [InlineData("DDRRR", "Dire")]
        [InlineData("RRR", "Radiant")]
        [InlineData("RDR", "Radiant")]
        public void Dota2SenateTest(string senate, string expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().PredictPartyVictory(senate));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string PredictPartyVictory(string senate)
        {
            var map = new Dictionary<char, int>();
            foreach (var c in senate)
            {
                if (!map.TryAdd(c, 1))
                {
                    map[c]++;
                }
            }

            if (map.Count == 1)
            {
                return map.Single().Key == 'R' ? "Radiant" : "Dire";
            }

            var d = 0;
            var r = 0;
            var queue = new Queue<char>(senate);
            while (map.All(x => x.Value > 0))
            {
                var voter = queue.Dequeue();
                if (voter == 'R')
                {
                    if (d > 0)
                    {
                        d--;
                        map[voter]--;
                        continue;
                    }

                    r++;
                }

                if (voter == 'D')
                {
                    if (r > 0)
                    {
                        r--;

                        map[voter]--;
                        continue;
                    }

                    d++;
                }

                queue.Enqueue(voter);
            }

            var remaining = queue.First();
            return remaining == 'R' ? "Radiant" : "Dire";
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}