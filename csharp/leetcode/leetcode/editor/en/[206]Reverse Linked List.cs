/**
Given the head of a singly linked list, reverse the list, and return the
reversed list.


 Example 1:


Input: head = [1,2,3,4,5]
Output: [5,4,3,2,1]


 Example 2:


Input: head = [1,2]
Output: [2,1]


 Example 3:


Input: head = []
Output: []



 Constraints:


 The number of nodes in the list is the range [0, 5000].
 -5000 <= Node.val <= 5000



 Follow up: A linked list can be reversed either iteratively or recursively.
Could you implement both?

 Related Topics Linked List Recursion 👍 19679 👎 357

*/

using System.Text.Json;
using MiddleOfTheLinkedList;
using Xunit;

namespace ReverseLinkedList
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4,5]", "[5,4,3,2,1]")]
        [InlineData("[1,2]", "[2,1]")]
        [InlineData("[]", "[]")]
        public void ReverseLinkedListTest(string inputJson, string reversedJson)
        {
            var linkedList = Helper.Json2LinkedList(inputJson);
            Assert.Equal(reversedJson, Helper.LinkedList2Json(new Solution().ReverseList(linkedList)));
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
        public ListNode ReverseList(ListNode head)
        {
            if (head is null)
            {
                return head;
            }

            ListNode prev = null;
            while (head.next is not null)
            {
                var tmp = head.next;
                head.next = prev;
                prev = head;
                head = tmp;
            }


            head.next = prev;
            return head;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}