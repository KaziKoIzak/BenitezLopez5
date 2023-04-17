/**************************************************************************************************
*** NAME : Izak Benitez-Lopez
*** CLASS : CSc 346
*** ASSIGNMENT : Assignment 5
*** DUE DATE : 04/19/23
*** INSTRUCTOR : GAMRADT
***************************************************************************************************
*** DESCRIPTION : What this assignment does is be able to to create a graph and use it for searching
*** and view purposes. This graph is created through the Graph.cs and handles a List of Nodes. These
*** Nodes are created through the Node.cs file. The Graph file also contains two interfaces that are 
*** IProcessData and IGraphAlgorithm. They have contracts that are filled by the Graph.cs files and
*** hold the Depth Search and the Breadth Search. This is all done by accepting an outside file and
*** reading it in.
***************************************************************************************************/
namespace GraphNS;

public class Program
{
    static void Main(string[] args)
    {
        Graph graph0 = new Graph("jo");

        Graph graph = new Graph("BenitezLopez5/trail.json");

        for (var f = 0; f < 0; f++)
        {
            Console.Write("DFS {0}:  ", f);
            graph.DepthFS(f);
            Console.WriteLine();
            Console.Write("BFS {0}:  ", f);
            graph.BreadthFS(f);
            Console.WriteLine();
        }

        Console.WriteLine("\n\n");

        Graph graph2 = new Graph ("attempt.json");

        for (var f = 0; f < 0; f++)
        {
            Console.Write("DFS {0}:  ", f);
            graph2.DepthFS(f);
            Console.WriteLine();
            Console.Write("BFS {0}:  ", f);
            graph2.BreadthFS(f);
            Console.WriteLine();
        }   

        Console.WriteLine("\n\n");

        Graph graph3 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/attempt.json");

        for (int f = 0; f < 11; f++)
        {
            Console.Write("DFS {0}:  ", f);
            graph3.DepthFS(f);
            Console.WriteLine();
            Console.Write("BFS {0}:  ", f);
            graph3.BreadthFS(f);
            Console.WriteLine();
        }   

        Console.WriteLine("\n\n");

        Graph graph4 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/BenitezLopez5/trail.json");

        for (int f = 0; f < 5; f++)
        {
            Console.Write("DFS {0}:  ", f);
            graph4.DepthFS(f);
            Console.WriteLine();
            Console.Write("BFS {0}:  ", f);
            graph4.BreadthFS(f);
            Console.WriteLine();
        }   
    }
}