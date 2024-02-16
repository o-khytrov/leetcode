# Given the root of a binary tree, return its maximum depth. 
# 
#  A binary tree's maximum depth is the number of nodes along the longest path 
# from the root node down to the farthest leaf node. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [3,9,20,null,null,15,7]
# Output: 3
#  
# 
#  Example 2: 
# 
#  
# Input: root = [1,null,2]
# Output: 2
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [0, 10⁴]. 
#  -100 <= Node.val <= 100 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 12
# 430 👎 212

import unittest
from typing import Optional


class MaximumDepthOfBinaryTree_Test(unittest.TestCase):

    def test_maximumDepthOfBinaryTree(self):
        test_data = [(TreeNode(3,
                               left=TreeNode(9),
                               right=TreeNode(20,
                                              left=TreeNode(15),
                                              right=TreeNode(7))),
                      3
                      ),
                     ]
        for tree, expected in test_data:
            with self.subTest(tree=tree, expected=expected):
                self.assertEquals(expected, Solution().maxDepth(tree))


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
    def maxDepth(self, root: Optional[TreeNode]) -> int:
        def dfs(node, depth) -> int:
            if node is None:
                return depth
            depth += 1
            return max(dfs(node.left, depth), dfs(node.right, depth))

        return dfs(root, 0)

# leetcode submit region end(Prohibit modification and deletion)
