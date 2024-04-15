# You are given the root of a binary tree containing digits from 0 to 9 only. 
# 
#  Each root-to-leaf path in the tree represents a number. 
# 
#  
#  For example, the root-to-leaf path 1 -> 2 -> 3 represents the number 123. 
#  
# 
#  Return the total sum of all root-to-leaf numbers. Test cases are generated 
# so that the answer will fit in a 32-bit integer. 
# 
#  A leaf node is a node with no children. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [1,2,3]
# Output: 25
# Explanation:
# The root-to-leaf path 1->2 represents the number 12.
# The root-to-leaf path 1->3 represents the number 13.
# Therefore, sum = 12 + 13 = 25.
#  
# 
#  Example 2: 
#  
#  
# Input: root = [4,9,0,5,1]
# Output: 1026
# Explanation:
# The root-to-leaf path 4->9->5 represents the number 495.
# The root-to-leaf path 4->9->1 represents the number 491.
# The root-to-leaf path 4->0 represents the number 40.
# Therefore, sum = 495 + 491 + 40 = 1026.
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 1000]. 
#  0 <= Node.val <= 9 
#  The depth of the tree will not exceed 10. 
#  
# 
#  Related Topics Tree Depth-First Search Binary Tree 👍 7668 👎 127

import unittest
from typing import Optional


class SumRootToLeafNumbers_Test(unittest.TestCase):

    def test_sumRootToLeafNumbers(self):
        test_data = [
            (TreeNode(1, TreeNode(2), TreeNode(3)), 25),
            (TreeNode(4, TreeNode(9, TreeNode(5), TreeNode(1)), TreeNode(0)), 1026)
        ]
        for node, expected in test_data:
            with self.subTest(node=node, expected=expected):
                self.assertEqual(expected, Solution().sumNumbers(node))


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
    def sumNumbers(self, root: Optional[TreeNode]) -> int:
        paths = []

        def dfs(node, path):
            if not node.left and not node.right:
                paths.append(path + str(node.val))
                return
            if node.left:
                dfs(node.left, path + str(node.val))
            if node.right:
                dfs(node.right, path + str(node.val))

        dfs(root, "")
        s = 0
        for p in paths:
            s += int(p)
        return s

# leetcode submit region end(Prohibit modification and deletion)
