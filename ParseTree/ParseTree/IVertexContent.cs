// <copyright file="IVertexContent.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

/// <summary>
/// Interface for content of the ParseTree nodes.
/// </summary>
public interface IVertexContent
{
    /// <summary>
    /// Gives string representation of the object.
    /// </summary>
    /// <returns>String representation of the object.</returns>
    public string ToString();
}