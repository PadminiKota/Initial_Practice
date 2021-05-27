using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Top_Frequent_K
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = new int[] { 1, 1, 1, 2, 2, 3 };
            Solution S = new Solution();
            S.TopKFrequent(input, 2);
        }
        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                var output = new Dictionary<int, int>();
                List<int> num = new List<int>();
                int cnt = 0;
                if (nums.Length == k)
                    return nums;
                Dict(0, nums.Length - 1, 0, num, nums, output);
                int[] heap = num.ToArray();
                if (k == heap.Length)
                    return heap;

                int[] result = new int[k];  // build the result array of size = k
                for (int i = 0; i < k; i++)
                {
                    buildMaxHeap(heap, output);
                    result[i] = heap[0];
                    heap[0] = heap[heap.Length - 1];
                    // arr[0] = arr[--arraySize];
                }
                return result;
            }
            private void buildMaxHeap(int[] heap, Dictionary<int, int> output)
            {
                for (int l = heap.Length - 1 / 2; l >= 0; l--)
                {
                    Heapify(heap, l, output);
                }
            }
            private void Heapify(int[] heap, int index, Dictionary<int, int> dict)
            {
                int smallest = index;
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < heap.Length && dict[heap[left]] > dict[heap[smallest]])
                {
                    smallest = left;
                }
                if (right < heap.Length && dict[heap[right]] > dict[heap[smallest]])
                {
                    smallest = right;
                }
                if (smallest != index)
                {
                    int temp = heap[index];
                    heap[index] = heap[smallest];
                    heap[smallest] = temp;
                    Heapify(heap, smallest, dict);
                }
            }
            private void Dict(int i, int j, int incre_cnt, List<int> num, int[] nums, Dictionary<int, int> output)
            {
                /****Creating dictionary with frequency ***/
                while (i <= j)
                {
                    if (!output.ContainsKey(nums[i]))
                    {
                        output.Add(nums[i], 0);
                        num.Add(nums[i]);

                        i++;
                    }
                    else
                    {
                        incre_cnt = output[nums[i]];
                        incre_cnt++;
                        output[nums[i]] = incre_cnt;
                        i++;
                        incre_cnt = 0;
                    }
                    if (!output.ContainsKey(nums[j]))
                    {
                        output.Add(nums[j], 0);
                        num.Add(nums[j]);

                        j--;
                    }
                    else
                    {
                        if (i != j)
                        {
                            incre_cnt = output[nums[j]];
                            incre_cnt++;
                            output[nums[j]] = incre_cnt;
                            j--;
                            incre_cnt = 0;
                        }

                    }

                }
            }

        }
    }
}
