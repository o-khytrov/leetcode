# You are given the root of a binary tree where each node has a value in the 
# range [0, 25] representing the letters 'a' to 'z'. 
# 
#  Return the lexicographically smallest string that starts at a leaf of this 
# tree and ends at the root. 
# 
#  As a reminder, any shorter prefix of a string is lexicographically smaller. 
# 
#  
#  For example, "ab" is lexicographically smaller than "aba". 
#  
# 
#  A leaf of a node is a node that has no children. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [0,1,2,3,4,3,4]
# Output: "dba"
#  
# 
#  Example 2: 
#  
#  
# Input: root = [25,1,3,1,3,0,2]
# Output: "adz"
#  
# 
#  Example 3: 
#  
#  
# Input: root = [2,2,1,null,1,0,null,0]
# Output: "abc"
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 8500]. 
#  0 <= Node.val <= 25 
#  
# 
#  Related Topics String Tree Depth-First Search Binary Tree 👍 1853 👎 260

import unittest
from typing import Optional


class SmallestStringStartingFromLeaf_Test(unittest.TestCase):

    def test_smallestStringStartingFromLeaf(self):
        test_data = [
            (
                TreeNode(0,
                         TreeNode(1, TreeNode(3), TreeNode(4)),
                         TreeNode(2, TreeNode(3), TreeNode(4))),
                "dba"

            ),
            (
                TreeNode(0,
                         right=TreeNode(1)),
                "ba"

            ),

        ]
        for tree, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().smallestFromLeaf(tree))


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
    def smallestFromLeaf(self, root: Optional[TreeNode]) -> str:
        paths = []

        def dfs(node, path):
            if not node:
                return
            current = chr(ord('a') + node.val)
            if not node.left and not node.right:
                paths.append(current + path)
                return
            if node.left:
                dfs(node.left, current + path)
            if node.right:
                dfs(node.right, current + path)

        dfs(root, "")

        return sorted(paths)[0]

# leetcode submit region end(Prohibit modification and deletion)
