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
    /// <param name="args">Input file and output file.</param>
    public static void Main(string[] args)
    {
        if (args.Length == 2)
        {
            if (!File.Exists(args[0]))
            {
                Console.WriteLine("File with this pass doesn't exist");
                return;
            }

            Graph graph = new Graph();
            graph.BuildGraphFromTopology(args[0]);

            var newGraph = KruskalsAlgorithm.Run(graph);
            if (!DFS.CheckThatAllVerticesReachable(newGraph))
            {
                Console.Error.WriteLine($"Not all vertices reachable");
                return;
            }

            newGraph.WriteToFile(args[1]);
        }
    }
}
