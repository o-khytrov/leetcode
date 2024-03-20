# You are given two linked lists: list1 and list2 of sizes n and m respectively.
#  
# 
#  Remove list1's nodes from the aᵗʰ node to the bᵗʰ node, and put list2 in 
# their place. 
# 
#  The blue edges and nodes in the following figure indicate the result: 
#  
#  Build the result list and return its head. 
# 
#  
#  Example 1: 
#  
#  
# Input: list1 = [10,1,13,6,9,5], a = 3, b = 4, list2 = [1000000,1000001,1000002
# ]
# Output: [10,1,13,1000000,1000001,1000002,5]
# Explanation: We remove the nodes 3 and 4 and put the entire list2 in their 
# place. The blue edges and nodes in the above figure indicate the result.
#  
# 
#  Example 2: 
#  
#  
# Input: list1 = [0,1,2,3,4,5,6], a = 2, b = 5, list2 = [1000000,1000001,1000002
# ,1000003,1000004]
# Output: [0,1,1000000,1000001,1000002,1000003,1000004,6]
# Explanation: The blue edges and nodes in the above figure indicate the result.
# 
#  
# 
#  
#  Constraints: 
# 
#  
#  3 <= list1.length <= 10⁴ 
#  1 <= a <= b < list1.length - 1 
#  1 <= list2.length <= 10⁴ 
#  
# 
#  Related Topics Linked List 👍 1717 👎 203

import unittest


class MergeInBetweenLinkedLists_Test(unittest.TestCase):

    def array2list(self, arr):
        head = ListNode(arr[0])
        current = head
        for value in arr[1:]:
            current.next = ListNode(value)
            current = current.next
        return head

    def list2array(self, linked_list):
        result = []
        current = linked_list
        while current:
            result.append(current.val)
            current = current.next
        return result

    def test_mergeInBetweenLinkedLists(self):
        test_data = [
            ([10, 1, 13, 6, 9, 5], 3, 4, [1000000, 1000001, 1000002], [10, 1, 13, 1000000, 1000001, 1000002, 5]),
            ([0, 1, 2, 3, 4, 5, 6], 2, 5, [1000000, 1000001, 1000002, 1000003, 1000004],
             [0, 1, 1000000, 1000001, 1000002, 1000003, 1000004, 6])
        ]
        for list1, a, b, list2, expected in test_data:
            with self.subTest():
                result = Solution().mergeInBetween(self.array2list(list1), a, b, self.array2list(list2))
                self.assertSequenceEqual(expected, self.list2array(result))


if __name__ == '__main__':
    unittest.main()
    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for singly-linked list.


class ListNode:
    def __init__(self, val=0, next=None):
        self.val = val
        self.next = next


class Solution:
    def mergeInBetween(self, list1: ListNode, a: int, b: int, list2: ListNode) -> ListNode:
        head = list1
        current = list1
        c = 0
        link_a = None
        link_b = None
        while current:
            if c == a - 1:
                link_a = current
            if c == b:
                link_b = current.next
                break
            current = current.next
            c += 1
        link_a.next = list2
        current = list2
        while current:
            next_node = current.next
            if next_node is None:
                current.next = link_b
                break
            else:
                current = current.next
        return head

# leetcode submit region end(Prohibit modification and deletion)
