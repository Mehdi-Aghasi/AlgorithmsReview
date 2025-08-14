using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreedyAlgoritm_Project
{
    public class Huffman
    {
        public HuffmanNode Build(char[] symbols, int[] freq)
        {
            List<HuffmanNode> nodes = new List<HuffmanNode>();
            for (int i = 0; i < symbols.Length; i++)
                nodes.Add(new HuffmanNode { Symbol = symbols[i], Frequency = freq[i] });

            while (nodes.Count > 1)
            {
                nodes.Sort((x, y) => x.Frequency - y.Frequency);
                HuffmanNode left = nodes[0];
                HuffmanNode right = nodes[1];
                HuffmanNode parent = new HuffmanNode
                {
                    Symbol = '*',
                    Frequency = left.Frequency + right.Frequency,
                    Left = left,
                    Right = right
                };
                nodes.Remove(left);
                nodes.Remove(right);
                nodes.Add(parent);
            }
            return nodes[0];
        }

        public void Print(HuffmanNode node, string code)
        {
            if (node == null) return;
            if (node.Left == null && node.Right == null)
                Console.WriteLine($"{node.Symbol}: {code}");
            Print(node.Left, code + "0");
            Print(node.Right, code + "1");
        }
    }
}
