public static class KruskalsAlgorithm
{
    public static Graph Run(Graph graph)
    {
        var sortedEdges = graph.Edges.OrderByDescending(e => e.Bandwidth).ToList();
        
        var resultGraph = new Graph();

        foreach (var edge in sortedEdges)
        {
            if (resultGraph.Vertices.Contains(edge.Vertex1) && resultGraph.Vertices.Contains(edge.Vertex2))
            {
                continue;
            }

            resultGraph.AddEdge(edge);
        }

        return resultGraph;
    }
}