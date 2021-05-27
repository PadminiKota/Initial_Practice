using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bipartite
{
    class Program
    {
        static void Main(string[] args)
        {

//[[1,2,3],[0,2],[0,1,3],[0,2]]
            int[][] edges = new int[][]
          {
                new int[] {1,2,3},
                new int[] {0,2},
                new int[] {0,1,3},
                new int[] {0,2},
          };
            Solution S = new Solution();
            S.IsBipartite(edges);
        }
        public class Solution
        {
            public bool IsBipartite(int[][] graph)
            {
                int n = graph.Length;
                bool[] Visited = new bool[n];
                List<int>[] Parent = new List<int>[n];
                int[] distance = new int[n];
                for(int i=0;i<n;i++)
                {
                    if (!Visited[i])
                    {
                        
                        Queue<int> queue = new Queue<int>();
                        queue.Enqueue(i);
                        distance[i] = 0;
                        if (!BFS_Helper(queue, i, Parent, Visited, distance,graph))
                            return false;

                    }
                }
                return true;
            }
            private bool BFS_Helper(Queue<int> queue,int i,List<int>[] Parent, bool[] Visited, int[] distance,int[][] graph)
            {
                Visited[i] = true;
                while(queue.Any())
                {
                    int Node = queue.Dequeue();
                    foreach(var adj_lst in graph[Node])
                    {
                        if(!Visited[adj_lst])
                        {
                            Visited[adj_lst] = true;
                            Parent[adj_lst] = new List<int>();
                            Parent[adj_lst].Add(Node);
                            distance[adj_lst] = distance[Node] + 1;
                            queue.Enqueue(adj_lst);

                        }
                        else
                        {
                            if(!Parent[Node].Contains(adj_lst))
                            {
                                if (distance[Node] == distance[adj_lst])
                                    return false; 
                            }
                        }
                    }
                }



                return true;
            }
        }
    }
}
