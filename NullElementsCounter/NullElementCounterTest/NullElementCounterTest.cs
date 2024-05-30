// <copyright file="NullElementCounterTest.cs" company="IlyaSotnikov">
// Copyright (c) IlyaSotnikov. All rights reserved.
// </copyright>

namespace NullElementsCounterTest;

using NUnit.Framework;
using NullElementsCounter;
using Moq;

/// <summary>
/// Tests for the <see cref="NullElementsCounter"/> class.
/// </summary>
public class Tests
{
    /// <summary>
    /// Tests if counter returns 0 if there is no "null" elements.
    /// </summary>
    [Test]
    public void CountNullElements_NoNullElements_ReturnsZero()
    {
        var list = new List<int> { 1, 2, 3, 4, 5 };
        var isNuller = new Mock<INullChecker<int>>();
        isNuller.Setup(x => x.IsNull(It.IsAny<int>())).Returns(false);

        var result = NullElementsCounter.CountNullElements(list, isNuller.Object);

        Assert.That(result, Is.EqualTo(0));
    }

    /// <summary>
    /// Tests if counter throws exception if list is null.
    /// </summary>
    [Test]
    public void CountNullElements_WithNullListAndCustomNullChecker_ReturnsZero()
    {
        var isNuller = new Mock<INullChecker<int>>();
        List<int>? list = null;

        Assert.Throws<ArgumentNullException>(() => NullElementsCounter.CountNullElements(list!, isNuller.Object));
    }

    /// <summary>
    /// Tests if counter throws exception if isNuller is null.
    /// </summary>
    [Test]
    public void CountNullElements_WithNullINullChecker_ThrowsArgumentNullException()
    {
        List<int> list = [1, 2, 3];

        Assert.Throws<ArgumentNullException>(() => NullElementsCounter.CountNullElements(list, null!));
    }

    /// <summary>
    /// Tests if counter returns 0 if list is empty.
    /// </summary>
    [Test]
    public void CountNullElements_WithEmptylist_ReturnsZero()
    {
        List<int> list = [];
        var isNuller = new CustomIsNuller();

        int result = NullElementsCounter.CountNullElements(list, isNuller);

        Assert.That(result, Is.EqualTo(0));
    }

    /// <summary>
    /// Tests if counter returns correct count if list if full null.
    /// </summary>
    [Test]
    public void CountNullElements_WithOnlyNullElements_ReturnsCorrectCount()
    {
        List<object> list = [null!, null!, null!];
        var isNuller = new Mock<INullChecker<object>>();
        isNuller.Setup(x => x.IsNull(It.IsAny<object>())).Returns(true);

        int result = NullElementsCounter.CountNullElements(list, isNuller.Object);

        Assert.That(result, Is.EqualTo(3));
    }

    /// <summary>
    /// Tests if counter returns correct result. In this test "null" ints is -1.
    /// </summary>
    [Test]
    public void CountNullElements_WithDifferentElements_ReturnsCorrectCount()
    {
        List<int> list = [-1, 0, 1, 2, 3, 4, 5, -1, -1, 4, 555, -1];
        var isNuller = new CustomIsNuller(); // "null" = -1

        int result = NullElementsCounter.CountNullElements(list, isNuller);

        Assert.That(result, Is.EqualTo(4));
    }

    /// <summary>
    /// Custom is nuller class for the tests.
    /// </summary>
    private class CustomIsNuller : INullChecker<int>
    {
        public bool IsNull(int element) => element == -1;
    }
}