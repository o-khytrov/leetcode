# Given a binary tree, find its minimum depth. 
# 
#  The minimum depth is the number of nodes along the shortest path from the 
# root node down to the nearest leaf node. 
# 
#  Note: A leaf is a node with no children. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [3,9,20,null,null,15,7]
# Output: 2
#  
# 
#  Example 2: 
# 
#  
# Input: root = [2,null,3,null,4,null,5,null,6]
# Output: 5
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [0, 10⁵]. 
#  -1000 <= Node.val <= 1000 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 71
# 32 👎 1287

import unittest
from typing import Optional


class MinimumDepthOfBinaryTree_Test(unittest.TestCase):

    def test_minimumDepthOfBinaryTree(self):
        test_data = [
            (
                TreeNode(3,
                         left=TreeNode(9),
                         right=TreeNode(20,
                                        left=TreeNode(15),
                                        right=TreeNode(7))
                         ),
                2
            )
        ]
        for tree, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().minDepth(tree))


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
    def minDepth(self, root: Optional[TreeNode]) -> int:
        if root is None:
            return 0
        left_depth = self.minDepth(root.left) + 1
        right_depth = self.minDepth(root.right) + 1
        if root.left is None:
            return right_depth

        if root.right is None:
            return left_depth
        return min(left_depth, right_depth)
        # leetcode submit region end(Prohibit modification and deletion)
