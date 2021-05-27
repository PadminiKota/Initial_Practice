using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopK
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = new int[]
                {4,
8,
9,
6,
6,
2,
10,
2,
8,
1,
2};
            topK(arr, 9);
        }

        /*
         * Complete the function below.
         */
        static int[] topK(int[] arr, int k)
        {
            List<int> heap_initial = new List<int>();
            //int[] heap =new int[k];
            Dictionary<int, int> dict = new Dictionary<int, int>();
            int m = 0;
            int i = 0;
            while(i<arr.Length-1 && m<k)
            {
                if (i == 0 || (!dict.ContainsValue(arr[i])))
                {
                    heap_initial.Add(arr[i]);
                    dict.Add(m, arr[i]);
                    m++;
                }

                i++;
            }
            int[] heap = heap_initial.ToArray();
            for (int j = (heap.Length - 1) / 2; j >= 0; j--)
            {
                MinHeapify(heap, j);
            }
            for (int l = k; l < arr.Length; l++)
            {
                if (!heap.Contains(arr[l]) && arr[l] > heap[0])
                {
                    heap[0] = arr[l];
                    MinHeapify(heap, 0);
                }
            }
            return heap;

        }
        static void MinHeapify(int[] heap, int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;
            if ((left <= heap.Length - 1) && heap[left] < heap[smallest])
            {
                smallest = left;
            }
            if ((right <= heap.Length - 1)&& heap[right] < heap[smallest])
            {
                smallest = left;
            }
            if (smallest != index)
            {
                int temp = heap[smallest];
                heap[smallest] = heap[index];
                heap[index] = temp;
                MinHeapify(heap, smallest);
            }
        }


    }
}
