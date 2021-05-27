using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Remove_Invalid_Parenthesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            S.RemoveInvalidParentheses(")(");
          
        }
        
        public class Solution
        {
            public IList<string> RemoveInvalidParentheses(string s)
            {
                var res = new List<string>();
                if (s == null || s.Length == 0)
                {
                    res.Add("");
                    return res;
                }

                var q = new Queue<string>();
                var visited = new HashSet<string>();
                q.Enqueue(s);
                visited.Add(s);
                bool found = false;

                while (q.Count != 0)
                {
                    var str = q.Dequeue();

                    if (IsValid(str))
                    {
                        res.Add(str);
                        found = true;
                    }

                    if (found) continue;

                    // generate all possible states
                    for (int i = 0; i < str.Length; i++)
                    {
                        // we only want to remove parentheses, not other letters
                        if (str[i] != ')' && str[i] != '(') continue;
                        string temp = str.Substring(0, i);
                        string temp2 = str.Substring(i + 1);
                        var news = str.Substring(0, i) + str.Substring(i + 1);
                        if (!visited.Contains(news))
                        {
                            q.Enqueue(news);
                            visited.Add(news);
                        }
                    }
                }
                return res;
            }

            public bool IsValid(string s)
            {
                int count = 0;
                for (int i = 0; i < s.Length; i++)
                {
                    var c = s[i];
                    if (c == '(') count++;
                    if (c == ')')
                    {
                        if (count == 0) return false;
                        count--;
                    }
                }
                return count == 0;
            }
        }
    }
}
