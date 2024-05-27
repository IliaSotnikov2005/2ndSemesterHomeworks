// <copyright file="Edge.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Represents an edge in the graph.
/// </summary>
public record Edge(Vertex vertex1, Vertex vertex2, int bandwidth)
{
    /// <summary>
    /// Gets the first vertex in the edge.
    /// </summary>
    public Vertex Vertex1 { get; private set; } = vertex1;

    /// <summary>
    /// Gets the second vertex in the edge.
    /// </summary>
    public Vertex Vertex2 { get; private set; } = vertex2;

    /// <summary>
    /// Gets the bandwidth of the edge.
    /// </summary>
    public int Bandwidth { get; private set; } = bandwidth;
}