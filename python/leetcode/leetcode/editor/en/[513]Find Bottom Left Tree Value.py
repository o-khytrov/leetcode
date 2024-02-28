# Given the root of a binary tree, return the leftmost value in the last row of 
# the tree. 
# 
#  
#  Example 1: 
#  
#  
# Input: root = [2,1,3]
# Output: 1
#  
# 
#  Example 2: 
#  
#  
# Input: root = [1,2,3,4,null,5,6,null,null,7]
# Output: 7
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the tree is in the range [1, 10⁴]. 
#  -2³¹ <= Node.val <= 2³¹ - 1 
#  
# 
#  Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 34
# 21 👎 272

import unittest
from typing import Optional


class FindBottomLeftTreeValue_Test(unittest.TestCase):

    def test_findBottomLeftTreeValue(self):
        test_data = [
            (TreeNode(2, TreeNode(1), TreeNode(3)), 1),
            (TreeNode(1,
                      TreeNode(2, TreeNode(4)),
                      TreeNode(3, TreeNode(5,
                                           TreeNode(7)), TreeNode(6))), 7)
        ]
        for tree, expected in test_data:
            with self.subTest():
                self.assertEqual(expected, Solution().findBottomLeftValue(tree))


if __name__ == '__main__':
    unittest.main()

    # leetcode submit region begin(Prohibit modification and deletion)
    # Definition for a binary tree node.


class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

import queue

class Solution:
    def findBottomLeftValue(self, root: Optional[TreeNode]) -> int:
        q = queue.Queue()
        q.put((root, 0))
        l = -1
        result = -1
        while not q.empty():
            node, level = q.get()
            if level != l:
                l = level
                result = node.val
            #print(f"{level}: {node.val}")
            if node.left is not None:
                q.put((node.left, level + 1))
            if node.right is not None:
                q.put((node.right, level + 1))
        return result

# leetcode submit region end(Prohibit modification and deletion)
