using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course_Schedule_2
{
    class Program
    {
        static void Main(string[] args)
        {

            int[][] edges = new int[][]
       {
                new int[] {0,1},
               new int[] {1,2},
                new int[] {2,0},
           new int[] {1,3},
       };
            Solution S = new Solution();
            S.FindOrder(4, edges);
        }


        public class Solution
        {
            static List<int> output = new List<int>();
            static int count = 0;
           static  int[] arrival = new int[4];
           static int[] departure = new int[4];
            static int[] cycle = new int[4];
            public int[] FindOrder(int numCourses, int[][] prerequisites)
            {
                List<int>[] graph = BuildGraph(prerequisites, numCourses);
                bool[] Visited = new bool[numCourses];
                int[] Parent = new int[numCourses];
               
                for (int j = 0; j < numCourses; j++)
                {

                    if (!Visited[j])
                    {
                        DFS_Helper(graph, Visited, Parent, arrival, departure, j);
                            //return new int[0];
                            //return output.ToArray();


                    }


                }
                return output.ToArray();

            }

            private List<int>[] BuildGraph(int [][] edges, int m)
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
            private int DFS_Helper(List<int>[] graph, bool[] Visited, int[] Parent, int[] arrival, int[] departure, int j)
            {
                arrival[j] = count;
                count++;
                Visited[j] = true;
                var highestreach = arrival[j];

                if (graph[j] != null)
                {
                     foreach (var adj_lst in graph[j])
                    {
                        if (!Visited[adj_lst])
                        {
                            Parent[adj_lst] = j;
                            var childreach= DFS_Helper(graph, Visited, Parent, arrival, departure, adj_lst);
                            if(childreach>arrival[j])
                            {
                                output.Insert(0, j);
                            }
                            highestreach = Math.Min(highestreach, childreach);
                        }
                        else
                        {
                            if (Parent[j] != adj_lst)
                                highestreach = Math.Min(highestreach, arrival[adj_lst]);

                        }
                    }
                
                  }
                //departure[j] = count;
                //count++;
                return highestreach;



            }

        }

    }
}
