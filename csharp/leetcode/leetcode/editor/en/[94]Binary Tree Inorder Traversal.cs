/**
Given the root of a binary tree, return the inorder traversal of its nodes'
values.


 Example 1:


Input: root = [1,null,2,3]
Output: [1,3,2]


 Example 2:


Input: root = []
Output: []


 Example 3:


Input: root = [1]
Output: [1]



 Constraints:


 The number of nodes in the tree is in the range [0, 100].
 -100 <= Node.val <= 100



Follow up: Recursive solution is trivial, could you do it iteratively?

 Related Topics Stack Tree Depth-First Search Binary Tree 👍 12758 👎 690

*/

using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using leetcode.CommonClasses;
using Xunit;

namespace BinaryTreeInorderTraversal
{
    public class Tests
    {
        [Fact]
        public void BinaryTreeInorderTraversalTest()
        {
            var tree = new TreeNode(1, left: null, right: new TreeNode(2, left: new TreeNode(3), right: null));

            Assert.Equal("[1,3,2]", JsonSerializer.Serialize(new Solution().InorderTraversal(tree)));
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
        private void TraverseInOrder(TreeNode node, IList<int> list)
        {
            if (node is null)
            {
                return;
            }

            TraverseInOrder(node.left, list);
            list.Add(node.val);
            TraverseInOrder(node.right, list);
        }

        public IList<int> InorderTraversal(TreeNode root)
        {
            var result = new List<int>();
            TraverseInOrder(root, result);
            return result;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}