/**
You are given an integer array matches where matches[i] = [winneri, loseri]
indicates that the player winneri defeated player loseri in a match.

 Return a list answer of size 2 where:


 answer[0] is a list of all players that have not lost any matches.
 answer[1] is a list of all players that have lost exactly one match.


 The values in the two lists should be returned in increasing order.

 Note:


 You should only consider the players that have played at least one match.
 The testcases will be generated such that no two matches will have the same
outcome.



 Example 1:


Input: matches = [[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]

Output: [[1,2,10],[4,5,7,8]]
Explanation:
Players 1, 2, and 10 have not lost any matches.
Players 4, 5, 7, and 8 each have lost one match.
Players 3, 6, and 9 each have lost two matches.
Thus, answer[0] = [1,2,10] and answer[1] = [4,5,7,8].


 Example 2:


Input: matches = [[2,3],[1,3],[5,4],[6,4]]
Output: [[1,2,5,6],[]]
Explanation:
Players 1, 2, 5, and 6 have not lost any matches.
Players 3 and 4 each have lost two matches.
Thus, answer[0] = [1,2,5,6] and answer[1] = [].



 Constraints:


 1 <= matches.length <= 10⁵
 matches[i].length == 2
 1 <= winneri, loseri <= 10⁵
 winneri != loseri
 All matches[i] are unique.


 Related Topics Array Hash Table Sorting Counting 👍 1722 👎 122

*/

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace FindPlayersWithZeroOrOneLosses
{
    public class Tests
    {
        [Theory]
        [InlineData("[[1,3],[2,3],[3,6],[5,6],[5,7],[4,5],[4,8],[4,9],[10,4],[10,9]]", "[[1,2,10],[4,5,7,8]]")]
        [InlineData("[[2,3],[1,3],[5,4],[6,4]]", "[[1,2,5,6],[]]")]
        public void FindPlayersWithZeroOrOneLossesTest(string matchesJson, string expectedResultJson)
        {
            var matches = Helper.ToIntMatrix(matchesJson);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().FindWinners(matches)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public IList<IList<int>> FindWinners(int[][] matches)
        {
            var players = new HashSet<int>();
            var losers = new Dictionary<int, int>();
            foreach (var match in matches)
            {
                var winner = match[0];
                var loser = match[1];
                players.Add(winner);
                players.Add(loser);

                if (!losers.TryAdd(loser, 1))
                {
                    losers[loser]++;
                }
            }

            return new List<IList<int>>()
            {
                players.Except(losers.Keys.ToHashSet()).OrderBy(x => x).ToList(),
                losers.Where(x => x.Value == 1).Select(x => x.Key).OrderBy(x => x).ToList()
            };
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}