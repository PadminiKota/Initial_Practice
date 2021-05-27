using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kth_Largest
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[] { 2, 1 };
            S.FindKthLargest(input,1);
        }
        public class Solution
        {
            public int FindKthLargest(int[] nums, int k)
            {
                if (nums.Length == 1)
                {
                    if (k == 1)
                        return 1;
                }
                //if (nums.Length == 2)
                //{
                //    if (k == 1)
                //    {
                //        if (nums[0] > nums[1])
                //            return nums[0];
                //        else
                //            return nums[1];
                //    }
                //    if (k == 2)
                //    {
                //        if (nums[0] > nums[1])
                //            return nums[1];
                //        else
                //            return nums[0];
                //    }

                //}
                int output = 0;
                QuickSelect(nums, k, 0, nums.Length - 1, output);

                return nums[nums.Length - k];
            }
            private void QuickSelect(int[] nums, int k, int start, int end, int output)
            {
                if (start < end)
                {
                    int i = partition(nums, start, end);
                    if (nums.Length - k > i)
                    {
                        QuickSelect(nums, k, i + 1, end, output);
                    }
                    else if (nums.Length - k < i)
                    {
                        QuickSelect(nums, k, start, i - 1, output);
                    }
                    else if (i == nums.Length - k)
                    {
                        output = nums[i];
                    }

                }
            }
            private int partition(int[] nums, int start, int end)
            {
                int pivot = nums[start];
                int i = start, j = end;
                while (i < j)
                {
                    while (nums[i] <= pivot && i < nums.Length - 1)
                    {
                        
                        i++;
                    }
                    while (nums[j] > pivot && j >= 0)
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
