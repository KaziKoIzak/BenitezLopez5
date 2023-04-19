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

//The Node Class (Reference for List)
public class Node
{
    //Variables
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}
    public List<Boolean>? AdjacentNodes{get; set;}

    /****************************************************************************************************
    *** METHOD: Overloaded/Default Constructor
    *****************************************************************************************************
    *** DESCRIPTION : This method is the overloaded constructor, when creating a new object, the 
    *** object will bet the default of a node will force each node with an optional parameter if it is
    *** required to
    *** INPUT ARGS : List<Boolean> AdjacentNodes, int Id, and Boolean WasVisited
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : Inputs are List<Boolean> AdjacentNodes, int Id, and Boolean WasVisited no outputs
    *** RETURN : No Return Type
    ****************************************************************************************************/
    public Node(List<Boolean>? AdjacentNodes = null, int Id = -1, Boolean WasVisited = false)
    {
        this.AdjacentNodes = AdjacentNodes;
        this.Id = Id;
        this.WasVisited = WasVisited;
    }
}