namespace GraphNS;

public class Graph: IProcessData, IGraphAlgorithm
{
    private List<Node>? _nodes;
    public Queue<Node> Queue{get; set;}
    public Stack<Node> Stack{get; set;}

    public Graph()
    {

    }
    
    private void ResetVistedSet()
    {
        for(int i = 0; i < _nodes.Count; i++)
            _nodes[i].WasVisited = false;
    }

    private Node? FindAdjacentUnvisitedNode(Node node)
    {

    }

    private static void ViewNode(Node node)
    {
        Console.Write($"{node} ");
    }

    public void BreadthFS(int start)
    {

    }

    public void DepthFS(int start)
    {

    }

    public void ReadData(string path)
    {

    }
}