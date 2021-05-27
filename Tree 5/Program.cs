using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_5
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
            {
                new int[] {0,1},
                new int[] {0,2},
                new int[] {0,3},
                new int[] {1,4},
            };
            Solution S = new Solution();
            S.ValidTree(5, edges);
        }
        public class Solution
        {
            public bool ValidTree(int n, int[][] edges)
            {
                List<int>[] Graph = BuildGraph(n, edges);
                bool[] Visited = new bool[n];
                List<int>[] Parent = new List<int>[n];
                Queue<int> queue = new Queue<int>();
                int count = 0;
                for (int i = 0; i < n; i++)
                {
                    if (!Visited[i])
                    {
                        count++;
                        if (count > 1)
                            return false;
                        queue.Enqueue(i);
                        if (BFS_Helper(queue, Visited, Parent, i, Graph))
                            return false;
                    }
                }
                return true;

            }

            private bool BFS_Helper(Queue<int> queue, bool[] Visited, List<int>[] Parent, int n, List<int>[] Graph)
            {
                Visited[n] = true;
                while (queue.Count > 0)
                {
                    int Node = queue.Dequeue();
                    foreach (var adj_lst in Graph[Node])
                    {
                        if (!Visited[adj_lst])
                        {
                            Parent[adj_lst] = new List<int>();
                            Parent[adj_lst].Add(Node);
                            Visited[adj_lst] = true;
                            queue.Enqueue(adj_lst);
                        }
                        else
                        {
                            if (Parent[Node].Contains(adj_lst))
                                return true;
                        }
                    }
                }
                return false;
            }
            private List<int>[] BuildGraph(int n, int[][] edges)
            {
                List<int>[] Graph = new List<int>[n];
                for (int i = 0; i <=edges.GetLength(0) - 1; i++)
                {
                    if (Graph[edges[i][0]] == null)
                        Graph[edges[i][0]] = new List<int>();
                    Graph[edges[i][0]].Add(edges[i][1]);
                    if (Graph[edges[i][1]] == null)
                        Graph[edges[i][1]] = new List<int>();
                    Graph[edges[i][1]].Add(edges[i][0]);
                }
                return Graph;

            }
        }
    }
}
