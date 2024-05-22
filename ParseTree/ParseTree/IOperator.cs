// <copyright file="IOperator.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTree;

/// <summary>
/// Interface of operator in parse tree.
/// </summary>
public interface IOperator
{
    /// <summary>
    /// Gets or sets left expression.
    /// </summary>
    public IParseTreeElement LeftChild { get; set; }

    /// <summary>
    /// Gets or sets right expression.
    /// </summary>
    public IParseTreeElement RightChild { get; set; }
}