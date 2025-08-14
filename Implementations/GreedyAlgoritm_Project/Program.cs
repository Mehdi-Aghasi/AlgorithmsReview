using GreedyAlgoritm_Project;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Huffman Algorithm ===");
        char[] symbols = { 'a', 'b', 'c', 'd', 'e' };
        int[] freq = { 5, 9, 12, 13, 16 };
        Huffman huffman = new Huffman();
        HuffmanNode root = huffman.Build(symbols, freq);
        huffman.Print(root, "");

        Console.WriteLine("\n=== Prim Algorithm ===");
        int[,] graph = {
                { 0, 2, 0, 6, 0 },
                { 2, 0, 3, 8, 5 },
                { 0, 3, 0, 0, 7 },
                { 6, 8, 0, 0, 9 },
                { 0, 5, 7, 9, 0 }
            };
        Prim prim = new Prim();
        int[] parent = prim.Execute(graph);
        Console.WriteLine("Edge \tWeight");
        for (int i = 1; i < parent.Length; i++)
            Console.WriteLine($"{parent[i]} - {i} \t{graph[i, parent[i]]}");

        Console.WriteLine("\n=== Activity Selection ===");
        int[] start = { 1, 3, 0, 5, 8, 5 };
        int[] finish = { 2, 4, 6, 7, 9, 9 };
        ActivitySelection activity = new ActivitySelection();
        List<int> selected = activity.Select(start, finish);
        Console.WriteLine("Selected activities:");
        foreach (var i in selected)
            Console.WriteLine($"Activity {i} (start: {start[i]}, finish: {finish[i]})");

        Console.WriteLine("\n=== Kruskal Algorithm ===");
        List<Edge> edges = new List<Edge>
            {
                new Edge{ Source=0, Destination=1, Weight=10 },
                new Edge{ Source=0, Destination=2, Weight=6 },
                new Edge{ Source=0, Destination=3, Weight=5 },
                new Edge{ Source=1, Destination=3, Weight=15 },
                new Edge{ Source=2, Destination=3, Weight=4 }
            };
        Kruskal kruskal = new Kruskal();
        List<Edge> mst = kruskal.Execute(edges, 4);
        Console.WriteLine("Edge \tWeight");
        foreach (var e in mst)
            Console.WriteLine($"{e.Source} - {e.Destination} \t{e.Weight}");
    }
}