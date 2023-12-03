using System;
using System.Collections.Generic;
using leetcode.CommonClasses;
using Xunit;

//Given the root of a binary tree, return the length of the diameter of the 
//tree. 
//
// The diameter of a binary tree is the length of the longest path between any 
//two nodes in a tree. This path may or may not pass through the root. 
//
// The length of a path between two nodes is represented by the number of edges 
//between them. 
//
// 
// Example 1: 
// 
// 
//Input: root = [1,2,3,4,5]
//Output: 3
//Explanation: 3 is the length of the path [4,2,1,3] or [5,2,1,3].
// 
//
// Example 2: 
//
// 
//Input: root = [1,2]
//Output: 1
// 
//
// 
// Constraints: 
//
// 
// The number of nodes in the tree is in the range [1, 10⁴]. 
// -100 <= Node.val <= 100 
// 
//
// Related Topics Tree Depth-First Search Binary Tree 👍 12800 👎 830

namespace DiameterOfBinaryTree
{
    public class Tests
    {
        [Fact]
        public void DiameterOfBinaryTreeTest()
        {
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4), new TreeNode(5)), new TreeNode(3));
            Assert.Equal(3, new Solution().DiameterOfBinaryTree(tree));
        }

        [Fact]
        public void DiameterOfBinaryTreeTest2()
        {
            var tree = new TreeNode(1, new TreeNode(2));
            Assert.Equal(1, new Solution().DiameterOfBinaryTree(tree));
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
        private int _maxDiameter = 0;
        private Dictionary<TreeNode, int> _memo = new();

        private int Dfs(TreeNode node)
        {
            if (node == null)
            {
                return 0;
            }

            if (_memo.ContainsKey(node))
            {
                return _memo[node];
            }

            var leftDepth = Dfs(node.left);
            var rightDepth = Dfs(node.right);
            var path = leftDepth + rightDepth;
            _maxDiameter = Math.Max(_maxDiameter, path);
            _memo[node] = Math.Max(leftDepth, rightDepth) + 1;
            return _memo[node];
        }

        public int DiameterOfBinaryTree(TreeNode root)
        {
            Dfs(root);
            return _maxDiameter;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}