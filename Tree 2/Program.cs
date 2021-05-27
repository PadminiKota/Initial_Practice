using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_2
{
    public class TreeNode
    {
        public int val;
        public TreeNode left;
        public TreeNode right;
        public TreeNode(int val = 0, TreeNode left = null, TreeNode right = null)
        {
            this.val = val;
            this.left = left;
            this.right = right;
        }
    }
    class Program
    {
        
            static void Main(string[] args)
        {
            var node1 = new TreeNode(1);
            var node2 = new TreeNode(2);
            var node3 = new TreeNode(3);
            var node4 = new TreeNode(4);
            var node5 = new TreeNode(5);
            var node6 = new TreeNode(6);
            var node7 = new TreeNode(7);

            node1.left = node2;
            node1.right = node3;
            node2.left = node4;
            node2.right = node5;
            node3.left = node6;
            node3.right = node7;

            var root = ConstructFromPrePost(
                //new int[] { 1, 2, 4, 5, 3, 6, 7 },
                //new int[] { 4, 5, 2, 6, 7, 3, 1 });

            new int[] { 1, 2},
                new int[] {2,1});

        }
        public static int preIndex = 0;
        public static int postIndex = 0;
        public static TreeNode ConstructFromPrePost(int[] pre, int[] post)
        {
            preIndex = 0;
            postIndex = 0;
            return runPreorder(pre, post);
        }

        private static TreeNode PrePostDFS_Helper(int[] pre, int[] post, int preindex, int postindex)
        {
            var prelength = pre.Length;
            var postlength = post.Length;
            if (pre == null || post == null || preindex > prelength || postindex > postlength)
                return null;
            var rootval = pre[preindex];
            TreeNode root = new TreeNode(pre[preindex]);
            preindex++;

            if (rootval != post[postindex])
            {
                root.left = PrePostDFS_Helper(pre, post, preindex, postindex);
                root.right = PrePostDFS_Helper(pre, post, preindex, postindex);
            }
            postindex++;
            return root;


        }
        private static TreeNode runPreorder(int[] pre, int[] post)
        {
            var preLength = pre.Length;
            var postLength = post.Length;

            if (pre == null || post == null || preIndex >= preLength || postIndex >= postLength)
                return null;

            var rootVal = pre[preIndex];

            var root = new TreeNode(pre[preIndex]);
            preIndex++;

            if (rootVal != post[postIndex])
            {
                root.left = runPreorder(pre, post);
                root.right = runPreorder(pre, post);
            }

            postIndex++;

            return root;
        }
    }
}
