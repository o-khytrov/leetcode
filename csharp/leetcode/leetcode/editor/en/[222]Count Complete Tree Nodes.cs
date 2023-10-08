/**
Given the root of a complete binary tree, return the number of the nodes in the
tree.

 According to Wikipedia, every level, except possibly the last, is completely
filled in a complete binary tree, and all nodes in the last level are as far left
as possible. It can have between 1 and 2ʰ nodes inclusive at the last level h.

 Design an algorithm that runs in less than O(n) time complexity.


 Example 1:


Input: root = [1,2,3,4,5,6]
Output: 6


 Example 2:


Input: root = []
Output: 0


 Example 3:


Input: root = [1]
Output: 1



 Constraints:


 The number of nodes in the tree is in the range [0, 5 * 10⁴].
 0 <= Node.val <= 5 * 10⁴
 The tree is guaranteed to be complete.


 Related Topics Binary Search Tree Depth-First Search Binary Tree 👍 8127 👎 450


*/

using leetcode.CommonClasses;
using Xunit;

namespace CountCompleteTreeNodes
{
    public class Tests
    {
        [Theory]
        [InlineData("[1,2,3,4,5,6]", 6)]
        [InlineData("[]", 0)]
        [InlineData("[1]", 1)]
        public void CountCompleteTreeNodesTest(string treeJson, int expectedResult)
        {
            Assert.Equal(expectedResult, new Solution().CountNodes(Helper.Json2BinaryTree(treeJson)));
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
        public int CountNodes(TreeNode root)
        {
            if (root is null)
            {
                return 0;
            }

            return 1 + CountNodes(root.left) + CountNodes(root.right);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}