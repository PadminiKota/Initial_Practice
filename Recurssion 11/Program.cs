using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_11
{
    class Program
    {
        static void Main(string[] args)
        {

            generate_palindromic_decompositions("abracadabra");
        }

        static string[] generate_palindromic_decompositions(string s)
        {
            List<string> sol = new List<string>();
            Helper(s,0,new StringBuilder(),sol);
            return sol.ToArray();

         //  List<Int64> st = new List<Int64>();
          //  var array = new long[]();

        }
        private static void Helper( string s, int i,  System.Text.StringBuilder partial_sol,List<string> sol)
        {
            if(i==s.Length)
            {
              
                sol.Add(string.Join("|",partial_sol.ToString()));
                return;
            }
            else
            {
                for(int j=i;j<s.Length;j++)
                {
                    int len = j - i + 1;
                    string current = s.Substring(i, j-i+1);
                    if (IsPlaindrome(current))
                    {
                        partial_sol.Append(current+"|");
                        Helper(s, i + len, partial_sol, sol);
                        partial_sol.Remove(partial_sol.Length-(current.Length+1),current.Length+1);
                    }
                }
               
               
            }
        }
        private static bool IsPlaindrome(string s)
        {
            char[] ch = s.ToCharArray();
            Array.Reverse(ch);
            string rev = new string(ch);
            bool b = s.Equals(rev, StringComparison.OrdinalIgnoreCase);
            return b;
        }

        private static bool isPalindrome1(string input, int low, int high)
        {
            while (low < high)
            {
                if (input[low++] != input[high--])
                {
                    return false;
                }
            }

            return true;
        }




    }
}
