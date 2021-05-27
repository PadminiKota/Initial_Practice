using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_8
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            string digits = "23";
            S.LetterCombinations(digits);
        }
        public class Solution
        {
            public IList<string> LetterCombinations(string digits)
            {
                int i = 0;
                Dictionary<int, string> Mapping = new Dictionary<int, string> {
            {2,"abc" },
            {3,"def"},
            {4,"ghi" },
            {5,"jkl" },
            {6,"mno" },
            {7,"pqrs" },
            {8,"tuv" },
            {9,"wxyz" },
            };

                List<string> part_sol = new List<string>();
                List<string> sol = new List<string>();
                Helper(digits, Mapping, i, part_sol, sol);
                return sol;
            }

            private void Helper(string digits, Dictionary<int, string> Mapping, int i, List<string> partial_sol, List<string> sol)
            {
                if (i==digits.Length)
                {
                   
                    sol.Add(string.Join("", partial_sol.ToArray()));
                }
                else
                {
                    
                    foreach(char c in Mapping[Int32.Parse(digits[i].ToString())])
                    {
                        partial_sol.Add(c.ToString());
                        Helper(digits, Mapping, i + 1, partial_sol, sol);
                        partial_sol.RemoveAt(partial_sol.Count - 1);
                       // partial_sol.cou
                    }
                }

            }
        }
    }
}
