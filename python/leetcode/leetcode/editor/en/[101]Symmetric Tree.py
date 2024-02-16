# Given the root of a binary tree, check whether it is a mirror of itself (i.e.,
#  symmetric around its center). 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [1,2,2,3,4,4,3]
# Output: true
#  
# 
#  Example 2: 
#  
#  
# Input: root = [1,2,2,null,3,null,3]
# Output: false
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 1000]. 
#  -100 <= Node.val <= 100 
#  
# 
#  
# Follow up: Could you solve it both recursively and iteratively?
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 14
# 896 👎 364

import unittest
from typing import Optional


class SymmetricTree_Test(unittest.TestCase):

    def test_symmetricTree(self):
        test_data = [
            (TreeNode(1,
                      left=TreeNode(2,
                                    left=TreeNode(3),
                                    right=TreeNode(4)
                                    ),
                      right=TreeNode(2,
                                     left=TreeNode(4),
                                     right=TreeNode(3))
                      )
             , True),
            (TreeNode(1,
                      left=TreeNode(2,
                                    right=TreeNode(3)
                                    ),
                      right=TreeNode(2,
                                     right=TreeNode(3))
                      )
             , False)
        ]
        for tree, expected in test_data:
            with self.subTest(tree=tree, expected=expected):
                self.assertEquals(expected, Solution().isSymmetric(tree))


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
    def isSymmetric(self, root: Optional[TreeNode]) -> bool:
        if not root:
            return False

        def areSymmetric(left, right):
            if left is None and right is None:
                return True
            if left is None and right is not None:
                return False
            if right is None and left is not None:
                return False
            if left.val != right.val:
                return False
            if not areSymmetric(left.right, right.left):
                return False
            if not areSymmetric(left.left, right.right):
                return False
            return True

        return areSymmetric(root.left, root.right)

        return areSymmetric()

# leetcode submit region end(Prohibit modification and deletion)
