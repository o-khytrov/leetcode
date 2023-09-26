/**
Given the head of a singly linked list, return the middle node of the linked
list.

 If there are two middle nodes, return the second middle node.


 Example 1:


Input: head = [1,2,3,4,5]
Output: [3,4,5]
Explanation: The middle node of the list is node 3.


 Example 2:


Input: head = [1,2,3,4,5,6]
Output: [4,5,6]
Explanation: Since the list has two middle nodes with values 3 and 4, we return
the second one.



 Constraints:


 The number of nodes in the list is in the range [1, 100].
 1 <= Node.val <= 100


 Related Topics Linked List Two Pointers 👍 10365 👎 306

*/

using System.Collections.Generic;
using System.Text.Json;
using Xunit;

namespace MiddleOfTheLinkedList
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4,5]", "[3,4,5]")]
        public void MiddleOfTheLinkedListTest(string linkedListJson, string expectedResult)
        {
            var sut = new Solution();
            var input = Helper.Json2LinkedList(linkedListJson);
            var result = Helper.LinkedList2Json(sut.MiddleNode(input));
            Assert.Equal(expectedResult, result);
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;

        public ListNode(int val = 0, ListNode next = null)
        {
            this.val = val;
            this.next = next;
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)

    public class Solution
    {
        public ListNode MiddleNode(ListNode head)
        {
            var map = new Dictionary<int, ListNode>();
            var c = 0;
            while (head is not null)
            {
                map[c] = head;
                c++;
                head = head.next;
            }

            return map[c / 2];
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}