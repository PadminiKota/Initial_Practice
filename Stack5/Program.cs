using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Stack5
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] ops = new string[5];
            ops[0] = "5";
            ops[1] ="2";
            ops[2] ="C";
            ops[3] ="D";
            ops[4] ="+";
            Solution S = new Solution();
            S.CalPoints(ops);


        }
        public class Solution
        {
            public int CalPoints(string[] ops)
            {
                Stack<int> scoreboard = new Stack<int>();
                Stack<int> previousscore = new Stack<int>();
         
                for (int i = 0; i <= ops.Length - 1; i++)
                {
                    if (ops[i].Any(c=>char.IsDigit(c)))
                    {
                        scoreboard.Push(Convert.ToInt32(ops[i]));
                        previousscore.Push(Convert.ToInt32(ops[i]));
                    }
                    else if (ops[i] == "C")
                    {
                        scoreboard.Pop();
                    }
                    else if (ops[i] == "D")
                    {
                        previousscore.Peek();
                        scoreboard.Push(2 *(scoreboard.Peek()));
                        previousscore.Push(2 *(scoreboard.Peek()));
                    }
                    else if (ops[i] == "+")
                    {
                        int top1 = scoreboard.Pop();
                        int top2 = scoreboard.Pop();
                        scoreboard.Push(top2);
                        scoreboard.Push(top1);
                        scoreboard.Push(top1 + top2);
                        previousscore.Push(top1 + top2);

                    }
                }
                List<int> scoresum = scoreboard.ToList();
                return scoresum.Sum();

            }
        }
    }
}
