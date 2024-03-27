Graph graph = Graph.BuildGraphFromTopology("text.txt");
Dictionary<int, int> d = Dijkstra.ShortestPath(graph, 1);
Console.WriteLine($"Text");
