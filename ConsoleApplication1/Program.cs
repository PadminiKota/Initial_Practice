using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[2] { 2, 3 };
            countWaysToClimb(input,7);
        }

        // Complete the countWaysToClimb function below.
        private static int cnt = 0;
        static long countWaysToClimb(int[] steps, int n)
        {
            int[] dp = new int[n+1];
            if (n == 0 || n == 1 || n == 2)
                return n;

            else
            {
                dp[0] = 0; int j = 0;
                while (j < steps.Length)
                {
                    for (int i = cnt; i < dp.Length; i++)
                    {
                        if (i == steps[j])
                        {
                            dp[i] = 1;
                            cnt = i+1;
                            break;
                        }
                        else
                        {
                            dp[i] = 0;
                        }
                    }
                    j++;
                }
                for (int k = cnt; k <=n; k++)
                {

                    dp[k] = dp[k - 2] + dp[k - 3];
                }

            }
            return dp[n-1];


        }


    }
}
