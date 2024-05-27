using Routers;

namespace RoutersTest;

using NUnit.Framework;

public class Tests
{
    [Test]
    public void BuildGraphFromTopology_ThrowsFileNotFoundException_WhenFileDoesNotExist()
    {
        Graph graph = new ();
        string filename = "nonexistent.txt";

        Assert.Throws<FileNotFoundException>(() => graph.BuildGraphFromTopology(filename));
    }

    [Test]
    public void BuildGraphFromTopology_ThrowsFileIsEmptyException_WhenFileIsEmpty()
    {
        Graph graph = new ();
        string filename = "../../../../TestFiles/testEmpty.txt";

        Assert.Throws<FileIsEmptyException>(() => graph.BuildGraphFromTopology(filename));
    }

    [Test]
    public void BuildGraphFromTopology_ValidFile_CreatesGraph()
    {
        Graph graph = new ();
        graph.BuildGraphFromTopology("../../../../TestFiles/test1.txt");
        Assert.Multiple(() =>
        {
            Assert.That(graph.Vertices.Count, Is.EqualTo(5));
            Assert.That(graph.Edges.Count, Is.EqualTo(7));
        });
    }

    [Test]
    public void Kruskal_ReturnsCorrect()
    {
        Graph graph = new ();
        graph.BuildGraphFromTopology("../../../../TestFiles/test1.txt");

        Graph kruskalResult = KruskalsAlgorithm.Run(graph);

        int[] expectedVertices = { 1, 2, 3, 4, 5 };
        int[] expectedEdgesBandwidths = { 3, 5, 6, 7 };

        foreach (var vertex in kruskalResult.Vertices)
        {
            Assert.That(expectedVertices, Does.Contain(vertex.Router));
        }

        foreach (var edge in kruskalResult.Edges)
        {
            Assert.That(expectedEdgesBandwidths, Does.Contain(edge.Bandwidth));
        }
    }

    [Test]
    public void CheckThatAllVerticesReachable_ReturnsCorrect()
    {
        Graph graph = new ();
        graph.BuildGraphFromTopology("../../../../TestFiles/test2.txt");

        Assert.That(DFS.CheckThatAllVerticesReachable(graph), Is.False);
    }
}