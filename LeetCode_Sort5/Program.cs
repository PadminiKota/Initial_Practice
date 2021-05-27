using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCode_Sort5
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            int[] arr = new int[4];
          
            arr[1] = 3;
            arr[2] = 2;
            arr[3] = 4;
        
        
            s.TwoSum(arr,6);
        }

        public class Solution
        {
            public int[] TwoSum(int[] numbers, int target)
            {
                int startpointer = 1, endpointer = numbers.Length-1;
                int[] output = new int[2];
                while (startpointer < endpointer)
                {
                    int targetsum = 0;
                    targetsum = Sum(numbers[startpointer], numbers[endpointer]);
                    if (targetsum > target)
                    {
                        endpointer--;
                    }
                    if (targetsum < target)
                    {
                        startpointer++;
                    }
                    if (targetsum == target)
                    {
                        output[0] = startpointer;
                        output[1] = endpointer;
                        break;
                    }
                }
                return output;

            }
            private static int Sum(int x, int y)
            {
                return (x + y);
            }
        }
    }
}
