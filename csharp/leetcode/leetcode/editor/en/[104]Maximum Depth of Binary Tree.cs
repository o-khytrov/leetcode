/**
Given the root of a binary tree, return its maximum depth.

 A binary tree's maximum depth is the number of nodes along the longest path
from the root node down to the farthest leaf node.


 Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 3


 Example 2:


Input: root = [1,null,2]
Output: 2



 Constraints:


 The number of nodes in the tree is in the range [0, 10⁴].
 -100 <= Node.val <= 100


 Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 1233
0 👎 204

*/

using System;
using leetcode.CommonClasses;
using Xunit;

namespace MaximumDepthOfBinaryTree
{
    public class Tests
    {
        [Theory]
        [InlineData]
        public void MaximumDepthOfBinaryTreeTest()
        {
        }
    }

//leetcode submit region begin(Prohibit modification and deletion)
    /**
     * Definition for a binary tree node.
     * public class TreeNode {
     *     public int val;
     *     public TreeNode left;
     *     public TreeNode right;
     *     public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) {
     *         this.val = val;
     *         this.left = left;
     *         this.right = right;
     *     }
     * }
     */
    public class Solution
    {
        private int _maxDepth = 0;

        private void Traverse(TreeNode? root, int depth)
        {
            if (root is null)
            {
                _maxDepth = Math.Max(_maxDepth, depth);
                return;
            }

            Traverse(root.left, depth + 1);
            Traverse(root.right, depth + 1);
        }

        public int MaxDepth(TreeNode root)
        {
            Traverse(root, 0);
            return _maxDepth;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}