/**
Given head which is a reference node to a singly-linked list. The value of each
node in the linked list is either 0 or 1. The linked list holds the binary
representation of a number.

 Return the decimal value of the number in the linked list.

 The most significant bit is at the head of the linked list.


 Example 1:


Input: head = [1,0,1]
Output: 5
Explanation: (101) in base 2 = (5) in base 10


 Example 2:


Input: head = [0]
Output: 0



 Constraints:


 The Linked List is not empty.
 Number of nodes will not exceed 30.
 Each node's value is either 0 or 1.


 Related Topics Linked List Math 👍 3958 👎 148

*/

using System.Collections;
using System.Collections.Generic;
using leetcode.CommonClasses;
using MiddleOfTheLinkedList;
using Xunit;

namespace ConvertBinaryNumberInALinkedListToInteger
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,0,1]", 5)]
        [InlineData("[0]", 0)]
        [InlineData("[1,0,0,1,0,0,1,1,1,0,0,0,0,0,0]", 18880)]
        public void ConvertBinaryNumberInALinkedListToIntegerTest(string linkedListJson, int expectedResult)
        {
            var list = Helper.Json2LinkedList(linkedListJson);
            Assert.Equal(expectedResult, new Solution().GetDecimalValue(list));
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    /**
     * Definition for singly-linked list.
     * public class ListNode {
     *     public int val;
     *     public ListNode next;
     *     public ListNode(int val=0, ListNode next=null) {
     *         this.val = val;
     *         this.next = next;
     *     }
     * }
     */
    public class Solution
    {
        private ListNode Reverse(ListNode head)
        {
            var stack = new Stack<ListNode>();
            var next = head;
            while (next is not null)
            {
                stack.Push(next);
                next = next.next;
            }

            var newHead = stack.Pop();
            next = newHead;
            while (stack.Count > 0)
            {
                next.next = stack.Pop();
                next = next.next;
            }

            next.next = null;

            return newHead;
        }

        public int GetDecimalValue(ListNode head)
        {
            head = Reverse(head);
            var result = 0;
            ListNode? next = head;
            int bitPosition = 0;
            while (next is not null)
            {
                var val = next.val;
                result |= val << bitPosition;


                bitPosition++;
                next = next.next;
            }

            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}