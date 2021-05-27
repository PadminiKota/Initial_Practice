using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_1
{
    class Program
    {


        static void Main(string[] args)
        {
        }
        public class Solution
        {
            public int SumOfLeftLeaves(TreeNode root)
            {
                int output = 0;
                if (root == null)
                    return 0;
                if (root.left == null && root.right == null)
                {
                    return 0;
                }
                else
                {

                    output = DFS_PreOrder(root);

                }
                return output;

            }

            private int DFS_PreOrder(TreeNode root)
            {

                Queue<TreeNode> Q = new Queue<TreeNode>();
                Q.Enqueue(root);
                int running_sum = 0;
                while (Q.Count != 0)
                {
                    int cnt = Q.Count;
                    for (int i = 1; i <= cnt; i++)
                    {
                        TreeNode temp = Q.Dequeue();


                        if (temp.left != null && temp.right != null)
                        {
                            running_sum += temp.left.val;
                            Q.Enqueue(temp.left);
                            Q.Enqueue(temp.right);
                        }
                        else if (temp.left == null && temp.right != null)
                        {

                            Q.Enqueue(temp.right);
                        }
                        else if (temp.left != null && temp.right == null)
                        {
                            running_sum += temp.left.val;
                            Q.Enqueue(temp.left);
                        }

                    }



                }
                return running_sum;
            }
        }


    }

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

    }


}
    