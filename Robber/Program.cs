using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robber
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[] { 1, 2, 3, 1 };
            S.Rob(input);

        }

        public class Solution
        {
            public int Rob(int[] nums)
            {
                int[] temp = new int[nums.Length + 1];
                for (int i = 0; i < temp.Length; i++)
                {
                    if (i == 1)
                        temp[i] = nums[i-1];
                    else
                        temp[i] = 0;
                }
                for (int j = 2; j < temp.Length; j++)
                {
                    temp[j] = Math.Max(temp[j - 1], (temp[j - 2] + nums[j - 1]));
                }
                return temp[temp.Length - 1];

            }
        }
    }
}
