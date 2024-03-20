using System.Text;

namespace ParseTreeSpace
{
    public class ParseTree(IEdgeContent content) // TODO change public -> private
    {
        public IEdgeContent Content { get; set; } = content;
        public ParseTree? LeftChild { get; set; } = null;
        public ParseTree? RightChild { get; set; } = null;

        public Operand Evaluate()
        {
            if (Content is Operand operand)
            {
                return operand;
            }
            else if (Content is IOperator op)
            {
                Operand leftValue = LeftChild?.Evaluate() ?? new Operand(0);
                Operand rightValue = RightChild?.Evaluate() ?? new Operand(0);

                return op.Calculate(leftValue, rightValue);
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            Stack<ParseTree> stack = new Stack<ParseTree>();
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
                    sb.Append(")");
                }
            }

            sb.Append(")");
            return sb.ToString();
        }

        private static ParseTree? buildTree(ref string[] expression)
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
                        ParseTree edge = new(new Plus());
                        edge.LeftChild = buildTree(ref expression);
                        edge.RightChild = buildTree(ref expression);
                        return edge;
                    }
                case "-":
                    {
                        ParseTree edge = new(new Minus());
                        edge.LeftChild = buildTree(ref expression);
                        edge.RightChild = buildTree(ref expression);
                        return edge;
                    }
                case "*":
                    {
                        ParseTree edge = new(new Multiplication());
                        edge.LeftChild = buildTree(ref expression);
                        edge.RightChild = buildTree(ref expression);
                        return edge;
                    }
                case "/":
                    {
                        ParseTree edge = new(new Division());
                        edge.LeftChild = buildTree(ref expression);
                        edge.RightChild = buildTree(ref expression);
                        return edge;
                    }
                default:
                    {
                        throw new ArgumentException();
                    }
            }
        }

        public static ParseTree buildTreeFromFile(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("File with expression is not found.");
            }
            string input = File.ReadAllText(filePath);
            input = input.Replace("( ", "").Replace(") ", "")[..^2];
            string[] expression = input.Split(" ");

            ParseTree? root = buildTree(ref expression) ?? throw new ArgumentException();
            return root;
        }
    }
}