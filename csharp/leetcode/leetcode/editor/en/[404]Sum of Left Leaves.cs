/**
Given the root of a binary tree, return the sum of all left leaves.

 A leaf is a node with no children. A left leaf is a leaf that is the left
child of another node.


 Example 1:


Input: root = [3,9,20,null,null,15,7]
Output: 24
Explanation: There are two left leaves in the binary tree, with values 9 and 15
respectively.


 Example 2:


Input: root = [1]
Output: 0



 Constraints:


 The number of nodes in the tree is in the range [1, 1000].
 -1000 <= Node.val <= 1000


 Related Topics Tree Depth-First Search Breadth-First Search Binary Tree 👍 4889
 👎 282

*/

using leetcode.CommonClasses;
using Xunit;

namespace SumOfLeftLeaves
{
    public class Tests
    {
        [Theory]
        public void SumOfLeftLeavesTest()
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
        private int Traverse(TreeNode root, bool isLeft)
        {
            if (root is null)
            {
                return 0;
            }

            if (root.left is null && root.right is null && isLeft)
            {
                return root.val;
            }

            return Traverse(root.left, true) + Traverse(root.right, false);
        }

        public int SumOfLeftLeaves(TreeNode root)
        {
            return Traverse(root.left, true) + Traverse(root.right, false);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}