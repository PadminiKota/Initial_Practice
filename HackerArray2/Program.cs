using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerArray2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] arr = new int[][] {
               new int[] { -1, - 1 ,0 ,- 9, - 2, - 2 },
  new int[] { - 2, - 1, - 6, - 8,- 2, - 5 },
 new int[] {- 1, - 1, - 1,- 2 - 3 - 4 },
 new int[] {- 1 - 9 - 2 - 4 - 4 - 5},
 new int[] {- 7 - 3 - 3 - 2 - 9 - 9},
 new int[] {- 1 - 3 - 1 - 2 - 4 - 5},
             };
            hourglassSum(arr);

           
        }
      

        static int hourglassSum(int[][] arr)
        {
            
            int temp = 0, output = 0;
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    temp = arr[i][j] + arr[i][j + 1] + arr[i][j + 2] + arr[i + 1][j + 1] + arr[i + 2][j] + arr[i + 2][j + 1] + arr[i + 2][j + 2];
                    if (temp < 0 && i == 0 && j == 0)
                        output = Math.Min(output, temp);
                    else
                        output = Math.Max(output, temp);
                   
                }

            }
            return output;
        }
    }
}
