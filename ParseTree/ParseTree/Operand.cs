// <copyright file="Operand.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

/// <summary>
/// Operand class.
/// </summary>
#pragma warning disable SA1009 // Closing parenthesis should be spaced correctly
public class Operand(int value) : IEdgeContent
#pragma warning restore SA1009 // Closing parenthesis should be spaced correctly
{
    /// <summary>
    /// Gets or sets the value of operand.
    /// </summary>
    /// <value>
    /// The value of operand.
    /// </value>
    public int Value { get; set; } = value;

    public static Operand operator +(Operand operand1, Operand operand2) => new (operand1.Value + operand2.Value);

    public static Operand operator -(Operand operand1, Operand operand2) => new (operand1.Value - operand2.Value);

    public static Operand operator *(Operand operand1, Operand operand2) => new (operand1.Value * operand2.Value);

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
}