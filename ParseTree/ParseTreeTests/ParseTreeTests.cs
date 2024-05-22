namespace ParseTreeTests;

using ParseTree;

[TestFixture]
public class ParseTreeTests
{
    [Test]
    public void Tree_ReturnsCorrectAnsver()
    {
        ParseTree tree = new ();
        tree.BuildTreeFromFile("../../../../Files/1.txt");

        Assert.That(tree.Evaluate(), Is.EqualTo(58));
    }

    [Test]
    public void Tree_DivisionByZero_ThrowsException()
    {
        ParseTree tree = new ();
            tree.BuildTreeFromFile("../../../../Files/2.txt");

        Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
    }

    [Test]
    public void Tree_NotExistingFile_ThrowsException()
    {
        ParseTree tree = new ();
        Assert.Throws<FileNotFoundException>(() => tree.BuildTreeFromFile("../../../../Files/1231.txt"));
    }

    [Test]
    public void Tree_InvalidTree_ThrowsException()
    {
        ParseTree tree = new ();
        Assert.Throws<ArgumentException>(() => tree.BuildTreeFromFile("../../../../Files/3.txt"));
    }
}