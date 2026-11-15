using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0049
    {
        public class Solution
        {
            public List<List<string>> GroupAnagrams(string[] strs)
            {
                Dictionary<string, List<string>> map = new();
                List<List<string>> ans = new();

                foreach (var str in strs)
                {
                    int[] arr = new int[26];

                    foreach (var c in str)
                    {
                        arr[c - 'a']++;
                    }

                    var a = string.Join(",", arr);

                    if (map.ContainsKey(a))
                    {
                        map[a].Add(str);
                    }
                    else
                    {
                        map[a] = new List<string>() { str };
                    }
                }

                foreach (var item in map)
                {
                    ans.Add(item.Value);
                }

                return ans;
            }
        }

    }
}
