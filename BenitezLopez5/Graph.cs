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
using System.Text.Json;

//Actual Graph Class
public class Graph: IProcessData, ISearchAlgorithm
{
    //Variable
    private List<Node> _nodes;
    public Queue<Node> Queue{get; set;}
    public Stack<Node> Stack{get; set;}

    /****************************************************************************************************
    *** METHOD: Overloaded/Default Constructor
    *****************************************************************************************************
    *** DESCRIPTION : This method is the overloaded constructor, when creating a new object, the 
    *** object will have the pathway of the file being imported by reading the data in and creating a new
    *** graph with the information
    *** INPUT ARGS : Inputs are string path
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : Inputs are string path no outputs
    *** RETURN : No Return Type
    ****************************************************************************************************/
    public Graph(string path)
    {    
        //Read the data and see if it is legit   
        ReadData(path);
    }
    
    /**************************************************************************************************
    *** METHOD: ResetVisitedSet
    ***************************************************************************************************
    *** DESCRIPTION : This method is in charge of making the list of _nodes.WasVistied sign into false.
    *** This is done in order to be able to do the BreadthFS and DepthFS algorithm all over again. If this
    *** isn't done, the algorithms don't work. 
    *** INPUT ARGS : None
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : None
    *** RETURN : None
    **************************************************************************************************/
    private void ResetVistedSet()
    {
        //Go through the list and make each node false
        foreach(Node index in _nodes)
            index.WasVisited = false;
    }

    /**************************************************************************************************
    *** METHOD: FindAdjacentUnvisitedNode
    ***************************************************************************************************
    *** DESCRIPTION : This method is in charge of checking if the node adjacent to the node we are currently
    *** on can be visited. The entire methodology is that the system checks if there exists an adjacent node
    ***, if there is, then check if it is actually adjacent to the current node and then finally check if it
    *** has been visited. 
    *** INPUT ARGS : Node node
    *** OUTPUT ARGS : Node
    *** IN/OUT ARGS : Input is Node node and output of Node
    *** RETURN : Node
    **************************************************************************************************/
    private Node? FindAdjacentUnvisitedNode(Node node)
    {
        //Check if there is an adjacent node
        if(node.AdjacentNodes != null) 
            //Try to find the next adjacent node in the list
            for (int i = 0; i < node.AdjacentNodes.Count; i++)
            {
                if(node.AdjacentNodes[i] == false || _nodes[i].WasVisited == true)
                    continue;
                else
                    return _nodes[i];
            }

        return null;
    }

    /******************************************************************************************************
    *** METHOD: ViewNode
    ******************************************************************************************************
    *** DESCRIPTION : This method is in charge of displaying the the value at the specified node Id
    *** INPUT ARGS : Node node
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : Input is Node node and no outputs
    *** RETURN : No return type
    *****************************************************************************************************/
    private static void ViewNode(Node node)
    {
        //Only print if there is something there
        if(node != null)
            Console.Write($"{node.Id} ");
    }

    /**************************************************************************************************
    *** METHOD: BreadthFS
    ***************************************************************************************************
    *** DESCRIPTION : This method is in charge of running the algortihm of the BreadthFS. This algorithm
    *** works by going one level at a time and going left to right. This is all achieved by using the
    *** Queue data type to be able to use the FIFO method.
    *** INPUT ARGS : int start
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : input is int start and no output
    *** RETURN : None
    **************************************************************************************************/
    public void BreadthFS(int start)
    {
        //Create temporary and Queue
        Queue = new Queue<Node>();
        Node temporary = new Node();

        //Start the queue visited
        _nodes[start].WasVisited = true;
        Queue.Enqueue(_nodes[start]);

        //Do the algorithm till the Queue is done
        while(Queue.Any())
        {
            //Dequeue Queue and vew temporary
            temporary = Queue.Dequeue();
            ViewNode(temporary);

            //Find the next adjacent node
            while (FindAdjacentUnvisitedNode(temporary) != null)
            {
                Queue.Enqueue(FindAdjacentUnvisitedNode(temporary));

                FindAdjacentUnvisitedNode(temporary).WasVisited = true;
            }
        }

        //Reset Visited Nodes
        ResetVistedSet();
    }

    /**************************************************************************************************
    *** METHOD: DepthFS
    ***************************************************************************************************
    *** DESCRIPTION : This method is in charge of running the algortihm of the DepthFS. This algorithm
    *** works by going all the way down to tree and taking care of the lower branches together. It will slowly
    *** traverse its way up, but if it can go lower to an undiscovered portion it will take care of that.
    *** This method is taken care of by a Stack data type by using the LIFO logic.
    *** INPUT ARGS : int start
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : input is int start and no output
    *** RETURN : None
    **************************************************************************************************/
    public void DepthFS(int start)
    {
        //Create a new stack and temporary
        Stack = new Stack<Node>();
        Node temporary = new Node();

        //Push onto stack beginnings
        Stack.Push(_nodes[start]);

        //Continue DepthFS algorithm till Stack empty
        while (Stack.Any())
        {
            temporary = Stack.Peek();

            //Cases if either temporary or adjacents are null
            //If temporary false, make them true then push to stack next adjacent if there is adjacent
            //If temporary true, go to next node if there is push, if not pop
            if(!temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
            {
                temporary.WasVisited = true;
                ViewNode(temporary);

                Stack.Push(FindAdjacentUnvisitedNode(temporary));
            }
            if(!temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) == null)
            {
                temporary.WasVisited = true;
                ViewNode(temporary);

                Stack.Pop();
            }
            if(temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) == null)
                temporary = Stack.Pop();
            if(temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
                Stack.Push(FindAdjacentUnvisitedNode(temporary));
        }

        //Reset visited set
        ResetVistedSet();
    }

    /***************************************************************************************************
    *** METHOD: ReadData
    ****************************************************************************************************
    *** DESCRIPTION : This method is to complete the interface contract from IProcessData. This function
    *** takes care of reading information from a file if and only if it doesn't contain an exception error.
    *** With all the data handling techniques thre are catch blocks ready to catch any error that may happen.
    *** INPUT ARGS : String path
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : Inputs are string path and no outputs
    *** RETURN : No return type
    **************************************************************************************************/
    public void ReadData(string path)
    {
        //Check if you can actually use the JSON file
        try
        {
            string json = File.ReadAllText(path);
            _nodes = JsonSerializer.Deserialize<List<Node>>(json)!;

            //Reserialize information
            json = JsonSerializer.Serialize<List<Node>>(_nodes);
            File.WriteAllText(path, json);
        }
        //If the file isn't found
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found: {path}");
        }
        //If JSON can't be read
        catch (JsonException)
        {
            Console.WriteLine($"Error reading data from file: {path}");
        }
        //If an unknown error happens
        catch(Exception ex)
        {
            Console.WriteLine("\nIt looks like there was an unkown issue opening the json file located at file path: " + path + "");
            Console.WriteLine("Error Message: " + ex.Message + "\n");
        }
    }
}