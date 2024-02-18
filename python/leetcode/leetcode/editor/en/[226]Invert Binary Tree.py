# Given the root of a binary tree, invert the tree, and return its root. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [4,2,7,1,3,6,9]
# Output: [4,7,2,9,6,3,1]
#  
# 
#  Example 2: 
#  
#  
# Input: root = [2,1,3]
# Output: [2,3,1]
#  
# 
#  Example 3: 
# 
#  
# Input: root = []
# Output: []
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [0, 100]. 
#  -100 <= Node.val <= 100 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 13
# 648 👎 204
import json
import unittest
from typing import Optional


class InvertBinaryTree_Test(unittest.TestCase):

    def test_invertBinaryTree(self):
        test_data = [
            (
                TreeNode(4,
                         left=TreeNode(2,
                                       left=TreeNode(1),
                                       right=TreeNode(3)),
                         right=TreeNode(7,
                                        left=TreeNode(6),
                                        right=TreeNode(9))),

                TreeNode(4,
                         left=TreeNode(7,
                                       left=TreeNode(9),
                                       right=TreeNode(6)),
                         right=TreeNode(2,
                                        left=TreeNode(3),
                                        right=TreeNode(1))),
            )
        ]
        for tree, expected in test_data:
            with self.subTest():
                self.asser(json.dumps(expected), json.dumps(Solution().invertTree(tree)))


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
    def invertTree(self, root: Optional[TreeNode]) -> Optional[TreeNode]:
        def inversion(node):
            if node is None:
                return
            tmp = node.left
            node.left = node.right
            node.right = tmp
            inversion(node.right)
            inversion(node.left)

        inversion(root)
        return root

# leetcode submit region end(Prohibit modification and deletion)
