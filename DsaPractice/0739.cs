using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0739
    {
        public class Solution
        {
            public int[] DailyTemperatures(int[] temperatures)
            {
                Stack<(int temp, int day)> stack = new();
                int[] result = new int[temperatures.Length];

                for (int i = 0; i < temperatures.Length; i++)
                {
                    while (stack.Count > 0)
                    {
                        var day = stack.Peek();

                        if (temperatures[i] <= day.temp)
                        {
                            break;
                        }
                        else
                        {
                            result[day.day] = i - day.day;
                            stack.Pop();
                        }
                    }

                    stack.Push((temperatures[i], i));
                }

                while (stack.Count > 0)
                {
                    var day = stack.Pop();
                    result[day.day] = 0;
                }

                return result;
            }
        }

    }
}
