/**
You are given an array of strings names, and an array heights that consists of
distinct positive integers. Both arrays are of length n.

 For each index i, names[i] and heights[i] denote the name and height of the iᵗʰ
 person.

 Return names sorted in descending order by the people's heights.


 Example 1:


Input: names = ["Mary","John","Emma"], heights = [180,165,170]
Output: ["Mary","Emma","John"]
Explanation: Mary is the tallest, followed by Emma and John.


 Example 2:


Input: names = ["Alice","Bob","Bob"], heights = [155,185,150]
Output: ["Bob","Alice","Bob"]
Explanation: The first Bob is the tallest, followed by Alice and the second Bob.




 Constraints:


 n == names.length == heights.length
 1 <= n <= 10³
 1 <= names[i].length <= 20
 1 <= heights[i] <= 10⁵
 names[i] consists of lower and upper case English letters.
 All the values of heights are distinct.


 Related Topics Array Hash Table String Sorting 👍 1094 👎 17

*/

using System;
using System.Linq;
using System.Text.Json;
using Xunit;

namespace SortThePeople
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"Mary\",\"John\",\"Emma\"]", "[180,165,170]",
            "[\"Mary\",\"Emma\",\"John\"]")]
        public void SortThePeopleTest(string namesJson, string heightsJson, string expectedOutputJson)
        {
            var names = JsonSerializer.Deserialize<string[]>(namesJson) ?? throw new ArgumentException("Invalid Json");
            var heights = JsonSerializer.Deserialize<int[]>(heightsJson) ??
                          throw new ArgumentException("Invalid Json");
            var sut = new Solution();

            var result = sut.SortPeople(names, heights);
            Assert.Equal(expectedOutputJson, JsonSerializer.Serialize(result));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public string[] SortPeople(string[] names, int[] heights)
        {
            return names.Zip(heights).OrderByDescending(x => x.Second).Select(x => x.First).ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}