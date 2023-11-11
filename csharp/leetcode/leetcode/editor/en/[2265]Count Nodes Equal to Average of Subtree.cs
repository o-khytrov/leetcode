using System.Collections.Generic;
using System.Runtime.Serialization;
using leetcode.CommonClasses;
using Xunit;

//Given the root of a binary tree, return the number of nodes where the value 
//of the node is equal to the average of the values in its subtree. 
//
// Note: 
//
// 
// The average of n elements is the sum of the n elements divided by n and 
//rounded down to the nearest integer. 
// A subtree of root is a tree consisting of root and all of its descendants. 
// 
//
// 
// Example 1: 
// 
// 
//Input: root = [4,8,5,0,1,null,6]
//Output: 5
//Explanation: 
//For the node with value 4: The average of its subtree is (4 + 8 + 5 + 0 + 1 + 
//6) / 6 = 24 / 6 = 4.
//For the node with value 5: The average of its subtree is (5 + 6) / 2 = 11 / 2 
//= 5.
//For the node with value 0: The average of its subtree is 0 / 1 = 0.
//For the node with value 1: The average of its subtree is 1 / 1 = 1.
//For the node with value 6: The average of its subtree is 6 / 1 = 6.
// 
//
// Example 2: 
// 
// 
//Input: root = [1]
//Output: 1
//Explanation: For the node with value 1: The average of its subtree is 1 / 1 = 
//1.
// 
//
// 
// Constraints: 
//
// 
// The number of nodes in the tree is in the range [1, 1000]. 
// 0 <= Node.val <= 1000 
// 
//
// Related Topics Tree Depth-First Search Binary Tree 👍 1972 👎 35

namespace CountNodesEqualToAverageOfSubtree
{
    public class Tests
    {
        [Fact]
        public void CountNodesEqualToAverageOfSubtreeTest()
        {
            var tree = new TreeNode(4, left: new TreeNode(8, left: new TreeNode(0), right: new TreeNode(1)),
                right: new TreeNode(5, left: new TreeNode(6)));
            Assert.Equal(5, new Solution().AverageOfSubtree(tree));
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
        private readonly Dictionary<TreeNode, int> _sum = new();
        private readonly Dictionary<TreeNode, int> _count = new();
        private int result = 0;

        private void Traverse(TreeNode? root)
        {
            if (root is null)
            {
                return;
            }

            Traverse(root.left);
            Traverse(root.right);
            var count = 1;
            var sum = root.val;
            if (root.left is not null && _sum.ContainsKey(root.left))
            {
                sum += _sum[root.left];
            }

            if (root.right is not null && _sum.ContainsKey(root.right))
            {
                sum += _sum[root.right];
            }

            _sum[root] = sum;

            if (root.left is not null && _count.ContainsKey(root.left))
            {
                count += _count[root.left];
            }

            if (root.right is not null && _count.ContainsKey(root.right))
            {
                count += _count[root.right];
            }

            _count[root] = count;
            if (sum / count == root.val)
            {
                result++;
            }
        }

        public int AverageOfSubtree(TreeNode root)
        {
            Traverse(root);
            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}