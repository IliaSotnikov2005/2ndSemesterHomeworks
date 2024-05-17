// <copyright file="ParseTree.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace;

using System.Text;
using System.Text.RegularExpressions;

/// <summary>
/// Parse tree class.
/// </summary>
public class ParseTree()
{
    private IParseTreeElement? Root { get; set; }

    /// <summary>
    /// Builds parse tree from file.
    /// </summary>
    /// <param name="filePath">Path to file with expression.</param>
    /// <returns>A ParseTree object.</returns>
    /// <exception cref="ArgumentException">If can't build parse tree.</exception>
    public ParseTree BuildTreeFromFile(string filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileNotFoundException("File with expression is not found.");
        }

        string[] expression = Regex.Replace(File.ReadAllText(filePath), @"[()\s]+", " ").Trim().Split(" ");

        this.Root = BuildTree(ref expression);

        return this;
    }

    /// <summary>
    /// Evaluates expression in the tree.
    /// </summary>
    /// <returns>Result of calculus.</returns>
    /// <exception cref="ArgumentException">If content of vertex is not operand or operator.</exception>
    public int Evaluate()
    {
        return this.Root != null ? this.Root.Evaluate().Value : 0;
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        if (this.Root == null)
        {
            return string.Empty;
        }

        var sb = new StringBuilder();
        var stack = new Stack<IParseTreeElement>();
        stack.Push(this.Root);

        while (stack.Count > 0)
        {
            IParseTreeElement current = stack.Pop();

            if (current is Operand)
            {
                sb.Append($" {current} ");
            }
            else if (current is IOperator currentOperator)
            {
                sb.Append($"( {currentOperator} ");
                stack.Push(currentOperator.RightChild);
                stack.Push(currentOperator.LeftChild);
            }

            if (stack.Count % 2 == 1 && current is not IOperator)
            {
                sb.Append(')');
            }
        }

        sb.Append(')');
        return sb.ToString();
    }

    private static IParseTreeElement BuildTree(ref string[] expression) // TODO ref??
    {
        if (expression.Length == 0)
        {
            throw new ArgumentException("Tree is invalid");
        }

        string element = expression[0];
        expression = expression[1..];
        if (int.TryParse(element, out int number))
        {
            return new Operand(number);
        }

        switch (element)
        {
            case "+":
                {
                    var vertex = new Plus(BuildTree(ref expression), BuildTree(ref expression));
                    return vertex;
                }

            case "-":
                {
                    var vertex = new Minus(BuildTree(ref expression), BuildTree(ref expression));
                    return vertex;
                }

            case "*":
                {
                    var vertex = new Multiplication(BuildTree(ref expression), BuildTree(ref expression));
                    return vertex;
                }

            case "/":
                {
                    var vertex = new Division(BuildTree(ref expression), BuildTree(ref expression));
                    return vertex;
                }

            default:
                {
                    throw new ArgumentException("Invalid operator");
                }
        }
    }
}