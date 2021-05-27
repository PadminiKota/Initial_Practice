using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Change
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> input = new List<int>() {1,
7,
22,
100,
64,
28,
8 };
            minimum_coins(input, 21);
        }
        public static int minimum_coins(List<int> coins, int value)
        {
            coins.Sort();
            if (coins.Count == 0)
                return 0;
            int[,] dp = new int[coins.Count+1, value+1];
             for (int j = 0; j < dp.GetLength(1); j++)
            {
                dp[0, j] = j;
            }
            for (int i = 1; i < dp.GetLength(0); i++)
            {
                for (int j = 1; j < dp.GetLength(1); j++)
                {
                    if (j > coins[i-1])
                    {
                        dp[i, j] = Math.Min(dp[i - 1, j], (1 + dp[i, j - coins[i-1]]));
                    }
                    else
                        dp[i, j] = dp[i - 1, j];
                }
            }
            return dp[coins.Count+1, value+1];

        }
    }

}

