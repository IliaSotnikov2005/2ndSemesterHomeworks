// <copyright file="Operand.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTree;

/// <summary>
/// Operand class.
/// </summary>
public class Operand(int value) : IParseTreeElement
{
    /// <summary>
    /// Gets or sets the value of operand.
    /// </summary>
    /// <value>
    /// The value of operand.
    /// </value>
    public int Value { get; set; } = value;

    /// <summary>
    /// Adds two terms.
    /// </summary>
    /// <param name="operand1">Nubmer 1.</param>
    /// <param name="operand2">Number 2.</param>
    /// <returns>Sum.</returns>
    public static Operand operator +(Operand operand1, Operand operand2) => new (operand1.Value + operand2.Value);

    /// <summary>
    /// Subtracts two numbers.
    /// </summary>
    /// <param name="operand1">Nubmer 1.</param>
    /// <param name="operand2">Number 2.</param>
    /// <returns>Substraction.</returns>
    public static Operand operator -(Operand operand1, Operand operand2) => new (operand1.Value - operand2.Value);

    /// <summary>
    /// Multiplies two numbers.
    /// </summary>
    /// <param name="operand1">Nubmer 1.</param>
    /// <param name="operand2">Number 2.</param>
    /// <returns>Product.</returns>
    public static Operand operator *(Operand operand1, Operand operand2) => new (operand1.Value * operand2.Value);

    /// <summary>
    /// Divides two numbers.
    /// </summary>
    /// <param name="operand1">Nubmer 1.</param>
    /// <param name="operand2">Number 2.</param>
    /// <returns>Division.</returns>
    public static Operand operator /(Operand operand1, Operand operand2)
    {
        if (operand2.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return new (operand1.Value / operand2.Value);
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return this.Value.ToString();
    }

    /// <inheritdoc/>
    public Operand Evaluate() => this;
}