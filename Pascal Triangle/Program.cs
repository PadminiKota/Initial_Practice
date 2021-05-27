using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pascal_Triangle
{
    class Program
    {
        static void Main(string[] args)
        {
            List<IList<int>> input = new List<IList<int>>() {
                { new List <int> { 2 } },
                //{ new List <int> { 3,4 } },
               // { new List <int> { 6,5,7 } },
               // { new List <int> { 4,1,8,3 } },
            };
            Solution S = new Solution();
            //S.Generate(5);
            S.MinimumTotal(input);
        }

        public class Solution
        {
           //List<IList<int>>
            public List<IList<int>> Generate(int numRows)
            {
                if (numRows == 0)
                {
                    return new List<IList<int>>() { new List<int> { } };
                }
                if (numRows == 1)
                {
                   return new List<IList<int>>() { new List<int> { 1 } };
                }
                List<IList<int>> triangle = new List<IList<int>>();
                
                List<int> prev = new List<int>();
                prev.Add(1);
                triangle.Add(new List<int>(prev));
                for (int i = 1; i < numRows; i++)
                {
                       List<int> row = new List<int>();
                        row.Add(1);
                        for(int j=1;j<prev.Count;j++)
                        {
                            row.Add(prev[j] + prev[j - 1]);
                        }
                        row.Add(1);
                    
                    prev = row;
                    triangle.Add(new List<int>(row));
                }

                return triangle;
            }

            public int MinimumTotal(IList<IList<int>> triangle)
            {
                int mintotal = 0;
                if (triangle.Count == 0)
                    return 0;
                List<IList<int>> dp = new List<IList<int>>();
                List<int> prev = new List<int>();
                foreach(var list in triangle)
                {
                    List<int> curr = new List<int>();
                    if (list.Count==1)
                    {
                        //curr.Add(list[0]);
                        prev = list.ToList();
                        //dp.Add(new List<int>(prev));
                    }
                    else
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if(i==0)
                            {
                                list[i] = prev[i] + list[i];
                               // curr.Add(val);
                            }
                            else if (i == list.Count - 1)
                            {
                                list[i] = prev[i-1] + list[i];
                                //curr.Add(val);
                            }
                            else
                            {
                                list[i] = Math.Min(prev[i - 1], prev[i]) + list[i];
                                //curr.Add(val_temp);
                            }
                       
                        }
                        prev = list.ToList();
                       // dp.Add(new List<int>(prev));

                    }
                    mintotal = prev.Min();
                }
                return mintotal;


            }


            public int MinimumTotal1(IList<IList<int>> triangle)
            {
                int mintotal = 0;
                if (triangle.Count == 0)
                    return 0;
                List<IList<int>> dp = new List<IList<int>>();
                List<int> prev = new List<int>();
                foreach (var list in triangle)
                {
                    List<int> curr = new List<int>();
                    if (list.Count == 1)
                    {
                        curr.Add(list[0]);
                        prev = curr;
                        dp.Add(new List<int>(prev));
                    }
                    else
                    {
                        for (int i = 0; i <= list.Count - 1; i++)
                        {
                            if (i == 0)
                            {
                                int val = prev[i] + list[i];
                                curr.Add(val);
                            }
                            else if (i == list.Count - 1)
                            {
                                int val = prev[i - 1] + list[i];
                                curr.Add(val);
                            }
                            else
                            {
                                int val_temp = Math.Min(prev[i - 1], prev[i]) + list[i];
                                curr.Add(val_temp);
                            }

                        }
                        prev = curr;
                        dp.Add(new List<int>(prev));

                    }
                    mintotal = prev.Min();
                }
                return mintotal;


            }
        }
    }
}
