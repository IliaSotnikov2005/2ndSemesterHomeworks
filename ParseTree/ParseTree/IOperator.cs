// <copyright file="IOperator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

/// <summary>
/// Interface for opetarors.
/// </summary>
public interface IOperator : IVertexContent
{
    /// <summary>
    /// Calculates an expression consisting of two operands.
    /// </summary>
    /// <param name="operand1">The first operand.</param>
    /// <param name="operand2">The second operand.</param>
    /// <returns>Operand object.</returns>
    public Operand Calculate(Operand operand1, Operand operand2);
}
