using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upskill_Sorting2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>() { 4,2,8,7,1,3,5,6};
            merge_sort(input);
            //input[0] = 4;
            //input[1] = 2;
            //input[2] = 8;
            //input[3] = 7;
            //input[4] = 1;
            //input[5] = 3;
            //input[6] = 5;
            //input[7] = 6;
        }
        public static List<int> merge_sort(List<int> arr)
        {
            
            int[] input = arr.ToArray();
            int right = input.Length-1;

            int left = 0;
            Divide(input, left, right);

             return input.ToList<int>();


        }
        private static void Divide(int[] arr, int left, int right)
        {
            int middle;
            if (left < right)
            {
                middle = (left + right) / 2;
                Divide(arr, left, middle);
                Divide(arr, middle + 1, right);
                Merge(arr, left, middle, right);

            }
        }
        private static void Merge(int[] arr, int left, int middle, int right)
        {
            int i, j, k;
            int L1_no = middle - left + 1;
            int R1_no = right - middle;
            int[] L1 = new int[L1_no];
            int[] R1 = new int[R1_no];
            for (i = 0; i < L1_no; i++)
            {
                L1[i] = arr[left + i];
            }
            for (j = 0; j < R1_no; j++)
            {
                R1[j] = arr[middle + 1 + j];
            }
            i = 0; j = 0; k = left;
            while (i < L1_no && j < R1_no)
            {
                if (L1[i] < R1[j])
                {
                    arr[k] = L1[i];
                    i++;
                }
                else
                {
                    arr[k] = R1[j];
                    j++;
                }
                k++;

            }
            while (i < L1_no)
            {
                arr[k] = L1[i];
                k++;
                i++;

            }
            while (j < R1_no)
            {
                arr[k] = R1[j];
                k++;
                j++;
            }
        }
    }
}
    

