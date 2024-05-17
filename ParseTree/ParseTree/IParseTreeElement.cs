// <copyright file="IParseTreeElement.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

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
}
