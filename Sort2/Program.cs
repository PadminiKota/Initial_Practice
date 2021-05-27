using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sort2
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            int[] input = new int[4];
            input[0] = 888;
            input[1] = 505;
            input[2] = 627;
            input[3] = 846;
           // input[4] = 0;
            S.SortArrayByParityII(input);

        }

        public class Solution
        {
            public int[] SortArrayByParityII(int[] A)
            {
                int j = 0;
                int temp = 0;
                for (int i = 0; i <= A.Length - 1; i++)
                {
                    if (i % 2 == 0)
                    {
                        if (A[i] % 2 == 0)
                            continue;
                        else
                        {
                            j = i + 1;
                            while (j <= A.Length - 1)
                            {
                                if (A[j] % 2 == 0)
                                {
                                    Swap(ref A[i], ref A[j]);
                                }
                                j = j + 1;
                            }
                        }
                    }
                    else if (i % 2 != 0)
                    {
                        if (A[i] % 2 != 0)
                            continue;
                        else
                        {
                            j = i + 1;
                            while (j <= A.Length - 1)
                            {
                                if (A[j] % 2 != 0)
                                {
                                    Swap(ref A[i], ref A[j]);
                                }
                                j = j + 1;
                            }
                        }
                    }


                }
                return A;

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
