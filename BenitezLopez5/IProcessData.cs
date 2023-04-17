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

//Decleration of Interface IProcessData used to be the interface file for the program
public interface IProcessData
{
    /***************************************************************************************************
    *** METHOD: ReadData
    ****************************************************************************************************
    *** DESCRIPTION : This method is located in the public interface as a sort of body of the interface. 
    *** The actual implementation of the function is found in the Graph file. This is the data reading 
    *** function. 
    *** INPUT ARGS : String path
    *** OUTPUT ARGS : None
    *** IN/OUT ARGS : Inputs are string path and no outputs
    *** RETURN : No return type
    **************************************************************************************************/
    public abstract void ReadData(string path);
}