using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0015
    {
        public class Solution
        {
            public List<List<int>> ThreeSum(int[] nums)
            {
                Dictionary<int, List<int>> map = new();
                HashSet<(int, int, int)> set = new();
                List<List<int>> result = new();

                for (int i = 0; i < nums.Length; i++)
                {
                    if (map.ContainsKey(nums[i]))
                    {
                        map[nums[i]].Add(i);
                    }
                    else
                    {
                        map[nums[i]] = new()
                        {
                            i
                        }; 
                    }
                }

                for (int i = 0; i < nums.Length; i++)
                {
                    for (int j = i+1; j < nums.Length; j++)
                    {
                        int sum = nums[i] + nums[j];
                        int negSum = -sum;

                        if (map.ContainsKey(negSum))
                        {
                            foreach (var index in map[negSum])
                            {
                                if (i != j && index != i && index != j)
                                {
                                    int[] arr = { nums[i], nums[j], nums[index] };
                                    Array.Sort(arr);
                                    set.Add((arr[0], arr[1], arr[2]));
                                    break;
                                }
                            }
                        }
                    }
                }

                foreach (var item in set)
                {
                    result.Add(new List<int>()
                    {
                        item.Item1,
                        item.Item2,
                        item.Item3
                    });
                }

                return result;
            }
        }

    }
}
