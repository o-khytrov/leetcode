# Given the root of a binary tree, return the sum of all left leaves. 
# 
#  A leaf is a node with no children. A left leaf is a leaf that is the left 
# child of another node. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [3,9,20,null,null,15,7]
# Output: 24
# Explanation: There are two left leaves in the binary tree, with values 9 and 1
# 5 respectively.
#  
# 
#  Example 2: 
# 
#  
# Input: root = [1]
# Output: 0
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 1000]. 
#  -1000 <= Node.val <= 1000 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 52
# 97 👎 298

import unittest
from idlelib.tree import TreeNode
from typing import Optional


class SumOfLeftLeaves_Test(unittest.TestCase):

    def test_sumOfLeftLeaves(self):
        test_data = [
            (TreeNode(3, TreeNode(9), TreeNode(20, TreeNode(15), TreeNode(7))), 24)

        ]
        for tree, expected in test_data:
            with self.subTest(tree=tree, expected=expected):
                self.assertEqual(expected, Solution().sumOfLeftLeaves(tree))


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
    def sumOfLeftLeaves(self, root: Optional[TreeNode]) -> int:
        def dfs(node, type):
            s = 0
            if not node:
                return 0
            if type == -1 and not node.left and not node.right:
                return node.val
            s += dfs(node.left, -1)
            s += dfs(node.right, 1)
            return s

        return dfs(root, 0)

# leetcode submit region end(Prohibit modification and deletion)
