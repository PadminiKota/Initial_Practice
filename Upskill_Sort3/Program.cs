using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Upskill_Sort3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[7];
            arr[0] =6;
            arr[1] =0;
            arr[2] =0;
            arr[3] =0;
            arr[4] =0;
           arr[5] =0;
            arr[6] = 0;
            findZeroSum_mine(arr);

           
        }
        //static string[] findZeroSum(int[] arr)
        //{
        //    // Write your code here.

        //    var result = new List<string>();
        //     if (arr.Length < 3)
        //    {
        //        return result.ToArray(); ;
        //    }
        //    if (arr.Length == 3)
        //    {
        //        if (Sum(arr[0], arr[1], arr[2]) == 0)
        //        {
        //            result.Add('"'+string.Join(",", arr)+'"');
        //            return result.ToArray();
        //        }
        //    }
        //    //int negpointer=0, pospointer = arr.Length-1;
        //    //while(negpointer<pospointer)
        //    //{
        //    //    while(arr[negpointer]<0 && negpointer<pospointer)
        //    //    {
        //    //        negpointer++;
        //    //    }
        //    //    while(arr[pospointer]>=0 && pospointer>negpointer)
        //    //    {
        //    //        pospointer--;
        //    //    }
        //    //    if(arr[negpointer]>=0 && arr[pospointer]<0)
        //    //    {
        //    //        Swap(ref arr[negpointer], ref arr[pospointer]);
        //    //        negpointer++;
        //    //        pospointer--;
        //    //    }
        //    //}
        //    int refnum = 0; int j = 0
        //    Array.Sort(arr);
        //   for(int i=0;i<arr.Length-1;i++)
        //    {
        //        refnum = arr[i];
        //        if(arr[i] != arr[i+1])
        //        {
        //            j = i + 1;
        //        }
        //        else
        //        {
        //            j = i + 2;
        //        }
        //         int refnum2 = arr[j];
        //        j++;
        //        while(j<=arr.Length-1)
        //        {
        //            if(Sum(refnum,refnum2,arr[j])==0)
        //            {
        //                result.Add('"' + refnum.ToString() + ',' + refnum2.ToString() + ',' + arr[j] + '"');

        //            }
        //            j++;
        //        }
        //    }



        //    return result.ToArray();
        //}

        static string[] findZeroSum_mine(int[] arr)
        {
            // Write your code here.

            var result = new List<string>();
            if (arr.Length < 3)
            {
                return result.ToArray(); ;
            }
            if (arr.Length == 3)
            {
                if (Sum(arr[0], arr[1], arr[2]) == 0)
                {
                    result.Add(string.Join(",", arr));
                    return result.ToArray();
                }
            }
            Array.Sort(arr);
           for(int i=0;i<arr.Length-1;i++)
            {
                int start = i + 1;
                int end = arr.Length - 1;
                if (i > 0 && arr[i] == arr[i - 1]) continue;
                while(start<end)
                {
                    if(start>i+1 && arr[start]==arr[start-1])
                    {
                        start++;
                        continue;
                    }
                    if(end>arr.Length-1 && arr[end] == arr[end+1])
                    {
                        end--;
                        continue;
                    }
                    int pivot = Sum(arr[i], arr[start], arr[end]);
                    if (pivot==0)
                    {
                        result.Add(arr[i].ToString() + ',' + arr[start].ToString() + ',' + arr[end].ToString());
                        end--;
                        start++;
                    }
                    if(pivot<0)
                    {
                        start++;
                    }
                    if(pivot>0)
                    {
                        end--;
                    }
                }

            }

            return result.ToArray();
        }

        private static int Sum(int x, int y, int z)
        {
            return (x + y + z);
        }
      
        private static void Swap(ref int x, ref int y)
        {
            int temp = 0;
            temp = x;
            x = y;
            y = temp;
        }

        static string[] findZeroSum(int[] arr)
        {
            // Write your code here.

            // Final list with string results of triplet pairs
            List<string> resultList = new List<string>();

            // If array size is less than 3 then return false since there is no scope to check sum
            if (arr == null || arr.Length < 3)
                return resultList.ToArray();

            int arraySize = arr.Length;

            // Sort the array
            Array.Sort(arr);

            // Iterate through each integer
            for (int i = 0; i < arraySize; i++)
            {
                // Skip if the next number is the same as before
                if (i > 0 && arr[i] == arr[i - 1])
                    continue;

                // Run 2 pointers from opposite on the same array
                for (int start = i + 1, end = arraySize - 1; start < end;)
                {
                    // skip any duplicate of the start value
                    if (start > i + 1 && arr[start] == arr[start - 1])
                    {
                        start++;
                        continue;
                    }

                    // skip any duplicate of the end value
                    if (end < arraySize - 1 && arr[end] == arr[end + 1])
                    {
                        end--;
                        continue;
                    }

                    // Sum of any 3 numbers
                    int sum = arr[i] + arr[start] + arr[end];

                    // if 3 sum is zero then add to the results
                    if (sum == 0)
                    {
                        resultList.Add(arr[i].ToString() + "," + arr[start].ToString() + "," + arr[end].ToString());

                        // increment start pointer
                        start++;

                        // decrement end pointer
                        end--;
                    }
                    else if (sum < 0) // if 3 sum is lesser than 0 increase start pointer
                    {
                        start++;
                    }
                    else // if 3 sum is greater than 0 decrease end pointer
                    {
                        end--;
                    }
                }
            }

            return resultList.ToArray();

        }



    }
}
