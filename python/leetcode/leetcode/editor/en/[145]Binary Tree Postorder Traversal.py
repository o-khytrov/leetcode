# Given the root of a binary tree, return the postorder traversal of its nodes' 
# values. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [1,null,2,3]
# Output: [3,2,1]
#  
# 
#  Example 2: 
# 
#  
# Input: root = []
# Output: []
#  
# 
#  Example 3: 
# 
#  
# Input: root = [1]
# Output: [1]
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of the nodes in the tree is in the range [0, 100]. 
#  -100 <= Node.val <= 100 
#  
# 
#  
# Follow up: Recursive solution is trivial, could you do it iteratively?
# 
#  Related Topics Stack Tree Depth-First Search Binary Tree 👍 6719 👎 183

import unittest
from typing import Optional, List


class BinaryTreePostorderTraversal_Test(unittest.TestCase):

    def test_binaryTreePostorderTraversal(self):
        test_data = [(TreeNode(1, right=TreeNode(2, left=TreeNode(3))), [3, 2, 1])]
        for tree, expected in test_data:
            with self.subTest(tree=tree, expected=expected):
                self.assertSequenceEqual(expected, Solution().postorderTraversal(tree))


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
    def postorderTraversal(self, root: Optional[TreeNode]) -> List[int]:
        l = []

        def dfs(node):
            if node is None:
                return
            dfs(node.left)
            dfs(node.right)
            l.append(node.val)

        dfs(root)
        return l
# leetcode submit region end(Prohibit modification and deletion)
