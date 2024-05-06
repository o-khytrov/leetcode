# You are given the head of a linked list. 
# 
#  Remove every node which has a node with a greater value anywhere to the 
# right side of it. 
# 
#  Return the head of the modified linked list. 
# 
#  
#  Example 1: 
#  
#  
# Input: head = [5,2,13,3,8]
# Output: [13,8]
# Explanation: The nodes that should be removed are 5, 2 and 3.
# - Node 13 is to the right of node 5.
# - Node 13 is to the right of node 2.
# - Node 8 is to the right of node 3.
#  
# 
#  Example 2: 
# 
#  
# Input: head = [1,1,1,1]
# Output: [1,1,1,1]
# Explanation: Every node has value 1, so no nodes are removed.
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of the nodes in the given list is in the range [1, 10⁵]. 
#  1 <= Node.val <= 10⁵ 
#  
# 
#  Related Topics Linked List Stack Recursion Monotonic Stack 👍 1599 👎 46

import unittest
from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class RemoveNodesFromLinkedList_Test(unittest.TestCase):

    def asserLinkedListsEqual(self, list1: ListNode, list2: ListNode) -> bool:
        while list1 and list2:
            self.assertEqual(list1.val, list2.val)
            list1 = list1.next
            list2 = list2.next
        return not list1 and not list2

    def test_removeNodesFromLinkedList(self):
        list1 = ListNode(5, ListNode(2, ListNode(13, ListNode(3, ListNode(8)))))
        list2 = Solution().removeNodes(list1)
        expected = ListNode(13, ListNode(8))
        self.asserLinkedListsEqual(expected, list2)

    def test_removeNodesFromLinkedList2(self):
        list1 = ListNode(1, ListNode(1, ListNode(1, ListNode(1))))
        list2 = Solution().removeNodes(list1)
        expected =ListNode(1, ListNode(1, ListNode(1, ListNode(1))))
        self.asserLinkedListsEqual(expected, list2)


if __name__ == '__main__':
    unittest.main()


# leetcode submit region begin(Prohibit modification and deletion)
# Definition for singly-linked list.


class Solution:
    def removeNodes(self, head: Optional[ListNode]) -> Optional[ListNode]:
        stack = []
        while head:

            while stack and stack[-1] < head.val:
                stack.pop()

            stack.append(head.val)
            head = head.next
        if not stack:
            return None
        head = ListNode(stack.pop(0))
        current = head
        while stack:
            current.next = ListNode(stack.pop(0))
            current = current.next

        return head

# leetcode submit region end(Prohibit modification and deletion)
