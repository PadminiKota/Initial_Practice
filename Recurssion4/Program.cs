using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion4
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[]{10,-3,7,1,2,3};
            S.Permute(input);
        }

        public class Solution
        {
            public IList<IList<int>> Permute(int[] nums)
            {
                int i = 0;
                return
                    new List<IList<int>>() { new List<int> (1) };
                IList<IList<int>> sol = new List<IList<int>>();
                List<int> partial_sol = new List<int>();
                Helper(nums,i,partial_sol,sol);
                return sol;

            }
            private void Helper(int[] nums, int i, List<int> partial_sol,IList<IList<int>> sol)
            {
                if(i==nums.Length)
                {
                    sol.Add(new List<int>(partial_sol));
                    return;
                }
                else
                {
                    for(int j=i;j<nums.Length;j++)
                    {
                        Swap(nums,j,i);
                        partial_sol.Add(nums[i]);
                        Helper(nums, i + 1, partial_sol, sol);
                        partial_sol.RemoveAt(partial_sol.Count-1);
                        Swap(nums, j, i);
                    }
                }
            }

            private static void Swap(int[] nums, int x, int y)
            {
                if (x == y)
                    return;
                int temp = nums[x];
                nums[x] = nums[y];
                nums[y] = temp;

            }
        }
    }
}
