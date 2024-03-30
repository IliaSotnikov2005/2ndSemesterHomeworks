Graph graph = new Graph();
graph.BuildGraphFromTopology("text.txt");
Console.WriteLine($"Input topology:\n{graph}");

var newGraph = KruskalsAlgorithm.Run(graph);
Console.WriteLine($"New topology:\n{newGraph}");
