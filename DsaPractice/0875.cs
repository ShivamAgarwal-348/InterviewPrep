using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0875
    {
        public class Solution
        {
            public int MinEatingSpeed(int[] piles, int h)
            {
                int minK = 1;
                int maxK = piles.Max();



                while (minK < maxK)
                {
                    int midK = minK + (maxK - minK) / 2;

                    var sucess = CanSuccedInEating(piles, h, midK);

                    if (sucess)
                    {
                        maxK = midK;
                    }
                    else
                    {
                        minK = midK + 1;
                    }
                }

                return maxK;
            }

            public bool CanSuccedInEating(int[] piles, int h, int k)
            {
                int time = 0;
                foreach (var pile in piles)
                {
                    time += pile / k + (pile % k == 0 ? 0 : 1);
                }

                return time <= h;
            }
        }

    }
}
