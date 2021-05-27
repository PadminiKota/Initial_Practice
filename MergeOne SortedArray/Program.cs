using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MergeOne_SortedArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr1 = new int[] { 1, 3, 5 };
            int[] arr2 = new int[] { 2, 4, 6,0,0,0 };
            merger_first_into_second(arr1, arr2);
        }

        static void merger_first_into_second(int[] arr1, int[] arr2)
        {
            /*
             * Write your code here.
             */
            int i = arr1.Length - 1, j = arr1.Length - 1;
            int k = arr2.Length - 1;
            while (k >= 0)
            {
                if (arr1[i] < arr2[j])
                {
                    arr2[k] = arr2[j];
                    j--;
                    k--;
                }
                else if (arr1[i] > arr2[j])
                {
                    arr2[k] = arr1[i];
                    i--;
                    k--;
                }
            }

        }


    }
}
