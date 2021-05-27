using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillUp_Sorting_1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[4];
            input[0] =1;
            input[1] =2;
            input[2] =3;
            input[3] =4;
            List<int> input2 = new List<int>();
            solve(input);
        }

        /*
         * Complete the function below.
         */
        static int[] solve(int[] arr)
        {
            if (arr.Length <= 0)
            {
                return arr;
            }
            int evenpointer = 0;
            int oddpointer = arr.Length - 1;
            while (evenpointer < oddpointer)
            {
                while (IsEven(arr[evenpointer]) && evenpointer<oddpointer)
                {
                    evenpointer++;
                }
                while (IsOdd(arr[oddpointer])&& oddpointer>evenpointer)
                {
                    oddpointer--;
                }
                if (!IsEven(arr[evenpointer]) && !IsOdd(arr[oddpointer]))
                {
                    Swap(ref arr[evenpointer], ref arr[oddpointer]);
                    evenpointer++;
                    oddpointer--;
                }
            }
            return arr;


        }
        private static void Swap(ref int x, ref int y)
        {
            int temp = 0;
            temp = x;
            x = y;
            y = temp;
        }
        private static bool IsEven(int num)
        {
            if (num % 2 == 0)
                return true;
            else
                return false;
        }
        private static bool IsOdd(int num)
        {
            if (num % 2 != 0)
                return true;
            else
                return false;
        }


    }
}
