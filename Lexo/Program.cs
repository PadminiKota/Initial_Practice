using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lexo
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[] { "key1 abcd",

 "key2 zzz",

 "key1 hello",

 "key3 world",

 "key1 hello"};
            Solution S = new Solution();
            S.solve(arr);

        }
        class Solution
        {
            public string[] solve(string[] arr)
            {
                /*
                 * Write your code here.
                 */
                Dictionary<string, string> dict = new Dictionary<string, string>();
                for (int i = 0; i < arr.Length; i++)
                {
                    string[] words = arr[i].Split(' ');
                    if (!dict.ContainsKey(words[0]))
                    {
                        var val_temp = ":1," + words[1];
                        dict.Add(words[0], val_temp);

                    }
                    else
                    {
                        string val = dict[words[0]];
                        string[] temp = val.Split(',').ToArray();
                        int incre_cnt = Convert.ToInt32(temp[0].Substring(1));
                        incre_cnt = incre_cnt + 1;
                        int cmp = string.Compare(temp[1], words[1]);
                        if (cmp == 1 || cmp == 0)
                        {
                            dict[words[0]] = ":" + incre_cnt + "," + temp[1];
                        }
                        else if (cmp == -1)
                        {
                            dict[words[0]] = ":" + incre_cnt + "," + words[1];
                        }


                    }


                }
                string[] strArray = dict.Select(x => ( x.Key , x.Value)).ToArray();
                return strArray;
            }
        }
       
    }
    /*
 * Complete the solve function below.
 */
    


}
