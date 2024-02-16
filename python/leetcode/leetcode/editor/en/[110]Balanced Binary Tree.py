# Given a binary tree, determine if it is height-balanced. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [3,9,20,null,null,15,7]
# Output: true
#  
# 
#  Example 2: 
#  
#  
# Input: root = [1,2,2,3,3,null,null,4,4]
# Output: false
#  
# 
#  Example 3: 
# 
#  
# Input: root = []
# Output: true
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [0, 5000]. 
#  -10⁴ <= Node.val <= 10⁴ 
#  
# 
#  Related Topics Tree Depth-First Search Binary Tree 👍 10358 👎 628

import unittest
from typing import Optional


class BalancedBinaryTree_Test(unittest.TestCase):

    def test_balancedBinaryTree(self):
        test_data = [(TreeNode(3,
                               left=TreeNode(9),
                               right=TreeNode(20,
                                              left=TreeNode(15),
                                              right=TreeNode(7)
                                              )
                               ),
                      True
                      ),
                     (TreeNode(1,
                               left=TreeNode(2,
                                             left=TreeNode(3,
                                                           left=TreeNode(4),
                                                           right=TreeNode(4)),
                                             right=TreeNode(3)),
                               right=TreeNode(2)),
                      False
                      ),
                     (TreeNode(1, right=TreeNode(2, right=TreeNode(3))), False)
                     ]
        for tree, expected in test_data:
            with self.subTest(tree=tree, expected=expected):
                self.assertEqual(expected, Solution().isBalanced(tree))


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
    def isBalanced(self, root: Optional[TreeNode]) -> bool:

        def dfs(node) -> int:
            if node is None:
                return 0
            l = dfs(node.left)
            r = dfs(node.right)
            if abs(l - r) > 1:
                raise AssertionError("Not a balanced tree")
            depth = 1 + max(l, r)
            return depth

        try:
            dfs(root)
        except AssertionError:
            return False
        return True

    # leetcode submit region end(Prohibit modification and deletion)
