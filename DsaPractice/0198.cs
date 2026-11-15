using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0198
    {
        public class Solution
        {
            public int Rob(int[] nums)
            {
                int moneyRobbed1HouseBefore = 0;
                int moneyRobbed2HouseBefore = 0;

                for (int i = 0; i < nums.Length; i++)
                {
                    int moneyRobbedTillCurrenthouse = Math.Max(moneyRobbed1HouseBefore, moneyRobbed2HouseBefore + nums[i]);
                    moneyRobbed2HouseBefore = moneyRobbed1HouseBefore;
                    moneyRobbed1HouseBefore = moneyRobbedTillCurrenthouse;
                }

                return moneyRobbed1HouseBefore;
            }

            public int RobRecursion(int[] nums)
            {
                return Recursion(nums, nums.Length - 1);
            }

            public int Recursion(int[] nums, int house)
            {
                if (house < 0)
                {
                    return 0;
                }

                return Math.Max(Recursion(nums, house - 1), Recursion(nums, house - 2) + nums[house]);
            }

            public int RobRecursionMemoised(int[] nums)
            {
                int?[] cache = new int?[nums.Length];
                return MemoisedRecursion(nums, nums.Length - 1, cache);
            }

            public int MemoisedRecursion(int[] nums, int house, int?[] cache)
            {
                if (house < 0)
                {
                    return 0;
                }

                if (cache[house].HasValue)
                {
                    return cache[house].Value;
                }

                cache[house] = Math.Max(MemoisedRecursion(nums, house - 1, cache), MemoisedRecursion(nums, house - 2, cache) + nums[house]);
                return cache[house].Value;
            }

            public int RobTabular(int[] nums)
            {
                int[] maxRobAmounts = new int[nums.Length + 2];

                for (int i = 2; i < nums.Length + 2; i++)
                {
                    maxRobAmounts[i] = Math.Max(maxRobAmounts[i - 1], maxRobAmounts[i - 2] + nums[i - 2]);
                }

                return maxRobAmounts[maxRobAmounts.Length-1];
            }
        }

    }
}
