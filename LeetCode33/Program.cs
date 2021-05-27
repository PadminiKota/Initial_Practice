using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode33
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1,3};
            Solution S = new Solution();
            S.Search(input, 3);
        }
        public class Solution
        {
            public int Search(int[] nums, int target)
            {
                if (nums[0] == target)
                    return 0;
                int L = 0, H = nums.Length - 1;
                int output = -1;
                while (L <= H)
                {
                    double temp = (L + H) / 2;
                    int M = (int)Math.Floor(temp);
                    if (nums[M] == target)
                    {
                        output = M;
                        break;
                    }
                    else if (nums[M] >= nums[L])
                    {
                        if (nums[M] > target && target < nums[L])
                        {
                            L = M + 1;
                        }
                        else
                        {
                            H = M - 1;
                        }

                    }
                    else
                    {
                        if (nums[M] > target && target < nums[L])
                        {
                            H = M - 1;
                        }
                        else
                        {

                            L = M + 1;
                        }
                    }
                }
                return output;

            }

        }


    }
}
