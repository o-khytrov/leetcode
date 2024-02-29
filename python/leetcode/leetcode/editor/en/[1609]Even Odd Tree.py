# A binary tree is named Even-Odd if it meets the following conditions: 
# 
#  
#  The root of the binary tree is at level index 0, its children are at level 
# index 1, their children are at level index 2, etc. 
#  For every even-indexed level, all nodes at the level have odd integer values 
# in strictly increasing order (from left to right). 
#  For every odd-indexed level, all nodes at the level have even integer values 
# in strictly decreasing order (from left to right). 
#  
# 
#  Given the root of a binary tree, return true if the binary tree is Even-Odd, 
# otherwise return false. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [1,10,4,3,null,7,9,12,8,6,null,null,2]
# Output: true
# Explanation: The node values on each level are:
# Level 0: [1]
# Level 1: [10,4]
# Level 2: [3,7,9]
# Level 3: [12,8,6,2]
# Since levels 0 and 2 are all odd and increasing and levels 1 and 3 are all 
# even and decreasing, the tree is Even-Odd.
#  
# 
#  Example 2: 
#  
#  
# Input: root = [5,4,2,3,3,7]
# Output: false
# Explanation: The node values on each level are:
# Level 0: [5]
# Level 1: [4,2]
# Level 2: [3,3,7]
# Node values in level 2 must be in strictly increasing order, so the tree is 
# not Even-Odd.
#  
# 
#  Example 3: 
#  
#  
# Input: root = [5,9,1,3,5,7]
# Output: false
# Explanation: Node values in the level 1 should be even integers.
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 10⁵]. 
#  1 <= Node.val <= 10⁶ 
#  
# 
#  Related Topics Tree Breadth-First Search Binary Tree 👍 1420 👎 70

import unittest
from typing import Optional


class EvenOddTree_Test(unittest.TestCase):

    def test_evenOddTree(self):
        test_data = [
            (
                TreeNode(1,
                         left=TreeNode(10,
                                       left=TreeNode(3,
                                                     left=TreeNode(12),
                                                     right=TreeNode(8))),
                         right=TreeNode(4,
                                        left=TreeNode(7,
                                                      left=TreeNode(6)),
                                        right=TreeNode(9,
                                                       right=TreeNode(2)))

                         )
                , True),
            (
                TreeNode(5,
                         left=TreeNode(4, left=TreeNode(3), right=TreeNode(3)),
                         right=TreeNode(2, left=TreeNode(7))
                         )
                , False),
            (
                TreeNode(5,
                         left=TreeNode(9, left=TreeNode(3), right=TreeNode(5)),
                         right=TreeNode(1, left=TreeNode(7))
                         )
                , False),
        ]
        for tree, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().isEvenOddTree(tree))


if __name__ == '__main__':
    unittest.main()

# leetcode submit region begin(Prohibit modification and deletion)
# Definition for a binary tree node.
from queue import Queue


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:

    def isEvenOddTree(self, root: Optional[TreeNode]) -> bool:
        def is_odd(i):
            return i % 2 == 0

        q = Queue()
        q.put((root, 0))
        m = {}
        while not q.empty():
            node, level = q.get()
            if is_odd(level):
                if m.get(level, 0) >= node.val or is_odd(node.val):
                    return False
            else:
                if node.val >= m.get(level, float('inf')) or not is_odd(node.val):
                    return False

            m[level] = node.val
            if node.left:
                q.put((node.left, level + 1))
            if node.right:
                q.put((node.right, level + 1))

        return True

# leetcode submit region end(Prohibit modification and deletion)
