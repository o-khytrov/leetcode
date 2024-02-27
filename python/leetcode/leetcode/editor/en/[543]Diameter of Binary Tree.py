# Given the root of a binary tree, return the length of the diameter of the 
# tree. 
# 
#  The diameter of a binary tree is the length of the longest path between any 
# two nodes in a tree. This path may or may not pass through the root. 
# 
#  The length of a path between two nodes is represented by the number of edges 
# between them. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [1,2,3,4,5]
# Output: 3
# Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
#  
# 
#  Example 2: 
# 
#  
# Input: root = [1,2]
# Output: 1
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 10⁴]. 
#  -100 <= Node.val <= 100 
#  
# 
#  Related Topics Tree Depth-First Search Binary Tree 👍 13245 👎 908

import unittest
from idlelib.tree import TreeNode
from typing import Optional


class DiameterOfBinaryTree_Test(unittest.TestCase):

    def test_diameterOfBinaryTree(self):
        test_data = [
            (TreeNode(1, TreeNode(2, TreeNode(4), TreeNode(5)), TreeNode(3)), 3)
        ]
        for tree, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().diameterOfBinaryTree(tree))


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
    def __init__(self):
        self.diameter = 0
        self.memo = {}

    def diameterOfBinaryTree(self, root: Optional[TreeNode]) -> int:
        def dfs(node: Optional[TreeNode]):
            if not node:
                return 0
            if node in self.memo:
                return self.memo[node]
            left_dept = dfs(node.left)
            right_dept = dfs(node.right)
            path_length = left_dept + right_dept
            self.diameter = max(self.diameter, path_length)
            self.memo[node] = max(left_dept, right_dept) + 1
            return self.memo[node]

        dfs(root)
        return self.diameter

# leetcode submit region end(Prohibit modification and deletion)
