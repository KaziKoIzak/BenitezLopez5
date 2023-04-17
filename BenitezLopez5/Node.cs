namespace GraphNS;

public class Node
{
    public int Id{get; set;}
    public Boolean WasVisited{get; set;}

    public List<Boolean>? AdjacentNodes{get; set;}
}