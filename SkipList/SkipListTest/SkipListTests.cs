// <copyright file="SkipListTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace SkipListTest;

using SkipList;

/// <summary>
/// Tests for skip list.
/// </summary>
public class Tests
{
    /// <summary>
    /// SkipList add test.
    /// </summary>
    [Test]
    public void SkipList_Add_AddsItemToList()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);

        Assert.That(skipList, Does.Contain(5));
        Assert.That(skipList.Count, Is.EqualTo(1));
    }

    /// <summary>
    /// SkipList add many items test.
    /// </summary>
    [Test]
    public void SkipList_Add_AddsManyItemsToList()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);
        skipList.Add(15);
        skipList.Add(10);
        skipList.Add(11);

        Assert.That(skipList, Does.Contain(5));
        Assert.That(skipList, Does.Contain(10));
        Assert.That(skipList, Does.Contain(15));
        Assert.That(skipList, Does.Contain(11));
        Assert.That(skipList, Has.Count.EqualTo(4));

        var array = skipList.ToArray();
        Assert.That(new int[] { 5, 10, 11, 15 }, Is.EqualTo(array));
    }

    /// <summary>
    /// Skip list remove test.
    /// </summary>
    [Test]
    public void SkipList_Remove_RemovesItemFromList()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);
        skipList.Add(6);
        skipList.Add(7);
        skipList.Remove(5);

        Assert.That(skipList, Does.Not.Contain(5));
        Assert.That(skipList, Has.Count.EqualTo(2));
    }

    /// <summary>
    /// Skip list copy test.
    /// </summary>
    [Test]
    public void SkipList_CopyTo_CopiesItemsToArray()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);
        skipList.Add(15);
        skipList.Add(10);
        skipList.Add(11);

        var array = skipList.ToArray();
        Assert.That(new int[] { 5, 10, 11, 15 }, Is.EqualTo(array));
    }

    /// <summary>
    /// Skip list index test.
    /// </summary>
    [Test]
    public void SkipList_IndexOf_ReturnsIndexOfItem()
    {
        var skipList = new SkipList<int>();
        skipList.Add(3);
        skipList.Add(2);
        skipList.Add(1);

        int index = skipList.IndexOf(3);

        Assert.That(index, Is.EqualTo(2));
    }

    /// <summary>
    /// Skip list indexer test.
    /// </summary>
    [Test]
    public void SkipList_CallByIndex_ReturnsItem()
    {
        var skipList = new SkipList<int>();
        skipList.Add(3);
        skipList.Add(2);
        skipList.Add(1);

        Assert.That(skipList[0], Is.EqualTo(1));
    }

    /// <summary>
    /// Skip list enumerator test.
    /// </summary>
    [Test]
    public void SkipList_GetEnumerator_ReturnsEnumeratorOfItems()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);

        IEnumerator<int> enumerator = skipList.GetEnumerator();

        Assert.That(enumerator.MoveNext(), Is.True);
        Assert.That(enumerator.Current, Is.EqualTo(5));
    }

    /// <summary>
    /// Skip list enumerator exception test.
    /// </summary>
    [Test]
    public void EnumeratorThrowsException_WhenCollectionChangedDuringIteration()
    {
        var skipList = new SkipList<int>();
        skipList.Add(5);
        skipList.Add(15);

        var enumerator = skipList.GetEnumerator();
        enumerator.MoveNext();

        skipList.Add(1);

        Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
    }
}