// Console.WriteLine("Enter the path to file with tree: ");
// string filePath = Console.ReadLine()?? string.Empty;
using ParseTreeSpace;

ParseTree tree = new();
tree.root = new ParseTree.Edge(new Plus());
tree.root.LeftChild = new ParseTree.Edge(new Operand(1));
tree.root.RightChild = new ParseTree.Edge(new Operand(3));
tree.Print();