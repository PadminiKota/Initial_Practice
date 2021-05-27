using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordBreak
{
    class Program
    {
        static void Main(string[] args)
        {
            Solution S = new Solution();
            //string s = "leetcode";
            //string s1 = s.Substring(0, 4);
            //string s2 = s.Substring(5, s.Length-1);
            List<string> input = new List<string>();
            input.Add("kick");
            input.Add("start");
            input.Add("kickstart");
            input.Add("is");
            input.Add("awe");
            input.Add("awesome");
            input.Add("some");
          // input.Add("awesome”);
           
            S.wordBreakCount(input,"kickstartisawesome");

        }
        public class Solution
        {
            public bool WordBreak1(string s, IList<string> wordDict)
            {
                var dict = wordDict.ToDictionary(x => x, x => true);
                bool[] output = new bool[s.Length + 1];
                output[0] = true;
                 for(int i=1;i<output.Length;i++)
                {
                    output[i] = false;
                    for (int word = 0; word <i;word++)
                    {
                        if(dict.ContainsKey(s.Substring(word,i-word)) && output[word]==true)
                        {
                            output[i] = true;
                        }

                    }

                }
                return output[s.Length];

            }

            public IList<string> WordBreak(string s, IList<string> wordDict)
            {
                var dict = wordDict.ToDictionary(x => x, x => true);
                IList<string> output = new List<string>();
                List<string> partial_sol = new List<string>();
                for (int i = 1; i < s.Length + 1; i++)
                {
                    for (int word = 0; word < i; word++)
                    {
                        if (dict.ContainsKey(s.Substring(word, i - word)))
                        {
                            string str = s.Substring(word, i - word);
                            str = string.Join(" ", str);
                            partial_sol.Add(str);
                        }
                    }
                        string temp = string.Join(",", partial_sol);
                        output.Add(temp);
                }
                return output;
            }

            public  int wordBreakCount(List<string> dictionary, string txt)
            {
                var dict = dictionary.ToDictionary(x => x, x => true);
                int count = 0;
                bool[] dp = new bool[txt.Length + 1];
                dp[0] = true;
                for (int i = 1; i < txt.Length + 1; i++)
                {
                    dp[i] = false;
                    for (int word = 0; word < i; word++)
                    {
                        if (dict.ContainsKey(txt.Substring(word, i - word)) && dp[word] == true)
                        {
                            count++;
                            dp[i] = true;
                            break;
                        }

                    }
                }
                return count;

            }

        }
    }
}
