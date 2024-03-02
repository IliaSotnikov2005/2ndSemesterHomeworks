[TestFixture]
public class TrieTests
{
    private Trie trie;

    [SetUp]
    public void Setup()
    {
        trie = new Trie();
    }

    [Test]
    public void AddElement_ReturnsTrue()
    {
        Assert.IsTrue(trie.Add("hello"));
    }

    [Test]
    public void AddExistingElement_ReturnsFalse()
    {
        trie.Add("hello");
        Assert.IsFalse(trie.Add("hello"));
    }

    [Test]
    public void ContainsElement_ReturnsTrue()
    {
        trie.Add("world");
        Assert.IsTrue(trie.Contains("world"));
    }

    [Test]
    public void DoesNotContainElement_ReturnsFalse()
    {
        Assert.IsFalse(trie.Contains("world"));
    }

    [Test]
    public void RemoveElement_ReturnsTrue()
    {
        trie.Add("apple");
        Assert.IsTrue(trie.Remove("apple"));
    }

    [Test]
    public void RemoveNotExistingElement_ReturnsFalse()
    {
        Assert.IsFalse(trie.Remove("hello"));
    }

    [Test]
    public void HowManyStartsWithPrefix_ReturnsCorrectCount()
    {
        trie.Add("cat");
        trie.Add("car");
        trie.Add("dog");
        Assert.That(trie.HowManyStartsWithPrefix("c"), Is.EqualTo(2));
    }
}