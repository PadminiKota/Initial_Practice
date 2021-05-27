using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Uplevel
{
    class Program
    {
        static void Main(string[] args)
        {
            string s1 = "Sitting";
            string s2 = "Kitten";
            int colcount=0,rowcount = 1;

            int[][] output = new int[s1.Length+1][];
            for(int i=0;i<output.Length;i++)
            {
                 output[i] = new int[s2.Length+1];
                if (i != 0)
                {
                    output[i][0] = rowcount;
                    rowcount++;
                }
                for(int j=0;j<output[i].Length && i==0; j++)
                {
                        output[i][j] = colcount;
                        colcount++;
                  
                }
            }
            for(int i=1;i<=s1.Length;i++)
            {
                for(int j=1;j<=s2.Length;j++)
                {
                    if(!string.IsNullOrEmpty(s1[i-1].ToString()) && !string.IsNullOrEmpty(s2[j-1].ToString()))
                    {
                        if (s1[i-1] != s2[j-1])
                            output[i][j] = Math.Min(output[i][j - 1], Math.Min(output[i - 1][j - 1], output[i - 1][j])) + 1;
                        else
                            output[i][j] = output[i - 1][j - 1];

                    }
                    
                    else
                        output[i][j] = output[i - 1][j - 1];
                }
            }
            int val = output[s1.Length][s2.Length];
        }
    }
}
