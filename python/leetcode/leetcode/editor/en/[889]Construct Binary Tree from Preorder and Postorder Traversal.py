# Given two integer arrays, preorder and postorder where preorder is the 
# preorder traversal of a binary tree of distinct values and postorder is the postorder 
# traversal of the same tree, reconstruct and return the binary tree. 
# 
#  If there exist multiple answers, you can return any of them. 
# 
#  
#  Example 1: 
#  
#  
# Input: preorder = [1,2,4,5,3,6,7], postorder = [4,5,2,6,7,3,1]
# Output: [1,2,3,4,5,6,7]
#  
# 
#  Example 2: 
# 
#  
# Input: preorder = [1], postorder = [1]
# Output: [1]
#  
# 
#  
#  Constraints: 
# 
#  
#  1 <= preorder.length <= 30 
#  1 <= preorder[i] <= preorder.length 
#  All the values of preorder are unique. 
#  postorder.length == preorder.length 
#  1 <= postorder[i] <= postorder.length 
#  All the values of postorder are unique. 
#  It is guaranteed that preorder and postorder are the preorder traversal and 
# postorder traversal of the same binary tree. 
#  
# 
#  Related Topics Array Hash Table Divide and Conquer Tree Binary Tree 👍 2921 ?
# ? 128
import json
from collections import defaultdict
from typing import List, Optional


# leetcode submit region begin(Prohibit modification and deletion)
# Definition for a binary tree node.
class TreeNode:
    def __init__(self, val=0, left=None, right=None):
        self.val = val
        self.left = left
        self.right = right

    def pretty_print(self, level=0, prefix="Root: "):
        """Recursively prints the tree structure."""
        print(" " * (level * 4) + prefix + str(self.val))
        if self.left:
            self.left.pretty_print(level + 1, "L--> ")
        if self.right:
            self.right.pretty_print(level + 1, "R--> ")


class Solution:
    def constructFromPrePost(self, preorder: List[int], postorder: List[int]) -> Optional[TreeNode]:
        post_val_to_ids = {}
        N = len(postorder)
        for i, p in enumerate(postorder):
            post_val_to_ids[p] = i

        def build(i1, i2, j1, j2):
            if i1 > i2 or j1 > j2:
                return None
            val = preorder[i1]
            root = TreeNode(val)
            if i1 != i2:
                left_val = preorder[i1 + 1]
                mid = post_val_to_ids[left_val]
                left_size = mid - j1 + 1
                root.left = build(i1 + 1, i1 + left_size, j1, mid)
                root.right = build(i1 + left_size + 1, i2, mid + 1, j2 - 1)

            return root

        return build(0, N - 1, 0, N - 1)


#
# preorder = [1, 2, 4, 5, 3, 6, 7]
# postorder = [4, 5, 2, 6, 7, 3, 1]
# tree = Solution().constructFromPrePost(preorder, postorder)
# tree.pretty_print()

preorder = [3, 4, 1, 2]
postorder = [1, 4, 2, 3]
tree = Solution().constructFromPrePost(preorder, postorder)
tree.pretty_print()

# leetcode submit region end(Prohibit modification and deletion)
