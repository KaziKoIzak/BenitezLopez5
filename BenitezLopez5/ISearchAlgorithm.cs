namespace GraphNS;

public interface ISearchAlgorithm
{
    public Queue<Node> Queue
    {
            get { return Queue; }
            set { Queue = value; }
    }
    public Stack<Node> Stack
    {
        get { return Stack; }
        set { Stack = value; }
    }
    
    public abstract void BreadthFS(int start);

    public abstract void DepthFS(int start);
}