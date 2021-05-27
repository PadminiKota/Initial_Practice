using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Schedule
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] edges = new int[][]
       {
                new int[] {1,0},
               // new int[] {1,3},
                //new int[] {2,4},
           //new int[] {0,2},
       };
            Solution S = new Solution();
            S.CanFinish(2, edges);
        }

        public class Solution
        {
      
            static int count = 1;
            public bool CanFinish(int numCourses, int[][] prerequisites)
            {

                List<int>[] graph = BuildGraph(prerequisites, numCourses);
                for (int j = 0; j < numCourses; j++)
                {
                    bool[] Visited = new bool[numCourses];
                    int[] Parent = new int[numCourses];
                    int[] arrival = new int[numCourses];
                    int[] departure = new int[numCourses];
                    if (!Visited[j])
                    {
                        if (DFS_Helper(graph, Visited, Parent, arrival, departure, j))
                            return false;
                    }


                }
                return true;
            }
            private List<int>[] BuildGraph(int[][] edges, int m)
            {
                List<int>[] graph = new List<int>[m];
                for (int i = 0; i <= edges.GetLength(0) - 1; i++)
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
            private bool DFS_Helper(List<int>[] graph, bool[] Visited, int[] Parent, int[] arrival, int[] departure, int j)
            {

                if (graph[j] != null)
                {
                    
                    arrival[j] = count;
                    count++;
                    Visited[j] = true;
                    foreach (var adj_lst in graph[j])
                    {
                        if (!Visited[adj_lst])
                        {
                            Parent[adj_lst] = j;
                            if (DFS_Helper(graph, Visited, Parent, arrival, departure, adj_lst))
                                return true;
                        }
                        else
                        {
                            if (departure[adj_lst] == 0)
                                return true;
                        }
                    }
                    departure[j] = count;
                    count++;

                }
                return false;

            }
        }

    }
}
