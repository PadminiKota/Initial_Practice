using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_6
{
    public class Class1
    {
    }

    public class Solution
    {
        public IList<string> LetterCombinations(string digits)
        {
            int i = 0;
            Dictionary<int, string> Mapping = new Dictionary<int, string> { 
            {2,"a,b,c" },
            {3,"d,e,f"},
            {4,"g,h,i" },
            {5,"j,k,l" },
            {6,"m,n,o" },
            {7,"p,q,r,s" },
            {8,"t,u,v" },
            {9,"w,x,y,z" },
            };

            List<string> part_sol = new List<string>();
            List<string> sol = new List<string>();
            Helper(digits,Mapping,i,part_sol,sol);
            return sol;
        }

        private void Helper(string digits,Dictionary<int,string> Mapping,int i, List<string> partial_sol, List<string> sol)
        {
            if(i>digits.Length)
            {
                sol.Add(partial_sol.ToString());
            }
            else
            {
               
               foreach(var item in Mapping)
                {
                    string value = item.Value;
                }
            }

        }
    }
}
