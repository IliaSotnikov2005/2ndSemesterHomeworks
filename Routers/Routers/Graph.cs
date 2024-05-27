// <copyright file="Graph.cs" company="IlyaSotnikov">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Routers;

using System.Text;

/// <summary>
/// Graph class.
/// </summary>
public class Graph
{
    /// <summary>
    /// Gets the set of vertices in the graph.
    /// </summary>
    public HashSet<Vertex> Vertices { get; private set; } = [];

    /// <summary>
    /// Gets the list of edges in the graph.
    /// </summary>
    public List<Edge> Edges { get; private set; } = [];

    /// <summary>
    /// Builds the graph from the topology defined in the specified file.
    /// </summary>
    /// <param name="filename">The name of the file containing the topology.</param>
    /// <exception cref="FileIsEmptyException">Throws if file is empty.</exception>
    public void BuildGraphFromTopology(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException();
        }

        string[] topology = File.ReadAllText(filename).Trim('\n').Split("\n");

        if (topology[0] == string.Empty)
        {
            throw new FileIsEmptyException();
        }

        foreach (var input in topology)
        {
            this.ParseInput(input);
        }
    }

    /// <summary>
    /// Adds an edge to the graph.
    /// </summary>
    /// <param name="edge">The edge to add.</param>
    public void AddEdge(Edge edge)
    {
        this.Edges.Add(edge);
        this.Vertices.Add(edge.Vertex1);
        this.Vertices.Add(edge.Vertex2);
    }

    /// <summary>
    /// Writes the contents of the graph to a file.
    /// </summary>
    /// <param name="filename">The name of the file to write to.</param>
    public void WriteToFile(string filename)
    {
        File.WriteAllText(filename, this.ToString());
    }

    /// <inheritdoc/>
    public override string ToString()
    {
        var sb = new StringBuilder();

        var sortedEdges = this.Edges.OrderBy(e => e.Vertex1.Router).ToList();

        int i = 0;
        while (i < sortedEdges.Count)
        {
            sb.Append($"{sortedEdges[i].Vertex1.Router}: ");

            while (i + 1 < sortedEdges.Count)
            {
                if (sortedEdges[i].Vertex1 != sortedEdges[i + 1].Vertex1)
                {
                    break;
                }

                sb.Append($"{sortedEdges[i].Vertex2.Router} ({sortedEdges[i].Bandwidth}), ");
                ++i;
            }

            sb.Append($"{sortedEdges[i].Vertex2.Router} ({sortedEdges[i].Bandwidth})\n");
            ++i;
        }

        return sb.ToString();
    }

    private void ParseInput(string input)
    {
        string[] parts = input.Split(':');
        var router1 = new Vertex(int.Parse(parts[0]));
        this.Vertices.Add(router1);

        string[] connections = parts[1].Split(',');

        foreach (string connection in connections)
        {
            string[] routerAndBandwidth = connection.Trim().Split(' ');
            var router2 = new Vertex(int.Parse(routerAndBandwidth[0]));
            this.Vertices.Add(router2);

            int bandwidth = int.Parse(routerAndBandwidth[1].Trim('(', ')'));

            var edge = new Edge(router1, router2, bandwidth);
            this.Edges.Add(edge);
        }
    }
}