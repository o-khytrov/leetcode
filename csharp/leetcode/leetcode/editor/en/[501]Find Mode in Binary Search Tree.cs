using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

//Given the root of a binary search tree (BST) with duplicates, return all the 
//mode(s) (i.e., the most frequently occurred element) in it. 
//
// If the tree has more than one mode, return them in any order. 
//
// Assume a BST is defined as follows: 
//
// 
// The left subtree of a node contains only nodes with keys less than or equal 
//to the node's key. 
// The right subtree of a node contains only nodes with keys greater than or 
//equal to the node's key. 
// Both the left and right subtrees must also be binary search trees. 
// 
//
// 
// Example 1: 
// 
// 
//Input: root = [1,null,2,2]
//Output: [2]
// 
//
// Example 2: 
//
// 
//Input: root = [0]
//Output: [0]
// 
//
// 
// Constraints: 
//
// 
// The number of nodes in the tree is in the range [1, 10⁴]. 
// -10⁵ <= Node.val <= 10⁵ 
// 
//
// 
//Follow up: Could you do that without using any extra space? (Assume that the 
//implicit stack space incurred due to recursion does not count).
//
// Related Topics Tree Depth-First Search Binary Search Tree Binary Tree 👍 3743
// 👎 755

namespace FindModeInBinarySearchTree
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,null,2,2]", "[2]")]
        [InlineData("[0]", "[0]")]
        public void FindModeInBinarySearchTreeTest(string binaryTreeJson, string expectedResultJson)
        {
            var tree = Helper.Json2BinaryTree(binaryTreeJson);
            Assert.Equal(expectedResultJson, JsonSerializer.Serialize(new Solution().FindMode(tree)));
        }

        [Fact]
        public void SingleTest()
        {
            var tree = new TreeNode(0);
            var result = new Solution().FindMode(tree);
            Assert.NotEmpty(result);
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
        private readonly Dictionary<int, int> _map = new();
        private int _maxFrequency = int.MinValue;

        private void Traverse(TreeNode? root)
        {
            if (root is null)
            {
                return;
            }

            if (!_map.TryAdd(root.val, 1))
            {
                _map[root.val]++;
            }

            _maxFrequency = Math.Max(_maxFrequency, _map[root.val]);

            Traverse(root.left);
            Traverse(root.right);
        }

        public int[] FindMode(TreeNode root)
        {
            Traverse(root);
            return _map.Where(x => x.Value == _maxFrequency).Select(x => x.Key).ToArray();
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}