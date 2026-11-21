using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0143
    {
        public class ListNode
        {
            public int val;
            public ListNode next;
            public ListNode(int val = 0, ListNode next = null)
            {
                this.val = val;
                this.next = next;
            }
        }

        public class Solution
        {
            public void ReorderList(ListNode head)
            {
                Dictionary<int, ListNode> map = new();
                ListNode curr = head;
                int headIndex = 0;

                while (curr is not null)
                {
                    var next = curr.next;
                    map[headIndex] = curr;
                    curr = next;
                    headIndex++;
                }

                ListNode newHead = new();

                for (int i = 0; i < (headIndex) / 2; i++)
                {
                    newHead.next = map[i];
                    newHead = newHead.next;
                    newHead.next = map[headIndex - i - 1];
                    newHead = newHead.next;
                }

                if (headIndex % 2 == 1)
                {
                    newHead.next = map[(headIndex - 1) / 2];
                    newHead = newHead.next;
                    newHead.next = null;
                }

                newHead.next = null;
            }
        }

    }
}
