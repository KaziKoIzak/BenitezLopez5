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

//Driving program
public class Program
{
    static void Main(string[] args)
    {
        //File not found tests
        Graph graph0 = new Graph("jo");

        //File found tests
        Graph graph3 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/attempt.json");

        for (int i = 0; i < 12; i++)
        {
            Console.Write($"DFS {i}:  ");
            graph3.DepthFS(i);
            Console.WriteLine();
            Console.Write($"BFS {i}:  ");
            graph3.BreadthFS(i);
            Console.WriteLine();
        }   

        Console.WriteLine("\n\n");

        Graph graph4 = new Graph ("/Users/izakbenitez-lopez/Desktop/OOP/BenitezLopez5/BenitezLopez5/trail.json");

        for (int j = 0; j < 5; j++)
        {
            Console.Write($"DFS {j}:  ");
            graph4.DepthFS(j);
            Console.WriteLine();
            Console.Write($"BFS {j}:  ");
            graph4.BreadthFS(j);
            Console.WriteLine();
        }   
    }
}