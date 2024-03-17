using System.Numerics;
using System.Text;

namespace ParseTreeSpace
{
    public class ParseTree
    {
        private Edge? root = null;

        class Edge(Operand operand)
        {
            public Operand Operand { get; set; } = operand;
            public Edge? LeftChild { get; set; } = null;
            public Edge? RightChild {get; set; } = null;
        }

        public void BuildFromFile()
        {
        
        }

        public void Print()
        {
            Console.WriteLine(this);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            Edge? current = root;

            return "";
        }

        public int Evaluate()
        {
            return 1;
        }

        private void BuildTree(string expression)
        {

        }
    }
}