using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniquePath2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[][] input = new int[][]
            {
              new int[] {0},
            //   new int[] {0,1,0},
              //  new int[] {0,0,0}
            };
            S.UniquePathsWithObstacles(input);
        }

        public class Solution
        {
            public int UniquePathsWithObstacles(int[][] obstacleGrid)
            {
                int[,] dp = new int[obstacleGrid.GetLength(0), obstacleGrid.Length];
                if (obstacleGrid.GetLength(0) - 1 == 0 && obstacleGrid.Length - 1 == 0 && obstacleGrid[0][0] == 1)
                {
                    return 0;
                }


                else
                {


                    for (int i = 0; i < obstacleGrid.Length; i++)
                    {
                        if (obstacleGrid[0][i] != 1)
                            dp[0, i] = 1;
                        else
                            break;
                    }
                    for (int j = 0; j < obstacleGrid.GetLength(0); j++)
                    {
                        if (obstacleGrid[j][0] != 1)
                            dp[j, 0] = 1;
                        else
                            break;
                    }
                    for (int i = 1; i < dp.GetLength(0); i++)
                    {
                        for (int j = 1; j < dp.GetLength(1); j++)
                        {
                            if (obstacleGrid[i][j] != 1)
                                dp[i, j] = dp[i - 1, j] + dp[i, j - 1];

                        }
                    }

                }
                return dp[dp.GetLength(0) - 1, dp.GetLength(1) - 1];

            }
        }
    }
}
