using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Subsets
{
    class Program
    {
        static void Main(string[] args)
        {

            string s = "";
            generate_all_subsets(s);

        }

        /*
         * Complete the function below.
         */
        static string[] generate_all_subsets(string s)
        {
            var output = new List<string>();
            if(string.IsNullOrEmpty(s))
            {
                return output.ToArray();
            }
            int i = 0;
            List<string> partial_sol = new List<string>();
            Helper(s, i, partial_sol, output);

            return output.ToArray(); 


        }
        private static void Helper(string s, int i, List<string> partial_sol, List<string> output)
        {
            if (i == s.Length)
            {
                output.Add(string.Join("", partial_sol.ToArray()));
                return;
               
            }
            else
            {
                Helper(s, i+1, partial_sol, output);
                partial_sol.Add(s[i].ToString());
                Helper(s, i + 1, partial_sol, output);
                partial_sol.RemoveAt(partial_sol.Count - 1);
            }
        }


    }
}
