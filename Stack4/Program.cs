using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack4
{
    class Program
    {
        static void Main(string[] args)
        {
            String S = "abbaca";
            Solution sol = new Solution();
            sol.RemoveDuplicates(S);


        }

        public class Solution
        {
            public string RemoveDuplicates(string S)
            {
                Stack<char> stack = new Stack<char>();
                 for (int i =S.Length-1; i>=0; i--)
                {
                    if(stack.Count!=0)
                    {
                        if (stack.Peek() == S[i])
                        {
                            stack.Pop();
                        }
                        else
                        {
                            stack.Push(S[i]);
                        }
                    }
                    else
                    {
                        stack.Push(S[i]);
                    }
                     
                 }
               string output = new string (stack.ToArray());
                return output;
                }
        }
    }
}
