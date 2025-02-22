# We run a preorder depth-first search (DFS) on the root of a binary tree. 
# 
#  At each node in this traversal, we output D dashes (where D is the depth of 
# this node), then we output the value of this node. If the depth of a node is D, 
# the depth of its immediate child is D + 1. The depth of the root node is 0. 
# 
#  If a node has only one child, that child is guaranteed to be the left child. 
# 
# 
#  Given the output traversal of this traversal, recover the tree and return 
# its root. 
# 
#  
#  Example 1: 
#  
#  
# Input: traversal = "1-2--3--4-5--6--7"
# Output: [1,2,5,3,4,6,7]
#  
# 
#  Example 2: 
#  
#  
# Input: traversal = "1-2--3---4-5--6---7"
# Output: [1,2,5,3,null,6,null,4,null,7]
#  
# 
#  Example 3: 
#  
#  
# Input: traversal = "1-401--349---90--88"
# Output: [1,401,null,349,88,90]
#  
# 
#  
#  Constraints: 
# 
#  
#  The number of nodes in the original tree is in the range [1, 1000]. 
#  1 <= Node.val <= 10⁹ 
#  
# 
#  Related Topics String Tree Depth-First Search Binary Tree 👍 1826 👎 52
import unittest
from collections import defaultdict
from typing import Optional


# leetcode submit region begin(Prohibit modification and deletion)
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right


class Solution:
    def recoverFromPreorder(self, traversal: str) -> Optional[TreeNode]:

        m = defaultdict(list)
        i = 0
        level = 0
        while i < len(traversal):
            n = 0
            while i < len(traversal) and traversal[i] == '-':
                i += 1
                level += 1
            while i < len(traversal) and traversal[i].isdigit():
                n *= 10
                n += int(traversal[i])
                i += 1

            node = TreeNode(n)
            m[level].append(node)
            if m[level-1]:
                parent = m[level-1][-1]
                if parent.left is None:
                    parent.left = node
                else:
                    parent.right = node

            level = 0

        return m[0][0]


# leetcode submit region end(Prohibit modification and deletion)

traversal = "1-2--3--4-5--6--7"
tree = Solution().recoverFromPreorder(traversal)

traversal = "1-401--349---90--88"
tree = Solution().recoverFromPreorder(traversal)
