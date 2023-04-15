namespace GraphNS;
using System.Text.Json;


public class Graph: IProcessData, ISearchAlgorithm
{
    private List<Node> _nodes{get; set;}
    public Queue<Node> Queue{get; set;}
    public Stack<Node> Stack{get; set;}

    public Graph(string path)
    {       
        _nodes = new List<Node>();

        ReadData(path);
    }
    
    private void ResetVistedSet()
    {
        foreach(Node index in _nodes)
            index.WasVisited = false;
    }

    private Node? FindAdjacentUnvisitedNode(Node node)
    {
        if (node.AdjacentNodes == null)
            return null;
        else 
        {
            for (int i = 0; i < node.AdjacentNodes.Count; i++)
            {
                if (_nodes[i].Id == node.Id)
                    continue;
                if (node.AdjacentNodes[i] == true)
                    if (_nodes[i].WasVisited == false)
                        return _nodes[i];
            }

            return null;
        }
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
        Queue = new Queue<Node>();
        Node temporary = new Node();

        _nodes[start].WasVisited = true;

        Queue.Enqueue(_nodes[start]);
    
        while (Queue.Count > 0)
        {
            temporary = Queue.Dequeue();
            ViewNode(temporary);

            while (FindAdjacentUnvisitedNode(temporary) != null)
            {
                Node temp = FindAdjacentUnvisitedNode(temporary);

                Queue.Enqueue(temp);

                temp.WasVisited = true;
            }
        }

        ResetVistedSet();
    }

    public void DepthFS(int start)
    {
        Stack = new Stack<Node>();
        Node temporary = new Node();

        _nodes[start].WasVisited = true;

        if(start == null)
                return;
        else if(_nodes.Count == 0)
                return;

        Stack.Push (_nodes[start]);
        while (Stack.Count > 0)
        {
            temporary = Stack.Peek();

            if (temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) == null)
            {
                temporary = Stack.Pop();
            }

            if (temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
            {
                Node temp = FindAdjacentUnvisitedNode(temporary);

                Stack.Push(temp);
            }

            if (!temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
            {
                temporary.WasVisited = true;

                ViewNode(temporary);

                Node temp = FindAdjacentUnvisitedNode(temporary);

                Stack.Push(temp);

                if (!temporary.WasVisited && FindAdjacentUnvisitedNode (temporary) == null)
                {
                    temporary.WasVisited = true;

                    ViewNode(temporary);

                    Stack.Pop();
                }
            }

            ResetVistedSet();
        }
    }

    public void ReadData(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            var nodeDataList = JsonSerializer.Deserialize<List<Node>>(json);
            _nodes = (List<Node>) nodeDataList;

            json = JsonSerializer.Serialize<List<Node>>(_nodes);

            File.WriteAllText(path, json);
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