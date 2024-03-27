public class Graph
{
    public static Dictionary<int, List<Node>> graph = new ();

    public static Graph BuildGraphFromTopology(string filename)
    {
        if (!File.Exists(filename))
        {
            throw new FileNotFoundException();
        }

        string[] topology = File.ReadAllText(filename).Trim('\n').Split("\n");

        var newGraph = new Graph();

        foreach (var input in topology)
        {
            ParseInput(input);
        }

        return newGraph;
    }

    private static void ParseInput(string input)
    {
        string[] parts = input.Split(':');
        int routerId = int.Parse(parts[0]);

        string[] connections = parts[1].Split(',');

        foreach (string connection in connections)
        {
            string[] routerAndBandwidth = connection.Trim().Split(' ');
            int router = int.Parse(routerAndBandwidth[0]);
            int bandwidth = int.Parse(routerAndBandwidth[1].Trim('(', ')'));
            var nodeToAddToCurrent = new Node(router, bandwidth);
            var nodeToAddCurrent = new Node(routerId, bandwidth);
            
            if (!graph.ContainsKey(routerId))
            {
                graph[routerId] = [];
            }

            if (!graph.ContainsKey(router))
            {
                graph[router] = [];
            }

            graph[routerId].Add(nodeToAddToCurrent);
            graph[router].Add(nodeToAddCurrent);
        }
    }

    public record Node(int router, int bandwidth)
    {
        public int router = router;
        public int bandwidth = bandwidth;
    }
}