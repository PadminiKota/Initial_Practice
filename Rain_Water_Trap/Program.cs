using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rain_Water_Trap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] height = new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 };
            Solution S = new Solution();
            S.Trap(height);
        }
        public class Solution
        {
            public int Trap(int[] height)
            {

                int[] right_max = new int[height.Length];
                //int j = 0;
                for (int i = height.Length - 1; i >= 0; i--)
                {
                    if (i == height.Length - 1)
                        right_max[i] = height[i];
                    else
                        right_max[i] = Math.Max(right_max[i+1], height[i]);
                   // j++;
                }
                int water_trap = 0;
                int left_max = 0;
                for (int k = 0; k < height.Length; k++)
                {
                    if (k == 0)
                        left_max = height[k];
                    else
                        left_max = Math.Max(left_max, height[k]);
                    water_trap += (Math.Min(left_max, right_max[k]) - height[k]);
                }
                return water_trap;
            }
        }
    }
}
