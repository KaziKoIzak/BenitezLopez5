namespace GraphNS;

public class Node
{
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}
    public List<Boolean> AdjacentNodes{get; set;}

    public Node(List<Boolean> AdjacentNodes = null, int Id = -1, Boolean WasVisited = false)
    {
        this.AdjacentNodes = AdjacentNodes; 
        this.Id = Id;
        this.WasVisited = WasVisited;
    }
}