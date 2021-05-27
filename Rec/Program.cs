using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rec
{
    class Program
    {
        static void Main(string[] args)
        {
            long[] arr = new long[] { 2, 4, 8 };
            check_if_sum_possible(arr, 6);
        }

        static bool check_if_sum_possible(long[] arr, long k)
        {
          
            return Helper(arr, k, 0, new List<long>());
          

        }
        private static bool Helper(long[] arr, long k, int i, List<long> partial_sol)
        {
            if (i >= arr.Length)
            {
                if(Validate(partial_sol,k))
                {
                   

                    return true;
                   
                }
                 
            }
            else
            {


                /**** Exculde * ***/
                if (Helper(arr, k, i + 1, partial_sol))
                    return true;

            /**
           Include****/
            partial_sol.Add(arr[i]);
                if (Helper(arr, k, i + 1, partial_sol))
                    return true;
            partial_sol.RemoveAt(partial_sol.Count - 1);

            }
            return false;
       
        }
        private static bool Validate(List<long> partial_sol,long k)
        {
            long sumval = 0;
            foreach(var item in partial_sol)
            {
                sumval += item;
            }
            if (sumval == k)
                return true;

            return false;

        }

    }
}
