using ParseTreeSpace;

ParseTree tree = ParseTree.buildTreeFromFile("expression.txt");
Console.WriteLine(tree.Evaluate());
Console.WriteLine(tree);
