using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort1
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[5];
            input[0] =3;
            input[1] =1;
            input[2] =4;
            input[3] =2;
            input[4] =0;

            S.RestoreString("aiohn", input);
        }
    }

    public class Solution
    {
        public string RestoreString(string s, int[] indices)
        {
            StringBuilder sb = new StringBuilder(s);
           
            int j = 1;
            for(int i=1;i<indices.Length;i++)
            {
                int temp = indices[i];
                char tempchar = s[i];
                while(j>0)
                {
                    if(indices[j]<indices[j-1])
                    {
                        indices[j] = indices[j - 1];
                        sb[j] = sb[j - 1];
                        indices[j - 1] = temp;
                        sb[j - 1] = tempchar;
                    }
                    j = j - 1;
                }
                j = i + 1;

            }

            return sb.ToString();
        }
    }
}
