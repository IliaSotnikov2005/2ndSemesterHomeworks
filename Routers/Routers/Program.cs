Graph graph = new Graph();
graph.BuildGraphFromTopology("text.txt");
KruskalsAlgorithm.Run(graph);
Console.WriteLine($"Text");
