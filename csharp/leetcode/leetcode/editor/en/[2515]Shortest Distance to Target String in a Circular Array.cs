/**
You are given a 0-indexed circular string array words and a string target. A
circular array means that the array's end connects to the array's beginning.


 Formally, the next element of words[i] is words[(i + 1) % n] and the previous
element of words[i] is words[(i - 1 + n) % n], where n is the length of words.


 Starting from startIndex, you can move to either the next word or the previous
word with 1 step at a time.

 Return the shortest distance needed to reach the string target. If the string
target does not exist in words, return -1.


 Example 1:


Input: words = ["hello","i","am","leetcode","hello"], target = "hello",
startIndex = 1
Output: 1
Explanation: We start from index 1 and can reach "hello" by
- moving 3 units to the right to reach index 4.
- moving 2 units to the left to reach index 4.
- moving 4 units to the right to reach index 0.
- moving 1 unit to the left to reach index 0.
The shortest distance to reach "hello" is 1.


 Example 2:


Input: words = ["a","b","leetcode"], target = "leetcode", startIndex = 0
Output: 1
Explanation: We start from index 0 and can reach "leetcode" by
- moving 2 units to the right to reach index 3.
- moving 1 unit to the left to reach index 3.
The shortest distance to reach "leetcode" is 1.

 Example 3:


Input: words = ["i","eat","leetcode"], target = "ate", startIndex = 0
Output: -1
Explanation: Since "ate" does not exist in words, we return -1.



 Constraints:


 1 <= words.length <= 100
 1 <= words[i].length <= 100
 words[i] and target consist of only lowercase English letters.
 0 <= startIndex < words.length


 Related Topics Array String 👍 308 👎 16

*/

using System;
using System.Text.Json;
using Xunit;

namespace ShortestDistanceToTargetStringInACircularArray
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"hello\",\"i\",\"am\",\"leetcode\",\"hello\"]", "hello", 1, 1)]
        [InlineData("[\"a\",\"b\",\"leetcode\"]", "leetcode", 0, 1)]
        [InlineData("[\"i\",\"eat\",\"leetcode\"]", "ate", 0, -1)]
        [InlineData(
            "[\"hsdqinnoha\",\"mqhskgeqzr\",\"zemkwvqrww\",\"zemkwvqrww\",\"daljcrktje\",\"fghofclnwp\",\"djwdworyka\",\"cxfpybanhd\",\"fghofclnwp\",\"fghofclnwp\"]",
            "zemkwvqrww", 8, 4)]
        public void ShortestDistanceToTargetStringInACircularArrayTest(string wordsJson, string target, int startIndex,
            int expectedResult)
        {
            var words = JsonSerializer.Deserialize<string[]>(wordsJson) ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().ClosetTarget(words, target, startIndex));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int ClosetTarget(string[] words, string target, int startIndex)
        {
            var shortestDistance = -1;
            for (var i = 0; i < words.Length; i++)
            {
                if (words[i] == target)
                {
                    int distanceRight;
                    int distanceLeft;
                    if (i > startIndex)
                    {
                        distanceLeft = words.Length - i + startIndex;
                        distanceRight = i - startIndex;
                    }
                    else
                    {
                        distanceLeft = startIndex - i;
                        distanceRight = words.Length - startIndex + i;
                    }


                    var minDistance = Math.Min(distanceRight, distanceLeft);
                    if (shortestDistance == -1)
                    {
                        shortestDistance = minDistance;
                    }
                    else
                    {
                        shortestDistance = Math.Min(minDistance, shortestDistance);
                    }
                }
            }

            return shortestDistance;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}