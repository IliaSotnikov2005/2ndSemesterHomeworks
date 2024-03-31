// <copyright file="ParseTree.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ParseTreeSpace
{
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Parse tree class.
    /// </summary>
    public class ParseTree(IVertexContent content)
    {
        private IVertexContent Content { get; set; } = content;

        private ParseTree? LeftChild { get; set; } = null;

        private ParseTree? RightChild { get; set; } = null;

        /// <summary>
        /// Builds parse tree from file.
        /// </summary>
        /// <param name="filePath">Path to file with expression.</param>
        /// <returns>A ParseTree object.</returns>
        /// <exception cref="ArgumentException">If can't build parse tree.</exception>
        public static ParseTree BuildTreeFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File with expression is not found.");
            }

            string input = File.ReadAllText(filePath);
            input = Regex.Replace(Regex.Replace(input, @"[()\s]+", " "), @"\s+", " ").Trim();
            string[] expression = input.Split(" ");

            ParseTree? root = BuildTree(ref expression) ?? throw new ArgumentException();
            return root;
        }

        /// <summary>
        /// Evaluates expression in the tree.
        /// </summary>
        /// <returns>Result of calculus.</returns>
        /// <exception cref="ArgumentException">If content of vertex is not operand or operator.</exception>
        public int Evaluate()
        {
            return this.EvaluateVertices().Value;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            var sb = new StringBuilder();
            var stack = new Stack<ParseTree>();
            stack.Push(this);

            while (stack.Count > 0)
            {
                ParseTree current = stack.Pop();

                if (current.LeftChild == null || current.RightChild == null)
                {
                    sb.Append($" {current.Content} ");
                }
                else
                {
                    sb.Append($"( {current.Content} ");
                    stack.Push(current.RightChild);
                    stack.Push(current.LeftChild);
                }

                if ((stack.Count - 1) % 2 == 0 && current.Content is not IOperator)
                {
                    sb.Append(')');
                }
            }

            sb.Append(')');
            return sb.ToString();
        }

        private static ParseTree? BuildTree(ref string[] expression)
        {
            if (expression.Length == 0)
            {
                return null;
            }

            string element = expression[0];
            expression = expression[1..];
            if (int.TryParse(element, out int number))
            {
                return new ParseTree(new Operand(number));
            }

            switch (element)
            {
                case "+":
                    {
                        ParseTree vertex = new (new Plus())
                        {
                            LeftChild = BuildTree(ref expression),
                            RightChild = BuildTree(ref expression),
                        };
                        return vertex;
                    }

                case "-":
                    {
                        ParseTree vertex = new (new Minus())
                        {
                            LeftChild = BuildTree(ref expression),
                            RightChild = BuildTree(ref expression),
                        };
                        return vertex;
                    }

                case "*":
                    {
                        ParseTree vertex = new (new Multiplication())
                        {
                            LeftChild = BuildTree(ref expression),
                            RightChild = BuildTree(ref expression),
                        };
                        return vertex;
                    }

                case "/":
                    {
                        ParseTree vertex = new (new Division())
                        {
                            LeftChild = BuildTree(ref expression),
                            RightChild = BuildTree(ref expression),
                        };
                        return vertex;
                    }

                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        private Operand EvaluateVertices()
        {
            if (this.Content is Operand operand)
            {
                return operand;
            }
            else if (this.Content is IOperator op)
            {
                Operand leftValue = this.LeftChild?.EvaluateVertices() ?? new Operand(0);
                Operand rightValue = this.RightChild?.EvaluateVertices() ?? new Operand(0);

                return op.Calculate(leftValue, rightValue);
            }
            else
            {
                throw new ArgumentException("Vertex content is not Operator or Operand object.");
            }
        }
    }
}