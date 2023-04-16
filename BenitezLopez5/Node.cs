namespace GraphNS;

public class Node
{
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}

    public List<Boolean>? adjNodes;

    public List<Boolean> AdjacentNodes
    {
        get
        {
            return adjNodes; 
        } 
        set
        {
            adjNodes = value;
        }
    }

    public Node(List<Boolean> AdjNodes = null, int Id = -1, Boolean WasVisited = false)
    {

        if (AdjNodes == null)
            AdjacentNodes = new List<Boolean>();
        else
        {
            AdjacentNodes = new List<Boolean>();
            for (int i = 0; i < adjNodes.Count; i++)
            {
                AdjacentNodes.Add(adjNodes[i]);
            }

            this.Id = Id;
            this.WasVisited = WasVisited;
        }
    }
}