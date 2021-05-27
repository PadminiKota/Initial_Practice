using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_10
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> o = new List<string>();
            generate_all_expressions("222", 24);
        }
        public static string[] generate_all_expressions(string s, long target)
        {

            List<string> sol = new List<string>();
            Helper(s, 0, "", sol, target, 0, 0);
            return sol.ToArray();

        }
        private static void Helper(string s, int i, string partial_sol, List<string> sol, long target, long runningsum, long prev_val)
        {
            if (i == s.Length)
            {
                if(runningsum==target)
                sol.Add(partial_sol);
                return;
            }
            else
            {
                for (int j = i; j < s.Length; j++)
                {
                    int len = j - i + 1;
                    var val = s.Substring(i, j - i + 1);
                    long current_val = Convert.ToInt64(val);
                  

                    if (i == 0)
                    {
                        Helper(s, i + len, val, sol, target, current_val, current_val);
                    }
                    else
                    {
                        Helper(s, i + len, partial_sol + "+" + val, sol, target, runningsum + current_val, current_val);
                        Helper(s, i + len, partial_sol +"*"+val, sol, target, (runningsum-prev_val+(prev_val * current_val)), prev_val * current_val);
                      
                    }
                }
            }
        }
        public class Solution
        {
            





        }
    }
}
