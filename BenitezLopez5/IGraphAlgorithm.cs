namespace GraphNS;

public interface IGraphAlgorithm
{
    public Queue<Node> Queue{get; set;}
    public Stack<Node> Stack{get; set;}
    
    public abstract void BreadthFS(int start);

    public abstract void DepthFS(int start);
}