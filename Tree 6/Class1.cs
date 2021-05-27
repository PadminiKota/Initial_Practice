using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_6
{
    public class Class1
    {
        int[][] edges = new int[][]
           {
                new int[] {0,1},
                new int[] {0,2},
                new int[] {0,3},
                new int[] {1,4},
           };
        Solution S = new Solution();
        S.ValidTree(5, edges);
    }

    public class Solution
    {
        public bool IsBipartite(int[][] graph)
        {

        }
    }
}
