/**
Given the root of a binary tree, construct a string consisting of parenthesis
and integers from a binary tree with the preorder traversal way, and return it.

 Omit all the empty parenthesis pairs that do not affect the one-to-one mapping
relationship between the string and the original binary tree.


 Example 1:


Input: root = [1,2,3,4]
Output: "1(2(4))(3)"
Explanation: Originally, it needs to be "1(2(4)())(3()())", but you need to
omit all the unnecessary empty parenthesis pairs. And it will be "1(2(4))(3)"


 Example 2:


Input: root = [1,2,3,null,4]
Output: "1(2()(4))(3)"
Explanation: Almost the same as the first example, except we cannot omit the
first parenthesis pair to break the one-to-one mapping relationship between the
input and the output.



 Constraints:


 The number of nodes in the tree is in the range [1, 10⁴].
 -1000 <= Node.val <= 1000


 Related Topics String Tree Depth-First Search Binary Tree 👍 3159 👎 3629

*/

using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using leetcode.CommonClasses;
using Xunit;

namespace ConstructStringFromBinaryTree
{
    public class Tests
    {
        [Fact]
        public void ConstructStringFromBinaryTreeTest()
        {
            var tree = new TreeNode(1, new TreeNode(2, new TreeNode(4)), new TreeNode(3));
            Assert.Equal("1(2(4))(3)", new Solution().Tree2str(tree));
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
        private bool HasChildren(TreeNode root)
        {
            return root.left is not null || root.right is not null;
        }


        public string Tree2str(TreeNode root)
        {
            var s = root.val.ToString();
            if (root.left is not null)
            {
                s += $"({Tree2str(root.left)})";
            }

            if (root.left is null && root.right is not null)
            {
                s += "()";
            }

            if (root.right is not null)
            {
                s += $"({Tree2str(root.right)})";
            }

            return s;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}