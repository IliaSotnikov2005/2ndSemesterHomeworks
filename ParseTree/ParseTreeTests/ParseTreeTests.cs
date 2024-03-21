namespace ParseTreeTests;

using ParseTreeSpace;

[TestFixture]
public class ParseTreeTests
{
    [Test]
    public void Tree_ReturnsCorrectAnsver()
    {
        var tree = ParseTree.BuildTreeFromFile("../../../../Files/1.txt");

        Assert.That(tree.Evaluate(), Is.EqualTo(58));
    }

    [Test]
    public void Tree_DivisionByZero_ThrowsException()
    {
        var tree = ParseTree.BuildTreeFromFile("../../../../Files/2.txt");

        Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
    }

    [Test]
    public void Tree_NotExistingFile_ThrowsException()
    {
        Assert.Throws<FileNotFoundException>(() => ParseTree.BuildTreeFromFile("../../../../Files/1231.txt"));
    }
}