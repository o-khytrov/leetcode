# You are given the head of a singly linked-list. The list can be represented 
# as: 
# 
#  
# L0 → L1 → … → Ln - 1 → Ln
#  
# 
#  Reorder the list to be on the following form: 
# 
#  
# L0 → Ln → L1 → Ln - 1 → L2 → Ln - 2 → …
#  
# 
#  You may not modify the values in the list's nodes. Only nodes themselves may 
# be changed. 
# 
#  
#  Example 1: 
#  
#  
# Input: head = [1,2,3,4]
# Output: [1,4,2,3]
#  
# 
#  Example 2: 
#  
#  
# Input: head = [1,2,3,4,5]
# Output: [1,5,2,4,3]
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the list is in the range [1, 5 * 10⁴]. 
#  1 <= Node.val <= 1000 
#  
# 
#  Related Topics Linked List Two Pointers Stack Recursion 👍 10798 👎 385

import unittest
from typing import Optional


class ReorderList_Test(unittest.TestCase):

    def test_reorderList(self):
        test_data = [
            (ListNode(1, ListNode(2, ListNode(3, ListNode(4)))), [1, 4, 2, 3]),
            (ListNode(1, ListNode(2, ListNode(3, ListNode(4, ListNode(5))))), [1, 5, 2, 4, 3])
        ]
        for linked_list, expected in test_data:
            with self.subTest():
                Solution().reorderList(linked_list)
                result_list = []
                head = linked_list
                while head:
                    result_list.append(head.val)
                    head = head.next
                self.assertSequenceEqual(expected, result_list)


if __name__ == '__main__':
    unittest.main()
    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for singly-linked list.


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def reorderList(self, head: Optional[ListNode]) -> None:
        """
        Do not return anything, modify head in-place instead.
        """
        lis = []
        current = head
        c = 0
        while current:
            lis.append(current)
            current = current.next
            c += 1

        n = 0
        current = None
        prev = None
        while lis:
            if n % 2 == 0:
                current = lis.pop(0)
            else:
                current = lis.pop()
            n += 1
            current.next = None
            if prev:
                prev.next = current
            prev = current

# leetcode submit region end(Prohibit modification and deletion)
