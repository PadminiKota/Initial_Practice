using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            String S="1,2,4";
            String s2 = "1,3,4";

            ListNode L1 = new ListNode();
            for (int i=0;i<S.Length;i++)
            {
                L1.InsertNode(S[i]);

            }
            //ListNode L2 = "[1,3,4]";
            //int tests = Convert.ToInt32(Console.ReadLine());

            

        }
     

        public class ListNode {
     public int val;
    public ListNode next;
     public ListNode(int val=0, ListNode next=null) {
         this.val = val;
         this.next = next;
     }
            public void InsertNode(int nodeData)
            {
                ListNode node = new ListNode(nodeData);
                node.val = nodeData;
                node.next = node;

            }
        }
 
    }
}
    
