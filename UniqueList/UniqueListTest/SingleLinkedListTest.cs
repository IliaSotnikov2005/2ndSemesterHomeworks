namespace SingleLinkedListTest;

using UniqueList;

[TestFixture]
public class SingleLinkedListTests
{
    [Test]
    public void Add_AddsElementToTheList_SizeIncreases()
    {
        var list = new SingleLinkedList<int>();

        list.Add(1);

        Assert.That(list.Size, Is.EqualTo(1));
    }

    [Test]
    public void Add_AddsElementToTheHeadOfTheList_FirstElementIsCorrect()
    {
        var list = new SingleLinkedList<int>();

        list.Add(1);

        Assert.That(list[0], Is.EqualTo(1));
    }

    [Test]
    public void RemoveAt_RemovesElementFromGivenIndex_SizeDecreases()
    {
        var list = new SingleLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.RemoveAt(0);

        Assert.That(list.Size, Is.EqualTo(1));
    }

    [Test]
    public void RemoveAt_RemovesElementFromGivenIndex_ElementIsCorrect()
    {
        var list = new SingleLinkedList<int>();

        list.Add(1);
        list.Add(2);
        list.RemoveAt(0);

        Assert.That(list[0], Is.EqualTo(1));
    }

    [Test]
    public void RemoveAt_ThrowsIndexOutOfRangeException_WhenIndexIsNegative()
    {
        var list = new SingleLinkedList<int>();

        Assert.Throws(typeof(IndexOutOfRangeException), () => list.RemoveAt(-1));
    }
}