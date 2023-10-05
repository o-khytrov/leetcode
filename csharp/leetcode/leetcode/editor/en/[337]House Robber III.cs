/**
The thief has found himself a new place for his thievery again. There is only
one entrance to this area, called root.

 Besides the root, each house has one and only one parent house. After a tour,
the smart thief realized that all houses in this place form a binary tree. It
will automatically contact the police if two directly-linked houses were broken
into on the same night.

 Given the root of the binary tree, return the maximum amount of money the
thief can rob without alerting the police.


 Example 1:


Input: root = [3,2,3,null,3,null,1]
Output: 7
Explanation: Maximum amount of money the thief can rob = 3 + 3 + 1 = 7.


 Example 2:


Input: root = [3,4,5,1,3,null,1]
Output: 9
Explanation: Maximum amount of money the thief can rob = 4 + 5 = 9.



 Constraints:


 The number of nodes in the tree is in the range [1, 10⁴].
 0 <= Node.val <= 10⁴


 Related Topics Dynamic Programming Tree Depth-First Search Binary Tree 👍 8166
👎 132

*/

using System;
using System.Collections.Generic;
using leetcode.CommonClasses;
using Xunit;

namespace HouseRobberIII
{
    public class Tests
    {
        [Theory]
        [InlineData("[3,2,3,null,3,null,1]", 7)]
        [InlineData("[3,4,5,1,3,null,1]", 9)]
        [InlineData("[4,2,null,1,3]", 8)]
        public void HouseRobberIIITest(string treeJson, int expectedResult)
        {
            var tree = Helper.Json2BinaryTree(treeJson);
            Assert.Equal(expectedResult, new Solution().Rob(tree));
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
        private readonly Dictionary<TreeNode, int> _memo = new();

        private int RobFrom(TreeNode? node)
        {
            if (node is null)
            {
                return 0;
            }

            if (_memo.TryGetValue(node, out var sum))
            {
                return sum;
            }

            var choice1 = node.val
                          + RobFrom(node.left?.left)
                          + RobFrom(node.left?.right)
                          + RobFrom(node.right?.left)
                          + RobFrom(node.right?.right);
            var choice2 = RobFrom(node.left) + RobFrom(node.right);
            _memo[node] = Math.Max(choice1, choice2);
            return _memo[node];
        }

        public int Rob(TreeNode root)
        {
            return RobFrom(root);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}