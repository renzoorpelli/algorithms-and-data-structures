namespace DataStructures.Graph;

public class Graph
{
    // nodes
    private int[] _vertices;
    // connectors
    private int[] _edges;
    private bool _isDirected;
    
    public Graph(bool isDirected = false)
    {
        this._vertices = [];
        this._edges = [];
        this._isDirected = isDirected;
    }
}