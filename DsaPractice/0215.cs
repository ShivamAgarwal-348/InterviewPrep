using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0215
    {
        public class Solution
        {
            public int FindKthLargest(int[] nums, int k)
            {
                PriorityQueue<int, int> minHeap = new();

                foreach (var num in nums)
                {
                    minHeap.Enqueue(num, num);
                    
                    if (minHeap.Count > k)
                    {
                        minHeap.Dequeue();
                    }
                }

                return minHeap.Dequeue();
            }   
        }

    }
}
