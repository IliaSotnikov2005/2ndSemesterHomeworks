// <copyright file="Vertex.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

/// <summary>
/// Represents a vertex in the graph.
/// </summary>
public record Vertex(int router)
{
    /// <summary>
    /// Gets the ID of the router.
    /// </summary>
    public int Router { get; private set; } = router;
}