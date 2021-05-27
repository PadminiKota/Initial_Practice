using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] target = new int[2];
            target[0] = 1;
            target[1] = 3;
            int n = 3;
            IList<string> output = s.BuildArray(target,n);
        }
        public class Solution
        {
            public IList<string> BuildArray(int[] target, int n)
            {
                Stack<int> ops = new Stack<int>();
                var result = new List<string>();
                var temp = new int[target.Length];
                int j = 0;
                for (int i = 1; i <= n; i++)
                {
                    
                        ops.Push(i);
                         result.Add("Push");
                        if (i == target[j])
                        {
                            temp[j] = i;
                            j++;
                        if (j == target.Length)
                            break;
                        }
                        else
                        {
                            ops.Pop();
                            result.Add("Pop");
                        }
                                                
                   
                }
                return result;
            }
        }
    }
}
