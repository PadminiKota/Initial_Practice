using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AmazonOA
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            S.Labelcreation("baccc",2);
        }
        public class Solution
        {
            public string Labelcreation(string s,int charlimit)
            {
                char[] output = new char[s.Length];
                char[] sorted_array = Sort_string(s);
                int i = 0, j = s.Length-1, limit = 0, k = 0;
                while (i <= j)
                {
                    if(limit!=charlimit)
                    {
                        output[k] = sorted_array[i];
                        k++;
                        i++;
                        if(i!=0)
                        {
                            if (sorted_array[i - 1] == sorted_array[i])
                                limit++;
                        }
               
                    }
                    else
                    {
                        if(sorted_array[i]!=sorted_array[j])
                        {
                            output[k] = sorted_array[j];
                            limit = 0;
                        }
                          
                        k++;
                        j--;
                     }

                }
                return output.ToString();

            }

            private char[] Sort_string( string input)
            {
                char[] sorted_array = new char[input.Length];
                sorted_array = input.ToCharArray().OrderByDescending(c => c).ToArray();
                return sorted_array;
            }
        }
    }
}
