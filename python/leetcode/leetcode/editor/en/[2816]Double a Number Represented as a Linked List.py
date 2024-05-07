# You are given the head of a non-empty linked list representing a non-negative 
# integer without leading zeroes. 
# 
#  Return the head of the linked list after doubling it. 
# 
#  
#  Example 1: 
#  
#  
# Input: head = [1,8,9]
# Output: [3,7,8]
# Explanation: The figure above corresponds to the given linked list which 
# represents the number 189. Hence, the returned linked list represents the number 189 
# * 2 = 378.
#  
# 
#  Example 2: 
#  
#  
# Input: head = [9,9,9]
# Output: [1,9,9,8]
# Explanation: The figure above corresponds to the given linked list which 
# represents the number 999. Hence, the returned linked list reprersents the number 999
#  * 2 = 1998. 
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the list is in the range [1, 10⁴] 
#  0 <= Node.val <= 9 
#  The input is generated such that the list represents a number that does not 
# have leading zeros, except the number 0 itself. 
#  
# 
#  Related Topics Linked List Math Stack 👍 907 👎 23

import unittest
from typing import Optional


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class DoubleANumberRepresentedAsALinkedList_Test(unittest.TestCase):
    def asserLinkedListsEqual(self, list1: ListNode, list2: ListNode) -> bool:
        while list1 and list2:
            self.assertEqual(list1.val, list2.val)
            list1 = list1.next
            list2 = list2.next
        self.assertTrue(not list1)
        self.assertTrue(not list2)

    def test_doubleANumberRepresentedAsALinkedList(self):
        list1 = ListNode(1, ListNode(8, ListNode(9)))
        expected = ListNode(3, ListNode(7, ListNode(8)))
        duplicated = Solution().doubleIt(list1)
        self.asserLinkedListsEqual(expected, duplicated)

    def test_doubleANumberRepresentedAsALinkedList2(self):
        list1 = ListNode(9, ListNode(9, ListNode(9)))
        expected = ListNode(1, ListNode(9, ListNode(9, ListNode(8))))
        duplicated = Solution().doubleIt(list1)
        self.asserLinkedListsEqual(expected, duplicated)


if __name__ == '__main__':
    unittest.main()
    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for singly-linked list.


class Solution:
    def doubleIt(self, head: Optional[ListNode]) -> Optional[ListNode]:
        current = head
        stack = []

        def carry(value, index):
            new_value = stack[index] + value
            if new_value > 9:
                rem = new_value % 10
                carry_over = (new_value - rem) // 10
                stack[index] = rem
                if index > 0:
                    carry_over(carry_over, index - 1)
                else:
                    stack.insert(0, carry_over)
            else:
                stack[index] = new_value

        while current:
            val = current.val
            duplicated = val * 2
            if duplicated > 9:
                rem = duplicated % 10
                carry_over = (duplicated - rem) // 10
                if stack:
                    carry(carry_over, len(stack) - 1)
                else:
                    stack.insert(0, carry_over)
                stack.append(rem)
            else:
                stack.append(duplicated)
            current = current.next
        new_head = ListNode(stack.pop(0))
        current = new_head
        while stack:
            current.next = ListNode(stack.pop(0))
            current = current.next
        return new_head

# leetcode submit region end(Prohibit modification and deletion)
