# Given the roots of two binary trees p and q, write a function to check if 
# they are the same or not. 
# 
#  Two binary trees are considered the same if they are structurally identical, 
# and the nodes have the same value. 
# 
#  
#  Example 1: 
#  
#  
# Input: p = [1,2,3], q = [1,2,3]
# Output: true
#  
# 
#  Example 2: 
#  
#  
# Input: p = [1,2], q = [1,null,2]
# Output: false
#  
# 
#  Example 3: 
#  
#  
# Input: p = [1,2,1], q = [1,1,2]
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in both trees is in the range [0, 100]. 
#  -10⁴ <= Node.val <= 10⁴ 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 11
# 087 👎 228

import unittest
from idlelib.tree import TreeNode
from typing import Optional


class SameTree_Test(unittest.TestCase):

    def test_sameTree(self):
        test_data = [(TreeNode(1, TreeNode(2), TreeNode(3)), TreeNode(1, TreeNode(2), TreeNode(3)), True)]
        for tree1, tree2, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().isSameTree(tree1, tree2))


if __name__ == '__main__':
    unittest.main()
    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for a binary tree node.


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def isSameTree(self, p: Optional[TreeNode], q: Optional[TreeNode]) -> bool:
        if not p and not q:
            return True
            # If one of the nodes is None, they are not same
        if not p or not q:
            return False
            # Check if current values are equal
        if p.val != q.val:
            return False
            # Recursively check left and right subtrees
        return self.isSameTree(p.left, q.left) and self.isSameTree(p.right, q.right)
# leetcode submit region end(Prohibit modification and deletion)
