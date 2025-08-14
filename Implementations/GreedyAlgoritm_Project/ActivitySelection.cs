using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgoritm_Project
{
    public class ActivitySelection
    {
        public List<int> Select(int[] start, int[] finish)
        {
            int n = start.Length;
            List<int> result = new List<int>();
            int lastFinish = -1;

            for (int i = 0; i < n; i++)
            {
                if (start[i] >= lastFinish)
                {
                    result.Add(i);
                    lastFinish = finish[i];
                }
            }
            return result;
        }

    }
}
