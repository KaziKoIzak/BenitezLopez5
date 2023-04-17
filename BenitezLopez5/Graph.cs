namespace GraphNS;
using System.Text.Json;

public class Graph: IProcessData, ISearchAlgorithm
{
    private List<Node> _nodes;
    public Queue<Node> Queue;
    public Stack<Node> Stack;

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

    private Node FindAdjacentUnvisitedNode(Node node)
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

        while(Queue.Any())
        {
            temporary = Queue.Dequeue();
            ViewNode(temporary);

            while (FindAdjacentUnvisitedNode(temporary) != null)
            {
                Queue.Enqueue(FindAdjacentUnvisitedNode(temporary));

                FindAdjacentUnvisitedNode(temporary).WasVisited = true;
            }
        }

        ResetVistedSet();
    }

    public void DepthFS(int start)
    {
        Stack = new Stack<Node>();
        Node temporary = new Node();

        if(start == null)
            return;
        else if(_nodes.Count == 0)
            return;
        else if(start >= _nodes.Count)
            return;

        Stack.Push(_nodes[start]);

        while (Stack.Any())
        {
            temporary = Stack.Peek();

            if (temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) == null)
                temporary = Stack.Pop();
            if (temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
                Stack.Push(FindAdjacentUnvisitedNode(temporary));
            if (!temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) != null)
            {
                temporary.WasVisited = true;
                ViewNode(temporary);

                Stack.Push(FindAdjacentUnvisitedNode(temporary));
            }
            if (!temporary.WasVisited && FindAdjacentUnvisitedNode(temporary) == null)
            {
                temporary.WasVisited = true;
                ViewNode(temporary);
                Stack.Pop();
            }
        }
        ResetVistedSet();
    }

    public void ReadData(string path)
    {
        try
        {
            string json = File.ReadAllText(path);
            _nodes = JsonSerializer.Deserialize<List<Node>>(json)!;

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
        catch(Exception ex)
        {
            Console.WriteLine("\nIt looks like there was an unkown issue opening the json file located at file path: " + path + "");
            Console.WriteLine("Error Message: " + ex.Message + "\n");
        }
    }
}