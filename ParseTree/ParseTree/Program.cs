using ParseTreeSpace;

ParseTree tree = ParseTree.BuildTreeFromFile("expression.txt");
Console.WriteLine(tree.Evaluate());
Console.WriteLine(tree);
