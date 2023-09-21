/**
The Leetcode file system keeps a log each time some user performs a change
folder operation.

 The operations are described below:


 "../" : Move to the parent folder of the current folder. (If you are already
in the main folder, remain in the same folder).
 "./" : Remain in the same folder.
 "x/" : Move to the child folder named x (This folder is guaranteed to always
exist).


 You are given a list of strings logs where logs[i] is the operation performed
by the user at the iᵗʰ step.

 The file system starts in the main folder, then the operations in logs are
performed.

 Return the minimum number of operations needed to go back to the main folder
after the change folder operations.


 Example 1:




Input: logs = ["d1/","d2/","../","d21/","./"]
Output: 2
Explanation: Use this change folder operation "../" 2 times and go back to the
main folder.


 Example 2:




Input: logs = ["d1/","d2/","./","d3/","../","d31/"]
Output: 3


 Example 3:


Input: logs = ["d1/","../","../","../"]
Output: 0



 Constraints:


 1 <= logs.length <= 10³
 2 <= logs[i].length <= 10
 logs[i] contains lowercase English letters, digits, '.', and '/'.
 logs[i] follows the format described in the statement.
 Folder names consist of lowercase English letters and digits.


 Related Topics Array String Stack 👍 860 👎 60

*/

using System;
using System.Text.Json;
using Xunit;

namespace CrawlerLogFolder
{
    public class Tests
    {
        [Theory]
        [InlineData("[\"d1/\",\"d2/\",\"../\",\"d21/\",\"./\"]", 2)]
        [InlineData("[\"d1/\",\"d2/\",\"./\",\"d3/\",\"../\",\"d31/\"]", 3)]
        [InlineData("[\"d1/\",\"../\",\"../\",\"../\"]", 0)]
        public void CrawlerLogFolderTest(string logsJson, int expectedResult)
        {
            var logs = JsonSerializer.Deserialize<string[]>(logsJson) ?? throw new ArgumentException("Invalid Json");
            Assert.Equal(expectedResult, new Solution().MinOperations(logs));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        public int MinOperations(string[] logs)
        {
            var cnt = 0;
            for (int i = 0; i < logs.Length; i++)
            {
                var command = logs[i];

                if (command.StartsWith("../"))
                {
                    cnt--;
                }

                if (char.IsLetterOrDigit(command[0]) && command.EndsWith("/"))
                {
                    cnt++;
                }


                if (cnt < 0)
                {
                    cnt = 0;
                }
            }

            return cnt;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}