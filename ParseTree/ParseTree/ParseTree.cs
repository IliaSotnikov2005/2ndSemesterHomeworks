using System.Numerics;
using System.Text;

namespace ParseTreeSpace
{
    public class ParseTree
    {
        public Edge? root = null; // TODO change public -> private readonly

        public class Edge(IEdgeContent content) // TODO change public -> private
        {
            public IEdgeContent Content { get; set; } = content;
            public Edge? LeftChild { get; set; } = null;
            public Edge? RightChild {get; set; } = null;

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
                return Content.ToString();
            }

            public void Print()
            {
                if (this.LeftChild == null)
                {
                    Console.Write($" {this.ToString()} ");
                }
                else
                {
                    Console.Write($"( {this.ToString()} ");
                    this.LeftChild.Print();
                    this.RightChild.Print();
                    Console.Write(")");
                }
            }
        }

        public void BuildFromFile()
        {
        
        }

        public void Print()
        {
            root.Print();
        }

        public override string ToString()
        {
            return "";
        }

        private void BuildTree(string expression)
        {

        }
    }
}