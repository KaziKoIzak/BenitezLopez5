namespace GraphNS;

public class Node
{
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}

    public List<Boolean> AdjacentNodes{get; set;}

    public Node(List<Boolean> AdjacentNodes = null, int Id = -1, Boolean WasVisited = false)
    {
        this.AdjacentNodes = new List<Boolean>();

        if(AdjacentNodes != null)
        {
            for (int i = 0; i < AdjacentNodes.Count; i++)
                this.AdjacentNodes.Add(AdjacentNodes[i]);
                
            this.Id = Id;
            this.WasVisited = WasVisited;
        }
    }
}