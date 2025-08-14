using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgoritm_Project
{
    public class Prim
    {
        public int[] Execute(int[,] graph)
        {
            int vertices = graph.GetLength(0);
            int[] parent = new int[vertices];
            int[] key = new int[vertices];
            bool[] mstSet = new bool[vertices];

            for (int i = 0; i < vertices; i++)
            {
                key[i] = int.MaxValue;
                mstSet[i] = false;
            }
            key[0] = 0;
            parent[0] = -1;

            for (int count = 0; count < vertices - 1; count++)
            {
                int u = MinKey(key, mstSet, vertices);
                mstSet[u] = true;

                for (int v = 0; v < vertices; v++)
                {
                    if (graph[u, v] != 0 && !mstSet[v] && graph[u, v] < key[v])
                    {
                        parent[v] = u;
                        key[v] = graph[u, v];
                    }
                }
            }
            return parent;
        }

        private int MinKey(int[] key, bool[] mstSet, int vertices)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int v = 0; v < vertices; v++)
            {
                if (!mstSet[v] && key[v] < min)
                {
                    min = key[v];
                    minIndex = v;
                }
            }
            return minIndex;
        }
    }
}
