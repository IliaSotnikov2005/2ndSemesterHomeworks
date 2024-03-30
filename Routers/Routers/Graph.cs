using System.Text;

public class Graph
{
    public HashSet<Vertex> Vertices { get; private set; } = [];

    public List<Edge> Edges { get; private set; } = [];

    public void BuildGraphFromTopology(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException();
        }

        string[] topology = File.ReadAllText(filename).Trim('\n').Split("\n");

        foreach (var input in topology)
        {
            ParseInput(input);
        }
    }

    public void AddEdge(Edge edge)
    {
        Edges.Add(edge);
        Vertices.Add(edge.Vertex1);
        Vertices.Add(edge.Vertex2);
    }

    private void ParseInput(string input)
    {
        string[] parts = input.Split(':');
        var router1 = new Vertex(int.Parse(parts[0]));
        Vertices.Add(router1);


        string[] connections = parts[1].Split(',');

        foreach (string connection in connections)
        {
            string[] routerAndBandwidth = connection.Trim().Split(' ');
            var router2 = new Vertex(int.Parse(routerAndBandwidth[0]));
            Vertices.Add(router2);

            int bandwidth = int.Parse(routerAndBandwidth[1].Trim('(', ')'));

            var edge = new Edge(router1, router2, bandwidth);
            Edges.Add(edge);
        }
    }

    public record Vertex(int router)
    {
        public int Router { get; set; } = router;
    }

    public record Edge(Vertex vertex1, Vertex vertex2, int bandwidth)
    {
        public Vertex Vertex1 { get; set; } = vertex1;
        public Vertex Vertex2 { get; set; } = vertex2;

        public int Bandwidth { get; set; } = bandwidth;
    }

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
}