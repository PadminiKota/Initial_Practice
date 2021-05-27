using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRank_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int> {1,2,3,4,5 };
            rotateLeft(4, arr);
        }
        public static List<int> rotateLeft(int d, List<int> arr)
        {
            int temp = 0;
            while (d > 0)
            {
                int i = 0;
                temp = arr[0];
                for (i = 1; i <= arr.Count; i++)
                {
                    if (i == arr.Count)
                        arr[i - 1] = temp;
                    else
                        arr[i - 1] = arr[i];
                }
                d--;
            }
            return arr;
        }

    }
}
