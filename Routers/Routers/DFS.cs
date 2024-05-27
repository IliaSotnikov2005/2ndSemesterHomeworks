// <copyright file="DFS.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// DFS class.
/// </summary>
public static class DFS
{
    /// <summary>
    /// Checks if all vertices in a graph are reachable from each other using depth-first search.
    /// </summary>
    /// <param name="graph">The graph to be checked.</param>
    /// <returns>True if all vertices are reachable, false otherwise.</returns>
    public static bool CheckThatAllVerticesReachable(Graph graph)
    {
        HashSet<Vertex> visited = [];
        Stack<Vertex> stack = new ();

        Vertex vertex = graph.Vertices.ElementAt(0);

        stack.Push(vertex);
        while (stack.Count > 0)
        {
            Vertex currentVertex = stack.Pop();
            visited.Add(currentVertex);

            foreach (Edge edge in graph.Edges)
            {
                if (edge.Vertex1 == currentVertex && !visited.Contains(edge.Vertex2))
                {
                    stack.Push(edge.Vertex2);
                }
            }
        }

        return visited.Count == graph.Vertices.Count;
    }
}