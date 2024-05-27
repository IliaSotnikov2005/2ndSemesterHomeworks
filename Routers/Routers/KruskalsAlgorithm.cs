// <copyright file="KruskalsAlgorithm.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Kruskal's algorithm class.
/// </summary>
public static class KruskalsAlgorithm
{
    /// <summary>
    /// Runs the Kruskal's algorithm on the given graph.
    /// </summary>
    /// <param name="graph">The input graph.</param>
    /// <returns>The maximum spanning tree of the input graph.</returns>
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