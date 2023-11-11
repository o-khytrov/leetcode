using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text.Json;
using Xunit;

//You are given an integer array target and an integer n. 
//
// You have an empty stack with the two following operations: 
//
// 
// "Push": pushes an integer to the top of the stack. 
// "Pop": removes the integer on the top of the stack. 
// 
//
// You also have a stream of the integers in the range [1, n]. 
//
// Use the two stack operations to make the numbers in the stack (from the 
//bottom to the top) equal to target. You should follow the following rules: 
//
// 
// If the stream of the integers is not empty, pick the next integer from the 
//stream and push it to the top of the stack. 
// If the stack is not empty, pop the integer at the top of the stack. 
// If, at any moment, the elements in the stack (from the bottom to the top) 
//are equal to target, do not read new integers from the stream and do not do more 
//operations on the stack. 
// 
//
// Return the stack operations needed to build target following the mentioned 
//rules. If there are multiple valid answers, return any of them. 
//
// 
// Example 1: 
//
// 
//Input: target = [1,3], n = 3
//Output: ["Push","Push","Pop","Push"]
//Explanation: Initially the stack s is empty. The last element is the top of 
//the stack.
//Read 1 from the stream and push it to the stack. s = [1].
//Read 2 from the stream and push it to the stack. s = [1,2].
//Pop the integer on the top of the stack. s = [1].
//Read 3 from the stream and push it to the stack. s = [1,3].
// 
//
// Example 2: 
//
// 
//Input: target = [1,2,3], n = 3
//Output: ["Push","Push","Push"]
//Explanation: Initially the stack s is empty. The last element is the top of 
//the stack.
//Read 1 from the stream and push it to the stack. s = [1].
//Read 2 from the stream and push it to the stack. s = [1,2].
//Read 3 from the stream and push it to the stack. s = [1,2,3].
// 
//
// Example 3: 
//
// 
//Input: target = [1,2], n = 4
//Output: ["Push","Push"]
//Explanation: Initially the stack s is empty. The last element is the top of 
//the stack.
//Read 1 from the stream and push it to the stack. s = [1].
//Read 2 from the stream and push it to the stack. s = [1,2].
//Since the stack (from the bottom to the top) is equal to target, we stop the 
//stack operations.
//The answers that read integer 3 from the stream are not accepted.
// 
//
// 
// Constraints: 
//
// 
// 1 <= target.length <= 100 
// 1 <= n <= 100 
// 1 <= target[i] <= n 
// target is strictly increasing. 
// 
//
// Related Topics Array Stack Simulation 👍 892 👎 449

namespace BuildAnArrayWithStackOperations
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,3]", 3, "[\"Push\",\"Push\",\"Pop\",\"Push\"]")]
        [InlineData("[1,2,3]", 3, "[\"Push\",\"Push\",\"Push\"]")]
        [InlineData("[1,2]", 4, "[\"Push\",\"Push\"]")]
        public void BuildAnArrayWithStackOperationsTest(string targetJson, int n, string expectedResult)
        {
            var target = JsonSerializer.Deserialize<int[]>(targetJson)
                         ?? throw new ArgumentException("Invalid json");
            Assert.Equal(expectedResult, JsonSerializer.Serialize(new Solution().BuildArray(target, n)));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    public class Solution
    {
        private readonly Stack<int> _stack = new();

        public IList<string> BuildArray(int[] target, int n)
        {
            var result = new List<string>();


            for (int i = 1; i <= n; i++)
            {
                _stack.Push(i);
                result.Add("Push");

                if (_stack.Count > 0 && _stack.Peek() != target[_stack.Count - 1])
                {
                    _stack.Pop();
                    result.Add("Pop");
                }

                if (_stack.Count == target.Length)
                {
                    break;
                }
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}