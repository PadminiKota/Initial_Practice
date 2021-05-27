using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexographical
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] { 4, 1, -1, 2, -1, 2, 3 };
            Solution S = new Solution();
            S.TopKFrequent(nums,2);
        }
        private
        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                var output = new Dictionary<int, int>();
                List<int> num = new List<int>();
                int i = 0, j = nums.Length - 1;
                int incre_cnt = 0;
                if (nums.Length == k)
                    return nums;

                /****Creating dictionary with frequency ***/
                while (i <= j)
                {
                    if (!output.ContainsKey(nums[i]))
                    {
                        output.Add(nums[i], 0);
                        num.Add(nums[i]);
                        i++;
                    }
                    else
                    {
                        incre_cnt = output[nums[i]];
                        incre_cnt++;
                        output[nums[i]] = incre_cnt;
                        i++;
                        incre_cnt = 0;
                    }
                    if (!output.ContainsKey(nums[j]))
                    {
                        output.Add(nums[j], 0);
                        num.Add(nums[j]);
                        j--;
                    }
                    else
                    {
                        if (i != j)
                        {
                            incre_cnt = output[nums[j]];
                            incre_cnt++;
                            output[nums[j]] = incre_cnt;
                            j--;
                            incre_cnt = 0;
                        }

                    }

                }
                int[] retval = num.ToArray();
                QuickSelect(retval, k, 0, retval.Length - 1, output);

                /*****
                var sort_output=output.OrderByDescending(x=>x.Value).ToDictionary(x=>x.Key,x=>x.Value);
                int[] op = sort_output.Keys.ToList().GetRange(0,k).ToArray();
                return op;
                *****/
                int[] s = new int[k];
                int l = 0;
                int m = retval.Length - 1;
                while(l<=k-1)
                {
                    s[l] = retval[m];
                    l++;
                    m--;
                }
               return s;


            }
            private void QuickSelect(int[] nums, int k, int start, int end, Dictionary<int, int> output)
            {
                if (start < end)
                {
                    int i = partition(nums, start, end, output);
                    
                    if (nums.Length - k > i && i!=0)
                    {
                        QuickSelect(nums, k, i + 1, end, output);
                    }
                    else if (nums.Length - k < i && i!=0)
                    {
                        QuickSelect(nums, k, start, i - 1, output);
                    }

                }
            }
            private int partition(int[] nums, int start, int end, Dictionary<int, int> output)
            {
                int pivot = nums[start];
                int i = start, j = end;
                while (i < j)
                {
                    while (output[nums[i]] <= output[pivot] && i < nums.Length - 1)
                    {
                        i++;
                    }
                    while (output[nums[j]] >= output[pivot] && j > 0)
                    {
                        j--;
                    }
                    if (i < j)
                    {
                        Swap(ref nums[i], ref nums[j]);
                    }

                }
                Swap(ref nums[start], ref nums[j]);
                return j;


            }
            private void Swap(ref int x, ref int y)
            {
                int temp = x;
                x = y;
                y = temp;
            }
        }
    }
}
