/**
Given the head of a singly linked list, group all the nodes with odd indices
together followed by the nodes with even indices, and return the reordered list.

 The first node is considered odd, and the second node is even, and so on.

 Note that the relative order inside both the even and odd groups should remain
as it was in the input.

 You must solve the problem in O(1) extra space complexity and O(n) time
complexity.


 Example 1:


Input: head = [1,2,3,4,5]
Output: [1,3,5,2,4]


 Example 2:


Input: head = [2,1,3,5,6,4,7]
Output: [2,3,6,7,1,5,4]



 Constraints:


 The number of nodes in the linked list is in the range [0, 10⁴].
 -10⁶ <= Node.val <= 10⁶


 Related Topics Linked List 👍 9484 👎 495

*/

using leetcode.CommonClasses;
using Xunit;

namespace OddEvenLinkedList
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4,5]", "[1,3,5,2,4]")]
        public void OddEvenLinkedListTest(string listJson, string expectedResultJson)
        {
            var linkedList = Helper.Json2LinkedList(listJson);
            Assert.Equal(expectedResultJson, Helper.LinkedList2Json(new Solution().OddEvenList(linkedList)));
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
        public ListNode OddEvenList(ListNode head)
        {
            if (head is null)
            {
                return null;

            }
            ListNode oddHead = null;
            ListNode mainHead = null;
            ListNode evenHead = null;
            ListNode mainEvenHead = null;
            var h = head;
            var index = 1;
            while (h != null)
            {
                var isOdd = index % 2 != 0;
                if (isOdd)
                {
                    if (oddHead == null)
                    {
                        oddHead = new ListNode(h.val);
                        mainHead = oddHead;
                    }
                    else
                    {
                        oddHead.next = new ListNode(h.val);
                        oddHead = oddHead.next;
                    }
                }
                else
                {
                    if (evenHead == null)
                    {
                        evenHead = new ListNode(h.val);
                        mainEvenHead = evenHead;
                    }
                    else
                    {
                        evenHead.next = new ListNode(h.val);
                        evenHead = evenHead.next;
                    }
                }


                h = h.next;
                index++;
            }

            oddHead.next = mainEvenHead;

            return mainHead;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}