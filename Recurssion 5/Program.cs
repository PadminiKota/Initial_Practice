using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recurssion_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[] { 1, 1, 2 };
            S.PermuteUnique(input);
        }

        public class Solution
        {
            public IList<IList<int>> PermuteUnique(int[] nums)
            {
                int i = 0;
                
                    
                    sol = new List<IList<int>>();
                sol.Reverse();
                List<int> partial_sol = new List<int>();
                Helper(nums, i, partial_sol, sol);
                return sol;

            }
            private void Helper(int[] nums, int i, List<int> partial_sol, IList<IList<int>> sol)
            {
               
                if (i == nums.Length)
                {                  
                        sol.Add(new List<int>(partial_sol));
                                       return;
                }
                else
                {
                    HashSet<int> visited = new HashSet<int>();
                    for (int j = i; j < nums.Length; j++)
                    {
                        if (visited.Contains(nums[j]))
                            continue;
                            
                            Swap(nums, j, i);
                            partial_sol.Add(nums[i]);
                            Helper(nums, i + 1, partial_sol, sol);
                            partial_sol.RemoveAt(partial_sol.Count - 1);
                            Swap(nums, j, i);
                            visited.Add(nums[j]);
                 
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
