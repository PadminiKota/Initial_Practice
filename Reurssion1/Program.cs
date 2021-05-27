using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reurssion1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            S.LetterCasePermutation("a1b2");
        }
        public class Solution
        {
            public IList<string> LetterCasePermutation(string S)
            {
                var sol = new List<string>();
                StringBuilder partial_sol = new StringBuilder();
                Helper(S, 0,partial_sol, sol);
                return sol;
            }
            private void Helper(string S, int i,StringBuilder partial_sol, List<string> sol)
            {
                
                if(i==S.Length)
                {
                    sol.Add(partial_sol.ToString());
                }
                else
                {
                 
                    if(Char.IsDigit(S[i]))
                    {
                        partial_sol.Append(S[i]);
                        Helper(S, i + 1, partial_sol, sol);
                        partial_sol.Remove(partial_sol.Length-1, 1);

                    }
                    else
                    {
                        partial_sol.Append(char.ToUpper(S[i]));
                        Helper(S, i + 1, partial_sol, sol);
                        partial_sol.Remove(partial_sol.Length-1, 1);

                        partial_sol.Append(char.ToLower(S[i]));
                        Helper(S, i + 1, partial_sol, sol);
                        partial_sol.Remove(partial_sol.Length-1, 1);

                    }

                }


            }
        }
    }
}
