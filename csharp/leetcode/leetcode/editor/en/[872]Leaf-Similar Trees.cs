/**
Consider all the leaves of a binary tree, from left to right order, the values
of those leaves form a leaf value sequence.



 For example, in the given tree above, the leaf value sequence is (6, 7, 4, 9, 8
).

 Two binary trees are considered leaf-similar if their leaf value sequence is
the same.

 Return true if and only if the two given trees with head nodes root1 and root2
are leaf-similar.


 Example 1:


Input: root1 = [3,5,1,6,2,9,8,null,null,7,4], root2 = [3,5,1,6,7,4,2,null,null,
null,null,null,null,9,8]
Output: true


 Example 2:


Input: root1 = [1,2,3], root2 = [1,3,2]
Output: false



 Constraints:


 The number of nodes in each tree will be in the range [1, 200].
 Both of the given trees will have values in the range [0, 200].


 Related Topics Tree Depth-First Search Binary Tree 👍 3392 👎 75

*/

using System.Collections.Generic;
using System.Linq;
using leetcode.CommonClasses;
using Xunit;

namespace LeafSimilarTrees
{
    public class Tests
    {
        [Theory]
        public void LeafSimilarTreesTest()
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
        private void GetLeafSequence(TreeNode root, List<int> leafs)
        {
            if (root is null)
            {
                return;
            }

            if (root.left is null && root.right is null)
            {
                leafs.Add(root.val);
                return;
            }

            GetLeafSequence(root.left, leafs);
            GetLeafSequence(root.right, leafs);
        }

        public bool LeafSimilar(TreeNode root1, TreeNode root2)
        {
            var leafs1 = new List<int>();
            GetLeafSequence(root1, leafs1);
            var leafs2 = new List<int>();
            GetLeafSequence(root2, leafs2);
            return leafs1.SequenceEqual(leafs2);
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}