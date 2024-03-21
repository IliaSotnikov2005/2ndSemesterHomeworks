// <copyright file="Operator.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

/// <summary>
/// Plus class.
/// </summary>
public class Plus : IOperator
{
    /// <inheritdoc/>
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 + operand2;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return "+";
    }
}

/// <summary>
/// Minus class.
/// </summary>
public class Minus : IOperator
{
    /// <inheritdoc/>
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 - operand2;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return "-";
    }
}

/// <summary>
/// Multiplicatoin class.
/// </summary>
public class Multiplication : IOperator
{
    /// <inheritdoc/>
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        return operand1 * operand2;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return "*";
    }
}

/// <summary>
/// Division class.
/// </summary>
public class Division : IOperator
{
    /// <inheritdoc/>
    /// <exception cref="DivideByZeroException">If division by zero.</exception>
    public Operand Calculate(Operand operand1, Operand operand2)
    {
        if (operand2.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return operand1 / operand2;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return "/";
    }
}