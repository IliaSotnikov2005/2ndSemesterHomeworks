namespace MapFilterFoldTests;

using FunctionsSpace;

public class Tests
{
    [Test]
    public void Map_AppliesFunctionToEachItemInList_ReturnsNewListWithResults()
    {
        var source = new List<int> { 1, 2, 3 };
        var function = new Func<int, int>(x => x * 2);

        var result = Functions.Map(source, function);

        Assert.That(result, Is.EqualTo(new List<int> { 2, 4, 6 }));
    }

    [Test]
    public void Filter_WithPredicateThatAlwaysReturnsTrue_ReturnsAllItems()
    {
        var source = new List<int> { 1, 2, 3, 4, 5 };
        var predicate = new Func<int, bool>(x => true);

        var result = Functions.Filter(source, predicate);

        Assert.That(result, Is.EqualTo(source));
    }

    [Test]
    public void Filter_WithPredicateThatAlwaysReturnsFalse_ReturnsNoItems()
    {
        var source = new List<int> { 1, 2, 3, 4, 5 };
        var predicate = new Func<int, bool>(x => false);

        var result = Functions.Filter(source, predicate);

        Assert.That(result, Is.Empty);
    }

    [Test]
    public void Filter_WithPredicateThatFiltersSomeItems_ReturnsOnlyFilteredItems()
    {
        var source = new List<int> { 1, 2, 3, 4, 5 };
        var predicate = new Func<int, bool>(x => x % 2 == 0);

        var result = Functions.Filter(source, predicate);

        Assert.That(result, Is.EqualTo(new List<int> { 2, 4 }));
    }

    [Test]
    public void Fold_ReturnsCorrect()
    {
        var source = new List<int> { 1, 2, 3 };
        Func<int, int, int> function = new((acc, element) => acc * element);

        var result = Functions.Fold(source, 1, function);

        Assert.That(result, Is.EqualTo(6));
    }
}