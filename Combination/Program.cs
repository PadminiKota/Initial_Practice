using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Combination
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input=new int[]{10,1,2,7,6,1,5};
            Solution S = new Solution();
            S.CombinationSum2(input,8);
        }

        public class Solution
        {
            public IList<IList<int>> CombinationSum2(int[] candidates, int target)
            {
                if (candidates.Length == 0)
                    return new List<IList<int>>() { new List<int> { } };
                if (candidates.Length == 1)
                {
                    if (candidates[0] == target)
                        return new List<IList<int>>() { new List<int> { target } };
                    else
                        return new List<IList<int>>() { };

                }
                IList<IList<int>> sol = new List<IList<int>>();
                candidates = candidates.OrderBy(x => x).ToArray();
                Helper(candidates, target, 0, new List<int>(), sol);
                return sol;

            }


            private void Helper(int[] candidates, int target, int i, List<int> partial_sol, IList<IList<int>> sol)
            {
                // partial_sol=partial_sol.OrderBy(x=>x).ToList();
                if (partial_sol.Sum() == target)
                {

                    // if(!sol.Any(x=>x.SequenceEqual(partial_sol)))
                    sol.Add(new List<int>(partial_sol));
                    return;

                }
                if (i == candidates.Length || partial_sol.Sum() > target)
                    return;
                else
                {
                    for (int j = i; j < candidates.Length; j++)
                    {
                        if (i != 0 && candidates[i - 1] == candidates[i])
                            continue;
                        partial_sol.Add(candidates[i]);
                        Helper(candidates, target, i + 1, partial_sol, sol);
                        partial_sol.RemoveAt(partial_sol.Count - 1);
                    }
                    //  Helper(candidates,target,i+1,partial_sol,sol);

                }


            }
        }
    }
}
