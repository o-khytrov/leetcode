/**
You are given the array paths, where paths[i] = [cityAi, cityBi] means there
exists a direct path going from cityAi to cityBi. Return the destination city,
that is, the city without any path outgoing to another city.

 It is guaranteed that the graph of paths forms a line without any loop,
therefore, there will be exactly one destination city.


 Example 1:


Input: paths = [["London","New York"],["New York","Lima"],["Lima","Sao Paulo"]]
Output: "Sao Paulo"
Explanation: Starting at "London" city you will reach "Sao Paulo" city which is
the destination city. Your trip consist of: "London" -> "New York" -> "Lima" ->
"Sao Paulo".


 Example 2:


Input: paths = [["B","C"],["D","B"],["C","A"]]
Output: "A"
Explanation: All possible trips are:
"D" -> "B" -> "C" -> "A".
"B" -> "C" -> "A".
"C" -> "A".
"A".
Clearly the destination city is "A".


 Example 3:


Input: paths = [["A","Z"]]
Output: "Z"



 Constraints:


 1 <= paths.length <= 100
 paths[i].length == 2
 1 <= cityAi.length, cityBi.length <= 10
 cityAi != cityBi
 All strings consist of lowercase and uppercase English letters and the space
character.


 Related Topics Hash Table String 👍 1407 👎 73

*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace DestinationCity
{
    public class Tests
    {
        [Theory]
        [InlineData("[[\"London\",\"New York\"],[\"New York\",\"Lima\"],[\"Lima\",\"Sao Paulo\"]]", "Sao Paulo")]
        [InlineData("[[\"B\",\"C\"],[\"D\",\"B\"],[\"C\",\"A\"]]", "A")]
        [InlineData("[[\"A\",\"Z\"]]", "Z")]
        public void DestinationCityTest(string pathsJson, string expectedResult)
        {
            var paths = JsonSerializer.Deserialize<string[][]>(pathsJson) ??
                        throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, new Solution().DestCity(paths));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string DestCity(IList<IList<string>> paths)
        {
            var from = new HashSet<string>();
            var to = new HashSet<string>();
            foreach (var pair in paths)
            {
                from.Add(pair[0]);
                to.Add(pair[1]);
            }

            to.ExceptWith(from);
            return to.First();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}