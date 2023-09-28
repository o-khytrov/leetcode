/**
You are given the root of a binary search tree (BST) and an integer val.

 Find the node in the BST that the node's value equals val and return the
subtree rooted with that node. If such a node does not exist, return null.


 Example 1:


Input: root = [4,2,7,1,3], val = 2
Output: [2,1,3]


 Example 2:


Input: root = [4,2,7,1,3], val = 5
Output: []



 Constraints:


 The number of nodes in the tree is in the range [1, 5000].
 1 <= Node.val <= 10⁷
 root is a binary search tree.
 1 <= val <= 10⁷


 Related Topics Tree Binary Search Tree Binary Tree 👍 5422 👎 175

*/

using leetcode.CommonClasses;

namespace SearchInABinarySearchTree
{
//leetcode submit region begin(Prohibit modification and deletion)

    public class Solution
    {
        public TreeNode SearchBST(TreeNode root, int val)
        {
            if (root is null)
            {
                return null;
            }

            if (root.val == val)
                return root;
            if (val > root.val)
            {
                return SearchBST(root.right, val);
            }
            else
            {
                return SearchBST(root.left, val);
            }
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}