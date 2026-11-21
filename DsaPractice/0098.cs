using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0098
    {
        public class TreeNode 
        {
            public int val;
            public TreeNode left;
            public TreeNode right;

            public TreeNode(int val=0, TreeNode left=null, TreeNode right=null) 
            {
                this.val = val;
                this.left = left;
                this.right = right;
            }
        }
        
        public class Solution
        {
            public bool IsValidBST(TreeNode root)
            {
                return IsValidBSTLimits(root, int.MinValue, int.MaxValue);
            }

            public bool IsValidBSTLimits(TreeNode root, int min, int max)
            {
                if (root is null)
                {
                    return true;
                }

                var isValidLeftBST = root.val > min && root.val < max && IsValidBSTLimits(root.left, min, root.val);
                var isValidRightBST = root.val > min && root.val < max && IsValidBSTLimits(root.right, root.val, max);

                return isValidLeftBST && isValidRightBST;
            }
        }

    }
}
