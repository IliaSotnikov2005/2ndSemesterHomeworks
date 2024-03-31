// <copyright file="Program.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace RoutersGraph;

/// <summary>
/// Program class.
/// </summary>
public static class Program
{
    /// <summary>
    /// Entry point for program.
    /// </summary>
    public static void Main()
    {
        Graph graph = new Graph();
        graph.BuildGraphFromTopology("text.txt");
        Console.WriteLine($"Input topology:\n{graph}");

        var newGraph = KruskalsAlgorithm.Run(graph);
        if (!DFS.CheckThatAllVerticesReachable(newGraph))
        {
            Console.Error.WriteLine($"Not all vertices reachable");
            return;
        }

        Console.WriteLine($"New topology:\n{newGraph}");
    }
}
