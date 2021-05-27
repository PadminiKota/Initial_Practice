using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_4
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
            {
                new int[] {2,3},
                new int[] {1,2},
                new int[] {1,3},
            };
            CountComponents(4,edges);
        }
        public static int CountComponents(int n, int[][] edges)
        {

            List<int>[] Graph = BuildGraph(edges,n);
            bool[] Visited = new bool[n];
            int count = 0;
            for (int i = 0; i < n; i++)
            {
                
                if (!Visited[i])
                {
                    count++;
                    DFS_Helper(i, Graph, Visited);
                }

            }

            return count;
        }
        private static  void DFS_Helper(int n, List<int>[] Graph, bool[] Visited)
        {
            Visited[n] = true;
            if(Graph[n]!=null)
            {
                foreach (var adj_list in Graph[n])
                {
                    if (!Visited[adj_list])
                        DFS_Helper(adj_list, Graph, Visited);
                }
            }
            
        }

        private static List<int>[] BuildGraph(int[][] edges, int n)
        {
            List<int>[] graph = new List<int>[n];
            for (int i = 0; i <= edges.GetLength(0)-1; i++)
            {
               
                    if (graph[edges[i][0]] == null)
                   
                    graph[edges[i][0]] = new List<int>();
                    
                    graph[edges[i][0]].Add(edges[i][1]);
                    if (graph[edges[i][1]] == null)
                
                    graph[edges[i][1]] = new List<int>();
                
                    graph[edges[i][1]].Add(edges[i][0]);
            }
            return graph;
        }

    }
}
