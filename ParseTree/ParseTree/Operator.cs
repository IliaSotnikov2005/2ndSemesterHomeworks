// <copyright file="Operator.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

/// <summary>
/// Plus class.
/// </summary>
public class Plus(IParseTreeElement leftChild, IParseTreeElement rightChild) : IParseTreeElement, IOperator
{
    /// <summary>
    /// Gets or sets left expression.
    /// </summary>
    public IParseTreeElement LeftChild { get; set; } = leftChild;

    /// <summary>
    /// Gets or sets right expression.
    /// </summary>
    public IParseTreeElement RightChild { get; set; } = rightChild;

    /// <inheritdoc/>
    public Operand Evaluate()
    {
        Operand leftValue = this.LeftChild.Evaluate();
        Operand rightValue = this.RightChild.Evaluate();

        return leftValue + rightValue;
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
public class Minus(IParseTreeElement leftChild, IParseTreeElement rightChild) : IParseTreeElement, IOperator
{
    /// <summary>
    /// Gets or sets left expression.
    /// </summary>
    public IParseTreeElement LeftChild { get; set; } = leftChild;

    /// <summary>
    /// Gets or sets right expression.
    /// </summary>
    public IParseTreeElement RightChild { get; set; } = rightChild;

    /// <inheritdoc/>
    public Operand Evaluate()
    {
        Operand leftValue = this.LeftChild.Evaluate();
        Operand rightValue = this.RightChild.Evaluate();

        return leftValue - rightValue;
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
public class Multiplication(IParseTreeElement leftChild, IParseTreeElement rightChild) : IParseTreeElement, IOperator
{
    /// <summary>
    /// Gets or sets left expression.
    /// </summary>
    public IParseTreeElement LeftChild { get; set; } = leftChild;

    /// <summary>
    /// Gets or sets right expression.
    /// </summary>
    public IParseTreeElement RightChild { get; set; } = rightChild;

    /// <inheritdoc/>
    public Operand Evaluate()
    {
        Operand leftValue = this.LeftChild.Evaluate();
        Operand rightValue = this.RightChild.Evaluate();

        return leftValue * rightValue;
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
public class Division(IParseTreeElement leftChild, IParseTreeElement rightChild) : IParseTreeElement, IOperator
{
    /// <summary>
    /// Gets or sets left expression.
    /// </summary>
    public IParseTreeElement LeftChild { get; set; } = leftChild;

    /// <summary>
    /// Gets or sets right expression.
    /// </summary>
    public IParseTreeElement RightChild { get; set; } = rightChild;

    /// <inheritdoc/>
    /// <exception cref="DivideByZeroException">If division by zero.</exception>
    public Operand Evaluate()
    {
        Operand leftValue = this.LeftChild.Evaluate();
        Operand rightValue = this.RightChild.Evaluate();

        if (rightValue.Value == 0)
        {
            throw new DivideByZeroException();
        }

        return leftValue / rightValue;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        return "/";
    }
}