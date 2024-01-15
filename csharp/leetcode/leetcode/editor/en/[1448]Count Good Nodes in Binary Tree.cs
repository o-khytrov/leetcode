/**
Given a binary tree root, a node X in the tree is named good if in the path
from root to X there are no nodes with a value greater than X.

 Return the number of good nodes in the binary tree.


 Example 1:




Input: root = [3,1,4,3,null,1,5]
Output: 4
Explanation: Nodes in blue are good.
Root Node (3) is always a good node.
Node 4 -> (3,4) is the maximum value in the path starting from the root.
Node 5 -> (3,4,5) is the maximum value in the path
Node 3 -> (3,1,3) is the maximum value in the path.

 Example 2:




Input: root = [3,3,null,4,2]
Output: 3
Explanation: Node 2 -> (3, 3, 2) is not good, because "3" is higher than it.

 Example 3:


Input: root = [1]
Output: 1
Explanation: Root is considered as good.


 Constraints:


 The number of nodes in the binary tree is in the range [1, 10^5].
 Each node's value is between [-10^4, 10^4].


 Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 5582
 👎 151

*/

using System;
using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace CountGoodNodesInBinaryTree
{
    public class Tests
    {
        [Fact]
        public void CountGoodNodesInBinaryTreeTest()
        {
            var tree = new TreeNode(3)
            {
                left = new TreeNode(1) { left = new TreeNode(3) },
                right = new TreeNode(4) { left = new TreeNode(1), right = new TreeNode(5) },
            };
            Assert.Equal(4, new Solution().GoodNodes(tree));
        }

        [Fact]
        public void CountGoodNodesInBinaryTreeTest2()
        {
            var tree = new TreeNode(3)
            {
                left = new TreeNode(3) { left = new TreeNode(4), right = new TreeNode(2) },
            };
            Assert.Equal(3, new Solution().GoodNodes(tree));
        }

        [Fact]
        public void CountGoodNodesInBinaryTreeTest3()
        {
            var tree = new TreeNode(1)
            {
            };
            Assert.Equal(1, new Solution().GoodNodes(tree));
        }

        [Fact]
        public void CountGoodNodesInBinaryTreeTest4()
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
        private int _count;

        private void Traverse(TreeNode root, int maxPathValue)
        {
            if (root is null)
            {
                return;
            }

            var val = root.val;
            if (val >= maxPathValue)
            {
                _count++;
            }

            maxPathValue = Math.Max(maxPathValue, val);
            Traverse(root.left, maxPathValue);
            Traverse(root.right, maxPathValue);
        }

        public int GoodNodes(TreeNode root)
        {
            Traverse(root, int.MinValue);
            return _count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}