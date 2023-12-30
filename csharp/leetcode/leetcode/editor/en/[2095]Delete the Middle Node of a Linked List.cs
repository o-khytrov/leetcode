/**
You are given the head of a linked list. Delete the middle node, and return the
head of the modified linked list.

 The middle node of a linked list of size n is the ⌊n / 2⌋ᵗʰ node from the
start using 0-based indexing, where ⌊x⌋ denotes the largest integer less than or
equal to x.


 For n = 1, 2, 3, 4, and 5, the middle nodes are 0, 1, 1, 2, and 2,
respectively.



 Example 1:


Input: head = [1,3,4,7,1,2,6]
Output: [1,3,4,1,2,6]
Explanation:
The above figure represents the given linked list. The indices of the nodes are
written below.
Since n = 7, node 3 with value 7 is the middle node, which is marked in red.
We return the new list after removing this node.


 Example 2:


Input: head = [1,2,3,4]
Output: [1,2,4]
Explanation:
The above figure represents the given linked list.
For n = 4, node 2 with value 3 is the middle node, which is marked in red.


 Example 3:


Input: head = [2,1]
Output: [2]
Explanation:
The above figure represents the given linked list.
For n = 2, node 1 with value 1 is the middle node, which is marked in red.
Node 0 with value 2 is the only node remaining after removing node 1.


 Constraints:


 The number of nodes in the list is in the range [1, 10⁵].
 1 <= Node.val <= 10⁵


 Related Topics Linked List Two Pointers 👍 3830 👎 69

*/

using System.Collections;
using System.Collections.Generic;
using leetcode.CommonClasses;
using Xunit;

namespace DeleteTheMiddleNodeOfALinkedList
{
    public class Tests
    {
        [Fact]
        public void DeleteTheMiddleNodeOfALinkedListTest()
        {
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
        public ListNode DeleteMiddle(ListNode head)
        {
            var map = new Dictionary<int, ListNode>();
            var count = 0;
            var p = head;
            while (p != null)
            {
                map.Add(count, p);
                p = p.next;
                count++;
            }

            var middle = count / 2;
            if (count == 1)
            {
                return null;
            }

            if (count == 2)
            {
                head.next = null;
                return head;
            }

            map[middle - 1].next = map[middle + 1];
            return head;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}