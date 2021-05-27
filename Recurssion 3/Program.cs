using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[] { 1, 2, 2 };
            S.SubsetsWithDup(input);
        }

        public class Solution
        {
            public IList<IList<int>> SubsetsWithDup(int[] nums)
            {
                int i = 0;
                IList<IList<int>> sol = new List<IList<int>>();
                List<int> partial_sol = new List<int>();
                // Array.Sort(nums);
                Helper(nums, i, partial_sol, sol);
                return sol;
            }
            private void Helper(int[] nums, int i, List<int> partial_sol, IList<IList<int>> sol)
            {

                if (i == nums.Length)
                {

                    sol.Add(new List<int>(partial_sol));
                    sol.Reverse();
                    return;

                }
                else
                {

                    int count = 1;
                    int j = i + 1;
                    while (j <= nums.Length - 1)
                    {
                        if (nums[i] == nums[j])
                            count++;
                        j++;
                    }
                    /***Exclude****/

                    Helper(nums, i + count, partial_sol, sol);
                    /***Include*****/
                    for (int k = 1; k < count + 1; k++)
                    {
                        partial_sol.Add(nums[i]);
                        Helper(nums, i + count, partial_sol, sol);

                    }

                    for (int k = 1; k < count + 1; k++)
                    {
                        partial_sol.RemoveAt(partial_sol.Count - 1);

                    }
                

                }
            }
        }
    }
}

