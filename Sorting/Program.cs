using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution s = new Solution();
            //int[] input = new int[11];
            //input[0] = 1024;
            //input[1] = 512;
            //input[2] = 256;
            //input[3] = 128;
            //input[4] = 64;
            //input[5] = 32;
            //input[6] = 16;
            //input[7] = 8;
            //input[8] = 4;
            //input[9] = 2;
            //input[10] = 1;

            /**Quicksort*****/

            //int[] input = new int[8];
            //input[0] = 4;
            //input[1] = 2;
            //input[2] = 8;
            //input[3] = 7;
            //input[4] = 1;
            //input[5] = 3;
            //input[6] = 5;
            //input[7] = 6;

            //s.SortBy_MergeSort(input);
            //List<int> temp = new List<int>();
            //temp[0] = 1;

            List<int> input2 = new List<int>();
            input2.Add(15);
            input2.Add(8);
            int[] array = new int[input2.Count];


            array=input2.ToArray();
            int index = array[1];
            array[1] = 56;
            List<int> output = array.ToList<int>();
           


        }

        public class Solution
        {
            public int[] SortBy_Selectionsort(int[] arr)
            {
                if (arr.Length <= 1)
                {
                    return arr;
                }
                else
                {
                    int min = 0;
                    int k = 0;
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        min = arr[i];
                        for (int j = i; j <= arr.Length - 1; j++)
                        {
                            if (arr[j] < min)
                            {
                                min = arr[j];
                                k = j;
                            }

                        }
                        if(k!=0)
                        Swap(ref arr[i], ref arr[k]);
                        k = 0;


                    }
                    return arr;
                }

            }
            public int[] SortBy_InsertionSort(int[] arr)
            {
                if (arr.Length <= 1)
                    return arr;
                else
                {
                    int j = 0;
                    for(int i=0;i<=arr.Length-1;i++)
                    {
                        j = i;
                        while (j>=0 && j!=arr.Length-1)
                        {
                            if(arr[j]>arr[j+1])
                            {
                                Swap(ref arr[j], ref arr[j+1]);
                            }
                            j--;
                        }
                    

                    }
                    return arr;
                }
            }
            public int[] SortBy_Quicksort(int[] arr)
            {
                if (arr.Length <= 1)
                    return arr;
                else
                {
                    int left = 0, right = arr.Length - 1;
                    QuickSort(arr, left, right);
                    

                }
                return arr;
            }
            private void QuickSort(int[] arr, int start, int end)
            {
                int i;
                if (start < end)
                {
                    i = partition(arr, start, end);

                    QuickSort(arr, start, i - 1);
                    QuickSort(arr, i + 1, end);
                }
            }

            
            private static int partition(int[] input, int left, int right)
            {
                /****i starts and searches for number greater than pivot and j searched for number less than pivot***/
                int pivot = input[left];
                int i = left, j = right;
                while(i<j)
                {
                   
                    while (i <= input.Length - 1 && input[i] <= pivot)
                    {
                        i++;
                    }
                    
                    while (input[j] > pivot && j >= 0)
                    {
                        j--;
                    }
                    if(i<j)
                    {
                        Swap(ref input[i], ref input[j]);
                    }
                }
                Swap(ref input[left], ref input[j]);
                return j;
               
            }

            public int[] SortBy_InsertionSort_Rev(int[] arr)
            {
                if (arr.Length <= 1)
                    return arr;
                else
                {
                    int j = 0;
                    for (int i = 0; i <= arr.Length - 1; i++)
                    {
                        j = i;
                        while (j >= 0 && j != arr.Length - 1)
                        {
                            if (arr[j] < arr[j + 1])
                            {
                                Swap(ref arr[j], ref arr[j + 1]);
                            }
                            j--;
                        }


                    }
                    return arr;
                }
            }

            public int[] SortBy_MergeSort(int[] arr)
            {

                MergeDivide(arr,0,arr.Length-1);
                  return arr;
            }
            private void MergeDivide(int[] input, int left, int right)
            {
                   int middle;
                   if(left<right)
                {
                    middle = (left + right) / 2;
                    MergeDivide(input, left, middle);
                    MergeDivide(input, middle + 1, right);
                    Merge(input,left,middle,right);

                }

            }
            private void Merge(int[] array, int left, int middle, int right)
            {
                int no_L1, no_R1;
                no_L1 = middle - left + 1;
                no_R1 = right - middle;
                int[] L1 = new int[no_L1];
                int[] R1 = new int[no_R1];
             
                int i, j,k;
                for(i=0;i<no_L1;i++)
                {
                    L1[i] = array[left + i];
                }
                for(j=0;j<no_R1;j++)
                {
                    R1[j] = array[middle + 1 + j];
                }
                i = 0;j = 0;k = left;
                while(i<no_L1 && j<no_R1)
                {
                    if(L1[i]<R1[j])
                    {
                        array[k] = L1[i];
                         i++;
                    }
                    else
                    {
                        array[k] = R1[j];
                        j++;
                    }
                    k++;
                }
                while(i<no_L1)
                {
                    array[k] = L1[i];
                    k++;
                    i++;
                }
                while (j < no_R1)
                {
                    array[k] = R1[j];
                    k++;
                    j++;
                }

            


            }



            private static void Swap(ref int x, ref int y)
             {

                int temp = 0;
                temp = x;
                x = y;
                y = temp;
             }

        }
    }
}
