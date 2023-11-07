/**
You are playing a video game where you are defending your city from a group of
n monsters. You are given a 0-indexed integer array dist of size n, where dist[i]
 is the initial distance in kilometers of the iᵗʰ monster from the city.

 The monsters walk toward the city at a constant speed. The speed of each
monster is given to you in an integer array speed of size n, where speed[i] is the
speed of the iᵗʰ monster in kilometers per minute.

 You have a weapon that, once fully charged, can eliminate a single monster.
However, the weapon takes one minute to charge. The weapon is fully charged at the
very start.

 You lose when any monster reaches your city. If a monster reaches the city at
the exact moment the weapon is fully charged, it counts as a loss, and the game
ends before you can use your weapon.

 Return the maximum number of monsters that you can eliminate before you lose,
or n if you can eliminate all the monsters before they reach the city.


 Example 1:


Input: dist = [1,3,4], speed = [1,1,1]
Output: 3
Explanation:
In the beginning, the distances of the monsters are [1,3,4]. You eliminate the
first monster.
After a minute, the distances of the monsters are [X,2,3]. You eliminate the
second monster.
After a minute, the distances of the monsters are [X,X,2]. You eliminate the
thrid monster.
All 3 monsters can be eliminated.

 Example 2:


Input: dist = [1,1,2,3], speed = [1,1,1,1]
Output: 1
Explanation:
In the beginning, the distances of the monsters are [1,1,2,3]. You eliminate
the first monster.
After a minute, the distances of the monsters are [X,0,1,2], so you lose.
You can only eliminate 1 monster.


 Example 3:


Input: dist = [3,2,4], speed = [5,3,2]
Output: 1
Explanation:
In the beginning, the distances of the monsters are [3,2,4]. You eliminate the
first monster.
After a minute, the distances of the monsters are [X,0,2], so you lose.
You can only eliminate 1 monster.



 Constraints:


 n == dist.length == speed.length
 1 <= n <= 10⁵
 1 <= dist[i], speed[i] <= 10⁵


 Related Topics Array Greedy Sorting 👍 1275 👎 203

*/

using System;
using System.Text.Json;
using Xunit;

namespace EliminateMaximumNumberOfMonsters
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,3,4]", "[1,1,1]", 3)]
        [InlineData("[1,1,2,3]", "[1,1,1,1]", 1)]
        [InlineData("[3,2,4]", "[5,3,2]", 1)]
        [InlineData("[3,5,7,4,5]", "[2,3,6,3,2]", 2)]
        public void EliminateMaximumNumberOfMonstersTest(string distJson, string speedJson, int expectedResult)
        {
            var dist = JsonSerializer.Deserialize<int[]>(distJson)
                       ?? throw new ArgumentException("Invalid Json");

            var speed = JsonSerializer.Deserialize<int[]>(speedJson)
                        ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().EliminateMaximum(dist, speed));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int EliminateMaximum(int[] dist, int[] speed)
        {
            var monsters = new int[dist.Length];
            for (int m = 0; m < dist.Length; m++)
            {
                var comesAt = dist[m] / speed[m];

                if (dist[m] % speed[m] != 0)
                {
                    comesAt++;
                }

                monsters[m] = comesAt;
            }

            Array.Sort(monsters);
            var minute = 1;
            var killed = 1;
            while (killed < monsters.Length)
            {
                if (minute < monsters[killed])
                {
                    killed++;
                    minute++;
                }
                else
                {
                    return killed;
                }
            }

            return killed;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}