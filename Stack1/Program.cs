using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stack1
{
    class Program
    {
        static void Main(string[] args)
        {
            String S = "(()())(())";
          
     
          
            Solution Sol = new Solution();
            Sol.RemoveOuterParentheses(S);
        }
        public class Solution
        {
            public string RemoveOuterParentheses(string S)
            {

                StringBuilder result = new StringBuilder();
                StringBuilder temp = new StringBuilder();
                Stack<char> stack = new Stack<char>();
                int startpos = 0;
                int finalpos = 0;

                for (int i = 0; i <= S.Length; i++)
                {                 
                     if (S[i] == ')')
                        stack.Pop();
                     if (S[i] == '(')
                        stack.Push('(');
                   if (stack.Count == 0)
                    {
                      
                            finalpos = i + 1;
                        temp = RemoveParentheses(S.Substring(startpos,finalpos));
                        result.Append(temp);
                        S = S.Remove(startpos, finalpos);
                        i = -1;
                        if (S == "") break;
                           
                        
                      
                        
                    }

                }

                return result.ToString();

            }
            private StringBuilder RemoveParentheses(String S)
            {
                StringBuilder output = new StringBuilder();
                for (int i = 1; i <= S.Length - 2; i++)
                {
                    output.Append(S[i]);
                }
                return output;
            }
        }
    }
}
