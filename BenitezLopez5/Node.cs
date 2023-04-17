namespace GraphNS;

public class Node
{
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}

    public List<Boolean>? AdjNodes;

    public List<Boolean> AdjacentNodes
    {
        get{return AdjNodes;}
        set{AdjNodes = value;}
    }

    public Node(List<Boolean> AdjacentNodes = null, int Id = -1, Boolean WasVisited = false)
    {

        if (AdjacentNodes == null)
            this.AdjacentNodes = new List<Boolean>();
        else
        {
            this.AdjacentNodes = new List<Boolean>();
            for (int i = 0; i < AdjacentNodes.Count; i++)
            {
                this.AdjacentNodes.Add(AdjacentNodes[i]);
            }
            this.Id = Id;
            this.WasVisited = WasVisited;

        }
    }
}