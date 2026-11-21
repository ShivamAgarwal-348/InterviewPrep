using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0213
    {
        public class Solution
        {
            public int Rob(int[] nums)
            {
                // can i run two tabulations, 1 from house 1 to n-1 and other from 2 to n. assuming that one of the houses is dropped???

                //adding the edge after failing the soln
                if (nums.Length == 1)
                {
                    return nums[0];
                }

                int[] housesWithoutFirst = nums.Skip(1).ToArray();
                int[] housesWithoutLast = nums.SkipLast(1).ToArray();

                return Math.Max(RobOptimized(housesWithoutFirst), RobOptimized(housesWithoutLast));
            }

            public int RobOptimized(int[] nums)
            {
                int MaxAmount2HousesBefore = 0;
                int MaxAmount1HousesBefore = 0;

                foreach (var num in nums)
                {
                    int currentMax = Math.Max(MaxAmount1HousesBefore, MaxAmount2HousesBefore + num);
                    MaxAmount2HousesBefore = MaxAmount1HousesBefore;
                    MaxAmount1HousesBefore = currentMax;
                }

                return MaxAmount1HousesBefore;
            }
        }
    }
}
