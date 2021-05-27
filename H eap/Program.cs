using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace H_eap
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] nums = new int[] {3, 0, 1, 0};
            Solution S = new Solution();
           // S.TopKFrequent(nums, 2);
            string s = ":1,hello";
            string[] temp = s.Split(',').ToArray();
           int cnt= Convert.ToInt32(temp[0].Substring(1));
        }
        public class Solution
        {
            public int[] TopKFrequent(int[] nums, int k)
            {
                var output = new Dictionary<int, int>();
                List<int> num = new List<int>();
                int i = 0, j = nums.Length - 1;
                int incre_cnt = 0, cnt = 0;
                if (nums.Length == k)
                    return nums;

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
                int[] heap = num.ToArray();
                for (int l = heap.Length; l >= 0; l--)
                {
                    Heapify(heap, l, output);
                }
                return heap;
            }
            private void Heapify(int[] heap, int index, Dictionary<int, int> dict)
            {
                int smallest = index;
                int left = 2 * index + 1;
                int right = 2 * index + 2;

                if (left < heap.Length && dict[heap[left]] < dict[heap[smallest]])
                {
                    smallest = left;
                }
                if (right < heap.Length && dict[heap[right]] < dict[heap[smallest]])
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

        }
    }
}
