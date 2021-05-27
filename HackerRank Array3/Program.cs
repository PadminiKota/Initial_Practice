using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_Array3
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[][]
            {
                new int[] {1, 2 ,100},
                new int[] {2, 5, 100},
                new int[] {3, 4, 100},
            };
            arrayManipulation(5, input);
        }
       

        static long arrayManipulation(int n, int[][] queries)
        {
            long[] arr = new long[n];
            int j = 1, m = 0;
            for (int k = 0; k < n; k++)
            {
                arr[k] = 0;
            }
            for (int i = 0; i < queries.GetLength(0); i++)
            {
                m = queries[i][0];
                while (m <= queries[i][2])
                {
                    arr[m - 1] = queries[i][2];
                    m++;
                }

            }
            long output = arr.Max();
            return output;

        }
    }
}
