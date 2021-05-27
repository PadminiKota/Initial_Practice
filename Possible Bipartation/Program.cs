using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Possible_Bipartation
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
          {
                new int[] {1,2},
                new int[] {1,3},
                new int[] {2,4},
               //new int[] {0,2},
          };
            Solution S = new Solution();
            S.PossibleBipartition(4,edges);
        }

        public class Solution
        {
            public bool PossibleBipartition(int N, int[][] dislikes)
            {
                List<int>[] Graph = BuildGraph(N, dislikes);
                bool[] Visited = new bool[N+1];
                List<int>[] Parent = new List<int>[N+1];
                int[] distance = new int[N+1];
                for (int i = 1; i <= N; i++)
                {
                    if (!Visited[i])
                    {
                        Visited[i] = true;
                        distance[i] = 0;
                        Queue<int> queue = new Queue<int>();
                        queue.Enqueue(i);
                        if (!BFS_Helper(queue, distance, Visited, Parent, Graph))
                            return false;

                    }
                }
                return true;

            }
            private bool BFS_Helper(Queue<int> queue, int[] distance, bool[] Visited, List<int>[] Parent, List<int>[] Graph)
            {
                while (queue.Any())
                {
                    int Node = queue.Dequeue();
                    foreach (var adj_lst in Graph[Node])
                    {
                        if (!Visited[adj_lst])
                        {
                            Visited[adj_lst] = true;
                            Parent[adj_lst] = new List<int>();
                            Parent[adj_lst].Add(Node);
                            distance[adj_lst] = distance[Node] + 1;
                            queue.Enqueue(adj_lst);

                        }
                        else
                        {
                            if (!Parent[Node].Contains(adj_lst))
                            {
                                if (distance[Node] == distance[adj_lst])
                                    return false;
                            }
                        }
                    }
                }
                return true;
            }
            private List<int>[] BuildGraph(int n, int[][] edges)
            {
                List<int>[] Graph = new List<int>[n+1];
               
                for (int i = 0; i <= edges.GetLength(0) - 1; i++)
                {
                    if (Graph[edges[i][0]] == null)
                        Graph[edges[i][0]] = new List<int>();
                    Graph[edges[i][0]].Add(edges[i][1]);
                    if (Graph[edges[i][1]] == null)
                        Graph[edges[i][1]] = new List<int>();
                    Graph[edges[i][1]].Add(edges[i][0]);
                }
                return Graph;

                //for (int i = 0; i <=edges.GetLength(0) - 1; i++)
                //{
                //    if (Graph[edges[i][0]] == null)
                //        Graph[edges[i][0]] = new List<int>();
                //    Graph[edges[i][0]].Add(edges[i][1]);
                //    if (Graph[edges[i][1]] == null)
                //        Graph[edges[i][1]] = new List<int>();
                //    Graph[edges[i][1]].Add(edges[i][0]);
                //}
                //return Graph;
            }
        }
    }
}
