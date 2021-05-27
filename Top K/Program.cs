using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_K
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[] {5,1,4,4,2};
            topK(arr, 3);
        }

        /*
      * Complete the function below.
      */
        static int[] topK(int[] arr, int k)
        {

            var hashSet = new HashSet<int>();
            List<int> output = new List<int>();
            int i = 0;
            int count = 0;

            while (i < arr.Length && count < k)
            {
                if (!hashSet.Contains(arr[i]))
                {
                    hashSet.Add(arr[i]);
                    output.Add(arr[i]);
                    count++;
                }

                //Console.Write(i + ", ");

                i++;
            }

            //Console.WriteLine("***************************");

            int[] heap = output.ToArray();

            if (heap.Length < k)
            {
                return heap;
            }

            int startIndex = k / 2 - 1;

            for (i = startIndex; i >= 0; i--)
            {
                Heapify(heap, i);
            }

            /*for(i = 0; i < k; i++)
            {
                Console.Write(heap[i] + ", ");
            }*/

            //Console.WriteLine("*********************");


            for (i = k; i < arr.Length; i++)
            {
                if (!heap.Contains(arr[i]) && arr[i] > heap[0])
                {
                    heap[0] = arr[i];
                    Heapify(heap, 0);
                }
            }

            return heap;
        }

        /*static int[] RemoveDuplicate(int[] arr)
        {
            List<int> output = new List<int>();
            var hashSet = new HashSet<int>();

            for(int i = 0; i < arr.Length; i++)
            {
                if(!hashSet.Contains(arr[i]))
                {
                    output.Add(arr[i]);
                    hashSet.Add(arr[i]);
                }
            }

            return output.ToArray();
        }*/

        static void Heapify(int[] heap, int i)
        {
            int smallest = i;

            int left = 2 * i + 1;
            int right = 2 * i + 2;

            if (right < heap.Length && heap[right] < heap[smallest])
            {
                smallest = right;
            }

            if (left < heap.Length && heap[left] < heap[smallest])
            {
                smallest = left;
            }

            if (smallest != i)
            {
                int temp = heap[i];
                heap[i] = heap[smallest];
                heap[smallest] = temp;

                Heapify(heap, smallest);
            }
        }


    }
}
