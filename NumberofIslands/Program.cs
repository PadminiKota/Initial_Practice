using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberofIslands
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            char[][] grid = new char[][]
            {
                new char[] { '1', '1', '1', '1', '0'},
               new char[] { '1','1','0','1','0'},
                new char[] { '1','1','0','0','0'},
               new char[] { '0','0','0','0','0'},
            };
            S.NumIslands(grid);
            
        }
        public class Solution
        {
            int col_len = 0;
            int row_len = 0;
            public int NumIslands(char[][] grid)
            {
                col_len = grid.Length;
                if (col_len == 0)
                    return 0;
                row_len = grid[0].Length;
                int count = 0;
                for (int i = 0; i < col_len; i++)
                {
                    for (int j = 0; j < row_len; j++)
                    {
                        if (grid[i][j] == '1')
                        {
                            //grid[i][j] = 'X';
                            DFS_Helper(grid, i, j);
                            count++;
                        }
                    }
                }
                return count;

            }
            private void DFS_Helper(char[][] grid, int i, int j)
            {
                if (i >= col_len || j  >= row_len || i < 0 || j < 0)
                    return;
                if (grid[i][j] == '0' || grid[i][j] == 'X')
                    return;
                grid[i][j] = 'X';
                List<int>[] adj_lst = new List<int>[]
                {
                 new List<int> { 0,1 },
                  new List<int> { 0,-1 },
                   new List<int> { 1,0 },
                    new List<int> {-1,0 },
                };
                for(int k=0;k<adj_lst.GetLength(0)-1;k++)
                {
                    var nexti = i + adj_lst[k][0];
                    var nextj = j + adj_lst[k][1];
                    DFS_Helper(grid, nexti, nextj);

                }
          
                }

        }


    }
    }

