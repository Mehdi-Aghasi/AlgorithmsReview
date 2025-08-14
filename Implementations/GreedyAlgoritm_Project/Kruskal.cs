using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgoritm_Project
{
    public class Kruskal
    {
        private int Find(int[] parent, int i)
        {
            if (parent[i] == i)
                return i;
            return Find(parent, parent[i]);
        }

        private void Union(int[] parent, int x, int y)
        {
            int xset = Find(parent, x);
            int yset = Find(parent, y);
            parent[xset] = yset;
        }

        public List<Edge> Execute(List<Edge> edges, int vertices)
        {
            edges.Sort((a, b) => a.Weight.CompareTo(b.Weight));
            int[] parent = new int[vertices];
            for (int i = 0; i < vertices; i++)
                parent[i] = i;

            List<Edge> result = new List<Edge>();

            foreach (var edge in edges)
            {
                int x = Find(parent, edge.Source);
                int y = Find(parent, edge.Destination);

                if (x != y)
                {
                    result.Add(edge);
                    Union(parent, x, y);
                }
            }

            return result;
        }
    }
}
