// <copyright file="IParseTreeElement.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTree;

/// <summary>
/// Element of parse tree.
/// </summary>
public interface IParseTreeElement
{
    /// <summary>
    /// Evaluates tree element.
    /// </summary>
    /// <returns>The resulting operand.</returns>
    public Operand Evaluate();

    /// <summary>
    /// Gives string representation of the object.
    /// </summary>
    /// <returns>String representation of the object.</returns>
    public string ToString();
}
