namespace GraphNS;
using System.Text.Json;


public class Graph: IProcessData, ISearchAlgorithm
{
    private List<Node>? _nodes;
    public Queue<Node> Queue{get; set;}
    public Stack<Node> Stack{get; set;}

    public Graph(string path)
    {       
         _nodes = new List<Node>();

        ReadData(path);
    }
    
    private void ResetVistedSet()
    {
        foreach(Node n in _nodes)
            n.WasVisited = false;
    }

    private Node? FindAdjacentUnvisitedNode(Node node)
    {

    }

    private static void ViewNode(Node node)
    {
        if(node == null)
            return;
        else
            Console.Write($"{node.Id} ");    
    }

    public void BreadthFS(int start)
    {

    }

    public void DepthFS(int start)
    {
        
    }

    public void ReadData(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            List<Node> nodeDataList = JsonSerializer.Deserialize<List<Node>>(json);

            foreach (Node nodeData in nodeDataList)
            {
               Node node = new Node(nodeData.Id);

                foreach (int adjacentNodeId in nodeData.AdjacentNodes)
                {
                    Node adjacentNode = _nodes.Find(n => n.Id == adjacentNodeId);

                    if (adjacentNode == null)
                    {
                        adjacentNode = new Node(adjacentNodeId);
                        _nodes.Add(adjacentNode);
                    }

                    node.AdjacentNodes.Add(adjacentNode);
                }

                _nodes.Add(node);
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File not found: {path}");
        }
        catch (JsonException)
        {
            Console.WriteLine($"Error reading data from file: {path}");
        }
    }
}