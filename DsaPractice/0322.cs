using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0322
    {
        public class Solution
        {
            public int CoinChange(int[] coins, int amount)
            {
                int val = Recursion(coins, amount);
                return val == int.MaxValue? -1 : val;
            }

            public int Recursion(int[] coins, int amount)
            {
                if (amount == 0)
                {
                    return 0;
                }

                int fewest = int.MaxValue;

                foreach (var coin in coins)
                {
                    if (coin > amount)
                    {
                        continue;
                    }

                    fewest = Math.Min(fewest, Recursion(coins, amount - coin));
                }

                return fewest == int.MaxValue ? int.MaxValue : fewest + 1;
            }

            public int CoinChangeTabular(int[] coins, int amount)
            {
                int n = coins.Length;
                int rows = amount + 1;
                int[] fewest = new int[rows];
                Array.Fill(fewest, int.MaxValue);
                fewest[0] = 0;

                for (int i = 1; i <= amount; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (coins[j] > i)
                        {
                            continue;
                        }

                        var nextval = fewest[i - coins[j]];
                        if (nextval == int.MaxValue)
                            continue;

                        fewest[i] = Math.Min(fewest[i], 1 + nextval);
                    }
                }

                return fewest[amount] == int.MaxValue ? -1 : fewest[amount];
            }

            public int CoinChangeMemoised(int[] coins, int amount)
            {
                int res = RecursionMemoised(coins, amount, new int?[amount + 1]);
                return res == int.MaxValue ? -1 : res;
            }

            public int RecursionMemoised(int[] coins, int amount, int?[] fewest)
            {
                if (amount == 0)
                {
                    return 0;
                }

                if (fewest[amount].HasValue)
                {
                    return fewest[amount].Value;
                }

                int x = int.MaxValue;

                foreach (var coin in coins)
                {
                    if (coin > amount)
                    {
                        continue;
                    }

                    int nextVal = RecursionMemoised(coins, amount - coin, fewest);
                    if (nextVal == int.MaxValue)
                    {
                        continue;
                    }

                    x = Math.Min(x, 1 + nextVal);
                }

                fewest[amount] = x;

                return x;
            }
        }

    }
}
