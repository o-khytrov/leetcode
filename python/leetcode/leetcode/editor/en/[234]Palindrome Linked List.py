# Given the head of a singly linked list, return true if it is a palindrome or 
# false otherwise. 
# 
#  
#  Example 1: 
#  
#  
# Input: head = [1,2,2,1]
# Output: true
#  
# 
#  Example 2: 
#  
#  
# Input: head = [1,2]
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the list is in the range [1, 10⁵]. 
#  0 <= Node.val <= 9 
#  
# 
#  
# Follow up: Could you do it in 
# O(n) time and 
# O(1) space?
# 
#  Related Topics Linked List Two Pointers Stack Recursion 👍 15990 👎 863

import unittest
from typing import Optional


class PalindromeLinkedList_Test(unittest.TestCase):

    def test_palindromeLinkedList(self):
        test_data = [
            (ListNode(1, ListNode(2, ListNode(2, ListNode(1)))), True),
            (ListNode(1, ListNode(2)), False)
        ]
        for data, expected in test_data:
            with self.subTest(data=data, expected=expected):
                self.assertEqual(expected, Solution().isPalindrome(data))


if __name__ == '__main__':
    unittest.main()
    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for singly-linked list.


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def isPalindrome(self, head: Optional[ListNode]) -> bool:
        a = []
        while head:
            a.append(head.val)
            head = head.next
        l = 0
        r = len(a) - 1
        while l <= r:
            if a[r] != a[l]:
                return False
            l += 1
            r -= 1
        return True

# leetcode submit region end(Prohibit modification and deletion)
