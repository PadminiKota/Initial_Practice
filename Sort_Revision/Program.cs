using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort_Revision
{
    class Program
    {
        static void Main(string[] args)
        {
        }


        /*
  * Complete the function below.
  */
        /*
 * Complete the function below.
 */
        static string[] findZeroSum(int[] arr)
        {

            // Write your code here.
            List<string> output = new List<string>();
            if (arr.Length == 0)
                return output.ToArray();
            Array.Sort(arr);
            for (int i = 0; i < arr.Length; i++)
            {
                int start = i + 1;
                int end = arr.Length - 1;
                if (i > 0 && arr[i] == arr[i - 1])
                    continue;
                while (start < end)
                {
                    if (start > i + 1 && arr[start] == arr[start - 1])
                    {
                        start++;
                        continue;
                    }
                    if (end < arr.Length - 1 && arr[end] == arr[end + 1])
                    {
                        end--;
                        continue;
                    }
                    int pivot = Sum(arr[i], arr[start], arr[end]);
                    if (pivot == 0)
                    {
                        output.Add(arr[i].ToString() + "," + arr[start].ToString() + "," + arr[end].ToString())
                        start++;
                        end--;
                    }
                    if (pivot < 0)
                    {
                        start++;
                    }
                    if (pivot > 0)
                    {
                        end--;
                    }

                }
            }
            return output.ToArray();

        }
        private static int Sum(int x, int y, int z)
        {
            return (x + y + z);
        }




    }

}
  
  

