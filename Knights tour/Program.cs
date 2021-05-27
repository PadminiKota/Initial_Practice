using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knights_tour
{
    class Program
    {
        static void Main(string[] args)
        {

            find_minimum_number_of_moves(2, 7, 0, 5, 1, 1);
        }






        static int count = 0;
        static int find_minimum_number_of_moves(int rows, int cols, int start_row, int start_col, int end_row, int end_col)
        {
            if (start_row == end_row && start_row == end_col)
                return 0;
            // Write your code here.
            List<int>[] adj_lst = new List<int>[]
             {
                 new List<int> { -2,-1 },
                 new List<int> { -2,1 },
                 new List<int> { -1,2 },
                 new List<int> {-1,-2 },
                 new List<int> {1,2 },
                 new List<int> {1,-2 },
                 new List<int> {2,-1 },
                 new List<int> {2,1 },
             };


             HashSet<string> visited = new HashSet<string>();
            Queue<int[]> queue = new Queue<int[]>();
      
            queue.Enqueue(new int[] { start_row, start_col });
            visited.Add($"{start_row},{start_col}");
            while (queue.Any())
            {
                int numofnodes = queue.Count;
                count++;
                while (numofnodes != 0)
                {
                    var move = queue.Dequeue();
                    int row = move[0];
                    int col = move[1];

                    for (int k = 0; k < adj_lst.GetLength(0); k++)
                    {
                       int  next_row = row + adj_lst[k][0];
                        int next_col = col + adj_lst[k][1];

                        if (next_row == end_row && next_col == end_col)
                            return count;
                        if (next_row <= rows && next_col <= cols && !visited.Contains($"{next_row},{next_col}") && next_row > 0 && next_col > 0)
                        {
                            queue.Enqueue(new int[] { next_row, next_col });
                            visited.Add($"{next_row},{next_col}");

                        }
                    }
                    numofnodes--;
                }

            }

            
            return -1;

        }
        private static void BFS_Helper(Queue<int[]> queue, HashSet<string> Visited, List<int>[] adj_lst, int end_row, int end_col, int rows, int cols, int start_row, int start_col)
        {
            
        }




    }
}


