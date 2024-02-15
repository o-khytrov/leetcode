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
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 10
# 950 👎 225

import unittest
from typing import Optional


class SameTree_Test(unittest.TestCase):

    def test_sameTree(self):
        test_data = [(
            TreeNode(1, left=TreeNode(2, left=TreeNode(3))),
            TreeNode(1, left=TreeNode(2, left=TreeNode(3))), True
        ),
            (TreeNode(1, left=TreeNode(2)), TreeNode(1, left=TreeNode(2)), True),
            (TreeNode(1, left=TreeNode(2), right=TreeNode(1)), TreeNode(1, left=TreeNode(1), right=TreeNode(2)), False)
        ]
        for p, q, expected in test_data:
            with self.subTest(p=p, q=q, expected=expected):
                self.assertEquals(expected, Solution().isSameTree(p, q))


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
        if p is None and q is None:
            return True
        if p is not None and q is None:
            return False
        if q is not None and p is None:
            return False
        if not self.isSameTree(p.left, q.left):
            return False
        if p.val != q.val:
            return False

        if not self.isSameTree(p.right, q.right):
            return False
        return True

# leetcode submit region end(Prohibit modification and deletion)
