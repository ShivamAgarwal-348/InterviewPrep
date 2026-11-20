using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0078
    {
        public class Solution
        {
            public List<List<int>> Subsets(int[] nums)
            {
                List<List<int>> result = new();
                List<int> list = new();

                DFS(nums, 0, result, list);
                return result;
            }

            public void DFS(int[] nums, int index, List<List<int>> result, List<int> list)
            {
                if (index == nums.Length)
                {
                    result.Add(new List<int>(list));
                    return;
                }

                list.Add(nums[index]);
                DFS(nums, index + 1, result, list);

                list.RemoveAt(list.Count - 1);
                DFS(nums, index + 1, result, list);
            }
        }

    }
}
