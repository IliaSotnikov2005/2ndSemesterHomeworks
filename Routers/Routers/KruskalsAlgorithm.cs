public static class KruskalsAlgorithm
{
    public static Graph Run(Graph graph)
    {
        var sortedEdges = graph.Edges.OrderByDescending(e => e.bandwidth).ToList();
        
        return graph;
    }
}