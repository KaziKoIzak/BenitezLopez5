namespace GraphNS;

public class Program
{
    static void Main(string[] args)
    {
        Graph g2 = new Graph("jo");

        Graph graph = new Graph("C:\\Users\\Dell Test\\Desktop\\SchoolStuff\\OOP\\HansonOOP5\\HansonOOP5\\inClassGraph.json");

        for (var f = 0; f < 4; f++)
        {
            Console.WriteLine("DFS {0}:  ", f);
            graph.DepthFS(f);
            Console.WriteLine();
            Console.WriteLine("BFS {0}:  ", f);
            graph.BreadthFS(f);
            Console.WriteLine();
        }

        Console.WriteLine("\n\n");

        Graph graph3 = new Graph ("filename.json");

        graph3 = new Graph ("C:\\Users\\Dell Test\\Desktop\\SchoolStuff\\OOP");

        for (var f = 0; f < 5; f++)
        {
            Console.WriteLine("DFS {0}:  ", f);
            graph3.DepthFS(f);
            Console.WriteLine();
            Console.WriteLine("BFS {0}:  ", f);
            graph3.BreadthFS(f);
            Console.WriteLine();
        }   
    }
}