    using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0003
    {
        public class Solution
        {
            public int LengthOfLongestSubstring(string s)
            {
                int left = 0;
                int right = 0;
                int[] array = new int[26];
                HashSet<char> set = new();
                int maxCount = 0;

                while (right < s.Length)
                {
                    char index = s[right];
                    
                    if (set.Contains(index))
                    {
                        while (true)
                        {
                            char leftIndex = s[left];
                            set.Remove(leftIndex);
                            left++;
                            if (leftIndex == index)
                            {
                                break;
                            }
                        }
                    }

                    set.Add(index);
                    right++;

                    maxCount = Math.Max(maxCount, right - left);
                }

                return maxCount;
            }
        }

    }
}
