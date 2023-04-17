namespace GraphNS;

public class Program
{
    static void Main(string[] args)
    {
        Graph g2 = new Graph("jo");

        Graph graph = new Graph("BenitezLopez5/trail.json");

        for (var f = 0; f < 0; f++)
        {
            Console.WriteLine("DFS {0}:  ", f);
            graph.DepthFS(f);
            Console.WriteLine();
            Console.WriteLine("BFS {0}:  ", f);
            graph.BreadthFS(f);
            Console.WriteLine();
        }

        Console.WriteLine("\n\n");

        Graph graph3 = new Graph ("attempt.json");

        for (var f = 0; f < 0; f++)
        {
            Console.WriteLine("DFS {0}:  ", f);
            graph3.DepthFS(f);
            Console.WriteLine();
            Console.WriteLine("BFS {0}:  ", f);
            graph3.BreadthFS(f);
            Console.WriteLine();
        }   

        Console.WriteLine("\n\n");

        Graph graph4 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/attempt.json");

        for (int f = 0; f < 11; f++)
        {
            Console.WriteLine("DFS {0}:  ", f);
            graph3.DepthFS(f);
            Console.WriteLine();
            Console.WriteLine("BFS {0}:  ", f);
            graph3.BreadthFS(f);
            Console.WriteLine();
        }   

        Console.WriteLine("\n\n");

        Graph graph5 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/BenitezLopez5/trail.json");

        for (int f = 0; f < 5; f++)
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