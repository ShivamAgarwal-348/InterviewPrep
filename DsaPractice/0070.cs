using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0070
    {
        public class Solution
        {
            public int ClimbStairs(int n)
            {
                if (n == 1)
                {
                    return 1;
                }
                
                if (n == 2)
                {
                    return 2;
                }

                int numOfWays2Stepsbefore = 1;
                int numOfWays1Stepsbefore = 2;

                for (int i = 3; i <= n; i++)
                {
                    int currentWays = numOfWays2Stepsbefore + numOfWays1Stepsbefore;
                    numOfWays2Stepsbefore = numOfWays1Stepsbefore;
                    numOfWays1Stepsbefore = currentWays;
                }

                return numOfWays1Stepsbefore;
            }
        }

    }
}
