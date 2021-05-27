using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rotate_Image
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] matrix = new int[4][]
            {
               new int[] { 5, 1, 9, 11 },
               new int[] {2, 4, 8, 10 },
               new int[] {13, 3, 6, 7 },
               new int[] {15, 14, 12, 16 }
           };
            Solution S = new Solution();
            S.Rotate(matrix);


            }
        public class Solution
        {
            public void Rotate(int[][] matrix)
            {
                int k = matrix.Length;
                for (int i = 0; i < (k + 1) / 2; i++)
                {
                    for (int j = 0; j < k / 2; j++)
                    {
                        int temp = matrix[k - 1 - j][i];
                        matrix[k - 1 - j][i] = matrix[k - 1 - i][k - 1 - j];
                        matrix[k - 1 - i][k - 1 - j] = matrix[j][k - 1 - i];
                        matrix[j][k - 1 - i] = matrix[i][j];
                        matrix[i][j] = temp;

                    }
                }

                /*** for(int j=0;j<(k+1)/2;j++)
                 {
                     for(int i=0;i<k/2;i++)
                     {
                         int temp=matrix[k-1-i][j];
                         matrix[k-1-i][j]=matrix[k-1-i][k-1-j];
                         matrix[k-1-i][k-1-j]=matrix[i][k-1-j];
                         matrix[i][k-1-j]=matrix[i][j];
                         matrix[i][j]=temp;
                     }
                 }****/

            }
        }
    }
}
