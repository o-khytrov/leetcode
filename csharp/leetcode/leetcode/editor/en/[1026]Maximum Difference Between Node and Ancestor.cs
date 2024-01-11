/**
Given the root of a binary tree, find the maximum value v for which there exist
different nodes a and b where v = |a.val - b.val| and a is an ancestor of b.

 A node a is an ancestor of b if either: any child of a is equal to b or any
child of a is an ancestor of b.


 Example 1:


Input: root = [8,3,10,1,6,null,14,null,null,4,7,13]
Output: 7
Explanation: We have various ancestor-node differences, some of which are given
below :
|8 - 3| = 5
|3 - 7| = 4
|8 - 1| = 7
|10 - 13| = 3
Among all possible differences, the maximum value of 7 is obtained by |8 - 1| =
7.

 Example 2:


Input: root = [1,null,2,null,0,3]
Output: 3



 Constraints:


 The number of nodes in the tree is in the range [2, 5000].
 0 <= Node.val <= 10⁵


 Related Topics Tree Depth-First Search Binary Tree 👍 4466 👎 123

*/

using System;
using leetcode.CommonClasses;
using Xunit;

namespace MaximumDifferenceBetweenNodeAndAncestor
{
    public class Tests
    {
        [Fact]
        public void MaximumDifferenceBetweenNodeAndAncestorTest()
        {
            var tree = new TreeNode(8)
            {
                left = new TreeNode(3)
                {
                    left = new TreeNode(1),
                    right = new TreeNode(6)
                    {
                        left = new TreeNode(4),
                        right = new TreeNode(7)
                    }
                },
                right = new TreeNode(10) { right = new TreeNode(14) { left = new TreeNode(13) } }
            };
            Assert.Equal(7, new Solution().MaxAncestorDiff(tree));
        }

        [Fact]
        public void MaximumDifferenceBetweenNodeAndAncestorTest2()
        {
            var tree = new TreeNode(1)
            {
                right = new TreeNode(2)
                {
                    right = new TreeNode(0) { left = new TreeNode(3) }
                }
            };
            Assert.Equal(3, new Solution().MaxAncestorDiff(tree));
        }

        [Fact]
        public void MaximumDifferenceBetweenNodeAndAncestorTest3()
        {
            var tree = new TreeNode(2)
            {
                right = new TreeNode(0)
                {
                    right = new TreeNode(0) { left = new TreeNode(1) }
                }
            };
            Assert.Equal(2, new Solution().MaxAncestorDiff(tree));
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
        private int _res = int.MinValue;

        private (int, int) Traverse(TreeNode root)
        {
            if (root.left is null && root.right is null)
            {
                return (root.val, root.val);
            }

            var maxDiff = root.val;
            var minDiff = root.val;
            if (root.left is not null)
            {
                var t = Traverse(root.left);
                maxDiff = Math.Max(maxDiff, t.Item1);
                minDiff = Math.Min(minDiff, t.Item2);
            }

            if (root.right is not null)
            {
                var t = Traverse(root.right);
                maxDiff = Math.Max(maxDiff, t.Item1);
                minDiff = Math.Min(minDiff, t.Item2);
            }

            _res = Math.Max(_res, Math.Abs(maxDiff - root.val));
            _res = Math.Max(_res, Math.Abs(root.val - minDiff));
            return (maxDiff, minDiff);
        }

        public int MaxAncestorDiff(TreeNode root)
        {
            Traverse(root);
            return _res;
        }
    }
//leetcode submit region end(Prohibit modification and deletion)
}