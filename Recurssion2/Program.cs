using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[] { 1, 2, 3 };
            input.OrderBy(x => x);
            input[]
            S.Subsets(input);
            return new List<IList<int>>(new List<int> { });
        }

        public class Solution
        {
            public IList<IList<int>> Subsets(int[] nums)
            {
                int i = 0;
                IList<IList<int>> sol = new List<IList<int>>();
             
                List<int> partial_sol = new List<int>();
                Helper(nums, i, partial_sol, sol);
                return sol;
                partial_sol.Sum()
            }
            private void Helper(int[] nums, int i, List<int> partial_sol, IList<IList<int>> sol)
            {
                if (i == nums.Length)
                {
                   
                    sol.Add(new List<int>(partial_sol).OrderByDescending(x=>x).ToList());
                    sol.Contains(partial_sol);
                    return;
                }
                else
                {
                    /**
                    Exculde****/
                    Helper(nums, i + 1, partial_sol, sol);

                    /**
                   Include****/
                    partial_sol.Add(nums[i]);
                    Helper(nums, i + 1, partial_sol, sol);
                    partial_sol.RemoveAt(partial_sol.Count - 1);

                }

            }
        }
    }
}
