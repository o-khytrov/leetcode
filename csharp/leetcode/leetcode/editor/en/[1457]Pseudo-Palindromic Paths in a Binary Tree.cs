/**
Given a binary tree where node values are digits from 1 to 9. A path in the
binary tree is said to be pseudo-palindromic if at least one permutation of the
node values in the path is a palindrome.

 Return the number of pseudo-palindromic paths going from the root node to leaf
nodes.


 Example 1:




Input: root = [2,3,1,3,1,null,1]
Output: 2
Explanation: The figure above represents the given binary tree. There are three
paths going from the root node to leaf nodes: the red path [2,3,3], the green
path [2,1,1], and the path [2,3,1]. Among these paths only red path and green
path are pseudo-palindromic paths since the red path [2,3,3] can be rearranged in [3
,2,3] (palindrome) and the green path [2,1,1] can be rearranged in [1,2,1] (
palindrome).


 Example 2:




Input: root = [2,1,1,1,3,null,null,null,null,null,1]
Output: 1
Explanation: The figure above represents the given binary tree. There are three
paths going from the root node to leaf nodes: the green path [2,1,1], the path [
2,1,3,1], and the path [2,1]. Among these paths only the green path is pseudo-
palindromic since [2,1,1] can be rearranged in [1,2,1] (palindrome).


 Example 3:


Input: root = [9]
Output: 1



 Constraints:


 The number of nodes in the tree is in the range [1, 10⁵].
 1 <= Node.val <= 9


 Related Topics Bit Manipulation Tree Depth-First Search Breadth-First Search
Binary Tree 👍 3089 👎 115

*/

using System.Collections.Generic;
using System.Linq;
using leetcode.CommonClasses;
using Xunit;

namespace PseudoPalindromicPathsInABinaryTree
{
    public class Tests
    {
        [Fact]
        public void PseudoPalindromicPathsInABinaryTreeTest()
        {
            var tree = new TreeNode(2)
            {
                left = new TreeNode(3) { left = new TreeNode(3), right = new TreeNode(1) },
                right = new TreeNode(1) { right = new TreeNode(1) }
            };
            Assert.Equal(2, new Solution().PseudoPalindromicPaths(tree));
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
        private int _count = 0;


        private void Traverse(TreeNode root, HashSet<int> path)
        {
            if (root == null)
            {
                return;
            }

            if (path.Contains(root.val))
            {
                path.Remove(root.val);
            }
            else
            {
                path.Add(root.val);
            }

            if (root.left == null && root.right == null)
            {
                if (path.Count() <= 1)
                {
                    _count++;
                }
            }

            Traverse(root.left, new HashSet<int>(path));
            Traverse(root.right, new HashSet<int>(path));
        }

        public int PseudoPalindromicPaths(TreeNode root)
        {
            Traverse(root, new HashSet<int>());
            return _count;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}