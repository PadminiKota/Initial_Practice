using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REcurssion_9
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            S.AddOperators("222", 24);
        }

        public class Solution
        {
            public static bool True { get; private set; }

            public IList<string> AddOperators(string num, long target)
            {
                         
                List<string> solution = new List<string>();
                for(int i=0;i<num.Length;i++)
                {
                    //var val = long.Parse(num.Substring(0, i));
                    RecursiveCall(num, 0, "", solution, target, "", 0);
                }
                
                return solution;
            }
            private void RecursiveCall(string num, int i, String expression,List<string> solution,long target,string Lastchar,long runningsum)
            {
                if(i>=num.Length)
                {

                    string output = ResolveExpressions(expression.ToString(),target,runningsum);
                    if (!string.IsNullOrEmpty(output))
                        solution.Add(expression.ToString());
                    return;
                }
                else
                {
                    for (int k = i; k < num.Length; k++)
                    {
                        var c = num.Substring(i,k-i+1);
                        expression += c;
                        Lastchar += c;
                        RecursiveCall(num, i + 1, expression + "*", solution, target, "", (long.Parse(Lastchar) * long.Parse(num[k + 1].ToString())));
                        RecursiveCall(num, i + 1, expression + "+", solution, target, "", (long.Parse(Lastchar) + long.Parse(num[k + 1].ToString())));
                    }
                   

                }
            }
                private static  string  ResolveExpressions( string expression, long target,long runningsum)
                {
                    bool valid_exp = Validate(expression);
                    long val;
                    if(valid_exp)
                    {
                    
                      //  val = Evaluate(expression);
                        if (runningsum == target)
                            return expression;
                   
                    }
                    else
                    {
                        return null;
                    }
                    return null;
                }
                private static bool  Validate(string expression)
                {
                     char first = expression[0];
                    char last = expression[expression.Length - 1];
                    if (first.Equals('(') || first.Equals('*') || first.Equals('+'))
                        return false;
                    if (last.Equals('(') || last.Equals('*') || last.Equals('+'))
                        return false;
                    if (!expression.Contains("*") && !expression.Contains("+"))
                        return false;
                    return true;
                }

                //private static long Evaluate(string expression)
                //{
                //    long temp = 0;

                //    for(int i=0;i<=expression.Length-1;i++)
                //    {
                    
                //        if(expression[i].Equals('+'))
                //        {
                //            temp = temp + int.Parse(expression[i+1].ToString());
                //            i = i + 1;
                //        }
                //       else if (expression[i].Equals('*'))
                //        {
                //            long y = temp;
                //            temp = y * int.Parse(expression[i+1].ToString());
                //            i = i + 1;
                //        }
                //      else  if (expression[i].Equals('('))
                //        {
                //            long x = temp;
                //            temp = int.Parse(x.ToString() + int.Parse(expression[i + 1].ToString()));
                //            i = i + 1;
                //        }
                //        else
                //        {
                //            temp = int.Parse(expression[i].ToString());
                //        }
                    
                //    }
                //    return temp;
                //}
        }
    }
}
