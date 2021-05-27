using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Leetcode_MeetingRooms
{
    class Program
    {
        static void Main(string[] args)
        {
            int[][] input = new int[3][];
            input[0] = new int[] { 1, 2 };
            input[1] = new int[] { 8, 10 };
            input[2] = new int[] { 4, 5 };

            int[][] query = new int[2][];
            query[0] = new int[] { 2, 3 };
            query[1] = new int[] { 3, 4 };

            //int[][] input = new int[3][];
            //input[0] = new int[] { 0, 1 };
            //input[1] = new int[] { 1, 2 };
            //input[2] = new int[] { 3, 4 };



            int rooms = 1;
            Solution S = new Solution();
            S.Meetingrooms(input,rooms,query);
        }

        class Solution
        {
            public string[] Meetingrooms(int[][] input, int rooms, int[][] query)
            {
                string[] output = new string[query.Length];
                int[][] sortedarray = input.OrderBy(y => y[0]).ToArray<int[]>();
                int startpoint = 0, endpoint = input.Length - 1;
                for(int i=0;i<query.Length;i++)
                {
                    int query_start_time = query[i][0];
                    int query_end_time = query[i][1];
                    while(startpoint<endpoint)
                    {
                        if(sortedarray[startpoint][0]<query_start_time)
                        {
                            startpoint++;
                            continue;
                        }
                        if(sortedarray[endpoint][0]>query_end_time)
                        {
                            endpoint--;
                            continue;
                        }

                    }

                }
                                                 
                                                 



                return output;

            }


            //public bool Meetingrooms_forloop(int[][] input)
            //{
            //    //int[][] sortedarray= input.OrderBy(y => y[0]);
                
            //    for(int i=0;i<input.Length;i++)
            //    {
            //        int prev_end_time = sort[i][1];
            //        for(int j=i+1;j<input.Length;j++)
            //        {
            //            if(input[j][0]<prev_end_time)
            //                return false;
            //        }
            //    }
            //    return true;

            //}

            public bool Meetingrooms_forloops(int[][] input)
            {
                var temparray = input.OrderBy(y => y[0]);
                int[][] sortedarray = temparray.ToArray<int[]>();
                for (int i = 0; i < sortedarray.Length; i++)
                {
                    int prev_end_time = sortedarray[i][1];
                    for (int j = i + 1; j < sortedarray.Length; j++)
                    {
                        if (sortedarray[j][0] < prev_end_time)
                            return false;
                    }
                }
                return true;

            }


            public bool Meetingrooms(int[][] input)
            {
                int[][] sortedarray = input.OrderBy(y => y[0]).ToArray<int[]>();
                for (int i = 0; i < sortedarray.Length; i++)
                {
                    int prev_end_time = sortedarray[i][1];
                    for (int j = i + 1; j < sortedarray.Length; j++)
                    {
                        if (sortedarray[j][0] < prev_end_time)
                            return false;
                    }
                }
                return true;

            }
        }
    }
}
