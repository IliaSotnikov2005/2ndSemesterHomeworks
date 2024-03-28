public class Graph
{
    public HashSet<Vertex> Vertices { get; private set; } = [];

    public List<Edge> Edges { get; private set; } = [];

    public static Dictionary<Vertex, List<Edge>> graph = [];

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

    private void ParseInput(string input)
    {
        string[] parts = input.Split(':');
        var router1 = new Vertex(int.Parse(parts[0]));
        Vertices.Add(router1);
        

        string[] connections = parts[1].Split(',');

        foreach (string connection in connections)
        {
            string[] routerAndBandwidth = connection.Trim().Split(' ');
            Vertex router2 = new Vertex(int.Parse(routerAndBandwidth[0]));
            Vertices.Add(router2);

            int bandwidth = int.Parse(routerAndBandwidth[1].Trim('(', ')'));
            
            Edge edge = new Edge(router1, router2, bandwidth);
            Edges.Add(edge);

            if (!graph.ContainsKey(router1))
            {
                graph[router1] = [];
            }

            if (!graph.ContainsKey(router2))
            {
                graph[router2] = [];
            }

        }
    }

    public record Vertex(int router)
    {
        public int router = router;
    }

    public record Edge(Vertex vertex1, Vertex vertex2, int bandwidth)
    {
        public Vertex vertex1 = vertex1;
        public Vertex vertex2 = vertex2;

        public int bandwidth = bandwidth;
    }
}