namespace ParseTreeTests;

using ParseTreeSpace;

[TestFixture]
public class ParseTreeTests
{
    [Test]
    public void Tree_ReturnsCorrectAnsver()
    {
        ParseTree tree = new ParseTree();
        tree.BuildTreeFromFile("../../../../Files/1.txt");

        Assert.That(tree.Evaluate(), Is.EqualTo(58));
    }

    [Test]
    public void Tree_DivisionByZero_ThrowsException()
    {
        ParseTree tree = new ParseTree();
            tree.BuildTreeFromFile("../../../../Files/2.txt");

        Assert.Throws<DivideByZeroException>(() => tree.Evaluate());
    }

    [Test]
    public void Tree_NotExistingFile_ThrowsException()
    {
        ParseTree tree = new ParseTree();
        Assert.Throws<FileNotFoundException>(() => tree.BuildTreeFromFile("../../../../Files/1231.txt"));
    }
}