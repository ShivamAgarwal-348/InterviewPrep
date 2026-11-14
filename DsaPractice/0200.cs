using System;
using System.Collections.Generic;
using System.Text;

namespace DsaPractice
{
    internal class _0200
    {
        public class Solution
        {
            public int NumIslands(char[][] grid)
            {
                Queue<(int, int)> queue = new();
                HashSet<(int, int)> set = new();
                int count = 0;
                int rowLength = grid.Length;
                int colLength = grid[0].Length;

                for (int i = 0; i < rowLength; i++)
                {
                    for (int j = 0; j < colLength; j++)
                    {
                        if (grid[i][j] == '1' && !set.Contains((i, j)))
                        {
                            queue.Enqueue((i, j));
                            count++;
                            BFS(grid, queue, set, rowLength, colLength);
                        }
                    }
                }

                return count;
            }

            public void BFS(char[][] grid, Queue<(int, int)> queue, HashSet<(int, int)> set, int rowLength, int colLength)
            {
                while (queue.Count > 0)
                {
                    (var x, var y) = queue.Dequeue();

                    if (x < 0 || y < 0 || x >= rowLength || y >= colLength || grid[x][y] == '0' || set.Contains((x, y)))
                    {
                        continue;
                    }

                    set.Add((x, y));

                    queue.Enqueue((x + 1, y));
                    queue.Enqueue((x, y + 1));
                    queue.Enqueue((x - 1, y));
                    queue.Enqueue((x, y - 1));
                }
            }
        }
    }
}
