using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0746
    {
        public class Solution
        {
            public int MinCostClimbingStairs(int[] cost)
            {
                int[] totalCosts = new int[cost.Length + 1];

                for (int i = 2; i < totalCosts.Length; i++)
                {
                    totalCosts[i] = Math.Min(cost[i - 1] + totalCosts[i - 1], cost[i - 2] + totalCosts[i - 2]);
                }

                return totalCosts[totalCosts.Length - 1];
            }
        }

    }
}
